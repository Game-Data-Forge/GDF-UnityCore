using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    static public class GDFDataAreaExtension
    {
        public static string ToDNS(GDFDataArea area)
        {
            return area.ToString().ToLower().Replace("_", "-");
        }

        public static string ToDNS(GDFDataArea area, string domain)
        {
            return ToDNS(area) + "." + domain;
        }

        static public string ToServerPrefix(this GDFDataArea self)
        {
            return ToDNS(self);
        }

        static public string ToDatabasePrefix(this GDFDataArea self)
        {
            switch (self)
            {
                case GDFDataArea.Unknown:
                    return "xx";
                case GDFDataArea.Europe:
                    return "eu";
                case GDFDataArea.Europe_GDPR:
                    return "eu_gdpr";
                case GDFDataArea.NorthAmerica:
                    return "na";
                case GDFDataArea.NorthAmerica_Canada_PIPEDA:
                    return "na_pipeda";
                case GDFDataArea.NorthAmerica_California_CCPA:
                    return "na_ccpa";
                case GDFDataArea.SouthAmerica:
                    return "sa";
                case GDFDataArea.SouthAmerica_Brazil_LGPD:
                    return "sa_lgpd";
                case GDFDataArea.SouthAmerica_Argentina_LPDP:
                    return "sa_lpdp";
                case GDFDataArea.Africa:
                    return "af";
                case GDFDataArea.Africa_SouthAfrica_POPIA:
                    return "af_popia";
                case GDFDataArea.Africa_Nigeria_NDPR:
                    return "af_ndpr";
                case GDFDataArea.Asia:
                    return "as";
                case GDFDataArea.Asia_Russia:
                    return "as_ru";
                case GDFDataArea.Asia_India_PDPB:
                    return "as_pdpb";
                case GDFDataArea.Asia_China_PIPL:
                    return "as_pipl";
                case GDFDataArea.Asia_Japan_APPI:
                    return "as_appi";
                case GDFDataArea.Asia_SouthKorea_PIPA:
                    return "as_pipa";
                case GDFDataArea.Asia_Singapore_PDPA:
                    return "as_pdpa";
                case GDFDataArea.Oceania:
                    return "oc";
                case GDFDataArea.Oceania_Australia:
                    return "oc_au";
                case GDFDataArea.Oceania_NewZealand:
                    return "oc_nw";
                case GDFDataArea.Antarctica:
                    return "an";
                case GDFDataArea.Tesseract:
                    return "ts";
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
            GDFLogger.Information("DNS for sync game-data-forge.com", CreateListOfDomainsName("sync", 1, "game-data-forge.com").ToArray());
            GDFLogger.Information("DNS for auth game-data-forge.com", CreateListOfDomainsName("auth", 1, "game-data-forge.com").ToArray());
        }
    }
}