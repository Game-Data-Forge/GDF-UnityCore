using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFFoundation.Tasks;
using System.Threading;
using System;

namespace Tools.Tasks
{
    public class NoArgsTests
    {
        private class TestException : Exception
        {
            public TestException(string message) : base(message) {}
        }

        bool done = false;

        [SetUp]
        public void Setup()
        {
            done = false;
        }

        [UnityTest]
        public IEnumerator CanRun()
        {
            UnityTask task = Task.Run(Runner);
            Assert.IsFalse(done);
            yield return task;
            Assert.IsTrue(done);
        }

        [UnityTest]
        public IEnumerator CanRunAsync()
        {
            UnityTask task = Task.Run(AsyncRunner);
            Assert.IsFalse(done);
            yield return task;
            Assert.IsTrue(done);
        }

        [UnityTest]
        public IEnumerator CanRunLambda()
        {
            UnityTask task = Task.Run(_ => {
                Thread.Sleep(500);
                done = true;
            });
            Assert.IsFalse(done);
            yield return task;
            Assert.IsTrue(done);
        }

        [UnityTest]
        public IEnumerator CanRunAsyncLambda()
        {
            UnityTask task = Task.Run(async _ => {
                await System.Threading.Tasks.Task.Delay(500);
                done = true;
            });
            Assert.IsFalse(done);
            yield return task;
            Assert.IsTrue(done);
        }

        [Test]
        public void CanAutoGenerateName()
        {
            Task task = Task.Run(_ => {});
            Assert.AreEqual(task.Name, nameof(CanAutoGenerateName));

            task = Task.Run(async _ => await System.Threading.Tasks.Task.Delay(500));
            Assert.AreEqual(task.Name, nameof(CanAutoGenerateName));
        }

        [Test]
        public void CanGiveName()
        {
            string name = "Test";
            Task task = Task.Run(_ => {}, name);
            Assert.AreEqual(task.Name, name);

            task = Task.Run(async _ => await System.Threading.Tasks.Task.Delay(500), name);
            Assert.AreEqual(task.Name, name);
        }

        [UnityTest]
        public IEnumerator CanWaitInCoroutine()
        {
            UnityTask task = Task.Run(Runner);
            Assert.IsFalse(done);
            yield return task;
            Assert.IsTrue(done);
        }
        
        [Test]
        public void CanWaitSync()
        {
            UnityTask task = Task.Run(Runner);
            Assert.IsFalse(done);
            task.Wait();
            Assert.IsTrue(done);
        }

        [UnityTest]
        public IEnumerator CanCheckState()
        {
            UnityTask task = Task.Run(_ => {
                Thread.Sleep(200);
            });

            Assert.Contains(task.State, new TaskState[] { TaskState.Pending, TaskState.Running});

            yield return null;

            Assert.AreEqual(task.State, TaskState.Running);

            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
        }

        [UnityTest]
        public IEnumerator CanCatchExceptions()
        {
            UnityTask task = Task.Run(_ => {
                Thread.Sleep(200);
                throw new TestException("Boop !");
            });

            yield return task;
            Assert.AreEqual(task.State, TaskState.Failure);
            Assert.AreEqual(task.Error.GetType(), typeof(TestException));
            Assert.IsNotNull(task.Error);
        }

        [UnityTest]
        public IEnumerator CanCancel()
        {
            UnityTask task = Task.Run(_ => {
                Thread.Sleep(200);
                done = true;
            });

            Assert.IsFalse(done);
            yield return null;
            task.Cancel();
            yield return task;
            Assert.AreEqual(task.State, TaskState.Cancelled);
            Assert.IsTrue(done);
        }

        [UnityTest]
        public IEnumerator CanAutoDetectCancel()
        {
            UnityTask task = Task.Run(Runner);

            Assert.IsFalse(done);
            yield return null;
            task.Cancel();
            Assert.IsTrue(task.IsCancelled);
            yield return task;
            Assert.AreEqual(task.State, TaskState.Cancelled);
            Assert.IsFalse(done);
        }

        [UnityTest]
        public IEnumerator CanManualDetectCancel()
        {
            UnityTask task = Task.Run(handler => {
                for(int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    handler.ThrowIfCancelled();
                }
                done = true;
            });

            Assert.IsFalse(done);
            yield return null;
            task.Cancel();
            yield return task;
            Assert.IsFalse(done);
            Assert.AreEqual(task.State, TaskState.Cancelled);
        }

        [UnityTest]
        public IEnumerator CanCreateASuccessfulTask()
        {
            UnityTask task = Task.Success();

            Assert.AreEqual(task.State, TaskState.Success);

            yield return task;

            Assert.AreEqual(task.State, TaskState.Success);
        }

        [UnityTest]
        public IEnumerator CanCreateAFailedTask()
        {
            UnityTask task = Task.Failure(new TestException("Boop !"));

            Assert.AreEqual(task.State, TaskState.Failure);

            yield return task;

            Assert.AreEqual(task.State, TaskState.Failure);
            Assert.AreEqual(task.Error.GetType(), typeof(TestException));
            Assert.IsNotNull(task.Error);
        }

        private void Runner(ITaskHandler handler)
        {
            handler.StepAmount = 50;
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(10);
                handler.Step();
            }
            done = true;
        }

        private async System.Threading.Tasks.Task AsyncRunner(ITaskHandler handler)
        {
            handler.StepAmount = 10;
            for (int i = 0; i < 10; i++)
            {
                await System.Threading.Tasks.Task.Delay(50);
                handler.Step();
            }
            done = true;
        }
    }
}