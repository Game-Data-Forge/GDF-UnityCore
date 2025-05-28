using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeEnvironmentManager : IRuntimeEnvironmentManager
    {
        private IRuntimeEngine _engine;

        public ProjectEnvironment Environment => _engine.Configuration.Environment;

        public RuntimeEnvironmentManager(IRuntimeEngine engine)
        {
            _engine = engine;
        }
    }
}