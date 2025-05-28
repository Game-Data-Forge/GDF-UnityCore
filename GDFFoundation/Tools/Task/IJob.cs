#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IJob.cs create at 2025/05/15 11:05:03
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Runtime.CompilerServices;

#endregion

namespace GDFFoundation
{
    public interface IJob : IPoolItem
    {
        #region Instance fields and properties

        public Exception Error { get; }
        public bool IsCancelled { get; }
        public bool IsDone { get; }

        public string Name { get; }
        public float Progress { get; }
        public JobState State { get; }

        #endregion

        #region Instance methods

        public void Cancel();
        public TaskAwaiter GetAwaiter();

        public void Wait();

        #endregion

        #region Nested type: Exceptions

        static public class Exceptions
        {
            #region Static fields and properties

            static public GDFException InUse => new GDFException("TSK", 001, "The operation is already in use !");

            #endregion
        }

        #endregion
    }

    public interface IJob<T> : IJob
    {
        #region Instance fields and properties

        public T Result { get; }

        #endregion

        #region Instance methods

        public new TaskAwaiter<T> GetAwaiter();

        public new T Wait();

        #endregion
    }
}