#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTimestamp.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides utility methods for working with timestamps.
    /// </summary>
    [Obsolete("Use GDFDatetime instead !")]
    public static class GDFTimestamp
    {
        #region Static methods

        /// <summary>
        ///     Return the timestamp from Unix 1970 January 01.
        /// </summary>
        /// <param name="sDateTime">The date and time value to convert to a timestamp.</param>
        /// <returns>The timestamp value representing the specified date and time.</returns>
        public static long Timestamp(DateTime sDateTime)
        {
            try
            {
                return ((DateTimeOffset)sDateTime).ToUnixTimeSeconds();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        ///     Return current timestamp from unix 1970 january 01.
        /// </summary>
        /// <returns>A long value representing the current timestamp.</returns>
        public static long Timestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        /// <summary>
        ///     Return timestamp milliseconds from unix 1970 january 01.
        /// </summary>
        /// <param name="sDateTime">The datetime value to convert to timestamp.</param>
        /// <returns>The timestamp in milliseconds.</returns>
        public static long TimestampMilliseconds(DateTime sDateTime)
        {
            return ((DateTimeOffset)sDateTime).ToUnixTimeMilliseconds();
        }

        /// <summary>
        ///     Return DateTime from timestamp in milliseconds since unix 1970 january 01.
        /// </summary>
        /// <param name="sTimeStampMilliseconds">The timestamp in milliseconds since unix 1970 january 01</param>
        /// <returns>The DateTime representation of the given timestamp</returns>
        public static DateTime TimeStampMillisecondsToDateTime(long sTimeStampMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(sTimeStampMilliseconds).DateTime;
        }

        /// <summary>
        ///     Return DateTime from timestamp unix 1970 january 01.
        /// </summary>
        /// <param name="sTimeStamp">The timestamp to convert to DateTime.</param>
        /// <returns>The DateTime converted from the timestamp.</returns>
        public static DateTime TimeStampToDateTime(long sTimeStamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(sTimeStamp).DateTime;
        }

        #endregion
    }
}