using System.IO;
using Newtonsoft.Json;

namespace GDFUnity.Editor
{
    public class ProjectSettings : FileStorage
    {
        private const string _CONTAINER = "ProjectSettings";

        static private ProjectSettings _instance = new ProjectSettings();
        static public ProjectSettings Instance => _instance;

        protected override Formatting _Formatting => Formatting.Indented;

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
    }
}
