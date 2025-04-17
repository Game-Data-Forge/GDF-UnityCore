using System.IO;
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

        protected override Formatting _Formatting => Formatting.Indented;

        public string GetDataPath(long projectReference)
        {
            return GenerateContainerName(projectReference.ToString());
        }

        protected override string GenerateContainerName(string container)
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
