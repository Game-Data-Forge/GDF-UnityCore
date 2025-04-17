using System;
using GDFEditor;
using UnityEditor;

namespace GDFUnity.Editor
{
    public class EditorThreadManager : IEditorThreadManager
    {
        private readonly object _lock = new object();
        private Action _runners;

        public void RunOnMainThread(Action action)
        {
            bool needToExecute;
            lock (_lock)
            {
                needToExecute = _runners == null;
                _runners += action;
            }

            if (needToExecute)
            {
                EditorApplication.update += Execute;
            }
        }

        private void Execute()
        {
            EditorApplication.update -= Execute;
            Action runners = null;
            lock (_lock)
            {
                runners = _runners;
                _runners = null;
            }
            
            runners?.Invoke();
        }
    }
}