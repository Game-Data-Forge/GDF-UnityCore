#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalizedString.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// The GDFLocalizedString class represents a localized string in multiple languages.
    /// /
    [Serializable]
    public class GDFLocalizedString : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a localized string value for multiple languages.
        /// </summary>
        public Dictionary<GDFLanguageEnum, string> Value { set; get; } = new Dictionary<GDFLanguageEnum, string>();

        #endregion
    }
}