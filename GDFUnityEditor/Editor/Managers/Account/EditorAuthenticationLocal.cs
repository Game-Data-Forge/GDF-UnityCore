using GDFEditor;
using GDFFoundation;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationLocal : CoreAuthenticationLocal<IEditorEngine>, IEditorAccountManager.IEditorAuthentication.IEditorLocal
    {
        public EditorAuthenticationLocal(IEditorEngine engine, EditorAccountManager manager) : base(engine, manager)
        {
            engine.EnvironmentManager.EnvironmentChanging.onBackgroundThread += OnEnvironmentChanging;
        }

        ~EditorAuthenticationLocal()
        {
            _engine.EnvironmentManager.EnvironmentChanging.onBackgroundThread -= OnEnvironmentChanging;
        }

        public void OnEnvironmentChanging(IJobHandler handler, ProjectEnvironment environment)
        {
            _storage = null;
        }
    }
}