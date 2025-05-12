using System;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeTypeManager
    {
        public void LoadRunner(IJobHandler handler);
        public bool Is(Type type, Type target);
        public string GetClassName(Type type);
        public Type GetType(string className);
    }
}