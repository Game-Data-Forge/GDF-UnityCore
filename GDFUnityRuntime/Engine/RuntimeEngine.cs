using GDFRuntime;
using UnityEngine;
using GDFFoundation.Tasks;

namespace GDFUnity
{
    public class RuntimeEngine : IRuntimeEngine
    {
        static private readonly object _lock = new object();
        static private RuntimeEngine _instance = null;
        static public RuntimeEngine Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new RuntimeEngine();
                    }
                }

                return _instance;
            }
        }

        [RuntimeInitializeOnLoadMethod]
        static private void RuntimeStart()
        {
            string _ = FileStorage.ROOT;
            GDF.Instance = () => Instance;
        }

        private GameObject _gameObject = null;

        private Task _launchOperation = null;
        private IRuntimeConfiguration _configuration;

        private IRuntimeThreadManager _threadManager;
        private IRuntimeServerManager _serverManager;
        private IRuntimeEnvironmentManager _environmentManager;
        private IRuntimeDeviceManager _deviceManager;
        private IRuntimeAuthenticationManager _authenticationManager;
        private IRuntimePlayerDataManager _playerDataManager;
        private IRuntimeTypeManager _typeManager;
        private IRuntimePlayerPersistanceManager _persistanceManager;

        public Task Launch => _launchOperation;
        public IRuntimeConfiguration Configuration => _configuration;

        public IRuntimeThreadManager ThreadManager => _threadManager;
        public IRuntimeServerManager ServerManager => _serverManager;
        public IRuntimeEnvironmentManager EnvironmentManager => _environmentManager;
        public IRuntimeDeviceManager DeviceManager => _deviceManager;
        public IRuntimeAuthenticationManager AuthenticationManager => _authenticationManager;
        public IRuntimePlayerDataManager PlayerDataManager => _playerDataManager;
        public IRuntimeTypeManager TypeManager => _typeManager;
        public IRuntimePlayerPersistanceManager PersistanceManager => _persistanceManager;

        private RuntimeEngine()
        {
            _configuration = RuntimeConfigurationEngine.Instance.Load();
            
            _gameObject = new GameObject("GDF Engine");
            GameObject.DontDestroyOnLoad(_gameObject);

            _threadManager = _gameObject.AddComponent<RuntimeThreadManager>();
            _serverManager = new RuntimeServerManager(this);
            _environmentManager = new RuntimeEnvironmentManager(this);
            _deviceManager = new RuntimeDeviceManager();
            _authenticationManager = new RuntimeAuthenticationManager(this);
            _typeManager = new RuntimeTypeManager();
            _persistanceManager = new RuntimePlayerPersistanceManager(this);
            _playerDataManager = new RuntimePlayerDataManager(this);

            _launchOperation = Task.Run((handler) => {
                _typeManager.LoadRunner(handler);
            }, "Start engine");
        }

        public Task Stop()
        {
            _instance = null;
            GameObject.Destroy(_gameObject);
            return Task.Success("Stop engine");
        }

        public void Kill()
        {
            _instance = null;
            GameObject.Destroy(_gameObject);
        }
    }
}
