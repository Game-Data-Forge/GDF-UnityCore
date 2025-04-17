using System;
using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public class Event
    {
        public event Action onMainThread;
        public event Action<ITaskHandler> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Event(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(ITaskHandler handler)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke());

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            handler.StepAmount = methods.Length > 0 ? methods.Length : 1;
            if (methods.Length > 0)
            {
                Action<ITaskHandler> invokable;
                foreach(Delegate method in methods)
                {
                    invokable = method as Action<ITaskHandler>;
                    invokable?.Invoke(handler.Split());
                }
            }
        }
    }
    
    public class Event<T>
    {
        public event Action<T> onMainThread;
        public event Action<ITaskHandler, T> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Event(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(ITaskHandler handler, T value1)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke(value1));

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            handler.StepAmount = onBackgroundThread != null ? methods.Length : 1;
            if (onBackgroundThread != null)
            {
                Action<ITaskHandler, T> invokable;
                foreach(Delegate method in methods)
                {
                    invokable = method as Action<ITaskHandler, T>;
                    invokable?.Invoke(handler.Split(), value1);
                }
            }
        }
    }
    
    public class Event<T, U>
    {
        public event Action<T, U> onMainThread;
        public event Action<ITaskHandler, T, U> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Event(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(ITaskHandler handler, T value1, U value2)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke(value1, value2));

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            handler.StepAmount = methods.Length > 0 ? methods.Length : 1;
            if (methods.Length > 0)
            {
                Action<ITaskHandler, T, U> invokable;
                foreach(Delegate method in methods)
                {
                    invokable = method as Action<ITaskHandler, T, U>;
                    invokable?.Invoke(handler.Split(), value1, value2);
                }
            }
        }
    }
}