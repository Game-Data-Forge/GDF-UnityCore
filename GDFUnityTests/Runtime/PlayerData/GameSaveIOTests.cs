using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public class GameSaveIOTests
    {
        [UnityTest]
        public IEnumerator CanChangeGameSave()
        {
            byte gameSave = GDF.Player.GameSave;

            UnityJob task = GDF.Player.LoadGameSave(1);
            Assert.AreEqual(gameSave, GDF.Player.GameSave);

            yield return WaitTask(task);

            Assert.AreEqual(1, GDF.Player.GameSave);
        }
        
        [UnityTest]
        public IEnumerator CanChangeBackToDefaultGameSave()
        {
            byte gameSave = GDF.Player.GameSave;

            UnityJob task = GDF.Player.LoadGameSave(1);
            Assert.AreEqual(gameSave, GDF.Player.GameSave);

            yield return WaitTask(task);

            Assert.AreEqual(1, GDF.Player.GameSave);

            task = GDF.Player.LoadCommonGameSave();
            
            yield return WaitTask(task);

            Assert.AreEqual(gameSave, GDF.Player.GameSave);
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
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);
            
            GDFTestPlayerData data2 = new GDFTestPlayerData();
            data2.TestString = value2;
            GDF.Player.Add(reference2, data2);

            task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.DeleteGameSave();
            yield return WaitTask(task);

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
            yield return WaitTask(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);

            GDF.Player.Delete(data);

            Assert.AreEqual(true, GDF.Player.HasDataToSave);

            task = GDF.Player.Save();
            yield return WaitTask(task);
            
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
            yield return WaitTask(task);
            
            data.TestString = value2;

            GDF.Player.AddToSaveQueue(data);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);

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
            yield return WaitTask(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            data.TestString = value2;
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            GDF.Player.AddToSaveQueue(data);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
            
            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);
            
            Assert.AreEqual(true, GDF.Player.HasDataToSave);
            Assert.AreEqual(true, GDF.Player.HasDataToSync);
            
            task = GDF.Player.Purge();
            yield return WaitTask(task);
            
            Assert.AreEqual(false, GDF.Player.HasDataToSave);
            Assert.AreEqual(false, GDF.Player.HasDataToSync);

            Assert.IsNull(GDF.Player.Get(reference));

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);

            Assert.IsNull(GDF.Player.Get(reference));

            data = new GDFTestPlayerData();
            data.TestString = value2;

            GDF.Player.Add(reference, data);

            Assert.IsNotNull(GDF.Player.Get(reference));
            
            task = GDF.Player.Save();
            yield return WaitTask(task);
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
            yield return WaitTask(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value);
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
            yield return WaitTask(task);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value);

            GDF.Player.Delete(data);

            task = GDF.Player.Save();
            yield return WaitTask(task);
            
            Assert.IsNull(GDF.Player.Get(reference));

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);
            
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
            yield return WaitTask(task);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

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
            yield return WaitTask(task);

            data.TestString = value2;
            
            GDF.Player.AddToSaveQueue(data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Player.LoadCommonGameSave();
            yield return WaitTask(task);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value1);
        }

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);

            yield return Connect();

            task = GDF.Player.Purge();
            yield return task;
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            UnityJob task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            GDF.Kill();
        }
        
        private IEnumerator Connect()
        {
            UnityJob task = GDF.Authentication.SignInDevice(Country.FromTwoLetterCode("FR"));
            yield return WaitTask(task);
        }

        private IEnumerator AlternateConnect()
        {
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);

            string address = "test-account-no-use-please@not-existing.plop";
            string password = "Super-seecret_Password+12357865";
            
            task = GDF.Authentication.SignInEmailPassword(Country.FromTwoLetterCode("FR"), address, password);
            yield return task;

            if (task.State == JobState.Failure)
            {
                task = GDF.Authentication.RegisterEmailPassword(Country.FromTwoLetterCode("FR"), address, password, password);
                yield return WaitTask(task);
            }
        }

        private IEnumerator WaitTask(UnityJob task, JobState expectedState = JobState.Success)
        {
            yield return task;

            if (task.State != expectedState)
            {
                Assert.Fail("Task '" + task.Name + "' finished with the unexpected state '" + task.State + "' !\n" + task.Error);
            }
        }
    }
}