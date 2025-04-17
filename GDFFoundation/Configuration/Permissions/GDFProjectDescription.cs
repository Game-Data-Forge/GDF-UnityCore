

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a project description in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFProjectDescription
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Represents the qualification freeze status of a project description.
        /// </summary>
        /// <remarks>
        /// The <see cref="FreezeQualification"/> property determines if the qualification of a project is frozen or not.
        /// When set to <c>true</c>, it indicates that the qualification is frozen and cannot be modified.
        /// When set to <c>false</c>, it indicates that the qualification is not frozen and can be modified.
        /// </remarks>
        public bool FreezeQualification { set; get; } = false;

        /// <summary>
        /// Represents a project description.
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        /// Represents a company in the GDFProjectDescription class.
        /// </summary>
        public string Company { set; get; } = string.Empty;

        /// <summary>
        /// Represents a project description.
        /// </summary>
        public long Project { set; get; }

        /// <summary>
        /// Represents the unique identifier of a project.
        /// </summary>
        public long ProjectReference { set; get; }

        /// <summary>
        /// Represents a project version in the GDF Foundation.
        /// </summary>
        public long ProjectVersion { set; get; }

        /// <summary>
        /// Gets or sets the engine version of the project.
        /// </summary>
        public string EngineVersion { set; get; } = string.Empty;
        public string HubDnsHttps { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the format for the server DNS with HTTPS.
        /// </summary>
        /// <remarks>
        /// The ServerDnsHttpsFormat should be a string value representing the format for the DNS of the server with HTTPS.
        /// It is used to determine the server URL when making requests to the server.
        /// </remarks>
        public string ServerDnsHttpsFormat { set; get; } = string.Empty;

        /// <summary>
        /// Represents the service keys associated with a project in the GDFFoundation.
        /// </summary>
        public List<GDFServiceKeyDescription> ServiceKeys { set; get; } = new List<GDFServiceKeyDescription>();

        /// <summary>
        /// Represents a collection of keys used for project credentials.
        /// </summary>
        public GDFProjectCredentials[] Keys { set; get; } = new GDFProjectCredentials[] { };

        /// <summary>
        /// Gets or sets the public token of the GDFProjectDescription.
        /// </summary>
        public string PublicToken { set; get; } = string.Empty;

        /// <summary>
        /// Represents a secret token for a project role.
        /// </summary>
        public string SecretToken { set; get; } = string.Empty;

        /// <summary>
        /// Represents a reference to a role in a project description.
        /// </summary>
        public long RoleReference { set; get; } = 0;

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string RoleName { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the role in the project.
        /// </summary>
        /// <value>The role description.</value>
        public string RoleDescription { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the user can edit metadata information.
        /// </summary>
        public bool CanEditMetaDataInfos { set; get; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the user can create meta data.
        /// </summary>
        /// <value><c>true</c> if the user can create meta data; otherwise, <c>false</c>.</value>
        public bool CanCreateMetaData { set; get; } = false;

        /// <summary>
        /// Class representing a track.
        /// </summary>
        public GDFDataTrackDescription[] Track { set; get; }

        /// <summary>
        /// Enum that represents the rights for a track in a project.
        /// </summary>
        public Dictionary<int, GDFTrackRights> TracksRights { set; get; } = new Dictionary<int, GDFTrackRights>();

        /// <summary>
        /// Represents the base language of a project.
        /// </summary>
        public string BaseLanguage { set; get; } = "en";

        /// <summary>
        /// Gets or sets the supported languages for the project.
        /// </summary>
        /// <remarks>
        /// The supported languages define the languages that are available for use in the project.
        /// </remarks>
        /// <value>
        /// The supported languages.
        /// </value>
        public string[] SupportedLanguages { set; get; } = new string[] { }; // must stay empty else it's populated by adds
    }
}

