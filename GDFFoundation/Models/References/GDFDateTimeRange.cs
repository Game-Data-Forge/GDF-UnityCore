

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a date and time range.
    /// </summary>
    [Serializable]
    public class GDFDateTimeRange : GDFDataType
    {
        /// <summary>
        /// Represents the minimum timestamp value of a GDFDateTimeRange object.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        /// <summary>
        /// Represents the maximum timestamp of a datetime range.
        /// </summary>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        /// Generate a random GDFDateTimeRange object with randomly generated TimestampMin and TimestampMax values.
        /// </summary>
        /// <returns>A new GDFDateTimeRange object with random TimestampMin and TimestampMax values.</returns>
        public static GDFDateTimeRange Random()
        {
            return new GDFDateTimeRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }
    }
}



