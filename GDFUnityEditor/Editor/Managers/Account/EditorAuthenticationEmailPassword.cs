using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationEmailPassword : CoreAuthenticationEmailPassword<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorEmailPassword
    {
        public EditorAuthenticationEmailPassword(IEditorEngine engine, EditorAccountManager manager) : base(engine, manager)
        {
            
        }
    }
}