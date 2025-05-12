using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GDFFoundation
{
    public class Job : IJob
    {
        static private Pool<Job> _pool = new Pool<Job>();
        static public Job Run(Action<IJobHandler> action, [CallerMemberName] string name = "Unknown")
        {
            Job task = _pool.Get();
            task._name = name;

            Task.Run(() => task.Process(action));
            return task;
        }
        static public Job Run(Func<IJobHandler, Task> action, [CallerMemberName] string name = "Unknown")
        {
            Job task = _pool.Get();
            task._name = name;

            task.Process(action);
            return task;
        }

        static public Job Success([CallerMemberName] string name = "Unknown")
        {
            Job task = _pool.Get();
            task._name = name;
            task._state = JobState.Success;
            return task;
        }

        static public Job Failure(Exception error, [CallerMemberName] string name = "Unknown")
        {
            Job task = _pool.Get();
            task._name = name;
            task._error = error;
            task._state = JobState.Failure;
            return task;
        }

        internal CancellationTokenSource source;
        internal float progress;
        protected string _name;
        protected JobState _state;
        protected Exception _error;

        public string Name => _name;
        public JobState State
        {
            get => _state;
        }
        public float Progress
        {
            get => progress;
        }
        public bool IsDone => _state >= JobState.Success;
        public Exception Error => _error;
        public bool IsCancelled => source.IsCancellationRequested;

        public Pool Pool { get; set; }

        public void Cancel()
        {
            source.Cancel();
        }

        public TaskAwaiter GetAwaiter()
        {
            return Task.Run(Wait).GetAwaiter();
        }

        public void Wait()
        {
            while (!IsDone) { }
        }

        public virtual void OnPooled()
        {
            source = new CancellationTokenSource();
            _state = JobState.Pending;
            progress = 0;
            _error = null;
        }

        public void OnReleased()
        {
            source?.Dispose();
            source = null;
        }

        public void Dispose()
        {
            PoolItem.Release(this);
        }

        private void Process(Action<IJobHandler> action)
        {
            using(IJobHandler handler = JobHandler.Get(this))
            {
                try
                {
                    _state = JobState.Running;
                    action?.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = JobState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (OperationCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = JobState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }

        private async void Process(Func<IJobHandler, Task> action)
        {
            using(IJobHandler handler = JobHandler.Get(this))
            {
                try
                {
                    _state = JobState.Running;
                    await action?.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = JobState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (OperationCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = JobState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }
    }

    public class Job<T> : Job, IJob<T>
    {
        static private Pool<Job<T>> _pool = new Pool<Job<T>>();
        static public Job<T> Run(Func<IJobHandler, T> action, [CallerMemberName] string name = "Unknown")
        {
            Job<T> task = _pool.Get();
            task._name = name;

            Task.Run(() => task.Process(action));
            return task;
        }
        static public Job<T> Run(Func<IJobHandler, Task<T>> action, [CallerMemberName] string name = "Unknown")
        {
            Job<T> task = _pool.Get();
            task._name = name;

            task.Process(action);
            return task;
        }

        static public Job<T> Success(T value = default, [CallerMemberName] string name = "Unknown")
        {
            Job<T> task = _pool.Get();
            task._name = name;
            task._result = value;
            task._state = JobState.Success;
            return task;
        }

        static public new Job<T> Failure(Exception error, [CallerMemberName] string name = "Unknown")
        {
            Job<T> task = _pool.Get();
            task._name = name;
            task._error = error;
            task._result = default;
            task._state = JobState.Failure;
            return task;
        }

        private T _result;

        public T Result
        {
            get
            {
                return Wait();
            }
        }

        public new T Wait()
        {
            base.Wait();
            return _result;
        }
        public new TaskAwaiter<T> GetAwaiter()
        {
            return Task.Run(Wait).GetAwaiter();
        }

        public override void OnPooled()
        {
            base.OnPooled();
            _result = default;
        }

        private void Process(Func<IJobHandler, T> action)
        {
            using(IJobHandler handler = JobHandler.Get(this))
            {
                try
                {
                    _state = JobState.Running;
                    _result = action.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = JobState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (OperationCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = JobState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }

        private async void Process(Func<IJobHandler, Task<T>> action)
        {
            using(IJobHandler handler = JobHandler.Get(this))
            {
                try
                {
                    _state = JobState.Running;
                    _result = await action.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = JobState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (OperationCanceledException e)
                {
                    _state = JobState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = JobState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }
    }
}