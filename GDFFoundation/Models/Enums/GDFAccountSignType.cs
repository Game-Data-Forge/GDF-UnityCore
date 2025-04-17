

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents the type of account sign-in.
    /// </summary>
    [Serializable]
    public enum GDFAccountSignType : int
    {
        /// <summary>
        /// Represents an unknown account sign type.
        /// </summary>
        None = 0, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents the device ID sign type.
        /// </summary>
        DeviceId = 1, // NEVER CHANGE INT VALUE !
        
        /// <summary>
        /// Represents the sign-in type for an account using an email and password.
        /// </summary>
        EmailPassword = 10, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// The sign type for an old email/password account to allow migration from Game-Data-Forge 2 or Dicolatin service.
        /// </summary>
        [Obsolete("Use to migration from Game-Data-Forge 2 or Dicolatin service")]
        OldEmailPassword = 75, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents an enumeration member that indicates login using email and password.
        /// </summary>
        LoginEmailPassword = 11, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents the sign-in type using a login and password combination.
        /// </summary>
        /// <remarks>
        /// This sign-in type is used when a user enters their login credentials, such as their username or email address, and
        /// password to access their account.
        /// </remarks>
        LoginPassword = 12, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents the Facebook sign-in option for an GDFAccount.
        /// </summary>
        Facebook = 20, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents the Google sign-in method.
        /// </summary>
        Google = 21, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents an Apple account sign-in type.
        /// </summary>
        Apple = 22, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Microsoft sign-in account type
        /// </summary>
        Microsoft = 23, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Represents a Twitter account sign-in type.
        /// </summary>
        Twitter = 24, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// LinkedIn sign-in method.
        /// </summary>
        LinkedIn = 25, // NEVER CHANGE INT VALUE !

        /// <summary>
        /// Discord sign-in method for GDFAccount.
        /// </summary>
        Discord = 30, // NEVER CHANGE INT VALUE !
    }
    

    [Serializable]
    public enum GDFOAuthKind : int
    {
        None = GDFAccountSignType.None,
        Facebook = GDFAccountSignType.Facebook,
        Google = GDFAccountSignType.Google,
        Apple = GDFAccountSignType.Apple,
        Microsoft = GDFAccountSignType.Microsoft,
        Twitter = GDFAccountSignType.Twitter,
        LinkedIn = GDFAccountSignType.LinkedIn,
        Discord = GDFAccountSignType.Discord,
    }
}

