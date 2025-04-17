

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a date and time value in Coordinated Universal Time (UTC).
    /// </summary>
    [Serializable]
    public class GDFDateUtc : GDFDataType
    {
        /// <summary>
        /// Represents a GDFDateUtc data type.
        /// </summary>
        public int Timestamp { set; get; } = 0;

        /// <summary>
        /// Generates a random GDFDateUtc object.
        /// </summary>
        /// <returns>A randomly generated GDFDateUtc object.</returns>
        public static GDFDateUtc Random()
        {
            return new GDFDateUtc()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }
    }
}



