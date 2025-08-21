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
    static public class DataRegionExtension
    {
        internal struct Cache
        {
            public string dns;
            public string prefix;

            public Cache(string dns, string prefix)
            {
                this.dns = dns;
                this.prefix = prefix;
            }
        }

        static internal readonly Dictionary<DataRegion, Cache> _cache = new Dictionary<DataRegion, Cache>
        {
            { DataRegion.Unknown,                       new Cache("unknown",                        "xx") },
            { DataRegion.Europe,                        new Cache("europe",                         "eu") },
            { DataRegion.Europe_GDPR,                   new Cache("europe-gdpr",                    "eu_gdpr") },
            { DataRegion.NorthAmerica,                  new Cache("northamerica",                   "na") },
            { DataRegion.NorthAmerica_Canada_PIPEDA,    new Cache("northamerica-canada-pipeda",     "na_pipeda") },
            { DataRegion.NorthAmerica_California_CCPA,  new Cache("northamerica-california-ccpa",   "na_ccpa") },
            { DataRegion.SouthAmerica,                  new Cache("southamerica",                   "sa") },
            { DataRegion.SouthAmerica_Brazil_LGPD,      new Cache("southamerica-brazil-lgpd",       "sa_lgpd") },
            { DataRegion.SouthAmerica_Argentina_LPDP,   new Cache("southamerica-argentina-lpdp",    "sa_lpdp") },
            { DataRegion.Africa,                        new Cache("africa",                         "af") },
            { DataRegion.Africa_SouthAfrica_POPIA,      new Cache("africa-southafrica-popia",       "af_popia") },
            { DataRegion.Africa_Nigeria_NDPR,           new Cache("africa-nigeria-ndpr",            "af_ndpr") },
            { DataRegion.Asia,                          new Cache("asia",                           "as") },
            { DataRegion.Asia_Russia,                   new Cache("asia-russia",                    "as_ru") },
            { DataRegion.Asia_India_PDPB,               new Cache("asia-india-pdpb",                "as_pdpb") },
            { DataRegion.Asia_China_PIPL,               new Cache("asia-china-pipl",                "as_pipl") },
            { DataRegion.Asia_Japan_APPI,               new Cache("asia-japan-appi",                "as_appi") },
            { DataRegion.Asia_SouthKorea_PIPA,          new Cache("asia-southKorea-pipa",           "as_pipa") },
            { DataRegion.Asia_Singapore_PDPA,           new Cache("asia-singapore-pdpa",            "as_pdpa") },
            { DataRegion.Oceania,                       new Cache("oceania",                        "oc") },
            { DataRegion.Oceania_Australia,             new Cache("oceania-australia",              "oc_au") },
            { DataRegion.Oceania_NewZealand,            new Cache("oceania-newZealand",             "oc_nw") },
            { DataRegion.Antarctica,                    new Cache("antarctica",                     "an") },
            { DataRegion.Tesseract,                     new Cache("tesseract",                      "ts") },
        };

        static private Dictionary<DataRegion, List<Country>> _countryCache = null;

        #region Static methods

        static public List<Country> GetCountries(this DataRegion self)
        {
            if (self == DataRegion.Unknown) return new List<Country>();

            BuildCache();

            return _countryCache[self];
        }

        static private void BuildCache()
        {
            if (_countryCache != null) return;

            _countryCache = new Dictionary<DataRegion, List<Country>>();

            foreach (KeyValuePair<Country, CountryExtension.Cache> item in CountryExtension.cache)
            {
                if (!_countryCache.ContainsKey(item.Value.region))
                {
                    _countryCache.Add(item.Value.region, new List<Country>());
                }
                _countryCache[item.Value.region].Add(item.Key);
            }
        }

        [Obsolete("This cannot work. It has to take into account formatted (prefix.range.area.domain:port) as well as non formatted (xxx.yyyy.zzz:port / 000.000.000.000:port / localhost:port / ...) addresses.")]
        static List<string> CreateListOfDomainsName(string prefixe, ushort projectRange, string domain)
        {
            List<string> list = new List<string>();
            foreach (DataRegion area in Enum.GetValues(typeof(DataRegion)))
            {
                if (area != DataRegion.Unknown)
                {
                    list.Add($"{prefixe}.{projectRange:00}.{area.ToServerPrefix()}.{domain}");
                }
            }

            return list;
        }

        public static void InConsole()
        {
            GDFLogger.Information("DNS for sync game-data-forge.com", CreateListOfDomainsName("sync", 1, "game-data-forge.com").ToArray());
            GDFLogger.Information("DNS for auth game-data-forge.com", CreateListOfDomainsName("auth", 1, "game-data-forge.com").ToArray());
        }

        static public string ToDatabasePrefix(this DataRegion self)
        {
            return _cache[self].prefix;
        }

        public static string ToDNS(this DataRegion self)
        {
            return _cache[self].dns;
        }

        public static string ToDNS(this DataRegion self, string domain)
        {
            return ToDNS(self) + "." + domain;
        }

        static public string ToServerPrefix(this DataRegion self)
        {
            return ToDNS(self);
        }

        #endregion
    }
}