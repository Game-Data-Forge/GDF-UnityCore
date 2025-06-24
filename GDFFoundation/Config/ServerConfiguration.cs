#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ServerConfiguration.cs create at 2025/05/20 13:05:21
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    /// Represents the server configuration settings which include server addresses
    /// and mechanisms to resolve the best server URL for a given country.
    /// </summary>
    [Serializable]
    public class ServerConfiguration
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the default host URL to be used for server connections
        /// when no specific URL is defined for a given country or condition.
        /// </summary>
        /// <remarks>
        /// This property is a fallback mechanism, ensuring that a valid host URL
        /// is always available in cases where no country-specific or manual configuration
        /// has been provided.
        /// </remarks>
        public string DefaultHost { get; set; }

        /// <summary>
        /// Represents a dictionary mapping ISO country codes to manual URLs.
        /// This dictionary is used to associate specific country codes with corresponding manual resource URLs.
        /// </summary>
        private Dictionary<Country, string> ManualUrlDictionary;

        /// <summary>
        /// Gets or sets the list of server addresses associated with specific countries.
        /// </summary>
        /// <remarks>
        /// This property is used to store and retrieve server information applicable to various countries.
        /// It is typically utilized in scenarios where server configurations are mapped to different ISO country codes.
        /// </remarks>
        public List<ServerAddress> ServersForCountries { get; set; } = new List<ServerAddress>();

        public string this[Country index]
        {
            get
            {
                Init();
                return GetBestUrlFor(index);
            }
        }

        #endregion

        #region Instance methods

        /// <summary>
        /// Retrieves the best URL for the specified country code based on the server configuration.
        /// </summary>
        /// <param name="country">The ISO country code for which the best URL is required.</param>
        /// <returns>The best URL corresponding to the specified country code. If no specific URL is found, returns the default host URL.</returns>
        public string GetBestUrlFor(Country country)
        {
            Init();
            return ManualUrlDictionary[country] ?? DefaultHost;
        }

        public IEnumerable<KeyValuePair<Country, string>> Enumerate()
        {
            Init();
            return ManualUrlDictionary;
        }

        private void Init()
        {
            if (ManualUrlDictionary == null)
            {
                ManualUrlDictionary = new Dictionary<Country, string>();
                foreach (ServerAddress serverAddress in ServersForCountries)
                {
                    foreach (Country c in serverAddress.Countries)
                    {
                        ManualUrlDictionary.TryAdd(c, serverAddress.Host);
                    }
                }

                foreach (Country country in CountryTool.COUNTRIES.Keys)
                {
                    if (country == Country.None) continue;

                    if (ManualUrlDictionary.ContainsKey(country) == false)
                    {
                        ManualUrlDictionary.TryAdd(country, DefaultHost);
                    }
                }
            }
        }

        #endregion
    }
}