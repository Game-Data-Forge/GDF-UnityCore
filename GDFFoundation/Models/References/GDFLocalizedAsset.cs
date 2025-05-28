#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalizedAsset.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a localized asset that can be used within the application.
    /// </summary>
    [Serializable]
    public class GDFLocalizedAsset : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a localized asset in the GDFFoundation library.
        /// </summary>
        public Dictionary<GDFLanguageEnum, GDFLongReference> Value { set; get; } = new Dictionary<GDFLanguageEnum, GDFLongReference>();

        #endregion
    }

    /// <summary>
    ///     Represents a localized asset in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFLocalizedAsset<T> : GDFLocalizedAsset where T : IGDFAsset
    {
    }
}