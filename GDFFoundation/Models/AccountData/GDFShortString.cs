

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a short string value.
    /// </summary>
    [Serializable]
    public class GDFShortString
    {
        /// <summary>
        /// Gets or sets the value of the property.
        /// </summary>
        /// <value>The value of the property.</value>
        public string Value { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the value of the GDFShortString.
        /// </summary>
        public GDFShortString()
        {
        }

        /// <summary>
        /// Represents a short string value.
        /// </summary>
        public GDFShortString(string sValue)
        {
            if (sValue == null)
            {
                sValue = string.Empty;
            }
            Value = sValue;
        }

        /// <summary>
        /// Represents a short string value.
        /// </summary>
        public GDFShortString(GDFShortString sValue)
        {
            Value = sValue.Value;
        }
    }
}

