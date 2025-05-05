using System.Collections;
using GDFFoundation;
using GDFFoundation.Tasks;
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
            UnityTask task = GDF.Launch;
            yield return WaitTask(task);

            task = GDF.Authentication.SignOut();
            yield return WaitTask(task);
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