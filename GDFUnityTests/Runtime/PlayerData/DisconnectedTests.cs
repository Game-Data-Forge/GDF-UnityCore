using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;

namespace PlayerData
{
    public class DisconnectedTests
    {
        /// <summary>
        /// It is forbidden to use the PlayerData Framework if the
        // engine is not connected with a valid user.
        /// </summary>
        [Test]
        public void CannotAccessFrameworkIfNotConnected()
        {
            Assert.Throws<GDFException> (() => {
                byte gameSave = GDF.Player.GameSave;
            });
            Assert.Throws<GDFException> (() => {
                GDF.Player.LoadGameSave(0);
            });
            Assert.Throws<GDFException> (() => {
                GDFPlayerData data = GDF.Player.Get("test");
            });
            Assert.Throws<GDFException> (() => {
                List<GDFPlayerData> data = GDF.Player.Get<GDFPlayerData>();
            });
            Assert.Throws<GDFException> (() => {
                GDF.Player.Save();
            });
            Assert.Throws<GDFException> (() => {
                GDFPlayerData data = new GDFTestPlayerData();
                GDF.Player.Add(data);
            });
            Assert.Throws<GDFException> (() => {
                GDFPlayerData data = new GDFTestPlayerData();
                GDF.Player.AddToSaveQueue(data);
            });
            Assert.Throws<GDFException> (() => {
                GDFPlayerData data = new GDFTestPlayerData();
                GDF.Player.Delete(data);
            });
        }

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            UnityJob task = (Job)GDF.Launch;
            yield return WaitTask(task);

            task = (Job)GDF.Authentication.SignOut();
            yield return WaitTask(task);
        }

        [TearDown]
        public void TearDown()
        {
            GDF.Kill();
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