using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFRuntime;
using GDFFoundation.Tasks;
using System;

namespace Tools.Events
{
    public class OneArgTests
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
            Event<int> ev = new Event<int>(GDF.Thread);
            ev.Invoke(new SimpleHandler(), 1);
        }

        [Test]
        public void CannotInvokeNull()
        {
            Event<int> ev = null;
            Assert.Throws<NullReferenceException> (() => {
                ev.Invoke(new SimpleHandler(), 1);
            });
        }

        [Test]
        public void CanInvokeImmediate()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1);

            Assert.AreEqual(1, immediate);
        }

        [Test]
        public void CanSeveralInvokeImmediate()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1);
            ev.Invoke(new SimpleHandler(), 1);

            Assert.AreEqual(2, immediate);
        }

        [Test]
        public void CanUnsubscribeImmediate()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1);

            Assert.AreEqual(1, immediate);

            ev.onBackgroundThread -= Runner;

            ev.Invoke(new SimpleHandler(), 1);

            Assert.AreEqual(1, immediate);
        }

        [UnityTest]
        public IEnumerator CanInvokeDelayed()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1);

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);
        }

        [UnityTest]
        public IEnumerator CanSeveralInvokeDelayed()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1);
            ev.Invoke(new SimpleHandler(), 1);

            yield return null;
            yield return null;

            Assert.AreEqual(2, delayed);

            ev.Invoke(new SimpleHandler(), 1);

            yield return null;
            yield return null;

            Assert.AreEqual(3, delayed);
        }

        [UnityTest]
        public IEnumerator CanUnsubscribeDelayed()
        {
            Event<int> ev = new Event<int>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1);

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);

            ev.onMainThread -= Runner;

            ev.Invoke(new SimpleHandler(), 1);

            yield return null;
            yield return null;

            Assert.AreEqual(1, delayed);
        }

        private void Runner(ITaskHandler handler, int increment)
        {
            immediate += increment;
        }

        private void Runner(int increment)
        {
            delayed += increment;
        }
    }
}