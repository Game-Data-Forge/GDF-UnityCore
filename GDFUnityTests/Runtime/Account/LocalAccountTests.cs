using System.Collections;
using GDFFoundation;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Account
{
    public class LocalAccountTests : BaseTests
    {
        [UnityTest]
        public IEnumerator AccountDoesNotExistWhenDeleted()
        {
            Assert.IsTrue(GDF.Account.IsLocal);
            Assert.IsTrue(GDF.Account.Authentication.Local.Exists);

            UnityJob job = GDF.Account.Delete();
            yield return WaitJob(job);

            Assert.IsFalse(GDF.Account.IsLocal);
            Assert.IsFalse(GDF.Account.Authentication.Local.Exists);
        }

        protected override Job Authenticate()
        {
            return GDF.Account.Authentication.Local.Login();
        }
    }
}