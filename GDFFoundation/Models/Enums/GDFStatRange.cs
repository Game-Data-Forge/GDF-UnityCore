


namespace GDFFoundation
{
    /// <summary>
    /// Represents the range of statistics.
    /// </summary>
    public enum GDFStatRange
    {
        /// <summary>
        /// Represents a minute range for statistics.
        /// </summary>
        Minute = 1,

        /// <summary>
        /// Represents a time range of one hour in the statistics.
        /// </summary>
        Hour = 2,

        /// <summary>
        /// Represents the range of a statistic for a day.
        /// </summary>
        /// <remarks>
        /// This member is part of the <see cref="GDFStatRange"/> enumeration.
        /// </remarks>
        Day = 4,

        /// <summary>
        /// Represents the month range for a statistic.
        /// </summary>
        Month = 8,

        /// <summary>
        /// Represents the year range of a statistic.
        /// </summary>
        Year = 16,
    }
}

