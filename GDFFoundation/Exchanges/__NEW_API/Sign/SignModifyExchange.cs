#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj SignModifyExchange.cs create at 2025/05/08 16:05:51
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class SignModifyExchange : IGDFLongReference
    {
        #region Instance fields and properties
        public string NewPassword { get; set; } = string.Empty;
        public string OldEmail { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;

        #region From interface IGDFLongReference

        public long Reference { get; set; }

        #endregion

        #endregion
    }
}