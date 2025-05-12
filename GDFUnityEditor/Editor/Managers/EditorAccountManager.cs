using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAccountManager : RuntimeAccountManager, IEditorAccountManager
    {
        public EditorAccountManager(IEditorEngine engine) : base(engine)
        {
        }
    }
}