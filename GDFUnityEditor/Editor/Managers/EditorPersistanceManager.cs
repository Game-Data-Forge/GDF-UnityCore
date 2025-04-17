using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorPlayerPersistanceManager : RuntimePlayerPersistanceManager, IEditorPlayerPersistanceManager
    {
        public EditorPlayerPersistanceManager(IEditorEngine engine) : base(engine)
        {
            
        }
    }
}