

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a PNG image stored as a base 64 string value.
    /// </summary>
    [Serializable]
    public class GDFImagePng : GDFDataType
    {
        /// <summary>
        /// Represents a base abstract class for GDFFoundation data types.
        /// </summary>
        public string ValueBaseSixtyFour { set; get; } = string.Empty;

        /// <summary>
        /// Return a random string of specified length using characters from "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/" set.
        /// </summary>
        /// <returns>A random string.</returns>
        public static GDFImagePng Random()
        {
            return new GDFImagePng()
            {
                ValueBaseSixtyFour = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}



