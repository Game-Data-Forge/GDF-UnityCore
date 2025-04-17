// Game-Data-Forge Solution
// Copyright ©2024-2025  idéMobi SARL
// Authors: Jean-François CONTART & Quentin BOULOGNE
// File identity: GDFFoundation.csproj GDFStatisticsConsolidateRange.cs create at 2025/03/25 11:03:36

namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the range to consolidate statistics.
    /// </summary>
    public enum GDFStatisticsConsolidateRange
    {
        /// <summary>
        ///     Represents a range that consolidates statistics for the current minute.
        /// </summary>
        ThisMinute,

        /// <summary>
        ///     Specifies statistics consolidation range as this hour.
        /// </summary>
        ThisHour,

        /// <summary>
        ///     Enumeration member representing the consolidate range of This Date.
        /// </summary>
        ThisDate,

        /// <summary>
        ///     Represents the current month in the GDFStatisticsConsolidateRange enumeration.
        /// </summary>
        ThisMonth,

        /// <summary>
        ///     Represents a specific day in the GDFStatisticsConsolidateRange enumeration.
        /// </summary>
        Day,
        Date,

        /// <summary>
        ///     Represents the hour time range for statistics consolidation.
        /// </summary>
        Hour,

        /// <summary>
        ///     Represents a month in the GDFStatisticsConsolidateRange enumeration.
        /// </summary>
        Month,

        /// <summary>
        ///     Represents the year statistic consolidation range.
        /// </summary>
        Year,
    }
}