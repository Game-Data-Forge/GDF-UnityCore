using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a localized asset that can be used within the application.
    /// </summary>
    [Serializable]
    public class GDFLocalizedAsset : IGDFSubModel
    {
        /// <summary>
        /// Represents a localized asset in the GDFFoundation library.
        /// </summary>
        public Dictionary<GDFLanguageEnum, GDFLongReference> Value { set; get; } = new Dictionary<GDFLanguageEnum, GDFLongReference>();
    }

    /// <summary>
    /// Represents a localized asset in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFLocalizedAsset<T> : GDFLocalizedAsset where T : IGDFAsset
    {
    }
}

