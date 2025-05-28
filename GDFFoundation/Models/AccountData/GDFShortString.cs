#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFShortString.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a short string value.
    /// </summary>
    [Serializable]
    public class GDFShortString
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the value of the property.
        /// </summary>
        /// <value>The value of the property.</value>
        public string Value { set; get; } = string.Empty;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Gets or sets the value of the GDFShortString.
        /// </summary>
        public GDFShortString()
        {
        }

        /// <summary>
        ///     Represents a short string value.
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
        ///     Represents a short string value.
        /// </summary>
        public GDFShortString(GDFShortString sValue)
        {
            Value = sValue.Value;
        }

        #endregion
    }
}