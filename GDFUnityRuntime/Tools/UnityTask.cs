using System;
using System.Runtime.CompilerServices;
using GDFFoundation;
using GDFFoundation.Tasks;
using UnityEngine;

namespace GDFUnity
{
    public class UnityTask : CustomYieldInstruction, ITask
    {
        private ITask _task;

        public string Name => _task.Name;

        public TaskState State => _task.State;

        public float Progress => _task.Progress;

        public bool IsDone => _task.IsDone;

        public Exception Error => _task.Error;

        public bool IsCancelled => _task.IsCancelled;

        public Pool Pool { get => _task.Pool; set => _task.Pool = value; }

        public override bool keepWaiting => !IsDone;

        public void Cancel() => _task.Cancel();

        public void Dispose() => _task.Dispose();

        public TaskAwaiter GetAwaiter() => _task.GetAwaiter();

        public void OnPooled() => _task.OnPooled();

        public void OnReleased() => _task.OnReleased();

        public void Wait() => _task.Wait();

        static public implicit operator UnityTask(Task task)
        {
            return new UnityTask{
                _task = task
            };
        }
    }

    public class UnityTask<T> : UnityTask, ITask<T>
    {
        private ITask<T> _task;

        public T Result => _task.Result;

        public new TaskAwaiter<T> GetAwaiter() => _task.GetAwaiter();
        public new T Wait() => _task.Wait();

        TaskAwaiter ITask.GetAwaiter() => ((ITask)_task).GetAwaiter();
        void ITask.Wait() => ((ITask)_task).Wait();
        

        static public implicit operator UnityTask<T>(Task<T> task)
        {
            return new UnityTask<T> {
                _task = task
            };
        }
    }
}