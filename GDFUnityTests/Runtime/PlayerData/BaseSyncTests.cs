using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public abstract class BaseSyncTests
    {
        [UnityTest]
        public IEnumerator KnowsIfThereAreDataToSync()
        {
            string reference = nameof(KnowsIfThereAreDataToSync);
            string value = "value 1";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;

            Assert.AreEqual(false, GDF.Player.HasDataToSync);

            GDF.Player.Add(reference, data);

            Assert.AreEqual(false, GDF.Player.HasDataToSync);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            GDF.Player.Delete(data);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
        }

        [UnityTest]
        public IEnumerator KeepDataToSyncEvenAfterReloading()
        {
            string reference = nameof(KeepDataToSyncEvenAfterReloading);

            string value1 = "value 1";
            string value2 = "value 2";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value1);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);

            data.TestString = value2;
            
            GDF.Player.AddToSaveQueue(data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Account.Authentication.SignOut();
            yield return WaitJob(task);

            yield return Connect();

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value1);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
        }

        [UnityTest]
        public IEnumerator CanSyncData()
        {
            int count = 39;
            
            GDFTestPlayerData data;

            for (int i = 0; i < count; i++)
            {
                data = new GDFTestPlayerData();
                data.TestInt = i;
                GDF.Player.Add(data);
            }

            UnityJob task = GDF.Player.Sync();
            yield return WaitJob(task);

            List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.GreaterOrEqual(list.Count, count);
            
            task = GDF.Player.Purge();
            yield return WaitJob(task);
            
            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);

            list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.AreEqual(0, list.Count);

            task = GDF.Player.Sync();
            yield return WaitJob(task);

            list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.GreaterOrEqual(list.Count, 0);
        }

        [UnityTest]
        public IEnumerator CanSyncDataAutoSaves()
        {
            int count = 39;

            List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.AreEqual(0, list.Count);
            
            GDFTestPlayerData data;

            for (int i = 0; i < count; i++)
            {
                data = new GDFTestPlayerData();
                data.TestInt = i;
                GDF.Player.Add(data);
            }

            UnityJob task = GDF.Player.Sync();
            yield return WaitJob(task);
            
            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);

            list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.Greater(list.Count, 0);
        }
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            UnityJob task = GDF.Launch;
            yield return WaitJob(task);

            yield return Connect();

            task = GDF.Player.Purge();
            yield return task;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            UnityJob task = GDF.Account.Authentication.SignOut();
            yield return WaitJob(task);
            
            GDF.Kill();
        }

        protected abstract IEnumerator Connect();

        protected IEnumerator WaitJob(UnityJob job, JobState expectedState = JobState.Success)
        {
            yield return job;

            if (job.State != expectedState)
            {
                Assert.Fail("Task '" + job.Name + "' finished with the unexpected state '" + job.State + "' !\n" + job.Error);
            }
        }
    }
}