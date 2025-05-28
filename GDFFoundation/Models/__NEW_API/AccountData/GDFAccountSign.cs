#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountSign.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class SignListExchange : IApiResult
    {
        #region Instance fields and properties

        public List<GDFAccountSign> Signs { get; set; }

        #region From interface IApiResult

        public string Status { get; set; }
        public bool Success { get; set; }

        #endregion

        #endregion
    }

    /// <summary>
    ///     Represents an account sign information.
    /// </summary>
    [Serializable]
    public class GDFAccountSign : GDFAccountData
    {
        #region Static methods

        public static bool CheckChannel(short channel)
        {
            if (channel < GDFConstants.K_CHANNEL_MIN)
            {
                throw new FormatException($"The field `{nameof(ISignChannel.Channel)}` must be a positive integer.");
            }

            if (channel > GDFConstants.K_CHANNEL_MAX)
            {
                throw new FormatException($"The field `{nameof(ISignChannel.Channel)}` must lower than 99.");
            }

            return true;
        }

        public static bool CheckDeviceIdentifier(string identifier)
        {
            if (identifier.Length < GDFConstants.K_DEVICE_IDENTIFIER_LENGTH_MIN)
            {
                throw new FormatException($"The field `{nameof(IDeviceSign.UniqueIdentifier)}` is too short.");
            }

            return true;
        }

        public static bool CheckEmail(string email)
        {
            if (email.Length < GDFConstants.K_EMAIL_LENGTH_MIN)
            {
                throw new FormatException($"The field `{nameof(IEmailSign.Email)}` is too short.");
            }

            if (email.Length > GDFConstants.K_EMAIL_LENGTH_MAX)
            {
                throw new FormatException($"The field `{nameof(IEmailSign.Email)}` is too long.");
            }

            if (!Regex.IsMatch(email, GDFConstants.K_EMAIL_EREG_PATTERN))
            {
                throw new FormatException($"The field `{nameof(IEmailSign.Email)}` is not a valid email address.");
            }

            return true;
        }

        public static bool CheckLogin(string login)
        {
            if (login.Length < GDFConstants.K_LOGIN_LENGTH_MIN)
            {
                throw new FormatException($"The field `login` is too short.");
            }

            if (login.Length > GDFConstants.K_LOGIN_LENGTH_MAX)
            {
                throw new FormatException($"The field `login` is too long.");
            }

            return true;
        }

        public static bool CheckOAuthAccessToken(string oAuthAccessToken)
        {
            if (oAuthAccessToken.Length < GDFConstants.K_O_AUTH_ACCESS_TOKEN_LENGTH_MIN)
            {
                throw new FormatException($"The field `{nameof(IOAuthSign.AccessToken)}` is too short.");
            }

            return true;
        }

        public static bool CheckOAuthKind(GDFOAuthKind oAuthKind)
        {
            if (oAuthKind == GDFOAuthKind.None)
            {
                throw new FormatException();
            }

            return true;
        }

        public static bool CheckPassword(string password)
        {
            if (password.Length < GDFConstants.K_PASSWORD_LENGTH_MIN)
            {
                throw new FormatException($"The field `{nameof(IPasswordSign.Password)}` is too short.");
            }

            if (password.Length > GDFConstants.K_PASSWORD_LENGTH_MAX)
            {
                throw new FormatException($"The field `{nameof(IPasswordSign.Password)}` is too long.");
            }

            if (!Regex.IsMatch(password, GDFConstants.K_PASSWORD_EREG_PATTERN))
            {
                throw new FormatException($"The field `{nameof(IPasswordSign.Password)}` must constaint {GDFConstants.K_PASSWORD_REQUIRE}");
            }

            return true;
        }

        public static bool CheckProject(long project)
        {
            if (project < 1)
            {
                throw new FormatException();
                return false;
            }

            return true;
        }


        /// <summary>
        ///     Creates a device sign using the specified device type, unique identifier, and project reference.
        /// </summary>
        /// <param name="deviceKind">The type of the device (e.g., iOS, Android, etc.).</param>
        /// <param name="uniqueIdentifier">The unique identifier (UDID) of the device.</param>
        /// <param name="projectReference">The ID of the project associated with the device.</param>
        /// <returns>A GDFAccountSign instance containing the generated device sign information.</returns>
        public static GDFAccountSign CreateDeviceSign(string uniqueIdentifier, long projectReference)
        {
            CheckDeviceIdentifier(uniqueIdentifier);
            CheckProject(projectReference);

            GDFAccountSign result = new GDFAccountSign();
            result.Project = projectReference;
            result.SignType = GDFAccountSignType.DeviceId;
            result.Name = GDFSecurityTools.CryptAes(result.SignType.ToString(), projectReference.ToString(), projectReference.ToString());
            string typeObfuscation = DeviceTypeObfuscation(result.SignType);
            result.SignHash = typeObfuscation + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier + projectReference) + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier);
            result.RescueHash = result.SignHash;
            return result;
        }

        /// <summary>
        ///     Create a sign with email and password
        /// </summary>
        /// <param name="email">The email address for the account</param>
        /// <param name="password">The password for the account</param>
        /// <param name="projectReference">The project ID</param>
        /// <returns>A new instance of GDFAccountSign with the specified email, password, and project ID</returns>
        public static GDFAccountSign CreateEmailPassword(string email, string password, long projectReference)
        {
            CheckProject(projectReference);
            CheckEmail(email);
            CheckPassword(password);
            GDFAccountSign rReturn = new GDFAccountSign();
            rReturn.Project = projectReference;
            rReturn.Name = GDFSecurityTools.CryptAes(EmailToPartialString(email), projectReference.ToString(), projectReference.ToString());
            string tType = DeviceTypeObfuscation(rReturn.SignType);
            rReturn.SignType = GDFAccountSignType.EmailPassword;
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(email + password + projectReference) + "-" + GDFSecurityTools.GenerateSha(password + email);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(email + projectReference) + "-" + GDFSecurityTools.GenerateSha(email);
            return rReturn;
        }

        /// <summary>
        ///     Creates an OAuth-based account sign object with the specified authentication kind, user identifier, and project reference.
        /// </summary>
        /// <param name="authKind">The type of OAuth provider used for authentication.</param>
        /// <param name="userIdentifier">The identifier of the user, typically provided by the OAuth service.</param>
        /// <param name="projectReference">The project reference key used to associate the account sign with a specific project.</param>
        /// <returns>A newly created <see cref="GDFAccountSign" /> object configured with the provided details.</returns>
        public static GDFAccountSign CreateOAuthSign(GDFOAuthKind authKind, string userIdentifier, long projectReference)
        {
            CheckProject(projectReference);
            CheckOAuthAccessToken(userIdentifier);
            CheckOAuthKind(authKind);
            GDFAccountSign result = new GDFAccountSign();
            result.Project = projectReference;
            result.SignType = (GDFAccountSignType)authKind;
            result.Name = GDFSecurityTools.CryptAes(result.SignType.ToString(), projectReference.ToString(), projectReference.ToString());
            string signKind = DeviceTypeObfuscation(result.SignType);
            result.SignHash = signKind + "-" + GDFSecurityTools.GenerateSha(userIdentifier + projectReference) + "-" + GDFSecurityTools.GenerateSha(userIdentifier);
            result.RescueHash = result.SignHash;
            return result;
        }

        /// <summary>
        ///     Obfuscates the device type based on the given sign type.
        /// </summary>
        /// <param name="sType">The sign type to obfuscate.</param>
        /// <returns>The obfuscated device type sign.</returns>
        private static string DeviceTypeObfuscation(GDFAccountSignType sType)
        {
            string rResult = "";

            switch (sType)
            {
                case GDFAccountSignType.EmailPassword:
                    rResult = "A";
                break;
                case GDFAccountSignType.DeviceId:
                    rResult = "D";
                break;
                case GDFAccountSignType.Facebook:
                    rResult = "E";
                break;
                case GDFAccountSignType.Google:
                    rResult = "F";
                break;
                case GDFAccountSignType.Apple:
                    rResult = "G";
                break;
                case GDFAccountSignType.Microsoft:
                    rResult = "H";
                break;
                case GDFAccountSignType.Twitter:
                    rResult = "I";
                break;
                case GDFAccountSignType.LinkedIn:
                    rResult = "J";
                break;
                case GDFAccountSignType.Discord:
                    rResult = "K";
                break;
                default:
                break;
            }

            return rResult;
        }


        /// <summary>
        ///     Converts the original email address to a partially masked string.
        /// </summary>
        /// <param name="sOriginalEmail">The original email address.</param>
        /// <returns>A partially masked string representation of the email address.</returns>
        public static string EmailToPartialString(string sOriginalEmail)
        {
            StringBuilder rReturn = new StringBuilder();

            if (sOriginalEmail.Length > 6)
            {
                rReturn.Append(sOriginalEmail[0]);
                rReturn.Append(sOriginalEmail[1]);
                for (int t = 2; t < sOriginalEmail.Length - 2; t++)
                {
                    if (sOriginalEmail[t] == '@')
                    {
                        rReturn.Append("@");
                    }
                    else if (sOriginalEmail[t] == ' ')
                    {
                        // It's a login email password case ... 
                        rReturn.Append(" / ");
                        if (sOriginalEmail.Length >= t + 4)
                        {
                            t++;
                            rReturn.Append(sOriginalEmail[t]);
                            t++;
                            rReturn.Append(sOriginalEmail[t]);
                        }
                    }
                    else if (sOriginalEmail[t] == '.')
                    {
                        rReturn.Append(".");
                    }
                    else
                    {
                        rReturn.Append("•");
                    }
                }

                rReturn.Append(sOriginalEmail[^2]);
                rReturn.Append(sOriginalEmail[^1]);
            }
            else
            {
                rReturn.Append(sOriginalEmail);
            }

            return rReturn.ToString();
        }

        /// <summary>
        ///     Generate a rescue hash by concatenating the email and project ID and generating a SHA hash.
        /// </summary>
        /// <param name="sEmail">The email associated with the account</param>
        /// <param name="sProject">The ID of the project</param>
        /// <returns>The rescue hash</returns>
        public static string GenerateHashRescue(string sEmail, long sProject)
        {
            return GDFSecurityTools.GenerateSha(sEmail + sProject) + "-" +
                   GDFSecurityTools.GenerateSha(sEmail);
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Name of the sign.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        ///     The rescue hash associated with the account sign.
        /// </summary>
        public string RescueHash { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the sign hash associated with an account.
        /// </summary>
        public string SignHash { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the type of sign for an account.
        /// </summary>
        public GDFAccountSignType SignType { set; get; } = GDFAccountSignType.None;

        /// <summary>
        ///     Represents the rescue token for an account sign in the GDFAccountSign class.
        /// </summary>
        /// <remarks>
        ///     The rescue token is used in the account sign flow to securely verify and rescue an account.
        /// </remarks>
        public string TokenRescue { set; get; } = string.Empty;

        /// <summary>
        ///     The token rescue limit for an account sign.
        /// </summary>
        /// <remarks>
        ///     This property represents the maximum number of token rescue attempts allowed for an account sign.
        ///     Once this limit is reached, further token rescue attempts will be denied.
        /// </remarks>
        public DateTime TokenRescueLimit { set; get; }

        #endregion
    }
}