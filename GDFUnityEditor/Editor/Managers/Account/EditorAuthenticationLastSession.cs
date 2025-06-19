using GDFEditor;
using GDFFoundation;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationLastSession : CoreAuthenticationLastSession<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorLastSession
    {
        public EditorAuthenticationLastSession(IEditorEngine engine, CoreAccountManager manager) : base(engine, manager)
        {
            engine.EnvironmentManager.EnvironmentChanging.onBackgroundThread += OnEnvironmentChanging;
        }

        ~EditorAuthenticationLastSession()
        {
            _engine.EnvironmentManager.EnvironmentChanging.onBackgroundThread -= OnEnvironmentChanging;
        }

        public void OnEnvironmentChanging(IJobHandler handler, ProjectEnvironment environment)
        {
            _storage = null;
        }
    }
}