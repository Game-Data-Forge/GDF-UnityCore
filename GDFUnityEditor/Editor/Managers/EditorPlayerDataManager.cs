using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorPlayerDataManager : RuntimePlayerDataManager, IEditorPlayerDataManager
    {
        public EditorPlayerDataManager(IEditorEngine engine) : base(engine)
        {
            
        }
    }
}