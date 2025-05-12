using System.Collections;
using GDFFoundation;
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
        Country country = Country.FromTwoLetterCode("FR");

        [UnityTest]
        public IEnumerator CanRegister()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }

        [UnityTest]
        public IEnumerator CanSignIn()
        {
            UnityJob task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInEmailPassword(country, login1, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanSwitchAccount()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.RegisterEmailPassword(country, login2, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
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

            UnityJob task = GDF.Authentication.RegisterEmailPassword(country, login1, password, password);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignInEmailPassword(country, login1, password);
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