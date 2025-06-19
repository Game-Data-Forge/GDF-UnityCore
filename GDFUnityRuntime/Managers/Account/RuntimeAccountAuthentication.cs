using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAccountAuthentication : CoreAccountAuthentication<RuntimeAuthenticationLocal, RuntimeAuthenticationDevice, RuntimeAuthenticationEmailPassword, RuntimeAuthenticationLastSession>
    {
        public RuntimeAccountAuthentication(IRuntimeEngine engine, RuntimeAccountManager manager) : base(manager)
        {
            _local = new RuntimeAuthenticationLocal(engine, manager);
            _device = new RuntimeAuthenticationDevice(engine, manager);
            _emailPassword = new RuntimeAuthenticationEmailPassword(engine, manager);
            _reSign = new RuntimeAuthenticationLastSession(engine, manager);
        }
    }
}