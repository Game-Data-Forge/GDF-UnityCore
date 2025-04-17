

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// Represents a deprecated class for managing localizable prefabs in GDFFoundation.
    /// @deprecated Use GDFPrefabLocalization instead
    /// /
    [Serializable]
    [Obsolete("Use GDFPrefabLocalization instead!")]
    public class GDFLocalizablePrefab : GDFDataType
    {
        /// <summary>
        /// Represents a localized prefab that is obsolete and should be replaced with GDFPrefabLocalization.
        /// </summary>
        public string Base { set; get; } = string.Empty;

        /// <summary>
        /// Represents a dictionary of localizable values.
        /// </summary>
        public Dictionary<string, string> Values { set; get; } = new Dictionary<string, string>();
    }
}



