using GDFEditor;
using GDFRuntime;

namespace GDFUnity.Editor
{
    public class EditorServerManager : RuntimeServerManager, IEditorServerManager
    {
        public EditorServerManager(IRuntimeEngine engine) : base(engine)
        {
        }
    }
}