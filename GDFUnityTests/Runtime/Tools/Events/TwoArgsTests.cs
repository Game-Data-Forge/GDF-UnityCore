using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFRuntime;
using GDFFoundation.Tasks;
using System;

namespace Tools.Events
{
    public class TwoArgsTests
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
            Event<int, float> ev = new Event<int, float>(GDF.Thread);
            ev.Invoke(new SimpleHandler(), 1, 2);
        }

        [Test]
        public void CannotInvokeNull()
        {
            Event<int, float> ev = null;
            Assert.Throws<NullReferenceException> (() => {
                ev.Invoke(new SimpleHandler(), 1, 2);
            });
        }

        [Test]
        public void CanInvokeImmediate()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1, 2);

            Assert.AreEqual(2, immediate);
        }

        [Test]
        public void CanSeveralInvokeImmediate()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1, 2);
            ev.Invoke(new SimpleHandler(), 1, 2);

            Assert.AreEqual(6, immediate);
        }

        [Test]
        public void CanUnsubscribeImmediate()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, immediate);

            ev.onBackgroundThread += Runner;

            Assert.AreEqual(0, immediate);

            ev.Invoke(new SimpleHandler(), 1, 2);

            Assert.AreEqual(2, immediate);

            ev.onBackgroundThread -= Runner;

            ev.Invoke(new SimpleHandler(), 1, 2);

            Assert.AreEqual(2, immediate);
        }

        [UnityTest]
        public IEnumerator CanInvokeDelayed()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1, 2);

            yield return null;
            yield return null;

            Assert.AreEqual(2, delayed);
        }

        [UnityTest]
        public IEnumerator CanSeveralInvokeDelayed()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1, 2);
            ev.Invoke(new SimpleHandler(), 1, 2);

            yield return null;
            yield return null;

            Assert.AreEqual(6, delayed);

            ev.Invoke(new SimpleHandler(), 1, 2);

            yield return null;
            yield return null;

            Assert.AreEqual(14, delayed);
        }

        [UnityTest]
        public IEnumerator CanUnsubscribeDelayed()
        {
            Event<int, float> ev = new Event<int, float>(GDF.Thread);

            Assert.AreEqual(0, delayed);

            ev.onMainThread += Runner;

            Assert.AreEqual(0, delayed);

            ev.Invoke(new SimpleHandler(), 1, 2);

            yield return null;
            yield return null;

            Assert.AreEqual(2, delayed);

            ev.onMainThread -= Runner;

            ev.Invoke(new SimpleHandler(), 1, 2);

            yield return null;
            yield return null;

            Assert.AreEqual(2, delayed);
        }

        private void Runner(ITaskHandler handler, int increment, float multiplier)
        {
            immediate += increment;
            immediate *= (int)multiplier;
        }

        private void Runner(int increment, float multiplier)
        {
            delayed += increment;
            delayed *= (int)multiplier;
        }
    }
}