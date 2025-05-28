#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFStatisticsTools.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides utility methods for generating and managing statistical keys and labels.
    /// </summary>
    public static class GDFStatisticsTools
    {
        #region Static methods

        /// <summary>
        ///     Generates a formatted statistic key based on the provided parameters, consolidating the date and time
        ///     information according to the specified <paramref name="consolidateRange" />.
        /// </summary>
        /// <param name="prefix">The base key string to be formatted and modified.</param>
        /// <param name="stamp">The date and time used to generate the consolidated key.</param>
        /// <param name="consolidateRange">
        ///     An enumeration value indicating the level of consolidation (e.g., minute, hour, day, month, year, etc.).
        /// </param>
        /// <param name="offset">An optional time offset (hours for time-based consolidations or days for date-based).</param>
        /// <returns>A formatted string representing the consolidated statistics key.</returns>
        public static string StatisticsKey(string prefix, DateTime stamp, GDFStatisticsConsolidateRange consolidateRange, int offset = 0)
        {
            string result = prefix.Replace("_", "-");
            DateTime tDateTime = stamp.AddHours(offset);
            switch (consolidateRange)
            {
                case GDFStatisticsConsolidateRange.ThisMinute:
                {
                    return result + "_ti_" + tDateTime.ToString("yyyy-MM-dd-HH-mm");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisHour:
                {
                    return result + "_th_" + tDateTime.ToString("yyyy-MM-dd-HH");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisDate:
                {
                    return result + "_td_" + tDateTime.ToString("yyyy-MM-dd");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisMonth:
                {
                    return result + "_tm_" + tDateTime.ToString("yyyy-MM");
                }
                break;
                case GDFStatisticsConsolidateRange.Day:
                {
                    return result + "_dy_" + tDateTime.ToString("ddd");
                }
                break;
                case GDFStatisticsConsolidateRange.Date:
                {
                    return result + "_d_" + tDateTime.ToString("dd");
                }
                break;
                case GDFStatisticsConsolidateRange.Hour:
                {
                    return result + "_h_" + tDateTime.ToString("HH");
                }
                break;
                case GDFStatisticsConsolidateRange.Month:
                {
                    return result + "_m_" + tDateTime.ToString("MM");
                }
                break;
                case GDFStatisticsConsolidateRange.Year:
                {
                    return result + "_y_" + tDateTime.ToString("yyyy");
                }
                break;
            }

            return result;
        }

        /// <summary>
        ///     Generates a statistics label string based on the provided timestamp and the specified
        ///     consolidation range, considering an optional time offset.
        /// </summary>
        /// <param name="stamp">The date and time used to generate the statistics label.</param>
        /// <param name="consolidateRange">
        ///     An enumeration value that specifies the level of consolidation (e.g., minute, hour, day, etc.).
        /// </param>
        /// <param name="offset">An optional integer offset applied to the timestamp (hours for time-based or days for date-based consolidations).</param>
        /// <returns>A formatted string representing the statistics label for the given consolidation range.</returns>
        public static string StatisticsLabel(DateTime stamp, GDFStatisticsConsolidateRange consolidateRange, int offset = 0)
        {
            string result = string.Empty;
            DateTime tDateTime = stamp.AddHours(offset);
            switch (consolidateRange)
            {
                case GDFStatisticsConsolidateRange.ThisMinute:
                {
                    return tDateTime.ToString("yyyy/MM/dd HH:mm:00");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisHour:
                {
                    return tDateTime.ToString("yyyy/MM/dd HH:00:00");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisDate:
                {
                    return tDateTime.ToString("yyyy/MM/dd");
                }
                break;
                case GDFStatisticsConsolidateRange.ThisMonth:
                {
                    return tDateTime.ToString("yyyy/MM");
                }
                break;
                case GDFStatisticsConsolidateRange.Day:
                {
                    return tDateTime.ToString("ddd");
                }
                break;
                case GDFStatisticsConsolidateRange.Date:
                {
                    return tDateTime.ToString("dd");
                }
                break;
                case GDFStatisticsConsolidateRange.Hour:
                {
                    return tDateTime.ToString("HH");
                }
                break;
                case GDFStatisticsConsolidateRange.Month:
                {
                    return tDateTime.ToString("MM");
                }
                break;
                case GDFStatisticsConsolidateRange.Year:
                {
                    return tDateTime.ToString("yyyy");
                }
                break;
            }

            return result;
        }

        #endregion
    }
}