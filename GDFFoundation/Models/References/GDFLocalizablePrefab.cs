#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalizablePrefab.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// Represents a deprecated class for managing localizable prefabs in GDFFoundation.
    /// @deprecated Use GDFPrefabLocalization instead
    /// /
    [Serializable]
    [Obsolete("Use GDFPrefabLocalization instead!")]
    public class GDFLocalizablePrefab : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a localized prefab that is obsolete and should be replaced with GDFPrefabLocalization.
        /// </summary>
        public string Base { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a dictionary of localizable values.
        /// </summary>
        public Dictionary<string, string> Values { set; get; } = new Dictionary<string, string>();

        #endregion
    }
}