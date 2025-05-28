using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public abstract class AsyncManager : IAsyncManager
    {
        protected class Locker : IDisposable
        {
            static private Dictionary<AsyncManager, Locker> _cache = new Dictionary<AsyncManager, Locker>();
            static public Locker Lock(AsyncManager manager)
            {
                Locker locker;
                if (!_cache.TryGetValue(manager, out locker))
                {
                    locker = new Locker(manager);
                    _cache.Add(manager, locker);
                }
                
                manager.State = ManagerState.Locked;
                return locker;
            }

            private AsyncManager _manager;

            private Locker(AsyncManager manager)
            {
                _manager = manager;
            }

            public void Dispose()
            {
                _manager.State = ManagerState.Ready;
            }
        }

        static public GDFException NotReady => new GDFException("ASC", 01, "The manager is not ready ! Couldn't start task...");

        public ManagerState State { get; protected set; }
        protected abstract Job Job { get; }

        public void EnsureUseable()
        {
            if (State != ManagerState.Ready) throw NotReady;

            if (Job == null) return;

            if (!Job.IsDone)
            {
                throw IJob.Exceptions.InUse;
            }
        }

        public virtual async Task Stop()
        {
            State = ManagerState.Stopping;
            if (Job == null) return;

            if (!Job.IsDone)
            {
                Job.Cancel();
                await Job;
            }

            Job.Dispose();
        }
    }
}