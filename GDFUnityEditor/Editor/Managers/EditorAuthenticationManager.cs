using GDFEditor;
using GDFFoundation;
using GDFFoundation.Tasks;
using UnityEngine;

namespace GDFUnity.Editor
{
    public class EditorAuthenticationManager : RuntimeAuthenticationManager, IEditorAuthenticationManager
    {
        private IEditorEngine _engine;

        public EditorAuthenticationManager(IEditorEngine engine) : base(engine)
        {
            _engine = engine;
            
            _engine.EnvironmentManager.EnvironmentChangingEvent.onBackgroundThread += OnEnvironmentChanging;
        }

        ~EditorAuthenticationManager()
        {
            _engine.EnvironmentManager.EnvironmentChangingEvent.onBackgroundThread -= OnEnvironmentChanging;
        }

        private void OnEnvironmentChanging(ITaskHandler handler, GDFEnvironmentKind kind)
        {
            if (!IsConnected)
            {
                return;
            }

            SignOutRunner(handler);
        }
    }
}