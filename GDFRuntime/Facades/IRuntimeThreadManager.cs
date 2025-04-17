using System;

namespace GDFRuntime
{
    public interface IRuntimeThreadManager
    {
        public void RunOnMainThread(Action action);
    }
}
