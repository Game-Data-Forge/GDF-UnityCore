

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a range of DateTime values in UTC.
    /// </summary>
    [Serializable]
    public class GDFDateTimeUtcRange : GDFDataType
    {
        /// <summary>
        /// Gets or sets the minimum timestamp value.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        /// <summary>
        /// Gets or sets the maximum timestamp for the GDFDateTimeUtcRange class.
        /// </summary>
        /// <remarks>
        /// The maximum timestamp represents the upper limit of the range for the GDFDateTimeUtcRange class.
        /// It is used in conjunction with the minimum timestamp to define a time range.
        /// </remarks>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        /// Generates a random GDFDateTimeUtcRange object.
        /// </summary>
        /// <returns>A new instance of GDFDateTimeUtcRange with randomly generated values for TimestampMin and TimestampMax.</returns>
        public static GDFDateTimeUtcRange Random()
        {
            return new GDFDateTimeUtcRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }
    }
}



