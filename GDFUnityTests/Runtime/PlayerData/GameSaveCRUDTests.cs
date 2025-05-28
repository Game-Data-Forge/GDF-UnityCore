using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public class GameSaveCRUDTests
    {
        [Test]
        public void CannotUseInvalidGameSave()
        {
            Assert.Throws<GDFException> (() => GDF.Player.LoadGameSave(100));
        }

        [UnityTest]
        public IEnumerator CanOverrideDataWithGameSave()
        {
            string reference = nameof(CanOverrideDataWithGameSave);

            string value1 = "value 1";
            string value2 = "value 2";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            
            data.TestString = value1;

            Assert.IsNull(GDF.Player.Get(reference));

            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value1);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;

            Assert.IsNotNull(GDF.Player.Get(reference));

            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value2);

            task = GDF.Player.Save();
            yield return WaitTask(task);
            
            task = GDF.Player.LoadGameSave(0);
            yield return WaitTask(task);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value1);
        }

        [UnityTest]
        public IEnumerator CanOverrideDataListWithGameSave()
        {
            string value1 = "value 1";
            string value2 = "value 2";
            string value11 = "value 11";
            string value12 = "value 12";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(data);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(data);

            List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
            
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].TestString, value1);
            Assert.AreEqual(list[1].TestString, value2);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value11;
            GDF.Player.Add(data);
            
            data = new GDFTestPlayerData();
            data.TestString = value12;
            GDF.Player.Add(data);

            list = GDF.Player.Get<GDFTestPlayerData>();
            
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].TestString, value11);
            Assert.AreEqual(list[1].TestString, value12);
        }

        [UnityTest]
        public IEnumerator CannotOverrideDataFromDifferentType()
        {
            string reference = nameof(CannotOverrideDataFromDifferentType);

            string value1 = "value 1";
            string value2 = "value 2";
            
            GDFTestPlayerData data1 = new GDFTestPlayerData();
            data1.TestString = value1;

            Assert.IsNull(GDF.Player.Get(reference));
            
            GDF.Player.Add(reference, data1);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data1, GDF.Player.Get(reference));
            Assert.AreEqual(data1.TestString, value1);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            GDFTestChildPlayerData data2 = new GDFTestChildPlayerData();
            data2.TestString = value2;

            Assert.IsNotNull(GDF.Player.Get(reference));

            Assert.Throws<GDFException> (() => GDF.Player.Add(reference, data2));
        }

        [UnityTest]
        public IEnumerator CanGetFromDefaultGameSaveByReference()
        {
            string reference = nameof(CanGetFromDefaultGameSaveByReference);

            string value1 = "value 1";
            string value2 = "value 2";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            
            data.TestString = value1;

            Assert.IsNull(GDF.Player.Get(reference));

            GDF.Player.Add(reference, data);
            
            Assert.IsNotNull(GDF.Player.Get(reference));
            Assert.AreEqual(data, GDF.Player.Get(reference));
            Assert.AreEqual(data.TestString, value1);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;

            Assert.IsNotNull(GDF.Player.Get(reference));

            GDF.Player.Add(reference, data);

            GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            // Executes several times in order to make sure the cache is working correctly (or not)
            data1 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data1);
            Assert.AreEqual(data1.TestString, value1);
            
            Assert.IsNotNull(data2);
            Assert.AreEqual(data2.TestString, value2);
        }

        [UnityTest]
        public IEnumerator CanGetFromDefaultGameSaveByType()
        {
            string value1 = "value 1";
            string value2 = "value 2";
            string value11 = "value 11";
            string value12 = "value 12";
            
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(data);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(data);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value11;
            GDF.Player.Add(data);
            
            data = new GDFTestPlayerData();
            data.TestString = value12;
            GDF.Player.Add(data);

            List<GDFTestPlayerData> data1 = GDF.Player.Get<GDFTestPlayerData>(defaultGameSave: true);
            List<GDFTestPlayerData> data2 = GDF.Player.Get<GDFTestPlayerData>();
            
            // Executes several times in order to make sure the cache is working correctly (or not)
            data1 = GDF.Player.Get<GDFTestPlayerData>(defaultGameSave: true);
            data2 = GDF.Player.Get<GDFTestPlayerData>();
            
            Assert.IsNotNull(data1);
            Assert.AreEqual(data1.Count, 2);
            Assert.AreEqual(data1[0].TestString, value1);
            Assert.AreEqual(data1[1].TestString, value2);
            
            Assert.IsNotNull(data2);
            Assert.AreEqual(data2.Count, 2);
            Assert.AreEqual(data2[0].TestString, value11);
            Assert.AreEqual(data2[1].TestString, value12);
        }

        [UnityTest]
        public IEnumerator CanSetOnDefaultGameSave()
        {
            string reference = nameof(CanSetOnDefaultGameSave);
            string value1 = "value 1";
            string value2 = "value 2";
            string value3 = "value 3";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value2);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            data.TestString = value3;

            GDF.Player.AddToSaveQueue(data);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value2);

            data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value3);
        }

        [UnityTest]
        public IEnumerator CanDeleteOnGameSave()
        {
            string reference = nameof(CanDeleteOnGameSave);
            string value1 = "value 1";
            string value2 = "value 2";
            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value2);

            data.Trashed = true;

            GDF.Player.AddToSaveQueue(data);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            Assert.AreEqual(data.TestString, value1);
        }

        [UnityTest]
        public IEnumerator CanDeleteOnDefaultGameSave()
        {
            string reference = nameof(CanDeleteOnDefaultGameSave);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value2);

            data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            Assert.IsNotNull(data);
            Assert.AreEqual(data.TestString, value1);

            data.Trashed = true;
            GDF.Player.AddToSaveQueue(data);
            
            data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            Assert.IsNull(data);

            data = GDF.Player.Get<GDFTestPlayerData>(reference);
            Assert.AreEqual(data.TestString, value2);
        }

        [Test]
        public void HasConsistentMemoryAddressesOnData()
        {
            string reference = nameof(HasConsistentMemoryAddressesOnData);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;

            GDF.Player.Add(reference, data);

            Assert.AreEqual(data, GDF.Player.Get(reference));
            
            GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
            GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.AreEqual(data1, data);
            Assert.AreEqual(data2, data);

            data.TestString = value2;
            
            Assert.AreEqual(data1.TestString, value2);
            Assert.AreEqual(data2.TestString, value2);

            GDF.Player.AddToSaveQueue(data);
            
            Assert.AreEqual(data1.TestString, value2);
            Assert.AreEqual(data2.TestString, value2);
        }

        // [UnityTest]
        // public IEnumerator DataFromAnAccountIsNotRetrieved()
        // {
        //     string reference = nameof(DataFromAnAccountIsNotRetrieved);

        //     string value1 = "value 1";
        //     string value2 = "value 2";
            
        //     GDFTestPlayerData data = new GDFTestPlayerData();
        //     data.TestString = value1;
        //     GDF.Player.Add(reference, data);
            
        //     Assert.IsNotNull(GDF.Player.Get(reference));
        //     Assert.AreEqual(data, GDF.Player.Get(reference));
        //     Assert.AreEqual(data.TestString, value1);

        //     UnityJob task = GDF.Player.Save();
        //     yield return WaitTask(task);

        //     data.TestString = value2;
            
        //     GDF.Player.AddToSaveQueue(data);
            
        //     Assert.IsNotNull(GDF.Player.Get(reference));
        //     Assert.AreEqual(data, GDF.Player.Get(reference));
        //     Assert.AreEqual(data.TestString, value2);
            
        //     Assert.AreEqual(true, GDF.Player.HasDataToSave);
        //     Assert.AreEqual(true, GDF.Player.HasDataToSync);

        //     yield return AlternateConnect();

        //     data = GDF.Player.Get<GDFTestPlayerData>(reference);
            
        //     Assert.IsNull(data);
        //     Assert.AreEqual(false, GDF.Player.HasDataToSave);
        //     Assert.AreEqual(false, GDF.Player.HasDataToSync);
            
        //     yield return Connect();
        // }

        [UnityTest]
        public IEnumerator DeletingOverrideReplacesMemoryWithDefault()
        {
            string reference = nameof(DeletingOverrideReplacesMemoryWithDefault);
            string value1 = "value 1";
            string value2 = "value 2";

            GDFTestPlayerData data = new GDFTestPlayerData();
            data.TestString = value1;
            GDF.Player.Add(reference, data);

            UnityJob task = GDF.Player.Save();
            yield return WaitTask(task);

            task = GDF.Player.LoadGameSave(1);
            yield return WaitTask(task);

            data = new GDFTestPlayerData();
            data.TestString = value2;
            GDF.Player.Add(reference, data);

            GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.IsNotNull(data1);
            Assert.AreEqual(data1.TestString, value2);

            GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            Assert.IsNotNull(data2);
            Assert.AreEqual(data2.TestString, value1);

            Assert.AreNotEqual(data1, data2);

            GDF.Player.Delete(data1);
            
            Assert.AreEqual(data1.TestString, data2.TestString);
            Assert.AreNotEqual(data1, data2);

            data2 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
            
            Assert.AreEqual(data1, data2);
            
            data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
            
            Assert.AreEqual(data1, data2);
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
            UnityJob task = GDF.Authentication.SignInDevice(Country.FR);
            yield return WaitTask(task);
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