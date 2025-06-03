using GDFEditor;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationReSign : CoreAuthenticationReSign<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorReSign
    {
        public EditorAuthenticationReSign(IEditorEngine engine, CoreAccountManager manager) : base(engine, manager)
        {
        }
    }
}