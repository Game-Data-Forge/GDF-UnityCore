using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public abstract class BaseGameSaveIOTests
    {
        bool triggeredImmediate = false;
        bool triggeredDelay = false;

        [UnityTest]
        public IEnumerator CanChangeGameSave()
        {
            byte gameSave = GDF.Player.GameSave;

            UnityJob task = GDF.Player.LoadGameSave(1);
            Assert.AreEqual(gameSave, GDF.Player.GameSave);

            yield return WaitJob(task);

            Assert.AreEqual(1, GDF.Player.GameSave);
        }
        
        [UnityTest]
        public IEnumerator CanChangeBackToDefaultGameSave()
        {
            byte gameSave = GDF.Player.GameSave;

            UnityJob task = GDF.Player.LoadGameSave(1);
            Assert.AreEqual(gameSave, GDF.Player.GameSave);

            yield return WaitJob(task);

            Assert.AreEqual(1, GDF.Player.GameSave);

            task = GDF.Player.LoadCommonGameSave();
            
            yield return WaitJob(task);

            Assert.AreEqual(gameSave, GDF.Player.GameSave);
        }

        [UnityTest]
        public IEnumerator CanDeleteDefaultGameSave()
        {
            string reference = nameof(CanDeleteDefaultGameSave);
            string value1 = "value";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);

            task = GDF.Player.DeleteGameSave();
            yield return WaitJob(task);

            Assert.IsNull(GDF.Player.Get(reference));

            data = new GDFTestPlayerData();

            GDF.Player.Add(reference, data);

            Assert.IsNotNull(GDF.Player.Get(reference));
        }

        [UnityTest]
        public IEnumerator CanDeleteGameSave()
        {
            string reference1 = "1" + nameof(CanDeleteGameSave);
            string reference2 = "2" + nameof(CanDeleteGameSave);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data1 = new GDFTestPlayerData();
            data1.TestString = value1;
            GDF.Player.Add(reference1, data1);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);
            
            GDFTestPlayerData data2 = new GDFTestPlayerData();
            data2.TestString = value2;
            GDF.Player.Add(reference2, data2);

            task = GDF.Player.Save();
            yield return WaitJob(task);

            task = GDF.Player.DeleteGameSave();
            yield return WaitJob(task);

            Assert.IsNull(GDF.Player.Get(reference2));

            data2 = new GDFTestPlayerData();

            GDF.Player.Add(reference2, data2);

            Assert.IsNotNull(GDF.Player.Get(reference2));
        }

        [UnityTest]
        public IEnumerator KnowsIfThereAreDataToSave()
        {
            string reference = nameof(KnowsIfThereAreDataToSave);
            string value = "value 1";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;

            Assert.AreEqual(false, GDF.Player.HasDataToSave);

            GDF.Player.Add(reference, data);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSave);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);

            GDF.Player.Delete(data);

            Assert.AreEqual(true, GDF.Player.HasDataToSave);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
        }

        [UnityTest]
        public IEnumerator ReloadingResetsMemory()
        {
            string reference = nameof(ReloadingResetsMemory);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            data.TestString = value2;

            GDF.Player.AddToSaveQueue(data);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);

            Assert.AreEqual(data.TestString, value2);

            GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data1);
            Assert.AreEqual(data1.TestString, value1);
            
            Assert.AreNotEqual(data, data1);
        }

        [UnityTest]
        public IEnumerator CanPurgeData()
        {
            string reference = nameof(CanPurgeData);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            Assert.AreEqual(true, GDF.Player.HasDataToSave);
            Assert.AreEqual(false, GDF.Player.HasDataToSync);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            data.TestString = value2;
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            GDF.Player.AddToSaveQueue(data);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
            
            task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
            
            task = GDF.Player.Purge();
            yield return WaitJob(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(false, GDF.Player.HasDataToSync);

            Assert.IsNull(GDF.Player.Get(reference));

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);

            Assert.IsNull(GDF.Player.Get(reference));

            data = new GDFTestPlayerData();
            data.TestString = value2;

            GDF.Player.Add(reference, data);

            Assert.IsNotNull(GDF.Player.Get(reference));
            
            task = GDF.Player.Save();
            yield return WaitJob(task);
        }

        [UnityTest]
        public IEnumerator CanSave()
        {
            string reference = nameof(CanSave);

            string value = "value 1";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;
            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value);
        }

        [UnityTest]
        public IEnumerator CanSaveUpdatedData()
        {
            string reference = nameof(CanSaveUpdatedData);

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

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);

            Assert.AreEqual(data.TestString, value1);

            data.TestString = value2;
            GDF.Player.AddToSaveQueue(data);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreNotEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);
        }

        [UnityTest]
        public IEnumerator CanSaveOnGameSave()
        {
            string reference = nameof(CanSaveOnGameSave);

            string value = "value 1";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;

            UnityJob task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);

            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value);
        }

        [UnityTest]
        public IEnumerator CanSaveUpdatedDataOnGameSave()
        {
            string reference = nameof(CanSaveUpdatedDataOnGameSave);

            string value1 = "value 1";
            string value2 = "value 2";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;

            UnityJob task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);

            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value1);

            task = GDF.Player.Save();
            yield return WaitJob(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);

            Assert.AreEqual(data.TestString, value1);

            data.TestString = value2;
            GDF.Player.AddToSaveQueue(data);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreNotEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);
        }

        [UnityTest]
        public IEnumerator DeleteDeletedDataOnSave()
        {
            string reference = nameof(DeleteDeletedDataOnSave);

            string value = "value 1";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;
            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            GDF.Player.Delete(data);

            task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsNull(GDF.Player.Get(reference));

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);
            
            Assert.IsNull(GDF.Player.Get(reference));
        }

        [UnityTest]
        public IEnumerator DataAreLostWhenDisconnected()
        {
            string reference = nameof(DataAreLostWhenDisconnected);

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
        }
        
        [UnityTest]
        public IEnumerator AutoLoadsOnAccountConnect()
        {
            string reference = nameof(AutoLoadsOnAccountConnect);

            string value = "value 1";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value;
            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);

            task = GDF.Account.Authentication.SignOut();
            yield return WaitJob(task);

            yield return Connect();

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value);
        }

        [UnityTest]
        public IEnumerator SwitchingGamesaveDoesNotSave()
        {
            string reference = nameof(SwitchingGamesaveDoesNotSave);

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

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value1);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfSynced()
        {
            GDF.Player.Saved.onBackgroundThread += OnSaved;
            GDF.Player.Saved.onMainThread += OnSaved;

            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Player.Save();
            yield return WaitJob(task);
            
            Assert.IsTrue(triggeredImmediate);

            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfSyncing()
        {
            GDF.Player.Saving.onBackgroundThread += OnSaving;
            GDF.Player.Saving.onMainThread += OnSaving;

            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Player.Save();
            yield return WaitJobStarted(task);
            
            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);

            yield return null;
            
            Assert.IsTrue(triggeredDelay);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfSLoaded()
        {
            GDF.Player.Loaded.onBackgroundThread += OnLoaded;
            GDF.Player.Loaded.onMainThread += OnLoaded;

            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Player.LoadCommonGameSave();
            yield return WaitJob(task);
            
            Assert.IsTrue(triggeredImmediate);

            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfLoading()
        {
            GDF.Player.Loading.onBackgroundThread += OnLoading;
            GDF.Player.Loading.onMainThread += OnLoading;

            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Player.LoadCommonGameSave();
            yield return WaitJobStarted(task);
            
            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);

            yield return null;
            
            Assert.IsTrue(triggeredDelay);
        }

        private void OnSaved()
        {
            triggeredDelay = true;
        }

        private void OnSaved(IJobHandler handler)
        {
            triggeredImmediate = true;
        }

        private void OnSaving()
        {
            triggeredDelay = true;
        }

        private void OnSaving(IJobHandler handler)
        {
            triggeredImmediate = true;
        }

        private void OnLoaded()
        {
            triggeredDelay = true;
        }

        private void OnLoaded(IJobHandler handler)
        {
            triggeredImmediate = true;
        }

        private void OnLoading()
        {
            triggeredDelay = true;
        }

        private void OnLoading(IJobHandler handler)
        {
            triggeredImmediate = true;
        }

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            triggeredImmediate = false;
            triggeredDelay = false;

            UnityJob task = GDF.Launch;
            yield return WaitJob(task);

            yield return Connect();

            task = GDF.Player.Purge();
            yield return task;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            GDF.Player.Saving.onBackgroundThread -= OnSaving;
            GDF.Player.Saving.onMainThread -= OnSaving;
            GDF.Player.Saved.onBackgroundThread -= OnSaved;
            GDF.Player.Saved.onMainThread -= OnSaved;
            GDF.Player.Loading.onBackgroundThread -= OnLoading;
            GDF.Player.Loading.onMainThread -= OnLoading;
            GDF.Player.Loaded.onBackgroundThread -= OnLoaded;
            GDF.Player.Loaded.onMainThread -= OnLoaded;

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

        private IEnumerator WaitJobStarted(IJob job)
        {
            while (job.State == JobState.Pending)
            {
                yield return job;
            }
        }
    }
}