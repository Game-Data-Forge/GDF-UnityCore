

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a JPEG image data type in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFImageJpeg : GDFDataType
    {
        /// <summary>
        /// Represents a base abstract class for GDFFoundation data types.
        /// </summary>
        public string ValueBaseSixtyFour { set; get; } = string.Empty;

        /// <summary>
        /// Generates a new instance of GDFImageJpeg with a randomly generated base64 value.
        /// </summary>
        /// <returns>A new instance of GDFImageJpeg.</returns>
        public static GDFImageJpeg Random()
        {
            return new GDFImageJpeg()
            {
                ValueBaseSixtyFour = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}



