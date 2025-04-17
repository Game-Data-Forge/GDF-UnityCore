using System.Collections.Generic;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorTypeManager : IRuntimeTypeManager
    {
        public Dictionary<string, TypeHierarchy> Player { get; }
    }
}