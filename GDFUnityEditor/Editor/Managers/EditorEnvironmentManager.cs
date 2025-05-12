using GDFEditor;
using GDFFoundation;
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

        private Notification<GDFEnvironmentKind> _EnvironmentChangingEvent { get; }
        private Notification<GDFEnvironmentKind> _EnvironmentChangedEvent { get; }
        private Job<GDFEnvironmentKind> _task = null;
        private EnvironmentConfiguration _environment;
        private IEditorEngine _engine;

        public Notification<GDFEnvironmentKind> EnvironmentChangingNotif => _EnvironmentChangingEvent;
        public Notification<GDFEnvironmentKind> EnvironmentChangedNotif => _EnvironmentChangedEvent;
        public GDFEnvironmentKind Environment => _environment.Environment;
        
        private GDFException canceledByUserException => new GDFException("ENV", 01, "Operation canceled by user !");

        public EditorEnvironmentManager(IEditorEngine engine)
        {
            _engine = engine;
            _environment = GDFUserSettings.Instance.LoadOrDefault(new EnvironmentConfiguration(), container: engine.Configuration.Reference.ToString());
            _EnvironmentChangingEvent = new Notification<GDFEnvironmentKind>(engine.ThreadManager);
            _EnvironmentChangedEvent = new Notification<GDFEnvironmentKind>(engine.ThreadManager);
        }

        public Job<GDFEnvironmentKind> SetEnvironment(GDFEnvironmentKind environment)
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();
                
                _task = ChangeEnvironmentTask(environment);

                return _task;
            }
        }

        private Job<GDFEnvironmentKind> ChangeEnvironmentTask(GDFEnvironmentKind environment)
        {
            string taskName = "Switch environment";
            if (environment == _environment.Environment)
            {
                return Job<GDFEnvironmentKind>.Success(environment, taskName);
            }

            if (GDF.Authentication.IsConnected)
            {
                if (!EditorUtility.DisplayDialog("Account conflict", "You are trying to change the environment while connected to an account"+
                "\nProceeding will disconnect the current account.", "Ok", "Cancel"))
                {
                    return Job<GDFEnvironmentKind>.Failure(canceledByUserException, taskName);
                }
            }
            
            return Job<GDFEnvironmentKind>.Run(handler => {
                handler.StepAmount = 3;

                EnvironmentChangingNotif.Invoke(handler.Split(), environment);

                _environment.Environment = environment;

                handler.Step();
                GDFUserSettings.Instance.Save(_environment, container: _engine.Configuration.Reference.ToString());

                EnvironmentChangedNotif.Invoke(handler.Split(), environment);
                return environment;
            }, taskName);
        }
    }
}