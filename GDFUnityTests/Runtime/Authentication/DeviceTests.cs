using System.Collections;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Authentication
{
    public class DeviceTests
    {
        GDFCountryISO country = GDFCountryISO.GetFromTwoLetterCode("FR");

        [UnityTest]
        public IEnumerator CanSignIn()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityTask task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanReSignIn()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityTask task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            UnityTask task = GDF.Launch;
            yield return WaitTask(task);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            if (GDF.Authentication.IsConnected)
            {
                UnityTask task = GDF.Account.Delete();
                yield return WaitTask(task);
            }
            
            GDF.Kill();
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