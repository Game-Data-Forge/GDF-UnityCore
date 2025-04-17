

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class for serializing and deserializing JSON values.
    /// </summary>
    [Serializable]
    public class GDFJson : GDFDataType
    {
        /// <summary>
        /// Represents a property for storing a JSON string value.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        /// <summary>
        /// Generates a random GDFJson object with a randomly generated value.
        /// </summary>
        /// <returns>A randomly generated GDFJson object.</returns>
        public static GDFJson Random()
        {
            return new GDFJson()
            {
                Value = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}



