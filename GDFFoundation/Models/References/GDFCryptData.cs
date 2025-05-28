#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFCryptData.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents encrypted data used in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFCryptData : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFCryptData object with a randomly generated value.
        /// </summary>
        /// <returns>A randomly generated GDFCryptData object.</returns>
        public static GDFCryptData Random()
        {
            return new GDFCryptData()
            {
                Value = GDFRandom.RandomStringBase64(48)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents the value of a GDFCryptData object.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        #endregion
    }
}