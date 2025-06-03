using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAccountAuthentication : CoreAccountAuthentication<EditorAuthenticationDevice, EditorAuthenticationEmailPassword, EditorAuthenticationReSign>, IEditorAccountManager.IEditorAuthentication
    {
        IEditorAccountManager.IEditorAuthentication.IEditorDevice IEditorAccountManager.IEditorAuthentication.Device => _device;
        IEditorAccountManager.IEditorAuthentication.IEditorEmailPassword IEditorAccountManager.IEditorAuthentication.EmailPassword => _emailPassword;
        IEditorAccountManager.IEditorAuthentication.IEditorReSign IEditorAccountManager.IEditorAuthentication.ReSign => _reSign;
        
        public EditorAccountAuthentication(IEditorEngine engine, EditorAccountManager manager) : base(manager)
        {
            _device = new EditorAuthenticationDevice(engine, manager);
            _emailPassword = new EditorAuthenticationEmailPassword(engine, manager);
            _reSign = new EditorAuthenticationReSign(engine, manager);
        }
    }
}