

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a date and time in the GDF Foundation.
    /// </summary>
    [Serializable]
    public class GDFDateTime : IGDFSubModel
    {
        /// <summary>
        /// Represents a timestamp stored as a long integer value.
        /// </summary>
        public long Timestamp { set; get; } = 0;

        /// <summary>
        /// Generates a random GDFDateTime object.
        /// </summary>
        /// <returns>A randomly generated GDFDateTime object.</returns>
        public static GDFDateTime Random()
        {
            return new GDFDateTime()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }

        /// <summary>
        /// Returns the current date and time as a GDFDateTime object.
        /// </summary>
        /// <returns>The current date and time as a GDFDateTime object.</returns>
        public static GDFDateTime Now()
        {
            return new GDFDateTime()
            {
                Timestamp = GDFTimestamp.Timestamp()
            };
        }
    }
}



