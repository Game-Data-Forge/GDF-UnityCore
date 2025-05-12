using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Authentication
{
    public class CommonTests
    {
        bool triggeredImmediate = false;
        bool triggeredDelay = false;
        Country country = Country.FromTwoLetterCode("FR");

        [UnityTest]
        public IEnumerator CanSignOut()
        {
            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
        }
        
        [UnityTest]
        public IEnumerator CanSignOutMulitpleTime()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);
        }

        [UnityTest]
        public IEnumerator CanDetectConnectionState()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanConnectWithoutDisconnecting()
        {
            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreEqual(task.State, JobState.Success);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfAccountStateChanged()
        {
            GDF.Authentication.AccountChangedNotif.onBackgroundThread += OnAutenticationChanged;
            GDF.Authentication.AccountChangedNotif.onMainThread += OnAutenticationChanged;
            
            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.IsTrue(triggeredImmediate);
            
            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            triggeredImmediate = false;

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

            Assert.IsTrue(triggeredImmediate);
            
            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);
        }

        [UnityTest]
        public IEnumerator CanBeNotifiedOfAccountStateChanging()
        {
            GDF.Authentication.AccountChangingNotif.onBackgroundThread += OnAutenticationChanging;
            GDF.Authentication.AccountChangingNotif.onMainThread += OnAutenticationChanging;
            
            Assert.IsFalse(triggeredImmediate);
            Assert.IsFalse(triggeredDelay);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return null;

            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);
            
            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            yield return WaitTask(task);

            triggeredImmediate = false;
            
            task = GDF.Authentication.SignOut();
            yield return null;

            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);
            
            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            yield return WaitTask(task);
        }

        [UnityTest]
        public IEnumerator DeleteAccountDisconnect()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);
            
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Account.Delete();
            yield return WaitTask(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);
        }

        private void OnAutenticationChanged(MemoryJwtToken token)
        {
            triggeredDelay = true;
        }

        private void OnAutenticationChanged(IJobHandler handler, MemoryJwtToken token)
        {
            triggeredImmediate = true;
        }

        private void OnAutenticationChanging(MemoryJwtToken token)
        {
            triggeredDelay = true;
        }

        private void OnAutenticationChanging(IJobHandler handler, MemoryJwtToken token)
        {
            triggeredImmediate = true;
        }

        [UnitySetUp]
        public IEnumerator Setup()
        {
            triggeredImmediate = false;
            triggeredDelay = false;
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            GDF.Authentication.AccountChangingNotif.onBackgroundThread -= OnAutenticationChanging;
            GDF.Authentication.AccountChangingNotif.onMainThread -= OnAutenticationChanging;
            GDF.Authentication.AccountChangedNotif.onBackgroundThread -= OnAutenticationChanged;
            GDF.Authentication.AccountChangedNotif.onMainThread -= OnAutenticationChanged;

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