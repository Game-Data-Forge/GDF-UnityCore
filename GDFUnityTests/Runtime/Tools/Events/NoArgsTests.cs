using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFRuntime;
using GDFFoundation;
using System;

namespace Tools.Events
{
    public class NoArgsTests
    {
        int immediate;
        int delayed;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            immediate = 0;
            delayed = 0;
            yield return (UnityJob)GDF.Launch;
        }

        [Test]
        public void CanInvokeEmpty()
        {
            Notification ev = new Notification(GDF.Thread);
            ev.Invoke(new SimpleHandler());
        }

        [Test]
        public void CannotInvokeNull()
        {
            Notification ev = null;
            Assert.Throws<NullReferenceException> (() => {
                ev.Invoke(new SimpleHandler());
            });
        }

        [Test]
        public void CanInvokeImmediate()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler());

            Assert.AreEqual(1, immediate);
        }

        [Test]
        public void CanSeveralInvokeImmediate()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler());
            ev.Invoke(new SimpleHandler());

            Assert.AreEqual(2, immediate);
        }

        [Test]
        public void CanUnsubscribeImmediate()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler());

            Assert.AreEqual(1, immediate);

            ev.onBackgroundThread -= Runner;

            ev.Invoke(new SimpleHandler());

            Assert.AreEqual(1, immediate);
        }

        [UnityTest]
        public IEnumerator CanInvokeDelayed()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler());

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);
        }

        [UnityTest]
        public IEnumerator CanSeveralInvokeDelayed()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler());
            ev.Invoke(new SimpleHandler());

            yield return null;
            yield return null;

            Assert.AreEqual(2, delayed);

            ev.Invoke(new SimpleHandler());

            yield return null;
            yield return null;

            Assert.AreEqual(3, delayed);
        }

        [UnityTest]
        public IEnumerator CanUnsubscribeDelayed()
        {
            Notification ev = new Notification(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler());

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);

            ev.onMainThread -= Runner;

            ev.Invoke(new SimpleHandler());

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);
        }

        private void Runner(IJobHandler handler)
        {
            immediate++;
        }

        private void Runner()
        {
            delayed++;
        }
    }
}