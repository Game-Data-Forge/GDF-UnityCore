using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Authentication
{
    public class DeviceTests
    {
        Country country = Country.FR;

        [UnityTest]
        public IEnumerator CanSignIn()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanReSignIn()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (GDF.Authentication.IsConnected)
            {
                UnityJob task = GDF.Account.Delete();
                yield return WaitTask(task);
            }
            
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