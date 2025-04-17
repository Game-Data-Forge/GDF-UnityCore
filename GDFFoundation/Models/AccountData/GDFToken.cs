

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a token used in the application.
    /// </summary>
    [Serializable]
    public class GDFToken
    {
        /// <summary>
        /// Represents a token used in the application.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        /// <summary>
        /// Represents a token used in the application.
        /// </summary>
        public GDFToken()
        {
            
        }

        /// <summary>
        /// Class representing an GDFToken.
        /// </summary>
        public GDFToken(string sValue)
        {
            if (sValue == null)
            {
                sValue = string.Empty;
            }
            Value = sValue;
        }

        /// <summary>
        /// Gets or sets the value of the GDFToken.
        /// </summary>
        public GDFToken(GDFToken sValue)
        {
            Value = sValue.Value;
        }
    }
}

