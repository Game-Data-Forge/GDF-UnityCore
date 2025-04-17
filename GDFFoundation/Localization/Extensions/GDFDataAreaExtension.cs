using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    static public class GDFDataAreaExtension
    {
        static public string ToServerPrefix(this GDFDataArea self)
        {
            switch (self)
            {
                case GDFDataArea.Unknown:
                    return "u";
                case GDFDataArea.European:
                    return "eu";
                case GDFDataArea.European_GDPR_EU:
                    return "gdpr";
                case GDFDataArea.NorthAmerica:
                    return "na";
                case GDFDataArea.NorthAmerica_Canada_PIPEDA:
                    return "pipeda";
                case GDFDataArea.NorthAmerica_California_CCPA:
                    return "ccpa";
                case GDFDataArea.SouthAmerica:
                    return "sa";
                case GDFDataArea.SouthAmerica_Brazil_LGPD:
                    return "lgpd";
                case GDFDataArea.SouthAmerica_Argentina_LPDP:
                    return "lpdp";
                case GDFDataArea.Africa:
                    return "af";
                case GDFDataArea.Africa_SouthAfrica_POPIA:
                    return "popia";
                case GDFDataArea.Africa_Nigeria_NDPR:
                    return "ndpr";
                case GDFDataArea.Asia:
                    return "as";
                case GDFDataArea.Asia_Russia:
                    return "ru";
                case GDFDataArea.Asia_India_PDPB:
                    return "pdpb";
                case GDFDataArea.Asia_China_PIPL:
                    return "pipl";
                case GDFDataArea.Asia_Japan_APPI:
                    return "appi";
                case GDFDataArea.Asia_SouthKorea_PIPA:
                    return "pipa";
                case GDFDataArea.Asia_Singapore_PDPA:
                    return "pdpa";
                case GDFDataArea.Oceania:
                    return "oc";
                case GDFDataArea.Oceania_Australia:
                    return "au";
                case GDFDataArea.Oceania_NewZealand:
                    return "nw";
                case GDFDataArea.Antarctica:
                    return "an";
                default:
                    throw new ArgumentOutOfRangeException(nameof(self), self, null);
            }
        }

        [Obsolete("This cannot work. It has to take into account formatted (prefix.range.area.domain:port) as well as non formatted (xxx.yyyy.zzz:port / 000.000.000.000:port / localhost:port / ...) addresses.")]
        static List<string> CreateListOfDomainsName(string prefixe, ushort projectRange, string domain)
        {
            List<string> list = new List<string>();
            foreach (GDFDataArea area in Enum.GetValues(typeof(GDFDataArea)))
            {
                if (area != GDFDataArea.Unknown)
                {
                    list.Add($"{prefixe}.{projectRange:00}.{area.ToServerPrefix()}.{domain}");
                }
            }
            return list;
        }

        public static void InConsole()
        {
            GDFLogger.Information("DNS for sync game-data-forge.com", CreateListOfDomainsName("sync",1, "game-data-forge.com").ToArray());
            GDFLogger.Information("DNS for auth game-data-forge.com", CreateListOfDomainsName("auth",1, "game-data-forge.com").ToArray());
        }
    }
}