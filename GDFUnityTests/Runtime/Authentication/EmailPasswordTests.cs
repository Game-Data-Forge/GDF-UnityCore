using System.Collections;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Authentication
{
    public class EmailPasswordTests
    {
        string login1 = "unit.test1@test.test";
        string login2 = "unit.test2@test.test";
        string password = "UnitTest_123456789";
        GDFCountryISO country = GDFCountryISO.GetFromTwoLetterCode("FR");

        [UnityTest]
        public IEnumerator CanRegister()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityTask task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }

        [UnityTest]
        public IEnumerator CanSignIn()
        {
            UnityTask task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInEmailPassword(country, login1, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanSwitchAccount()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityTask task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.RegisterEmailPassword(country, login2, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
            
            task = GDF.Account.Delete();
            yield return WaitTask(task);
            
            task = GDF.Authentication.SignInEmailPassword(country, login1, password);
            yield return WaitTask(task);
        }
        
        [UnityTest]
        public IEnumerator CanReSignIn()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityTask task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, TaskState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInEmailPassword(country, login1, password);
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