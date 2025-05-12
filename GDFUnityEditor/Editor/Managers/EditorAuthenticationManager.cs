using GDFEditor;
using GDFFoundation;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationManager : RuntimeAuthenticationManager, IEditorAuthenticationManager
    {
        private IEditorEngine _engine;

        public EditorAuthenticationManager(IEditorEngine engine) : base(engine)
        {
            _engine = engine;
            
            _engine.EnvironmentManager.EnvironmentChangingNotif.onBackgroundThread += OnEnvironmentChanging;
        }

        ~EditorAuthenticationManager()
        {
            _engine.EnvironmentManager.EnvironmentChangingNotif.onBackgroundThread -= OnEnvironmentChanging;
        }

        private void OnEnvironmentChanging(IJobHandler handler, GDFEnvironmentKind kind)
        {
            if (!IsConnected)
            {
                return;
            }

            SignOutRunner(handler);
        }
    }
}