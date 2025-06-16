#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDatetime.cs create at 2025/04/08 15:04:53
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Globalization;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides utility methods for working with <see cref="DateTime" />.
    /// </summary>
    public static class GDFDatetime
    {
        #region Constants

        private const string _ISO_8601_FORMAT = "yyyy-MM-dd HH:mm:ss.ffffff";

        #endregion

        #region Static fields and properties

        /// <summary>
        ///     Get the current GDF <see cref="DateTime" />.
        /// </summary>
        static public DateTime Now => DateTime.UtcNow;
        static public string NowISO => ToISO(Now);

        #endregion

        #region Static methods

        /// <summary>
        ///     Convert a GDF <see cref="DateTime" /> to a local <see cref="DateTime" />.
        /// </summary>
        /// <param name="gdfDateTime">The GDF <see cref="DateTime" />.</param>
        /// <returns>The local <see cref="DateTime" />.</returns>
        static public DateTime Convert(DateTime gdfDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(gdfDateTime, TimeZoneInfo.Local);
        }

        /// <summary>
        ///     Converts an ISO 8601 string into a valid <see cref="DateTime" />.
        /// </summary>
        /// <param name="iso8601">The ISO 8601 formated string.</param>
        /// <returns>The resulting <see cref="DateTime" />.</returns>
        static public DateTime FromISO(string iso8601)
        {
            return DateTime.ParseExact(iso8601, _ISO_8601_FORMAT, CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Converts a <see cref="DateTime" /> into a valid ISO 8601 string.
        /// </summary>
        /// <param name="iso8601">The <see cref="DateTime" />.</param>
        /// <returns>The resulting ISO 8601 formated string.</returns>
        static public string ToISO(DateTime dateTime)
        {
            return dateTime.ToString(_ISO_8601_FORMAT);
        }

        /// <inheritdoc cref="ToISO" />
        static public string ToISO8601(this DateTime dateTime)
        {
            return ToISO(dateTime);
        }

        #endregion
    }
}