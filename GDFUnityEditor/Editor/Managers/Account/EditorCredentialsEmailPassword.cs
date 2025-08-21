using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorCredentialsEmailPassword : CoreCredentialsEmailPassword, IEditorAccountManager.IEditorCredentials.IEditorEmailPassword
    {
        public EditorCredentialsEmailPassword(EditorAccountManager manager) : base(manager)
        {
            
        }
    }
}