using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAccountCredentials : CoreAccountCredentials<EditorAccountManager, EditorCredentialsEmailPassword>, IEditorAccountManager.IEditorCredentials
    {
        IEditorAccountManager.IEditorCredentials.IEditorEmailPassword IEditorAccountManager.IEditorCredentials.EmailPassword => _emailPassword;
        
        public EditorAccountCredentials(EditorAccountManager manager) : base(manager)
        {
            _emailPassword = new EditorCredentialsEmailPassword(manager);
        }
    }
}