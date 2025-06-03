using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAccountManager : CoreAccountManager<RuntimeAccountAuthentication, RuntimeAccountCredentials>
    {
        public RuntimeAccountManager(IRuntimeEngine engine) : base(engine)
        {
            _authentication = new RuntimeAccountAuthentication(engine, this);
            _credentials = new RuntimeAccountCredentials(this);
        }
    }
}