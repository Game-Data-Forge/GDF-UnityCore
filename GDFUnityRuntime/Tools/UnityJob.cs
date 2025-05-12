using System;
using System.Runtime.CompilerServices;
using GDFFoundation;
using UnityEngine;

namespace GDFUnity
{
    public class UnityJob : CustomYieldInstruction, IJob
    {
        protected IJob _task;

        public string Name => _task.Name;

        public JobState State => _task.State;

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

        static public implicit operator UnityJob(Job task)
        {
            return new UnityJob{
                _task = task
            };
        }
    }

    public class UnityJob<T> : UnityJob, IJob<T>
    {
        private new IJob<T> _task
        {
            get
            {
                return (IJob<T>)base._task;
            }
            set
            {
                base._task = value;
            }
        }

        public T Result => _task.Result;

        public new TaskAwaiter<T> GetAwaiter() => _task.GetAwaiter();
        public new T Wait() => _task.Wait();

        TaskAwaiter IJob.GetAwaiter() => ((IJob)_task).GetAwaiter();
        void IJob.Wait() => ((IJob)_task).Wait();
        

        static public implicit operator UnityJob<T>(Job<T> task)
        {
            return new UnityJob<T> {
                _task = task
            };
        }
    }
}