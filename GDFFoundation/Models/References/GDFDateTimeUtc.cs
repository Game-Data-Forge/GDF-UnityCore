

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a UTC DateTime data type for GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFDateTimeUtc : GDFDataType
    {
        /// <summary>
        /// Represents a timestamp.
        /// </summary>
        public long Timestamp { set; get; } = 0;

        /// <summary>
        /// Generates a random instance of GDFDateTimeUtc.
        /// </summary>
        /// <returns>A random instance of GDFDateTimeUtc.</returns>
        public static GDFDateTimeUtc Random()
        {
            return new GDFDateTimeUtc()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }
    }
}



