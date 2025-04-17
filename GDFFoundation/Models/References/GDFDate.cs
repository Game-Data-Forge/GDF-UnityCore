

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a date data type in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFDate : GDFDataType
    {
        /// <summary>
        /// Represents a timestamp value.
        /// </summary>
        public int Timestamp { set; get; } = 0;

        /// <summary>
        /// Generates a random GDFDate with a random timestamp.
        /// </summary>
        /// <returns>A randomly generated GDFDate object.</returns>
        public static GDFDate Random()
        {
            return new GDFDate()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }
    }
}



