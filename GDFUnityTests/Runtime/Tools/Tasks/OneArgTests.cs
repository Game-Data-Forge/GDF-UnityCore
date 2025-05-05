using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using GDFUnity;
using GDFFoundation.Tasks;
using System.Threading;
using System;

namespace Tools.Tasks
{
    public class OneArgTests
    {
        private class TestException : Exception
        {
            public TestException(string message) : base(message) {}
        }

        [UnityTest]
        public IEnumerator CanRun()
        {
            UnityTask<bool> task = Task<bool>.Run(Runner);

            yield return task;
            Assert.IsTrue(task.Result);
        }

        [UnityTest]
        public IEnumerator CanRunAsync()
        {
            UnityTask<bool> task = Task<bool>.Run(AsyncRunner);

            yield return task;
            Assert.IsTrue(task.Result);
        }

        [UnityTest]
        public IEnumerator CanRunLambda()
        {
            UnityTask<bool> task = Task<bool>.Run(_ => {
                Thread.Sleep(500);
                return true;
            });

            yield return task;
            Assert.IsTrue(task.Result);
        }

        [UnityTest]
        public IEnumerator CanRunAsyncLambda()
        {
            UnityTask<bool> task = Task<bool>.Run(async _ => {
                await System.Threading.Tasks.Task.Delay(500);
                return true;
            });

            yield return task;
            Assert.IsTrue(task.Result);
        }

        [Test]
        public void CanAutoGenerateName()
        {
            Task task = Task<bool>.Run(_ => {});
            Assert.AreEqual(task.Name, nameof(CanAutoGenerateName));

            task = Task<bool>.Run(async _ => await System.Threading.Tasks.Task.Delay(500));
            Assert.AreEqual(task.Name, nameof(CanAutoGenerateName));
        }

        [Test]
        public void CanGiveName()
        {
            string name = "Test";
            Task task = Task<bool>.Run(_ => {}, name);
            Assert.AreEqual(task.Name, name);

            task = Task<bool>.Run(async _ => await System.Threading.Tasks.Task.Delay(500), name);
            Assert.AreEqual(task.Name, name);
        }

        [UnityTest]
        public IEnumerator CanWaitInCoroutine()
        {
            UnityTask<bool> task = Task<bool>.Run(Runner);

            yield return task;
            Assert.IsTrue(task.Result);
        }
        
        [Test]
        public void CanWaitSync()
        {
            UnityTask<bool> task = Task<bool>.Run(Runner);
            
            task.Wait();
            Assert.IsTrue(task.Result);
        }

        [Test]
        public void CanWaitResult()
        {
            UnityTask<bool> task = Task<bool>.Run(Runner);
            
            Assert.IsTrue(task.Result);
        }

        [UnityTest]
        public IEnumerator CanCheckState()
        {
            UnityTask<bool> task = Task<bool>.Run(_ => {
                Thread.Sleep(200);
                return true;
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
            UnityTask<bool> task = Task<bool>.Run(_ => {
                Thread.Sleep(200);

                Action action = () => throw new TestException("Boop !");
                action();
                
                return true;
            });

            yield return task;
            Assert.AreEqual(task.State, TaskState.Failure);
            Assert.AreEqual(task.Error.GetType(), typeof(TestException));
            Assert.IsNotNull(task.Error);
        }

        [UnityTest]
        public IEnumerator CanCancel()
        {
            UnityTask<bool> task = Task<bool>.Run(_ => {
                Thread.Sleep(200);
                return true;
            });
            
            yield return null;
            task.Cancel();
            yield return task;
            Assert.AreEqual(task.State, TaskState.Cancelled);
            Assert.IsTrue(task.Result);
        }

        [UnityTest]
        public IEnumerator CanAutoDetectCancel()
        {
            UnityTask<bool> task = Task<bool>.Run(Runner);
            
            yield return null;
            task.Cancel();
            Assert.IsTrue(task.IsCancelled);
            yield return task;
            Assert.AreEqual(task.State, TaskState.Cancelled);
            Assert.IsFalse(task.Result);
        }

        [UnityTest]
        public IEnumerator CanManualDetectCancel()
        {
            UnityTask<bool> task = Task<bool>.Run(handler => {
                for(int i = 0; i < 100; i++)
                {
                    Thread.Sleep(10);
                    handler.ThrowIfCancelled();
                }
                return true;
            });
            
            yield return null;
            task.Cancel();
            yield return task;
            Assert.IsFalse(task.Result);
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

        private bool Runner(ITaskHandler handler)
        {
            handler.StepAmount = 50;
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(10);
                handler.Step();
            }
            return true;
        }

        private async System.Threading.Tasks.Task<bool> AsyncRunner(ITaskHandler handler)
        {
            handler.StepAmount = 10;
            for (int i = 0; i < 10; i++)
            {
                await System.Threading.Tasks.Task.Delay(50);
                handler.Step();
            }
            return true;
        }
    }
}