using System;
using System.Runtime.CompilerServices;

namespace GDFFoundation.Tasks
{
    public interface ITask : IPoolItem
    {
        static public class Exceptions
        {
            static public GDFException InUse => new GDFException("TSK", 001, "The operation is already in use !");
        }

        public string Name { get; }
        public TaskState State { get; }
        public float Progress { get; }
        public bool IsDone { get; }
        public Exception Error { get; }
        public bool IsCancelled { get; }

        public void Wait();
        public TaskAwaiter GetAwaiter();

        public void Cancel();
    }
    
    public interface ITask<T> : ITask
    {
        public T Result { get; }

        public new T Wait();
        public new TaskAwaiter<T> GetAwaiter();
    }
}