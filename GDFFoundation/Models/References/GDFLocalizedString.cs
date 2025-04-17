using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// The GDFLocalizedString class represents a localized string in multiple languages.
    /// /
    [Serializable]
    public class GDFLocalizedString : IGDFSubModel
    {
        /// <summary>
        /// Represents a localized string value for multiple languages.
        /// </summary>
        public Dictionary<GDFLanguageEnum, string> Value { set; get; } = new Dictionary<GDFLanguageEnum, string>();
    }
}
