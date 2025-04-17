using System;
using System.Text;
using System.Text.RegularExpressions;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account sign information.
    /// </summary>
    [Serializable]
    public class GDFAccountSign : GDFAccountData
    {
        /// <summary>
        /// Name of the sign.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Represents the type of sign for an account.
        /// </summary>
        public GDFAccountSignType SignType { set; get; } = GDFAccountSignType.None;

        /// <summary>
        /// Represents the sign hash associated with an account.
        /// </summary>
        public string SignHash { set; get; } = string.Empty;

        /// <summary>
        /// The rescue hash associated with the account sign.
        /// </summary>
        public string RescueHash { set; get; } = string.Empty;

        /// <summary>
        /// The login hash associated with the account sign.
        /// </summary>
        /// <remarks>
        /// This property stores the login hash associated with the account sign. The login hash is used for authenticating the user during the sign-in process.
        /// </remarks>
        [Obsolete("To remove")]
        public string LoginHash { set; get; } = string.Empty;

        /// <summary>
        /// Represents the status of a sign.
        /// </summary>
       
        [Obsolete("To remove")]
        public GDFAccountSignAction SignStatus { set; get; } = GDFAccountSignAction.None;

        /// <summary>
        /// Represents the rescue token for an account sign in the GDFAccountSign class.
        /// </summary>
        /// <remarks>
        /// The rescue token is used in the account sign flow to securely verify and rescue an account.
        /// </remarks>
        public string TokenRescue { set; get; } = string.Empty;

        /// <summary>
        /// The token rescue limit for an account sign.
        /// </summary>
        /// <remarks>
        /// This property represents the maximum number of token rescue attempts allowed for an account sign.
        /// Once this limit is reached, further token rescue attempts will be denied.
        /// </remarks>
        public long TokenRescueLimit { set; get; }

        /// <summary>
        /// The token used for verifying a sign action.
        /// </summary>
        // TODO : Rename to TokenVerification and rename column in Database by operation
        [Obsolete("To remove")]
        public string TokenVerif { set; get; } = string.Empty;

        /// <summary>
        /// The verifcation token limit for the account sign.
        /// </summary>
        // TODO : Rename to TokenVerificationLimit and rename column in Database by operation
        [Obsolete("To remove")]
        public int TokenVerifLimit { set; get; }

        /// <summary>
        /// Gets or sets the verification hash for sign add or sign up.
        /// </summary>
        // TODO : Rename to SignVerificationHash and rename column in Database by operation
        [Obsolete("To remove")]
        public string SignVerifHash { set; get; } = string.Empty;

        /// <summary>
        /// The rescue verification hash associated with the account sign.
        /// This hash is used during sign up and sign add operations.
        /// </summary>
        // TODO : Rename to RescueVerificationHash and rename column in Database by operation
        public string RescueVerifHash { set; get; } = string.Empty;

        /// <summary>
        /// The login verification hash associated with an account sign.
        /// </summary>
        // TODO : Rename to LoginVerificationHash and rename column in Database by operation
        [Obsolete("To remove")]
        public string LoginVerifHash { set; get; } = string.Empty;


        public static bool CheckDeviceIdentifier(string identifier)
        {
            if (identifier.Length < GDFConstants.K_DEVICE_IDENTIFIER_LENGTH_MIN)
            {
                throw new FormatException($"The field `{nameof(IDeviceSign.UniqueIdentifier)}` is too short.");
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

        public static bool CheckOAuthKind(GDFOAuthKind oAuthKind)
        {
            if (oAuthKind == GDFOAuthKind.None)
            {
                throw new FormatException();
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
        
        
        
        /// <summary>
        /// Converts the original email address to a partially masked string.
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
        /// Creates a device sign using the specified device type, unique identifier, and project reference.
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
            result.RescueHash = typeObfuscation + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier + projectReference) + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier);
            result.SignHash = typeObfuscation + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier + projectReference) + "-" + GDFSecurityTools.GenerateSha(uniqueIdentifier);
            return result;
        }
        
        public static GDFAccountSign CreateOAuthSign(GDFOAuthKind authKind,  string userIdentifier, long projectReference)
        {
            CheckProject(projectReference);
            CheckOAuthAccessToken(userIdentifier);
            CheckOAuthKind(authKind);
            GDFAccountSign rReturn = new GDFAccountSign();
            rReturn.Project = projectReference;
            rReturn.SignType = (GDFAccountSignType) authKind;
            rReturn.Name = GDFSecurityTools.CryptAes(rReturn.SignType.ToString(), projectReference.ToString(), projectReference.ToString());
            string tType = DeviceTypeObfuscation(rReturn.SignType);
            rReturn.RescueHash = "";
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(userIdentifier + projectReference) + "-" + GDFSecurityTools.GenerateSha(userIdentifier);
            return rReturn;
        }
        
        /// <summary>
        /// Create a sign with email and password
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
            rReturn.RescueHash = tType + "-" +GDFSecurityTools.GenerateSha(email + projectReference) + "-" + GDFSecurityTools.GenerateSha(email);
            rReturn.SignHash = tType + "-" +GDFSecurityTools.GenerateSha(email + password + projectReference) + "-" + GDFSecurityTools.GenerateSha(password + email);
            return rReturn;
        }

        /// <summary>
        /// Create a sign with login, email, and password.
        /// </summary>
        /// <param name="sLogin">The login for the account.</param>
        /// <param name="sEmail">The email for the account.</param>
        /// <param name="sPassword">The password for the account.</param>
        /// <param name="sProject">The project ID.</param>
        /// <returns>A new GDFAccountSign object with the specified login, email, and password.</returns>
        public static GDFAccountSign CreateLoginEmailPassword(string login, string email, string password, long projectReference)
        {
            CheckProject(projectReference);
            CheckEmail(email);
            CheckPassword(password);
            
            GDFAccountSign rReturn = new GDFAccountSign();
            rReturn.Project = projectReference;
            rReturn.Name = GDFSecurityTools.CryptAes(login + " " + EmailToPartialString(email), projectReference.ToString(), projectReference.ToString());
            rReturn.SignType = GDFAccountSignType.LoginEmailPassword;
            rReturn.LoginHash = GDFSecurityTools.GenerateSha(login + projectReference) + "-" +
                                GDFSecurityTools.GenerateSha(login);
            rReturn.RescueHash = GDFSecurityTools.GenerateSha(email + projectReference) + "-" +
                                 GDFSecurityTools.GenerateSha(email);
            rReturn.SignHash = GDFSecurityTools.GenerateSha(password + email + login + projectReference) + "-" +
                               GDFSecurityTools.GenerateSha(password + login);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with login and password
        /// </summary>
        /// <param name="sLogin">The user login</param>
        /// <param name="sPassword">The user password</param>
        /// <param name="sProject">The project ID</param>
        /// <returns>The created GDFAccountSign object</returns>
        public static GDFAccountSign CreateLoginPassword(string login, string password, long projectReference)
        {
            CheckProject(projectReference);
            CheckLogin(login);
            CheckPassword(password);
            GDFAccountSign rReturn = new GDFAccountSign();
            rReturn.Project = projectReference;
            rReturn.Name = GDFSecurityTools.CryptAes(login, projectReference.ToString(), projectReference.ToString());
            rReturn.SignType = GDFAccountSignType.LoginPassword;
            rReturn.LoginHash = GDFSecurityTools.GenerateSha(login + projectReference) + "-" +
                                GDFSecurityTools.GenerateSha(login);
            rReturn.RescueHash = GDFSecurityTools.GenerateSha(login + projectReference) + "-" +
                                 GDFSecurityTools.GenerateSha(login);
            rReturn.SignHash = GDFSecurityTools.GenerateSha(password + login + projectReference) + "-" +
                               GDFSecurityTools.GenerateSha(password + login);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Creates a sign with social id (Facebook).
        /// </summary>
        /// <param name="sFacebookId">The social id (Facebook) of the user.</param>
        /// <param name="sProject">The project id.</param>
        /// <returns>A new instance of the <see cref="GDFAccountSign"/> class with the specified parameters.</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateFacebook(string sFacebookId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Facebook);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Facebook.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Facebook;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with a Discord ID and associate it with a project.
        /// </summary>
        /// <param name="sFacebookId">The Discord ID of the user</param>
        /// <param name="sProject">The ID of the project</param>
        /// <returns>The created GDFAccountSign</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateDiscord(string sFacebookId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Discord);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Discord.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Discord;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sFacebookId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sFacebookId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with social id (Google)
        /// </summary>
        /// <param name="sGoogleId">The Google Id of the user</param>
        /// <param name="sProject">The project identifier</param>
        /// <returns>Returns a new instance of GDFAccountSign</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateGoogle(string sGoogleId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Google);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Google.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Google;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sGoogleId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sGoogleId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sGoogleId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sGoogleId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sGoogleId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sGoogleId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with social id (AppleID)
        /// </summary>
        /// <param name="sAppleId">The social id (Apple ID) of the sign</param>
        /// <param name="sProject">The project id</param>
        /// <returns>A new instance of GDFAccountSign with the specified Apple ID and project id</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateApple(string sAppleId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Apple);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Apple.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Apple;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sAppleId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sAppleId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sAppleId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sAppleId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sAppleId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sAppleId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign for Microsoft account
        /// </summary>
        /// <param name="sMicrosoftId">The unique identifier of the Microsoft account</param>
        /// <param name="sProject">The project ID</param>
        /// <returns>A new instance of <see cref="GDFAccountSign"/> representing the created Microsoft sign</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateMicrosoft(string sMicrosoftId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Microsoft);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Microsoft.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Microsoft;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sMicrosoftId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sMicrosoftId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sMicrosoftId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sMicrosoftId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sMicrosoftId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sMicrosoftId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with social id (Twitter)
        /// </summary>
        /// <param name="sTwitterId">The social id (Twitter) of the user</param>
        /// <param name="sProject">The project identifier</param>
        /// <returns>The created Twitter sign</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateTwitter(string sTwitterId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.Twitter);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.Twitter.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.Twitter;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sTwitterId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sTwitterId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sTwitterId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sTwitterId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sTwitterId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sTwitterId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Create a sign with social id (LinkedIn) and associate it with a project
        /// </summary>
        /// <param name="sLinkedInId">The LinkedIn social id</param>
        /// <param name="sProject">The project id</param>
        /// <returns>The created GDFAccountSign instance</returns>
        [Obsolete("Remove ... use CheckOAuthAccessToken")]
        public static GDFAccountSign CreateLinkedIn(string sLinkedInId, long sProject)
        {
            GDFAccountSign rReturn = new GDFAccountSign();
            string tType = DeviceTypeObfuscation(GDFAccountSignType.LinkedIn);
            rReturn.Project = sProject;
            rReturn.Name = GDFSecurityTools.CryptAes(GDFAccountSignType.LinkedIn.ToString(), sProject.ToString(), sProject.ToString());
            rReturn.SignType = GDFAccountSignType.LinkedIn;
            rReturn.LoginHash = tType + "-" + GDFSecurityTools.GenerateSha(sLinkedInId + sProject) + "-" +
                                GDFSecurityTools.GenerateSha(sLinkedInId);
            rReturn.RescueHash = tType + "-" + GDFSecurityTools.GenerateSha(sLinkedInId + sProject) + "-" +
                                 GDFSecurityTools.GenerateSha(sLinkedInId);
            rReturn.SignHash = tType + "-" + GDFSecurityTools.GenerateSha(sLinkedInId + sProject) + "-" +
                               GDFSecurityTools.GenerateSha(sLinkedInId);
            rReturn.SignStatus = GDFAccountSignAction.None;
            return rReturn;
        }

        /// <summary>
        /// Generate a rescue hash by concatenating the email and project ID and generating a SHA hash.
        /// </summary>
        /// <param name="sEmail">The email associated with the account</param>
        /// <param name="sProject">The ID of the project</param>
        /// <returns>The rescue hash</returns>
        public static string GenerateHashRescue(string sEmail, long sProject)
        {
            return GDFSecurityTools.GenerateSha(sEmail + sProject) + "-" +
                   GDFSecurityTools.GenerateSha(sEmail);
        }

        /// <summary>
        /// Obfuscates the device type based on the given sign type.
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
                case GDFAccountSignType.LoginPassword:
                    rResult = "B";
                    break;
                case GDFAccountSignType.LoginEmailPassword:
                    rResult = "C";
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
    }
}

