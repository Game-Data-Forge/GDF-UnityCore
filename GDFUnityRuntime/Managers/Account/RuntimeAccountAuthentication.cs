using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAccountAuthentication : CoreAccountAuthentication<RuntimeAuthenticationDevice, RuntimeAuthenticationEmailPassword, RuntimeAuthenticationReSign>
    {
        public RuntimeAccountAuthentication(IRuntimeEngine engine, RuntimeAccountManager manager) : base(manager)
        {
            _device = new RuntimeAuthenticationDevice(engine, manager);
            _emailPassword = new RuntimeAuthenticationEmailPassword(engine, manager);
            _reSign = new RuntimeAuthenticationReSign(engine, manager);
        }
    }
}