

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a request for a player token.
    /// </summary>
    [Serializable]
    public class GDFRequestPlayerToken
    {
        /// <summary>
        /// Represents an account range.
        /// </summary>
        //[JsonProperty("Ran")]
        public short AccountRange { set; get; }

        /// <summary>
        /// Gets or sets the ProjectReference.
        /// </summary>
        //[JsonProperty("Prj")]
        public long ProjectReference { set; get; }

        /// <summary>
        /// Represents a player reference in the GDFRequestPlayerToken class.
        /// </summary>
        //[JsonProperty("Pla")]
        public long PlayerReference { set; get; }

        /// <summary>
        /// Represents a player token used for authentication and authorization.
        /// </summary>
        //[JsonProperty("Tok")]
        public string Token { set; get; }

        /// <summary>
        /// Gets or sets the old token.
        /// </summary>
        /// <remarks>
        /// This property holds the value of the old token associated with a player.
        /// It is used in the process of creating a new player token or during sign up.
        /// </remarks>
        //[JsonProperty("Oto")]
        public string OldToken { set; get; }

        /// <summary>
        /// Represents the sign-in type for an account.
        /// </summary>
        //[JsonProperty("Env")]
        public GDFAccountSignType SignType { set; get; } = GDFAccountSignType.None;

        /// <summary>
        /// Represents the environment kind in which the GDFRequestPlayerToken is used.
        /// </summary>
        /// <remarks>
        /// The GDFEnvironmentKind determines the environment in which the GDFRequestPlayerToken object is used. It can be one of the following values:
        /// - Development: The development environment.
        /// - PlayTest: The playtest environment.
        /// - Qualification: The qualification environment.
        /// - Preproduction: The pre-production environment.
        /// - Production: The production environment.
        /// - PostProduction: The post-production environment.
        /// </remarks>
        //[JsonProperty("Env")]
        public GDFEnvironmentKind EnvironmentKind { set; get; }

        /// <summary>
        /// Represents the origin of an exchange.
        /// </summary>
        //[JsonProperty("Exo")]
        public GDFExchangeOrigin ExchangeOrigin { set; get; }

        /// <summary>
        /// Represents the user synchronization information.
        /// </summary>
        [Obsolete("Synchronisation date data are stored by the application as a long date.")]
        public GDFSyncInformation UserSyncInformation { set; get; } = new GDFSyncInformation();

        /// <summary>
        /// Represents the player synchronisation information.
        /// </summary>
        [Obsolete("Synchronisation date data are stored by the application as a long date.")]
        public GDFSyncInformation PlayerSyncInformation { set; get; } = new GDFSyncInformation();

        /// <summary>
        /// Represents the synchronization information for the studio.
        /// </summary>
        [Obsolete("Synchronisation date data are stored by the application as a long date.")]
        public GDFSyncInformation StudioSyncInformation { set; get; } = new GDFSyncInformation();

        //[Obsolete("NEVER USE! RESERVED TO JSON CONVERT!")]
        /// <summary>
        /// Represents a request for player token.
        /// </summary>
        public GDFRequestPlayerToken()
        {
        }

        /// <summary>
        /// Represents a request for player token.
        /// </summary>
        public GDFRequestPlayerToken(IGDFProjectInformation sProjectInformation)
        {
            AccountRange = 0;
            PlayerReference = 0;
            ProjectReference = sProjectInformation.GetProjectReference();
            Token = string.Empty;
            OldToken = string.Empty;
            EnvironmentKind = sProjectInformation.GetProjectEnvironment();
            ExchangeOrigin = GDFExchangeOrigin.Unknown;
        }

        /// <summary>
        /// Represents a player token request.
        /// </summary>
        /// <remarks>
        /// This class is used to request a player token for a specific project and environment.
        /// </remarks>
        public GDFRequestPlayerToken(long sProjectReference, GDFEnvironmentKind sEnvironmentKind)
        {
            AccountRange = 0;
            PlayerReference = 0;
            ProjectReference = sProjectReference;
            Token = string.Empty;
            OldToken = string.Empty;
            EnvironmentKind = sEnvironmentKind;
            ExchangeOrigin = GDFExchangeOrigin.Unknown;
        }

        /// <summary>
        /// Class representing a request for a player token.
        /// </summary>
        public GDFRequestPlayerToken(GDFRequestPlayerToken sToCopy)
        {
            if (sToCopy != null)
            {
                AccountRange = sToCopy.AccountRange;
                PlayerReference = sToCopy.PlayerReference;
                ProjectReference = sToCopy.ProjectReference;
                Token = sToCopy.Token;
                OldToken = sToCopy.OldToken;
                SignType = sToCopy.SignType;
                EnvironmentKind = sToCopy.EnvironmentKind;
                ExchangeOrigin = sToCopy.ExchangeOrigin;
            }
        }
    }
}