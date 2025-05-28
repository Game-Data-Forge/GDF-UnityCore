using GDFRuntime;
using UnityEngine;
using GDFFoundation;

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

#if !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod]
        static private void RuntimeStart()
        {
            string _ = FileStorage.ROOT;
            GDF.Instance = () => Instance;
        }
#endif

        private GameObject _gameObject = null;

        private Job _launch = null;
        private IRuntimeConfiguration _configuration;

        private IRuntimeThreadManager _threadManager;
        private IRuntimeServerManager _serverManager;
        private IRuntimeEnvironmentManager _environmentManager;
        private IRuntimeDeviceManager _deviceManager;
        private IRuntimeAccountManager _accountManager;
        private IRuntimeAuthenticationManager _authenticationManager;
        private IRuntimePlayerDataManager _playerDataManager;
        private IRuntimeTypeManager _typeManager;
        private IRuntimePlayerPersistanceManager _persistanceManager;

        public Job Launch => _launch;
        public IRuntimeConfiguration Configuration => _configuration;

        public IRuntimeThreadManager ThreadManager => _threadManager;
        public IRuntimeServerManager ServerManager => _serverManager;
        public IRuntimeEnvironmentManager EnvironmentManager => _environmentManager;
        public IRuntimeDeviceManager DeviceManager => _deviceManager;
        public IRuntimeAccountManager AccountManager => _accountManager;
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
            _accountManager = new RuntimeAccountManager(this);
            _authenticationManager = new RuntimeAuthenticationManager(this);
            _typeManager = new RuntimeTypeManager();
            _persistanceManager = new RuntimePlayerPersistanceManager(this);
            _playerDataManager = new RuntimePlayerDataManager(this);

            _launch = Job.Run((handler) => {
                _typeManager.LoadRunner(handler);
            }, "Start engine");
            _launch.Pool = null; // Makes the launch task is never recycled.
        }

        public Job Stop()
        {
            GameObject.Destroy(_gameObject);
            return Job.Run(async handler => {
                handler.StepAmount = 3;
                try
                {
                    await _playerDataManager.Stop();
                    handler.Step();
                    
                    await _accountManager.Stop();
                    handler.Step();

                    await _authenticationManager.Stop();
                    handler.Step();
                }
                finally
                {
                    _launch.Dispose();
                    _instance = null;
                }
            }, "Stop engine");
        }

        public void Kill()
        {
            _instance = null;
            GameObject.Destroy(_gameObject);
        }
    }
}
