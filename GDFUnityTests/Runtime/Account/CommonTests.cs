using System.Collections;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Account
{
    public class CommonTests
    {
        GDFCountryISO country = GDFCountryISO.GetFromTwoLetterCode("FR");

        [UnityTest]
        public IEnumerator CanDelete()
        {
            long lastAccount = GDF.Authentication.Token.Account;

            UnityTask task = GDF.Account.Delete();
            yield return WaitTask(task);

            task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);

            Assert.AreNotEqual(lastAccount, GDF.Authentication.Token.Account);
        }

        [UnitySetUp]
        public IEnumerator Setup()
        {
            UnityTask task = GDF.Launch;
            yield return WaitTask(task);
            
            task = GDF.Authentication.SignInDevice(country);
            yield return WaitTask(task);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            UnityTask task = GDF.Authentication.SignOut();
            yield return WaitTask(task);

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