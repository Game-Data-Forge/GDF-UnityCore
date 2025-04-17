using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    public class GDFProjectConfiguration
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { set; get; }

        public Dictionary<GDFEnvironmentKind, GDFProjectMinimalCredentials> Credentials { set; get; }

        public string Name { set; get; } = string.Empty;

        public string Description { set; get; } = string.Empty;

        public string Organization { set; get; } = string.Empty;

        public Dictionary<string, short> Channels { get; set; } = new Dictionary<string, short>();

        public Dictionary<string, string> AgentPool { get; set; }
    }
}