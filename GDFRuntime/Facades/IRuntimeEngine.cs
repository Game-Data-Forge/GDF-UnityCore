using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public interface IRuntimeEngine
    {
        public Task Launch { get; }

        public IRuntimeConfiguration Configuration { get; }

        public IRuntimeThreadManager ThreadManager { get; }
        public IRuntimeServerManager ServerManager { get; }
        public IRuntimeEnvironmentManager EnvironmentManager { get; }
        public IRuntimeDeviceManager DeviceManager { get; }
        public IRuntimeAccountManager AccountManager { get; }
        public IRuntimeAuthenticationManager AuthenticationManager { get; }
        public IRuntimePlayerDataManager PlayerDataManager { get; }
        public IRuntimeTypeManager TypeManager { get; }
        public IRuntimePlayerPersistanceManager PersistanceManager { get; }

        public Task Stop();
        public void Kill();
    }
}
