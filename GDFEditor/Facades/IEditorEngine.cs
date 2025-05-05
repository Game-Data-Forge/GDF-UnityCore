using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorEngine : IRuntimeEngine
    {
        public new IEditorConfiguration Configuration { get; }

        public new IEditorThreadManager ThreadManager { get; }
        public new IEditorServerManager ServerManager { get; }
        public new IEditorEnvironmentManager EnvironmentManager { get; }
        public new IEditorDeviceManager DeviceManager { get; }
        public new IEditorAccountManager AccountManager { get; }
        public new IEditorAuthenticationManager AuthenticationManager { get; }
        public new IEditorPlayerDataManager PlayerDataManager { get; }
        public new IEditorTypeManager TypeManager { get; }
        public new IEditorPlayerPersistanceManager PersistanceManager { get; }
    }
}
