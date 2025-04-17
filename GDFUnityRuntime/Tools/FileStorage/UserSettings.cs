using System;
using System.IO;
using Newtonsoft.Json;

namespace GDFUnity
{
    public class UserSettings : FileStorage<UserSettings>
    {
        private const string _CONTAINER =
#if UNITY_EDITOR
        "UserSettings";
#else
        "";
#endif 
        
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
