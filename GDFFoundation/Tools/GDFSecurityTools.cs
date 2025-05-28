#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFSecurityTools.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace GDFFoundation
{
    // TODO : separate in another file
    /// <summary>
    ///     Enumeration of SHA hashing algorithms supported by GDFSecurityTools.
    /// </summary>
    public enum GDFSecurityShaTypeEnum
    {
        /// <summary>
        ///     Enum member representing the SHA1 hashing algorithm for use in the GDFSecurityTools.GenerateSha method.
        /// </summary>
        Sha1,


        Sha256,

        /// <summary>
        ///     The SHA-512 hash algorithm.
        /// </summary>
        Sha512,
    }

    // TODO : separate in another file
    /// <summary>
    ///     The AES encryption algorithm types.
    /// </summary>
    public enum GDFSecurityAesTypeEnum
    {
        /// <summary>
        ///     Represents the AES 128 encryption algorithm.
        /// </summary>
        Aes128,
    }

    /// <summary>
    ///     Security tools, use for SHA, AES (crypt, decrypt) and Base64 (encode, decode)
    ///     All methods are static
    /// </summary>
    /// <example>
    ///     How to use:
    ///     <code>
    /// using GDFFoundation;
    /// string tEncoded = NWESecurityTools.Base64Encode("my string to encode!");
    /// </code>
    /// </example>
    public static class GDFSecurityTools
    {
        #region Static methods

        /// <summary>
        ///     Decode Base64 to string
        /// </summary>
        /// <param name="sBase64EncodedData">Base64 string</param>
        /// <returns>A string decoded</returns>
        public static string Base64Decode(string sBase64EncodedData)
        {
            var tBase64EncodedBytes = Convert.FromBase64String(sBase64EncodedData);
            return Encoding.UTF8.GetString(tBase64EncodedBytes);
        }

        /// <summary>
        ///     Encode string to Base64
        /// </summary>
        /// <param name="sPlainText">String to encode</param>
        /// <returns>A Base64 encoded string</returns>
        public static string Base64Encode(string sPlainText)
        {
            // TODO: verif if is that working?
            //sPlainText = UnityWebRequest.EscapeURL(sPlainText);
            //sPlainText = Uri.EscapeUriString(sPlainText); // obsolete
            sPlainText = Uri.EscapeDataString(sPlainText);
            var tPlainTextBytes = Encoding.UTF8.GetBytes(sPlainText); // convert to uft8 bt byte
            return Convert.ToBase64String(tPlainTextBytes, Base64FormattingOptions.None); // return the base64 text
        }

        /// <summary>
        ///     Compute the MD5 hash value of a given input string.
        /// </summary>
        /// <param name="sInput">The input string</param>
        /// <returns>The MD5 hash value as a string</returns>
        static string ComputeMd5(string sInput)
        {
            StringBuilder tStringBuilder = new StringBuilder();
            // Initialize a MD5 hash object
            using (MD5 tMd5 = MD5.Create())
            {
                // Compute the hash of the given string
                byte[] tHashValue = tMd5.ComputeHash(Encoding.UTF8.GetBytes(sInput));
                // Convert the byte array to string format
                foreach (byte b in tHashValue)
                {
                    tStringBuilder.Append($"{b:X2}");
                }
            }

            return tStringBuilder.ToString();
        }

        /// <summary>
        ///     Encrypts a string using AES encryption algorithm and returns the encrypted string in Base64 format.
        /// </summary>
        /// <param name="sText">The string to encrypt.</param>
        /// <param name="sKey">The encryption key.</param>
        /// <param name="sVector">The initialization vector.</param>
        /// <param name="sAes">Optional. The AES encryption type. Default is Aes128.</param>
        /// <returns>The encrypted string in Base64 format.</returns>
        public static string CryptAes(string sText, string sKey, string sVector, GDFSecurityAesTypeEnum sAes = GDFSecurityAesTypeEnum.Aes128)
        {
            string rParamB64 = string.Empty;
            if (string.IsNullOrEmpty(sText) == false)
            {
                // Set AES bits size
                Int32 tAesSize = 128;
                string tKey = KeyLengthFix(sKey, 24);
                string tVector = KeyLengthFix(sVector, 16);
                // Encrypt the string to an array of bytes.
                byte[] tEncrypted = InternalCryptAes(sText, Encoding.ASCII.GetBytes(tKey), Encoding.ASCII.GetBytes(tVector), tAesSize);
                // Encode parameters
                rParamB64 = Convert.ToBase64String(tEncrypted);
            }

            return rParamB64;
        }

        /// <summary>
        ///     Encrypts a string using the AES algorithm.
        /// </summary>
        /// <param name="sRescueToken">The string to encrypt.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sEnvironmentKind">The environment kind.</param>
        /// <param name="sSecretKeyManager">An implementation of the IGDFSecretKey interface to retrieve the secret key.</param>
        /// <param name="sProjectKeyManager">An implementation of the IGDFProjectKey interface to retrieve the project key.</param>
        /// <returns>The encrypted string.</returns>
        public static string CryptSomething(string sRescueToken, long sProjectReference, ProjectEnvironment sEnvironmentKind, IGDFSecretKey sSecretKeyManager, IGDFProjectKey sProjectKeyManager)
        {
            if (sSecretKeyManager != null && sProjectKeyManager != null)
            {
                return CryptAes(sRescueToken, sSecretKeyManager.GetSecretKey(sProjectReference, sEnvironmentKind),
                    sProjectKeyManager.GetProjectKey(sProjectReference, sEnvironmentKind));
            }
            else
            {
                return sRescueToken;
            }
        }

        /// <summary>
        ///     Decrypts a string using AES encryption.
        /// </summary>
        /// <param name="sText">The string to be decrypted.</param>
        /// <param name="sKey">The encryption key.</param>
        /// <param name="sVector">The initialization vector.</param>
        /// <param name="sAes">The AES encryption type (default: Aes128).</param>
        /// <returns>The decrypted string.</returns>
        public static string DecryptAes(string sText, string sKey, string sVector, GDFSecurityAesTypeEnum sAes = GDFSecurityAesTypeEnum.Aes128)
        {
            // Decode parameters
            if (string.IsNullOrEmpty(sText) == false)
            {
                // Set AES bits size
                Int32 tAesSize = 128;
                string tKey = KeyLengthFix(sKey, 24);
                string tVector = KeyLengthFix(sVector, 16);
                //Debug.Log("sText = " + sText);
                byte[] tEncrypted = Convert.FromBase64String(sText);
                // Decrypt the string to an array of bytes.
                return InternalDecryptAes(tEncrypted, Encoding.ASCII.GetBytes(tKey), Encoding.ASCII.GetBytes(tVector), tAesSize);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     Decrypts a string using AES encryption algorithm.
        /// </summary>
        /// <param name="sRescueTokenSecured">The encrypted string to decrypt</param>
        /// <param name="sProjectReference">The ID of the project</param>
        /// <param name="sEnvironmentKind">The environment kind</param>
        /// <param name="sSecretKeyManager">The secret key manager</param>
        /// <param name="sProjectKeyManager">The project key manager</param>
        /// <returns>The decrypted string or the original input if decryption fails or one of the managers is null</returns>
        public static string DecryptSomething(string sRescueTokenSecured, long sProjectReference, ProjectEnvironment sEnvironmentKind, IGDFSecretKey sSecretKeyManager, IGDFProjectKey sProjectKeyManager)
        {
            if (sSecretKeyManager != null && sProjectKeyManager != null)
            {
                string tReturn = DecryptAes(sRescueTokenSecured, sSecretKeyManager.GetSecretKey(sProjectReference, sEnvironmentKind), sProjectKeyManager.GetProjectKey(sProjectReference, sEnvironmentKind));
                if (string.IsNullOrEmpty(tReturn))
                {
                    return sRescueTokenSecured;
                }
                else
                {
                    return tReturn;
                }
            }
            else
            {
                return sRescueTokenSecured;
            }
        }

        /// <summary>
        ///     Generates a SHA hash for a given plaintext string.
        /// </summary>
        /// <param name="sPlainText">The string to generate the SHA hash for.</param>
        /// <param name="sSha">The SHA algorithm type to use (defaults to Sha1).</param>
        /// <returns>The SHA hash as a lowercase string.</returns>
        public static string GenerateSha(string sPlainText, GDFSecurityShaTypeEnum sSha = GDFSecurityShaTypeEnum.Sha1)
        {
            var tData = Encoding.ASCII.GetBytes(sPlainText);
            if (sSha == GDFSecurityShaTypeEnum.Sha1)
            {
                using (SHA1 tShaManager = SHA1.Create())
                {
                    byte[] tHash = tShaManager.ComputeHash(tData);
                    var tHashedInputStringBuilder = BitConverter.ToString(tHash);
                    return tHashedInputStringBuilder.Replace(GDFConstants.K_MINUS, string.Empty).ToLower();
                }
            }
            else if (sSha == GDFSecurityShaTypeEnum.Sha256)
            {
                using (SHA256 tShaManager = SHA256.Create())
                {
                    byte[] tHash = tShaManager.ComputeHash(tData);
                    var tHashedInputStringBuilder = BitConverter.ToString(tHash);
                    return tHashedInputStringBuilder.Replace(GDFConstants.K_MINUS, string.Empty).ToLower();
                }
            }
            else
            {
                using (SHA512 tShaManager = SHA512.Create())
                {
                    byte[] tHash = tShaManager.ComputeHash(tData);
                    var tHashedInputStringBuilder = BitConverter.ToString(tHash);
                    return tHashedInputStringBuilder.Replace(GDFConstants.K_MINUS, string.Empty).ToLower();
                }
            }
        }

        /// <summary>
        ///     Computes the MD5 hash value of an input string and returns it as a hexadecimal string.
        /// </summary>
        /// <param name="sInput">The input string to hash</param>
        /// <returns>The MD5 hash value as a hexadecimal string</returns>
        public static string HashMd5(string sInput)
        {
            using (MD5 tMd5 = MD5.Create())
            {
                return BitConverter.ToString(tMd5.ComputeHash(Encoding.UTF8.GetBytes(sInput)))
                    .Replace("-", "");
            }
        }

        /// <summary>
        ///     Generate AES
        /// </summary>
        /// <param name="sPlainText">string Text</param>
        /// <param name="sKey">array byte Key</param>
        /// <param name="sIv">array byte Vector Key</param>
        /// <param name="sAesSize">AES size</param>
        /// <returns>A new array byte crypt from sPlainText using sKey, sIV and sAesSize</returns>
        private static byte[] InternalCryptAes(string sPlainText, byte[] sKey, byte[] sIv, Int32 sAesSize)
        {
            // Check arguments.
            if (sPlainText == null || sPlainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sPlainText));
            }

            if (sKey == null || sKey.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sKey));
            }

            if (sIv == null || sIv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sIv));
            }

            byte[] rEncrypted;
            using (Aes tAes = Aes.Create())
            {
                tAes.Mode = CipherMode.ECB;
                tAes.Padding = PaddingMode.PKCS7;
                tAes.KeySize = sAesSize;
                tAes.BlockSize = sAesSize;
                tAes.Key = sKey;
                tAes.IV = sIv;
                // Create a encrypt operator to perform the stream transform.
                ICryptoTransform tEncryptOperator = tAes.CreateEncryptor(tAes.Key, tAes.IV);
                // Create the streams used for encryption.
                using (MemoryStream tMsEncrypt = new MemoryStream())
                {
                    using (CryptoStream tCsEncrypt = new CryptoStream(tMsEncrypt, tEncryptOperator, CryptoStreamMode.Write))
                    {
                        using (StreamWriter tSwEncrypt = new StreamWriter(tCsEncrypt))
                        {
                            // Write all data to the stream.
                            tSwEncrypt.Write(sPlainText);
                        }

                        rEncrypted = tMsEncrypt.ToArray();
                    }
                }
            }

            return rEncrypted;
        }

        /// <summary>
        ///     Decrypt AES
        /// </summary>
        /// <param name="sPlainText">The plain text as byte array</param>
        /// <param name="sKey">The key as byte array</param>
        /// <param name="sIv">The initialization vector as byte array</param>
        /// <param name="sAesSize">The size of the AES in bits</param>
        /// <returns>A new string decrypted from sPlainText using sKey, sIV and sAesSize</returns>
        private static string InternalDecryptAes(byte[] sPlainText, byte[] sKey, byte[] sIv, Int32 sAesSize)
        {
            // Check arguments.
            if (sPlainText == null || sPlainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sPlainText));
            }

            if (sKey == null || sKey.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sKey));
            }

            if (sIv == null || sIv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(sIv));
            }

            string rDecrypt = null;
            try
            {
                using (Aes tAes = Aes.Create())
                {
                    tAes.Mode = CipherMode.ECB;
                    tAes.Padding = PaddingMode.PKCS7;
                    tAes.KeySize = sAesSize;
                    tAes.BlockSize = sAesSize;
                    tAes.Key = sKey;
                    tAes.IV = sIv;
                    // Create a decrypt operator to perform the stream transform.
                    ICryptoTransform tDecryptOperator = tAes.CreateDecryptor(tAes.Key, tAes.IV);
                    // Create the streams used for decryption.
                    using (MemoryStream tMsDecrypt = new MemoryStream(sPlainText))
                    {
                        using (CryptoStream tCsDecrypt = new CryptoStream(tMsDecrypt, tDecryptOperator, CryptoStreamMode.Read))
                        {
                            using (StreamReader tSrDecrypt = new StreamReader(tCsDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                rDecrypt = tSrDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception tException)
            {
                GDFLogger.Critical(tException.ToString());
            }

            return rDecrypt;
        }

        /// <summary>
        ///     Fixes the length of a key by padding it with 'A' characters if necessary.
        /// </summary>
        /// <param name="sKey">The key to fix the length of.</param>
        /// <param name="sSize">The desired size of the key.</param>
        /// <returns>The fixed-length key.</returns>
        private static string KeyLengthFix(string sKey, int sSize)
        {
            string rReturn;
            if (string.IsNullOrEmpty(sKey))
            {
                sKey = string.Empty;
            }

            if (sKey.Length == sSize)
            {
                rReturn = sKey;
            }
            else if (sKey.Length > sSize)
            {
                rReturn = sKey.Substring(0, sSize);
            }
            else
            {
                rReturn = sKey;
                while (rReturn.Length < sSize)
                {
                    rReturn = rReturn + "A";
                }
            }

            return rReturn;
        }

        #endregion
    }
}