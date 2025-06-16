using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Account
{
    public class CommonTests
    {
        Country country = Country.FR;

        [UnityTest]
        public IEnumerator CanDelete()
        {
            long lastAccount = GDF.Account.Reference;

            UnityJob task = GDF.Account.Delete();
            yield return WaitTask(task);

            task = GDF.Account.Authentication.Device.Login(country);
            yield return WaitTask(task);

            Assert.AreNotEqual(lastAccount, GDF.Account.Reference);
        }

        [UnitySetUp]
        public IEnumerator Setup()
        {
            UnityJob task = GDF.Launch;
            yield return WaitTask(task);
            
            task = GDF.Account.Authentication.Device.Login(country);
            yield return WaitTask(task);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            UnityJob task = GDF.Account.Authentication.SignOut();
            yield return WaitTask(task);

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