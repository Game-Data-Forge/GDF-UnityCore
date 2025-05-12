using System;
using GDFFoundation;

namespace GDFRuntime
{
    public class Notification
    {
        public event Action onMainThread;
        public event Action<IJobHandler> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Notification(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(IJobHandler handler)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke());

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            if (methods == null || methods.Length == 0) return;

            handler.StepAmount = methods.Length;
            Action<IJobHandler> invokable;
            foreach(Delegate method in methods)
            {
                invokable = method as Action<IJobHandler>;
                invokable?.Invoke(handler.Split());
            }
        }
    }
    
    public class Notification<T>
    {
        public event Action<T> onMainThread;
        public event Action<IJobHandler, T> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Notification(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(IJobHandler handler, T value1)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke(value1));

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            if (methods == null || methods.Length == 0) return;

            handler.StepAmount = methods.Length;
            Action<IJobHandler, T> invokable;
            foreach(Delegate method in methods)
            {
                invokable = method as Action<IJobHandler, T>;
                invokable?.Invoke(handler.Split(), value1);
            }
        }
    }
    
    public class Notification<T, U>
    {
        public event Action<T, U> onMainThread;
        public event Action<IJobHandler, T, U> onBackgroundThread; 
        private IRuntimeThreadManager _threadManager;

        public Notification(IRuntimeThreadManager threadManager)
        {
            _threadManager = threadManager;
            onMainThread = null;
            onBackgroundThread = null;
        }

        public void Invoke(IJobHandler handler, T value1, U value2)
        {
            _threadManager.RunOnMainThread(() => onMainThread?.Invoke(value1, value2));

            Delegate[] methods = onBackgroundThread?.GetInvocationList();
            if (methods == null || methods.Length == 0) return;

            handler.StepAmount = methods.Length;
            Action<IJobHandler, T, U> invokable;
            foreach(Delegate method in methods)
            {
                invokable = method as Action<IJobHandler, T, U>;
                invokable?.Invoke(handler.Split(), value1, value2);
            }
        }
    }
}