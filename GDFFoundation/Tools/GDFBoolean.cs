


namespace GDFFoundation
{
    /// <summary>
    /// Provides extension methods for converting a boolean value to a string representation.
    /// </summary>
    public static class GDFBoolean
    {
        /// <summary>
        /// Converts a boolean value to a string representation of "Yes" or "No".
        /// </summary>
        /// <param name="sValue">The boolean value to convert.</param>
        /// <returns>The string representation of the boolean value as "Yes" if true, and "No" if false.</returns>
        public static string ToYesNoString(this bool sValue)
        {
            return sValue ? "Yes" : "No";
        }

        /// <summary>
        /// Converts a boolean value to a string representation of "0" or "1".
        /// </summary>
        /// <param name="sValue">The boolean value to be converted.</param>
        /// <returns>A string representation of "0" if the value is false, or "1" if the value is true.</returns>
        public static string To01String(this bool sValue)
        {
            return sValue ? "1" : "0";
        }
    }
}

