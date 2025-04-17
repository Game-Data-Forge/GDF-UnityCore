using GDFEditor;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;
using UnityEditor;

namespace GDFUnity.Editor
{
    public class EditorEnvironmentManager : IEditorEnvironmentManager
    {
        private readonly object _taskLock = new object();

        private class EnvironmentConfiguration
        {
            public GDFEnvironmentKind Environment { get; set; } = GDFEnvironmentKind.Development;
        }

        private Event<GDFEnvironmentKind> _EnvironmentChangingEvent { get; }
        private Event<GDFEnvironmentKind> _EnvironmentChangedEvent { get; }
        private Task<GDFEnvironmentKind> _task = null;
        private EnvironmentConfiguration _environment;
        private IEditorEngine _engine;

        public Event<GDFEnvironmentKind> EnvironmentChangingEvent => _EnvironmentChangingEvent;
        public Event<GDFEnvironmentKind> EnvironmentChangedEvent => _EnvironmentChangedEvent;
        public GDFEnvironmentKind Environment => _environment.Environment;
        
        private GDFException canceledByUserException => new GDFException("ENV", 01, "Operation canceled by user !");

        public EditorEnvironmentManager(IEditorEngine engine)
        {
            _engine = engine;
            _environment = GDFUserSettings.Instance.LoadOrDefault(new EnvironmentConfiguration(), container: engine.Configuration.Reference.ToString());
            _EnvironmentChangingEvent = new Event<GDFEnvironmentKind>(engine.ThreadManager);
            _EnvironmentChangedEvent = new Event<GDFEnvironmentKind>(engine.ThreadManager);
        }

        public Task<GDFEnvironmentKind> SetEnvironment(GDFEnvironmentKind environment)
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();
                
                _task = ChangeEnvironmentTask(environment);

                return _task;
            }
        }

        private Task<GDFEnvironmentKind> ChangeEnvironmentTask(GDFEnvironmentKind environment)
        {
            string taskName = "Switch environment";
            if (environment == _environment.Environment)
            {
                return Task<GDFEnvironmentKind>.Success(environment, taskName);
            }

            if (GDF.Authentication.IsConnected)
            {
                if (!EditorUtility.DisplayDialog("Account conflict", "You are trying to change the environment while connected to an account"+
                "\nProceeding will disconnect the current account.", "Ok", "Cancel"))
                {
                    return Task<GDFEnvironmentKind>.Failure(canceledByUserException, taskName);
                }
            }
            
            return Task<GDFEnvironmentKind>.Run(handler => {
                handler.StepAmount = 3;

                EnvironmentChangingEvent.Invoke(handler.Split(), environment);

                _environment.Environment = environment;

                handler.Step();
                GDFUserSettings.Instance.Save(_environment, container: _engine.Configuration.Reference.ToString());

                EnvironmentChangedEvent.Invoke(handler.Split(), environment);
                return environment;
            }, taskName);
        }
    }
}