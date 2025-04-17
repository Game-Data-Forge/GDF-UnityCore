using System;
using System.Globalization;

namespace GDFFoundation
{
    /// <summary>
    /// Provides utility methods for working with <see cref="DateTime"/>.
    /// </summary>
    public static class GDFDatetime
    {
        private const string _ISO_8601_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
        /// <summary>
        /// Get the current GDF <see cref="DateTime"/>.
        /// </summary>
        static public DateTime Now => DateTime.UtcNow;

        /// <summary>
        /// Convert a GDF <see cref="DateTime"/> to a local <see cref="DateTime"/>.
        /// </summary>
        /// <param name="gdfDateTime">The GDF <see cref="DateTime"/>.</param>
        /// <returns>The local <see cref="DateTime"/>.</returns>
        static public DateTime Convert(DateTime gdfDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(gdfDateTime, TimeZoneInfo.Local);
        }

        /// <summary>
        /// Converts an ISO 8601 string into a valid <see cref="DateTime"/>.
        /// </summary>
        /// <param name="iso8601">The ISO 8601 formated string.</param>
        /// <returns>The resulting <see cref="DateTime"/>.</returns>
        static public DateTime FromISO(string iso8601)
        {
            return DateTime.ParseExact(iso8601, _ISO_8601_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> into a valid ISO 8601 string.
        /// </summary>
        /// <param name="iso8601">The <see cref="DateTime"/>.</param>
        /// <returns>The resulting ISO 8601 formated string.</returns>
        static public string ToISO(DateTime dateTime)
        {
            return dateTime.ToString(_ISO_8601_FORMAT);
        }

        /// <inheritdoc cref="ToISO"/>
        static public string ToISO8601(this DateTime dateTime)
        {
            return ToISO(dateTime);
        }
    }
}

