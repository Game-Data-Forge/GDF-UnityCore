using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAuthenticationLastSession : CoreAuthenticationLastSession<IRuntimeEngine>
    {
        public RuntimeAuthenticationLastSession(IRuntimeEngine engine, CoreAccountManager manager) : base(engine, manager)
        {
        }
    }
}