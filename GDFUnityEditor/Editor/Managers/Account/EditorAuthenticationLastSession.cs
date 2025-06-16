using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationLastSession : CoreAuthenticationLastSession<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorLastSession
    {
        public EditorAuthenticationLastSession(IEditorEngine engine, CoreAccountManager manager) : base(engine, manager)
        {
        }
    }
}