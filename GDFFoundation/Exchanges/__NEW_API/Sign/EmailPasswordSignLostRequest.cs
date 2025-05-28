#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj EmailPasswordSignLostRequest.cs create at 2025/05/16 08:05:51
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignLostInfos
    {
        #region Instance fields and properties

        public string Email { get; set; }
        public string EmailFrom { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public bool Success { get; set; }

        #endregion
    }

    [Serializable]
    public class EmailExternalRequest
    {
        #region Instance fields and properties
        public string Environment { get; set; }
        public string Language { get; set; }
        
        public string EmailFrom { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Link { get; set; }
        public string Hash { get; set; }

        #endregion
    }
}