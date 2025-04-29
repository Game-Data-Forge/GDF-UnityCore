using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace GDFFoundation.Tasks
{
    public class Task : ITask
    {
        static private Pool<Task> _pool = new Pool<Task>();
        static public Task Run(Action<ITaskHandler> action, [CallerMemberName] string name = "Unknown")
        {
            Task task = _pool.Get();
            task._name = name;

            System.Threading.Tasks.Task.Run(() => task.Process(action));
            return task;
        }
        static public Task Run(Func<ITaskHandler, System.Threading.Tasks.Task> action, [CallerMemberName] string name = "Unknown")
        {
            Task task = _pool.Get();
            task._name = name;

            task.Process(action);
            return task;
        }

        static public Task Success([CallerMemberName] string name = "Unknown")
        {
            Task task = _pool.Get();
            task._name = name;
            task._state = TaskState.Success;
            return task;
        }

        static public Task Failure(Exception error, [CallerMemberName] string name = "Unknown")
        {
            Task task = _pool.Get();
            task._name = name;
            task._error = error;
            task._state = TaskState.Failure;
            return task;
        }

        static public YieldAwaitable Yield()
        {
            return System.Threading.Tasks.Task.Yield();
        }

        internal CancellationTokenSource source;
        internal float progress;
        protected string _name;
        protected TaskState _state;
        protected Exception _error;

        public string Name => _name;
        public TaskState State
        {
            get => _state;
        }
        public float Progress
        {
            get => progress;
        }
        public bool IsDone => _state >= TaskState.Success;
        public Exception Error => _error;
        public bool IsCancelled => source.IsCancellationRequested;

        public Pool Pool { get; set; }

        public void Cancel()
        {
            source.Cancel();
        }

        public TaskAwaiter GetAwaiter()
        {
            return System.Threading.Tasks.Task.Run(Wait).GetAwaiter();
        }

        public void Wait()
        {
            while (!IsDone) { }
        }

        public virtual void OnPooled()
        {
            source = new CancellationTokenSource();
            _state = TaskState.Pending;
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

        private void Process(Action<ITaskHandler> action)
        {
            using(ITaskHandler handler = TaskHandler.Get(this))
            {
                try
                {
                    _state = TaskState.Running;
                    action?.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = TaskState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = TaskState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = TaskState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }

        private async void Process(Func<ITaskHandler, System.Threading.Tasks.Task> action)
        {
            using(ITaskHandler handler = TaskHandler.Get(this))
            {
                try
                {
                    _state = TaskState.Running;
                    await action?.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = TaskState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = TaskState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = TaskState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }
    }

    public class Task<T> : Task, ITask<T>
    {
        static private Pool<Task<T>> _pool = new Pool<Task<T>>();
        static public Task<T> Run(Func<ITaskHandler, T> action, [CallerMemberName] string name = "Unknown")
        {
            Task<T> task = _pool.Get();
            task._name = name;

            System.Threading.Tasks.Task.Run(() => task.Process(action));
            return task;
        }
        static public Task<T> Run(Func<ITaskHandler, System.Threading.Tasks.Task<T>> action, [CallerMemberName] string name = "Unknown")
        {
            Task<T> task = _pool.Get();
            task._name = name;

            task.Process(action);
            return task;
        }

        static public Task<T> Success(T value = default, [CallerMemberName] string name = "Unknown")
        {
            Task<T> task = _pool.Get();
            task._name = name;
            task._result = value;
            task._state = TaskState.Success;
            return task;
        }

        static public new Task<T> Failure(Exception error, [CallerMemberName] string name = "Unknown")
        {
            Task<T> task = _pool.Get();
            task._name = name;
            task._error = error;
            task._result = default;
            task._state = TaskState.Failure;
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
            return System.Threading.Tasks.Task.Run(Wait).GetAwaiter();
        }

        public override void OnPooled()
        {
            base.OnPooled();
            _result = default;
        }

        private void Process(Func<ITaskHandler, T> action)
        {
            using(ITaskHandler handler = TaskHandler.Get(this))
            {
                try
                {
                    _state = TaskState.Running;
                    _result = action.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = TaskState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = TaskState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = TaskState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }

        private async void Process(Func<ITaskHandler, System.Threading.Tasks.Task<T>> action)
        {
            using(ITaskHandler handler = TaskHandler.Get(this))
            {
                try
                {
                    _state = TaskState.Running;
                    _result = await action.Invoke(handler);
                    handler.ThrowIfCancelled();
                    progress = 1;
                    _state = TaskState.Success;
                }
                catch (TaskCanceledException e)
                {
                    _state = TaskState.Cancelled;
                    GDFLogger.Error(e);
                }
                catch (Exception e)
                {
                    _error = e;
                    _state = TaskState.Failure;
                    GDFLogger.Error(e);
                }
            }
        }
    }
}