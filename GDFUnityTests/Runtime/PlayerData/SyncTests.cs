using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public class SyncTests
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

            UnityTask task = GDF.Player.Save();
            yield return WaitTask(task);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            GDF.Player.Delete(data);

            task = GDF.Player.Save();
            yield return WaitTask(task);
            
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

            UnityTask task = GDF.Player.Save();
            yield return WaitTask(task);

            data.TestString = value2;
            
            GDF.Player.AddToSaveQueue(data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

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

            UnityTask task = GDF.Player.Sync();
            yield return WaitTask(task);

            List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.GreaterOrEqual(list.Count, count);
            
            task = GDF.Player.Purge();
            yield return WaitTask(task);
            
            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);

            list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.AreEqual(0, list.Count);

            task = GDF.Player.Sync();
            yield return WaitTask(task);

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

            UnityTask task = GDF.Player.Sync();
            yield return WaitTask(task);
            
            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);

            list = GDF.Player.Get<GDFTestPlayerData>();
            Assert.Greater(list.Count, 0);
        }
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            UnityTask task = GDF.Launch;
            yield return WaitTask(task);

            yield return Connect();

            task = GDF.Player.Purge();
            yield return task;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            UnityTask task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            GDF.Kill();
        }
        
        private IEnumerator Connect()
        {
            UnityTask task = GDF.Authentication.SignInDevice(GDFCountryISO.GetFromTwoLetterCode("FR"));
            yield return WaitTask(task);
        }

        private IEnumerator WaitTask(UnityTask task, TaskState expectedState = TaskState.Success)
        {
            yield return task;

            if (task.State != expectedState)
            {
                Assert.Fail("Task '" + task.Name + "' finished with the unexpected state '" + task.State + "' !\n" + task.Error);
            }
        }
    }
}