using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAuthenticationEmailPassword : CoreAuthenticationEmailPassword<IRuntimeEngine>
    {
        public RuntimeAuthenticationEmailPassword(IRuntimeEngine engine, RuntimeAccountManager manager) : base(engine, manager)
        {
            
        }
    }
}