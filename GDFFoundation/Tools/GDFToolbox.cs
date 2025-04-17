

namespace GDFFoundation
{
    /// <summary>
    /// A collection of utility methods for various operations.
    /// </summary>
    public partial class GDFToolbox
    {
        /// <summary>
        /// Base64 encodes a string.
        /// </summary>
        /// <param name="sText">The string to encode.</param>
        /// <returns>The encoded string.</returns>
        public static string Base64Encode(string sText)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sText));
        }

        /// <summary>
        /// Decodes a Base64 encoded string.
        /// </summary>
        /// <param name="sBase64EncodedData">The Base64 encoded string to decode.</param>
        /// <returns>The decoded string.</returns>
        public static string Base64Decode(string sBase64EncodedData)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(sBase64EncodedData));
        }

        /// <summary>
        /// Converts a byte size into a human-readable format.
        /// </summary>
        /// <param name="sByteSize">The byte size to convert.</param>
        /// <returns>A string representing the converted byte size in a human-readable format.</returns>
        public static string MemorySize(long sByteSize)
        {
            string rResult;

            if (sByteSize > 1000000000000)
            {
                rResult = ((double)sByteSize / 1000000000000).ToString("#.##") + " TB";
            }
            else if (sByteSize > 1000000000)
            {
                rResult = ((double)sByteSize / 1000000000).ToString("#.##") + " GB";
            }
            else if (sByteSize > 1000000)
            {
                rResult = ((double)sByteSize / 1000000).ToString("#.##") + " MB";
            }
            else if (sByteSize > 1000)
            {
                rResult = ((double)sByteSize / 1000).ToString("#.##") + " KB";
            }
            else
            {
                rResult = sByteSize + " B";
            }
            return rResult;
        }
    }
}

