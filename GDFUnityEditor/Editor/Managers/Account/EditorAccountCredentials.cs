using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAccountCredentials : CoreAccountCredentials<EditorAccountManager>, IEditorAccountManager.IEditorCredentials
    {
        public EditorAccountCredentials(EditorAccountManager manager) : base(manager)
        {
            
        }
    }
}