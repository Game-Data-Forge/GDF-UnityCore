using System.IO;
using GDFFoundation;
using GDFRuntime;
using Newtonsoft.Json;

namespace GDFUnity
{
    public class GDFUserSettings : FileStorage<GDFUserSettings>
    {
        private const string _CONTAINER =
#if UNITY_EDITOR
        "UserSettings/GameDataForge";
#else
        "GameDataForge";
#endif

        static public string ProjectContainer(IRuntimeEngine engine)
        {
            return engine.Configuration.Reference.ToString();
        }

        static public string EnvironmentContainer(IRuntimeEngine engine)
        {
#if UNITY_EDITOR
            return Path.Combine(ProjectContainer(engine), engine.EnvironmentManager.Environment.ToLongString());
#else
            return ProjectContainer(engine);
#endif
        }

        static public string AccountContainer(IRuntimeEngine engine)
        {
            return Path.Combine(EnvironmentContainer(engine), engine.AccountManager.Identity);
        }

        protected override Formatting _Formatting =>
#if UNITY_EDITOR
            Formatting.Indented;
#else
            Formatting.None;
#endif

        public string GetDataPath(long projectReference)
        {
            return GenerateContainerName(projectReference.ToString());
        }

        public override string GenerateContainerName(string container)
        {
            if (container == null)
            {
                container = _CONTAINER;
            }
            else
            {
                container = Path.Combine(_CONTAINER, container);
            }
            return base.GenerateContainerName(container);
        }

        public void DeleteProject(long reference)
        {
            string container = GenerateContainerName(reference.ToString());
            if (Directory.Exists(container))
            {
                Directory.Delete(container, true);
            }
        }
    }
}
