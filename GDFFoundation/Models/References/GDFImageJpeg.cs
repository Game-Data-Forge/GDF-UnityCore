#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFImageJpeg.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a JPEG image data type in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFImageJpeg : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a new instance of GDFImageJpeg with a randomly generated base64 value.
        /// </summary>
        /// <returns>A new instance of GDFImageJpeg.</returns>
        public static GDFImageJpeg Random()
        {
            return new GDFImageJpeg()
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