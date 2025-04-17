

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GDFFoundation
{
    /// <summary>
    /// The GDFStringCleaner class provides several static methods to clean and manipulate strings.
    /// </summary>
    public static class GDFStringCleaner
    {
        /// <summary>
        /// Remove diacritics from a string.
        /// </summary>
        /// <param name="sText">The input string.</param>
        /// <returns>The string without diacritics.</returns>
        public static string RemoveDiacritics(string sText)
        {
            string rReturn = string.Empty;
            if (string.IsNullOrWhiteSpace(sText))
            {
                rReturn = sText;
            }
            else
            {
                sText = sText.Normalize(NormalizationForm.FormD);
                var chars = sText.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
                rReturn = new string(chars).Normalize(NormalizationForm.FormC);
                rReturn = AplhaNumericCleaner(rReturn);
            }
            return rReturn;
        }

        /// <summary>
        /// Cleans the DNS server address by stripping unnecessary characters and protocols.
        /// </summary>
        /// <returns>The cleaned DNS server address.</returns>
        /// <param name="sServerDNS">The DNS server address to clean.</param>
        public static string CleanDNS(string sServerDNS)
        {
            string rServerDNS = sServerDNS;

            if (string.IsNullOrEmpty(sServerDNS) == false)
            {
                rServerDNS = rServerDNS.TrimEnd('/');
                if (rServerDNS.StartsWith("https://", StringComparison.Ordinal))
                {
                    rServerDNS = rServerDNS.Substring("https://".Length);
                }
                if (rServerDNS.StartsWith("http://", StringComparison.Ordinal))
                {
                    rServerDNS = rServerDNS.Substring("http://".Length);
                }
                if (rServerDNS.StartsWith("http://", StringComparison.Ordinal))
                {
                    rServerDNS = rServerDNS.Substring("http://".Length);
                }
            }
            return rServerDNS;
        }

        /// <summary>
        /// Remove the separator characters from the given text.
        /// </summary>
        /// <param name="sText">The text from which to remove the separator characters.</param>
        /// <returns>The text with separator characters removed.</returns>
        public static string TextRemoveSeparator(string sText)
        {
            string rText = sText;
            if (string.IsNullOrEmpty(sText) == false)
            {
                rText = rText.Replace(GDFConstants.kFieldSeparatorA, string.Empty);
                rText = rText.Replace(GDFConstants.kFieldSeparatorB, string.Empty);
                rText = rText.Replace(GDFConstants.kFieldSeparatorC, string.Empty);
                // new adds
                rText = rText.Replace(GDFConstants.kFieldSeparatorD, string.Empty);
                rText = rText.Replace(GDFConstants.kFieldSeparatorE, string.Empty);
            }
            return rText;
        }

        /// <summary>
        /// Protects the input text by replacing occurrences of specific field separator characters with their substituted values.
        /// </summary>
        /// <param name="sText">The input text to be protected.</param>
        /// <returns>The protected text with replaced field separator characters.</returns>
        public static string TextProtect(string sText)
        {
            string rText = sText;
            if (string.IsNullOrEmpty(sText) == false)
            {
                rText = rText.Replace(GDFConstants.kFieldSeparatorA, GDFConstants.kFieldSeparatorASubstitute);
                rText = rText.Replace(GDFConstants.kFieldSeparatorB, GDFConstants.kFieldSeparatorBSubstitute);
                rText = rText.Replace(GDFConstants.kFieldSeparatorC, GDFConstants.kFieldSeparatorCSubstitute);
                // new adds
                rText = rText.Replace(GDFConstants.kFieldSeparatorD, GDFConstants.kFieldSeparatorDSubstitute);
                rText = rText.Replace(GDFConstants.kFieldSeparatorE, GDFConstants.kFieldSeparatorESubstitute);
            }
            return rText;
        }

        /// <summary>
        /// Unprotect the text for the separator usage.
        /// </summary>
        /// <returns>The unprotect text.</returns>
        /// <param name="sText">The text to be unprotected.</param>
        public static string TextUnprotect(string sText)
        {
            string rText = sText;
            if (string.IsNullOrEmpty(sText) == false)
            {
                rText = rText.Replace(GDFConstants.kFieldSeparatorASubstitute, GDFConstants.kFieldSeparatorA);
                rText = rText.Replace(GDFConstants.kFieldSeparatorBSubstitute, GDFConstants.kFieldSeparatorB);
                rText = rText.Replace(GDFConstants.kFieldSeparatorCSubstitute, GDFConstants.kFieldSeparatorC);
                // new adds
                rText = rText.Replace(GDFConstants.kFieldSeparatorDSubstitute, GDFConstants.kFieldSeparatorD);
                rText = rText.Replace(GDFConstants.kFieldSeparatorESubstitute, GDFConstants.kFieldSeparatorE);
            }
            return rText;
        }

        /// <summary>
        /// Protects the text for CSV export.
        /// </summary>
        /// <param name="sText">The text to be protected.</param>
        /// <returns>The protected text.</returns>
        public static string TextCSVProtect(string sText)
        {
            string rText = sText;
            rText = rText.Replace(GDFConstants.kStandardSeparator, GDFConstants.kStandardSeparatorSubstitute);

            return rText;
        }

        /// <summary>
        /// Unprotect the text from CSV import.
        /// </summary>
        /// <returns>The unprotected text.</returns>
        /// <param name="sText">The text to unprotect.</param>
        public static string TextCSVUnprotect(string sText)
        {
            string rText = sText;
            rText = rText.Replace(GDFConstants.kStandardSeparatorSubstitute, GDFConstants.kStandardSeparator);
            return rText;
        }

        /// <summary>
        /// Convert the boolean value to a numerical string.
        /// Returns "0" if the boolean value is false, "1" if the boolean value is true.
        /// </summary>
        /// <param name="sBoolean">The boolean value to be converted.</param>
        /// <returns>The numerical string representing the boolean value.</returns>
        public static string BoolToNumericalString(bool sBoolean)
        {
            if (sBoolean == false)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        /// <summary>
        /// Class for cleaning and manipulating URLs.
        /// </summary>
        private static readonly  Regex URLCleanerRgx = new Regex("[^a-zA-Z0-9-_\\:\\/\\.]", RegexOptions.Compiled);

        /// <summary>
        /// Removes invalid characters from a URL string.
        /// </summary>
        /// <param name="sString">The URL string to clean.</param>
        /// <returns>A cleaned URL string.</returns>
        public static string URLCleaner(string sString)
        {
            return URLCleanerRgx.Replace(sString, string.Empty);
        }

        /// <summary>
        /// Class containing regular expression for cleaning email strings.
        /// </summary>
        private static readonly  Regex EmailCleanerRgx = new Regex("[^a-zA-Z0-9-_@\\.]", RegexOptions.Compiled);

        /// <summary>
        /// Remove any characters from the input string that are not letters (a-z, A-Z), digits (0-9), underscore (_), hyphen (-), at symbol (@), or period (.).
        /// </summary>
        /// <param name="sString">The input string.</param>
        /// <returns>The cleaned email.</returns>
        public static string EmailCleaner(string sString)
        {
            return EmailCleanerRgx.Replace(sString, string.Empty);
        }

        /// <summary>
        /// Regular expression for removing non-alphanumeric characters from strings for Unix.
        /// </summary>
        private static readonly Regex UnixCleanerRgx = new Regex("[^a-zA-Z0-9_]", RegexOptions.Compiled);

        /// <summary>
        /// Remove Unix specific characters from a string
        /// </summary>
        /// <returns>The cleaned string.</returns>
        /// <param name="sString">The input string</param>
        public static string UnixCleaner(string sString)
        {
            if (sString != null)
            {
                return UnixCleanerRgx.Replace(sString, string.Empty);
            }
            else
            {
                return string.Empty;
            }
        }
        

        private static readonly Regex SpaceCleanerRgx = new Regex(@"\s+", RegexOptions.Compiled);

        public static string SpaceCleaner(string sString)
        {
            return SpaceCleanerRgx.Replace(sString, string.Empty);
        }

        /// <summary>
        /// Regular expression for removing non-alphabetic characters.
        /// </summary>
        private static readonly  Regex AplhaCleanerRgx = new Regex("[^a-zA-Z]", RegexOptions.Compiled);

        /// <summary>
        /// Remove all non-alphabetic characters from a given string.
        /// </summary>
        /// <param name="sString">The input string.</param>
        /// <returns>The string with all non-alphabetic characters removed.</returns>
        public static string AplhaCleaner(string sString)
        {
            return AplhaCleanerRgx.Replace(sString, string.Empty);
        }

        /// <summary>
        /// Class containing methods for cleaning strings of non-alphanumeric characters.
        /// </summary>
        private static readonly  Regex AplhaNumericCleanerRgx = new Regex("[^a-zA-Z0-9]", RegexOptions.Compiled);

        /// <summary>
        /// Remove all non-alphanumeric characters from a given string.
        /// </summary>
        /// <param name="sString">The string to clean.</param>
        /// <returns>The cleaned string without any non-alphanumeric characters.</returns>
        public static string AplhaNumericCleaner(string sString)
        {
            return AplhaNumericCleanerRgx.Replace(sString, string.Empty);
        }

        /// <summary>
        /// Regex pattern for converting alphanumeric characters to numeric characters.
        /// </summary>
        private static readonly  Regex AplhaNumericToNumericRgx = new Regex("[^a-zA-Z0-9]", RegexOptions.Compiled);

        /// <summary>
        /// Converts an alphanumeric string to a numeric string.
        /// </summary>
        /// <param name="sString">The alphanumeric string to convert.</param>
        /// <returns>The numeric string.</returns>
        public static string AplhaNumericToNumeric(string sString)
        {
            string rReturn = AplhaNumericToNumericRgx.Replace(sString, string.Empty).ToUpper();
            rReturn = rReturn.Replace("A", "1");
            rReturn = rReturn.Replace("B", "2");
            rReturn = rReturn.Replace("C", "7");
            rReturn = rReturn.Replace("D", "8");
            rReturn = rReturn.Replace("E", "5");
            rReturn = rReturn.Replace("F", "4");
            rReturn = rReturn.Replace("G", "6");
            rReturn = rReturn.Replace("H", "9");
            rReturn = rReturn.Replace("I", "1");
            rReturn = rReturn.Replace("J", "4");
            rReturn = rReturn.Replace("K", "3");
            rReturn = rReturn.Replace("L", "5");
            rReturn = rReturn.Replace("M", "7");
            rReturn = rReturn.Replace("N", "8");
            rReturn = rReturn.Replace("O", "6");
            rReturn = rReturn.Replace("P", "5");
            rReturn = rReturn.Replace("Q", "6");
            rReturn = rReturn.Replace("R", "4");
            rReturn = rReturn.Replace("S", "9");
            rReturn = rReturn.Replace("T", "4");
            rReturn = rReturn.Replace("U", "1");
            rReturn = rReturn.Replace("V", "1");
            rReturn = rReturn.Replace("W", "4");
            rReturn = rReturn.Replace("X", "9");
            rReturn = rReturn.Replace("Y", "1");
            rReturn = rReturn.Replace("Z", "9");
            return rReturn;
        }

        /// <summary>
        /// Regular expression used to remove characters that are not letters, numbers, spaces, and certain special characters in a given string.
        /// </summary>
        /// <remarks>
        /// The SaltCleanerRgx regular expression is used by the SaltCleaner method to remove unwanted characters from the input string.
        /// </remarks>
        private static readonly  Regex SaltCleanerRgx = new Regex("[^a-zA-Z0-9 -_\\(\\)\\[\\]\\,\\;\\:\\!\\.]", RegexOptions.Compiled);

        /// <summary>
        /// Clean a string by removing any characters that are not letters, numbers, spaces, dashes, underscores, parentheses, square brackets, commas, semicolons, colons, exclamation marks or periods.
        /// </summary>
        /// <returns>
        /// The cleaned string.
        /// </returns>
        /// <param name="sString">The string to clean.</param>
        public static string SaltCleaner(string sString)
        {
            //GDFBenchmark.Start();
            string rReturn = SaltCleanerRgx.Replace(sString, string.Empty);
            //GDFBenchmark.Finish();
            return rReturn;
        }

        /// <summary>
        /// Splits the string by Camel Case format.
        /// </summary>
        /// <returns>The camel case.</returns>
        /// <param name="input">The string to be split. </param>
        public static string SplitCamelCase(string input)
        {
            string rReturn = Regex.Replace(input, "([A-Z])", " $1", RegexOptions.ECMAScript).Trim();
            rReturn = rReturn.Replace("_", string.Empty);
            return rReturn;
        }

        /// <summary>
        /// Replaces the Unix newline ("\r\n") with the Unix newline ("\n").
        /// </summary>
        /// <param name="sString">The string to fix.</param>
        /// <returns>The fixed string.</returns>
        public static string NewLineUnixFix(string sString)
        {
            return sString.Replace("\r\n", "\n");
        }

        /// <summary>
        /// Formats the given C# code by adding appropriate indentation.
        /// </summary>
        /// <param name="sString">The C# code to be formatted.</param>
        /// <returns>The formatted C# code.</returns>
        public static string CSharpFormat(string sString)
        {
            //GDFBenchmark.Start();
            StringBuilder rReturn = new StringBuilder();
            int tIndentCount = 0;
            string tString = NewLineUnixFix(sString);
            string[] tLines = tString.Split(new string[] { "\n", "\r" }, StringSplitOptions.None);
            foreach (string tLine in tLines)
            {
                if (tLine.Contains("{"))
                {
                    tIndentCount++;
                }
                if (tLine.Contains("}"))
                {
                    tIndentCount--;
                }
                for (int i = 0; i < tIndentCount; i++)
                {
                    rReturn.Append("\t");
                }
                //rReturn.Append(tLine.Replace("\t",""));
                rReturn.Append(tLine);
                rReturn.Append(GDFConstants.K_ReturnLine);
                if (tLine.Contains("{"))
                {
                    tIndentCount++;
                }
                if (tLine.Contains("}"))
                {
                    tIndentCount--;
                }
            }
            //GDFBenchmark.Finish();
            return rReturn.ToString().TrimEnd(new char[] { '\n', '\r' });
        }
    }
}

