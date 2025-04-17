using GDFFoundation;
using GDFRuntime;
using System.Collections.Generic;

namespace GDFUnity
{
    public class RuntimeConfiguration : IRuntimeConfiguration
    {
        public long Reference { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public GDFEnvironmentKind Environment { get; set; }
        public string PublicToken { get; set; }
        public string PrivateToken { get; set; }
        public short Channel { get; set; }
        public Dictionary<string, string> AgentPool { get; set; }
    }
}
