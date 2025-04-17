using System;
using GDFRuntime;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeThreadManager : MonoBehaviour, IRuntimeThreadManager
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
        }

        private void Update()
        {
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