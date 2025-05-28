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
        Country country = Country.FR;

        [UnityTest]
        public IEnumerator CanSignOut()
        {
            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitJob(task);

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
        }
        
        [UnityTest]
        public IEnumerator CanSignOutMulitpleTime()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);
        }

        [UnityTest]
        public IEnumerator CanDetectConnectionState()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitJob(task);

            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);
            
            Assert.IsFalse(GDF.Authentication.IsConnected);
        }
        
        [UnityTest]
        public IEnumerator CanConnectWithoutDisconnecting()
        {
            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitJob(task);

            task = GDF.Authentication.SignInDevice(country);
            yield return WaitJob(task);

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
            yield return WaitJob(task);

            Assert.IsTrue(triggeredImmediate);
            
            yield return null;
            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            triggeredImmediate = false;

            task = GDF.Authentication.SignOut();
            yield return WaitJob(task);

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
            yield return WaitJobStarted(task);

            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);

            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            yield return WaitJob(task);

            triggeredImmediate = false;
            
            task = GDF.Authentication.SignOut();
            yield return WaitJobStarted(task);

            Assert.IsTrue(triggeredImmediate);
            Assert.IsFalse(task.IsDone);
            
            yield return null;
            
            Assert.IsTrue(triggeredDelay);

            yield return WaitJob(task);
        }

        [UnityTest]
        public IEnumerator DeleteAccountDisconnect()
        {
            Assert.IsFalse(GDF.Authentication.IsConnected);

            UnityJob task = GDF.Authentication.SignInDevice(country);
            yield return WaitJob(task);
            
            Assert.IsTrue(GDF.Authentication.IsConnected);

            task = GDF.Account.Delete();
            yield return WaitJob(task);
            
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
            yield return WaitJob(task);
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
                yield return WaitJob(task);
            }
            
            GDF.Kill();
        }

        private IEnumerator WaitJob(UnityJob job, JobState expectedState = JobState.Success)
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