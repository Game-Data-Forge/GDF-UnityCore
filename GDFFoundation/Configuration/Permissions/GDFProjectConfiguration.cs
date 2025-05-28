#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectConfiguration.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    public class GDFProjectConfiguration
    {
        #region Instance fields and properties

        public Dictionary<string, short> Channels { get; set; } = new Dictionary<string, short>();

        public CloudConfiguration CloudConfig { get; set; }

        public Dictionary<ProjectEnvironment, GDFProjectMinimalCredentials> Credentials { set; get; }

        public string Description { set; get; } = string.Empty;

        public string Name { set; get; } = string.Empty;

        public string Organization { set; get; } = string.Empty;

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { set; get; }

        #endregion
    }
}