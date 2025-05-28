#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ServerAddress.cs create at 2025/05/20 18:05:00
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    /// Represents a server address with associated countries and a host.
    /// </summary>
    public class ServerAddress
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the list of ISO country codes associated with the server address.
        /// </summary>
        public List<Country> Countries { get; set; } = new List<Country>();

        /// <summary>
        /// Gets or sets the hostname or IP address representing the server's address.
        /// </summary>
        /// <remarks>
        /// This property typically contains the network or server address that is used
        /// for establishing connections, performing lookups, or configuring endpoints in various
        /// server configurations. The value can represent different purposes such as
        /// synchronization, authentication, or data communication.
        /// Example usages within configuration might include defining specific endpoints
        /// tailored for various countries, purposes, or server roles.
        /// </remarks>
        public string Host { get; set; }

        #endregion
    }
}