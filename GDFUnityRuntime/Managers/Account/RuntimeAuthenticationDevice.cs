using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAuthenticationDevice : CoreAuthenticationDevice<IRuntimeEngine>
    {
        public RuntimeAuthenticationDevice(IRuntimeEngine engine, RuntimeAccountManager manager) : base(engine, manager)
        {
            
        }
    }
}