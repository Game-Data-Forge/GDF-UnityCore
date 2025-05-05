using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFRuntime;
using GDFFoundation.Tasks;
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
            yield return (UnityTask)GDF.Launch;
        }

        [Test]
        public void CanInvokeEmpty()
        {
            Event ev = new Event(GDF.Thread);
            ev.Invoke(new SimpleHandler());
        }

        [Test]
        public void CannotInvokeNull()
        {
            Event ev = null;
            Assert.Throws<NullReferenceException> (() => {
                ev.Invoke(new SimpleHandler());
            });
        }

        [Test]
        public void CanInvokeImmediate()
        {
            Event ev = new Event(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler());

            Assert.AreEqual(1, immediate);
        }

        [Test]
        public void CanSeveralInvokeImmediate()
        {
            Event ev = new Event(GDF.Thread);

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
            Event ev = new Event(GDF.Thread);

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
            Event ev = new Event(GDF.Thread);

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
            Event ev = new Event(GDF.Thread);

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
            Event ev = new Event(GDF.Thread);

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

        private void Runner(ITaskHandler handler)
        {
            immediate++;
        }

        private void Runner()
        {
            delayed++;
        }
    }
}