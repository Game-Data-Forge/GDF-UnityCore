using System.Collections;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Engine
{
    public class CommonTests
    {
        [Test]
        public void CannotUseSomeGDFFeaturesIfNotLaunched()
        {
            Assert.Throws<GDFException> (() => {
                string str = GDF.Thread.ToString();
            });
            Assert.Throws<GDFException> (() => {
                string str = GDF.Environment.ToString();
            });
            Assert.Throws<GDFException> (() => {
                string str = GDF.Device.ToString();
            });
            Assert.Throws<GDFException> (() => {
                string str = GDF.Authentication.ToString();
            });
            Assert.Throws<GDFException> (() => {
                string str = GDF.Player.ToString();
            });
        }
        
        [Test]
        public void CanUseSomeGDFFeaturesIfNotLaunched()
        {
            string str = GDF.Configuration.ToString();
            str = GDF.Launch.ToString();
        }
        
        [UnityTest]
        public IEnumerator CanStart()
        {
            UnityTask task = GDF.Launch;

            Assert.Contains(task.State, new TaskState[] { TaskState.Pending, TaskState.Running});

            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
        }
        
        [UnityTest]
        public IEnumerator CanStop()
        {
            UnityTask task = GDF.Launch;
            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
            
            Task awaitedTask = GDF.Authentication.SignInDevice(GDFCountryISO.GetFromTwoLetterCode("FR"));
            task = GDF.Stop();

            yield return task;

            Assert.IsTrue(awaitedTask.IsDone);
            Assert.AreEqual(task.State, TaskState.Success);
        }
        
        [UnityTest]
        public IEnumerator CanKill()
        {
            UnityTask task = GDF.Launch;
            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
            
            Task awaitedTask = GDF.Authentication.SignInDevice(GDFCountryISO.GetFromTwoLetterCode("FR"));
            GDF.Kill();

            Assert.IsFalse(awaitedTask.IsDone);
        }
        
        [UnityTest]
        public IEnumerator CanRestart()
        {
            UnityTask task = GDF.Launch;

            Assert.Contains(task.State, new TaskState[] { TaskState.Pending, TaskState.Running});

            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
            
            task = GDF.Stop();

            yield return task;
            
            Assert.AreEqual(task.State, TaskState.Success);

            task = GDF.Launch;

            Assert.Contains(task.State, new TaskState[] { TaskState.Pending, TaskState.Running});

            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
        }
        
        [SetUp]
        public void Setup()
        {
            GDF.Kill();
        }
    }
}