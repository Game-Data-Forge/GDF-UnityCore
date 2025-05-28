#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj OkMessageResult.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public struct OkMessageResult
    {
        public string Status { get; set; }

        public bool Success { get; set; }
        public string message { get; set; }
        public string environment { get; set; }
        public string project { get; set; }
        public string channel { get; set; }
        public long account { get; set; }
    }
}