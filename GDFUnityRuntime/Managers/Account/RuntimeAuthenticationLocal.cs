using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAuthenticationLocal : CoreAuthenticationLocal<IRuntimeEngine>
    {
        public RuntimeAuthenticationLocal(IRuntimeEngine engine, RuntimeAccountManager manager) : base(engine, manager)
        {
            
        }
    }
}