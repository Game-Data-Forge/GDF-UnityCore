#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFImagePng.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a PNG image stored as a base 64 string value.
    /// </summary>
    [Serializable]
    public class GDFImagePng : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Return a random string of specified length using characters from "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/" set.
        /// </summary>
        /// <returns>A random string.</returns>
        public static GDFImagePng Random()
        {
            return new GDFImagePng()
            {
                ValueBaseSixtyFour = GDFRandom.RandomStringBase64(48)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a base abstract class for GDFFoundation data types.
        /// </summary>
        public string ValueBaseSixtyFour { set; get; } = string.Empty;

        #endregion
    }
}