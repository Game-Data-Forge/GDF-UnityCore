#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj CloudConfiguration.cs create at 2025/05/20 14:05:25
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    /// Represents the configuration settings for a cloud environment, including authentication, synchronization,
    /// volatile storage, and a dashboard URL.
    /// </summary>
    public class CloudConfiguration
    {
        #region Instance fields and properties

        /// <summary>
        /// Represents the server configuration specific to authentication services within the cloud configuration.
        /// </summary>
        /// <remarks>
        /// This property is used to define and manage the settings related to the authentication server
        /// in the application’s cloud architecture. It provides configuration details such as default hosts
        /// and country-specific server addresses.
        /// </remarks>
        public ServerConfiguration Auth { get; set; } = new ServerConfiguration();

        /// <summary>
        /// Gets or sets the dashboard URL configuration for the cloud environment.
        /// </summary>
        public string Dashboard { get; set; }

        /// <summary>
        /// Represents the synchronization configuration for the cloud setup.
        /// This property holds a <see cref="ServerConfiguration"/> instance that manages
        /// server-related synchronization settings for the system.
        /// </summary>
        public ServerConfiguration Sync { get; set; } = new ServerConfiguration();

        /// <summary>
        /// Gets or sets the volatile server configuration used by the system.
        /// This property represents a transient configuration that may not
        /// persist across sessions or executions.
        /// </summary>
        public ServerConfiguration Volatile { get; set; } = new ServerConfiguration();

        #endregion
    }
}