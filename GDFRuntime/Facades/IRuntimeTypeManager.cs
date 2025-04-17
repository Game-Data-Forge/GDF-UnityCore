using System;
using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public interface IRuntimeTypeManager
    {
        public void LoadRunner(ITaskHandler handler);
        public bool Is(Type type, Type target);
        public string GetClassName(Type type);
        public Type GetType(string className);
    }
}