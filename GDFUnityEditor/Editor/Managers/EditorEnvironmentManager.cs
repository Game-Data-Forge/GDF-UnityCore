using GDFEditor;
using GDFFoundation;
using GDFRuntime;
using UnityEditor;

namespace GDFUnity.Editor
{
    public class EditorEnvironmentManager : AsyncManager, IEditorEnvironmentManager
    {
        private readonly object _lock = new object();

        private class EnvironmentConfiguration
        {
            public ProjectEnvironment Environment { get; set; } = ProjectEnvironment.Development;
        }

        private Notification<ProjectEnvironment> _EnvironmentChangingEvent { get; }
        private Notification<ProjectEnvironment> _EnvironmentChangedEvent { get; }
        private Job<ProjectEnvironment> _job = null;
        private EnvironmentConfiguration _environment;
        private IEditorEngine _engine;

        public Notification<ProjectEnvironment> EnvironmentChanging => _EnvironmentChangingEvent;
        public Notification<ProjectEnvironment> EnvironmentChanged => _EnvironmentChangedEvent;
        public ProjectEnvironment Environment => _environment.Environment;

        protected override Job Job => _job;
        
        private GDFException canceledByUserException => new GDFException("ENV", 01, "Operation canceled by user !");

        public EditorEnvironmentManager(IEditorEngine engine)
        {
            _engine = engine;
            _environment = GDFUserSettings.Instance.LoadOrDefault(new EnvironmentConfiguration(), container: engine.Configuration.Reference.ToString());
            _EnvironmentChangingEvent = new Notification<ProjectEnvironment>(engine.ThreadManager);
            _EnvironmentChangedEvent = new Notification<ProjectEnvironment>(engine.ThreadManager);

            State = ManagerState.Ready;
        }

        public Job<ProjectEnvironment> SetEnvironment(ProjectEnvironment environment)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = ChangeEnvironmentJob(environment);

                return _job;
            }
        }

        private Job<ProjectEnvironment> ChangeEnvironmentJob(ProjectEnvironment environment)
        {
            string taskName = "Switch environment";
            if (environment == _environment.Environment)
            {
                return Job<ProjectEnvironment>.Success(environment, taskName);
            }

            if (GDF.Account.IsAuthenticated)
            {
                if (!EditorUtility.DisplayDialog("Account conflict", "You are trying to change the environment while connected to an account"+
                "\nProceeding will disconnect the current account.", "Ok", "Cancel"))
                {
                    return Job<ProjectEnvironment>.Failure(canceledByUserException, taskName);
                }
            }
            
            return Job<ProjectEnvironment>.Run(handler => {
                using Locker _ = Locker.Lock(this);

                handler.StepAmount = 3;

                EnvironmentChanging.Invoke(handler.Split(), environment);

                _environment.Environment = environment;

                handler.Step();
                GDFUserSettings.Instance.Save(_environment, container: _engine.Configuration.Reference.ToString());

                EnvironmentChanged.Invoke(handler.Split(), environment);
                return environment;
            }, taskName);
        }
    }
}