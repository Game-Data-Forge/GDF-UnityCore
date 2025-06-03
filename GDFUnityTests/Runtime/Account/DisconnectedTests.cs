using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Account
{
    public class DisconnectedTests
    {
        [Test]
        public void CannotUseIfNotAuthenticated()
        {
            Assert.Throws<GDFException>(() => {
                GDF.Account.Delete();
            });
        }
        
        [UnitySetUp]
        public IEnumerator Setup()
        {
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);

            task = GDF.Account.Authentication.SignOut();
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