using GDFEditor;
using GDFRuntime;
using UnityEditor;
using GDFFoundation.Tasks;

namespace GDFUnity.Editor
{
    public class EditorEngine : IEditorEngine
    {
        static private readonly object _lock = new object();
        static private EditorEngine _instance = null;
        static private EditorEngine Instance
        {
            get
            {
                try
                {
                    lock (_lock)
                    {
                        IEditorConfiguration configuration = EditorConfigurationEngine.Instance.Load();
                        if (_instance == null)
                        {
                            _instance = new EditorEngine(configuration);
                        }
                    }
                }
                catch
                {
                    if (_instance != null)
                    {
                        _instance = null;
                    }
                    throw;
                }

                return _instance;
            }
        }
        static internal EditorEngine UnsafeInstance => _instance;

        [InitializeOnLoadMethod]
        static private void EditorStart()
        {
            GDF.Instance = () => Instance;
            GDFEditor.Instance = () => Instance;
        }

        private Task _launchOperation = null;
        private IEditorConfiguration _configuration;
        
        private IEditorThreadManager _threadManager;
        private IEditorServerManager _serverManager;
        private IEditorEnvironmentManager _environmentManager;
        private IEditorDeviceManager _deviceManager;
        private IEditorAuthenticationManager _authenticationManager;
        private IEditorPlayerDataManager _playerDataManager;
        private IEditorTypeManager _typeManager;
        private IEditorPlayerPersistanceManager _persistanceManager;

        public Task Launch => _launchOperation;
        public IEditorConfiguration Configuration => _configuration;

        public IEditorThreadManager ThreadManager => _threadManager;
        public IEditorServerManager ServerManager => _serverManager;
        public IEditorEnvironmentManager EnvironmentManager => _environmentManager;
        public IEditorDeviceManager DeviceManager => _deviceManager;
        public IEditorAuthenticationManager AuthenticationManager => _authenticationManager;
        public IEditorPlayerDataManager PlayerDataManager => _playerDataManager;
        public IEditorTypeManager TypeManager => _typeManager;
        public IEditorPlayerPersistanceManager PersistanceManager => _persistanceManager;
        
        IRuntimeConfiguration IRuntimeEngine.Configuration => Configuration;

        IRuntimeThreadManager IRuntimeEngine.ThreadManager => ThreadManager;
        IRuntimeServerManager IRuntimeEngine.ServerManager => ServerManager;
        IRuntimeEnvironmentManager IRuntimeEngine.EnvironmentManager => EnvironmentManager;
        IRuntimeDeviceManager IRuntimeEngine.DeviceManager => DeviceManager;
        IRuntimeAuthenticationManager IRuntimeEngine.AuthenticationManager => AuthenticationManager;
        IRuntimePlayerDataManager IRuntimeEngine.PlayerDataManager => PlayerDataManager;
        IRuntimeTypeManager IRuntimeEngine.TypeManager => TypeManager;
        IRuntimePlayerPersistanceManager IRuntimeEngine.PersistanceManager => PersistanceManager;

        private EditorEngine(IEditorConfiguration configuration)
        {
            _configuration = configuration;

            _threadManager = new EditorThreadManager();
            _serverManager = new EditorServerManager(this);
            _environmentManager = new EditorEnvironmentManager(this);
            _deviceManager = new EditorDeviceManager(this);
            _authenticationManager = new EditorAuthenticationManager(this);
            _typeManager = new EditorTypeManager();
            _persistanceManager = new EditorPlayerPersistanceManager(this);
            _playerDataManager = new EditorPlayerDataManager(this);

            _launchOperation = Task.Run((handler) => {
                _typeManager.LoadRunner(handler);
            }, "Start engine");
        }

        public Task Stop()
        {
            _instance = null;
            return Task.Success("Stop engine");
        }

        public void Kill()
        {
            _instance = null;
        }
    }
}
