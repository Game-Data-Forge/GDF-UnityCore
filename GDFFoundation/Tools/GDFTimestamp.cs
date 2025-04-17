

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Provides utility methods for working with timestamps.
    /// </summary>
    [Obsolete("Use GDFDatetime instead !")]
    public static class GDFTimestamp
    {
        /// <summary>
        /// Return the timestamp from Unix 1970 January 01.
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
        /// Return timestamp milliseconds from unix 1970 january 01.
        /// </summary>
        /// <param name="sDateTime">The datetime value to convert to timestamp.</param>
        /// <returns>The timestamp in milliseconds.</returns>
        public static long TimestampMilliseconds(DateTime sDateTime)
        {
            return ((DateTimeOffset)sDateTime).ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Return current timestamp from unix 1970 january 01.
        /// </summary>
        /// <returns>A long value representing the current timestamp.</returns>
        public static long Timestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Return DateTime from timestamp unix 1970 january 01.
        /// </summary>
        /// <param name="sTimeStamp">The timestamp to convert to DateTime.</param>
        /// <returns>The DateTime converted from the timestamp.</returns>
        public static DateTime TimeStampToDateTime(long sTimeStamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(sTimeStamp).DateTime;
        }

        /// <summary>
        /// Return DateTime from timestamp in milliseconds since unix 1970 january 01.
        /// </summary>
        /// <param name="sTimeStampMilliseconds">The timestamp in milliseconds since unix 1970 january 01</param>
        /// <returns>The DateTime representation of the given timestamp</returns>
        public static DateTime TimeStampMillisecondsToDateTime(long sTimeStampMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(sTimeStampMilliseconds).DateTime;
        }
    }
}

