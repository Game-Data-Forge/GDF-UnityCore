#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDataAreaExtension.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    static public class ContinentExtension
    {
        internal struct Cache
        {
            public string dns;

            public Cache(string dns)
            {
                this.dns = dns;
            }
        }

        static internal readonly Dictionary<Continent, Cache> _cache = new Dictionary<Continent, Cache>
        {
            { Continent.Unknown,       new Cache("unknown") },
            { Continent.Europe,        new Cache("europe") },
            { Continent.NorthAmerica,  new Cache("northamerica") },
            { Continent.SouthAmerica,  new Cache("southamerica") },
            { Continent.Africa,        new Cache("africa") },
            { Continent.Asia,          new Cache("asia") },
            { Continent.Oceania,       new Cache("oceania") },
            { Continent.Antarctica,    new Cache("antarctica") }
        };

        static private Dictionary<Continent, List<Country>> _countryCache = null;

        #region Static methods

        static public List<Country> GetCountries(this Continent self)
        {
            if (self == Continent.Unknown) return new List<Country>();

            BuildCache();

            return _countryCache[self];
        }

        static private void BuildCache()
        {
            if (_countryCache != null) return;

            _countryCache = new Dictionary<Continent, List<Country>>();

            foreach (KeyValuePair<Country, CountryExtension.Cache> item in CountryExtension.cache)
            {
                if (!_countryCache.ContainsKey(item.Value.continent))
                {
                    _countryCache.Add(item.Value.continent, new List<Country>());
                }
                _countryCache[item.Value.continent].Add(item.Key);
            }
        }

        static public string GetDNS(this Continent self)
        {
            return _cache[self].dns;
        }

        #endregion
    }
}