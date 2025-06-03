using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationDevice : CoreAuthenticationDevice<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorDevice
    {
        public EditorAuthenticationDevice(IEditorEngine engine, EditorAccountManager manager) : base(engine, manager)
        {
            
        }
    }
}