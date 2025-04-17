using System;
using System.IO;
using Newtonsoft.Json;

namespace GDFUnity.Editor
{
    public class ProjectSettings : FileStorage<ProjectSettings>
    {
        private const string _CONTAINER = "ProjectSettings";

        protected override Formatting _Formatting => Formatting.Indented;

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
    }
}
