using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAuthenticationReSign : CoreAuthenticationReSign<IRuntimeEngine>
    {
        public RuntimeAuthenticationReSign(IRuntimeEngine engine, CoreAccountManager manager) : base(engine, manager)
        {
        }
    }
}