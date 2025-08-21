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
    public class RangedDatabaseConfiguration : Dictionary<Country, Dictionary<int, DatabaseCredentials>>
    {
        public void AutoFill(string tablePrefix)
        {
            if (DatabaseCredentials.Default == null) return;

            foreach (Country country in CountryTool.COUNTRIES.Keys)
            {
                if (ContainsKey(country))
                {
                    continue;
                }

                int key = (int)country * 1000 + 1;

                Dictionary<int, DatabaseCredentials> value = new Dictionary<int, DatabaseCredentials>();
                DatabaseCredentials credentials = DatabaseCredentials.Default.Copy();

                credentials.Database = string.Format(credentials.Database, country.GetContinent().GetDNS());
                credentials.TableFormat = $"{tablePrefix}{key:000000}_{{0}}";

                value.Add(key, credentials);
                Add(country, value);
            }
        }
    }
}