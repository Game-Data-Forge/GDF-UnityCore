#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFToken.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a token used in the application.
    /// </summary>
    [Serializable]
    public class GDFToken
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a token used in the application.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a token used in the application.
        /// </summary>
        public GDFToken()
        {
        }

        /// <summary>
        ///     Class representing an GDFToken.
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
        ///     Gets or sets the value of the GDFToken.
        /// </summary>
        public GDFToken(GDFToken sValue)
        {
            Value = sValue.Value;
        }

        #endregion
    }
}