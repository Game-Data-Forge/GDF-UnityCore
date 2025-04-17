


using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents encrypted data used in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFCryptData : GDFDataType
    {
        /// <summary>
        /// Represents the value of a GDFCryptData object.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        /// <summary>
        /// Generates a random GDFCryptData object with a randomly generated value.
        /// </summary>
        /// <returns>A randomly generated GDFCryptData object.</returns>
        public static GDFCryptData Random()
        {
            return new GDFCryptData()
            {
                Value = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}



