

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a date range with minimum and maximum timestamps.
    /// </summary>
    [Serializable]
    public class GDFDateRange : GDFDataType
    {
        /// <summary>
        /// Represents the minimum timestamp value of a date range.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        /// <summary>
        /// Gets or sets the maximum timestamp value for the GDFDateRange object.
        /// </summary>
        /// <value>The maximum timestamp value.</value>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        /// Generates a random GDFDateRange object.
        /// The generated GDFDateRange object has its TimestampMin and TimestampMax properties set to random integer values.
        /// </summary>
        /// <returns>A new instance of the GDFDateRange class with randomly assigned TimestampMin and TimestampMax properties.</returns>
        public static GDFDateRange Random()
        {
            return new GDFDateRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }
    }
}



