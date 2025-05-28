#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFEnvironmentKindExtension.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

using System.Collections.Generic;

namespace GDFFoundation
{
    static public class CountryExtension
    {
        internal struct Cache
        {
            public string name;
            public string code;
            public GDFDataArea area;

            public Cache(string name, string code, GDFDataArea area)
            {
                this.name = name;
                this.code = code;
                this.area = area;
            }
        }

        #region Static fields and properties

        internal static readonly Dictionary<Country, Cache> cache = new Dictionary<Country, Cache>
        {
            { Country.None, new Cache("None", "None", GDFDataArea.Unknown) },

            { Country.AF, new Cache("Afghanistan", "AF", GDFDataArea.Asia) },
            { Country.AL, new Cache("Albania", "AL", GDFDataArea.Europe) },
            { Country.DZ, new Cache("Algeria", "DZ", GDFDataArea.Africa) },
            { Country.AS, new Cache("American Samoa", "AS", GDFDataArea.NorthAmerica) }, // US territory
            { Country.AD, new Cache("Andorra", "AD", GDFDataArea.Europe) },
            { Country.AO, new Cache("Angola", "AO", GDFDataArea.Africa) },
            { Country.AI, new Cache("Anguilla", "AI", GDFDataArea.NorthAmerica) },
            { Country.AQ, new Cache("Antarctica", "AQ", GDFDataArea.Antarctica) },
            { Country.AG, new Cache("Antigua and Barbuda", "AG", GDFDataArea.NorthAmerica) },
            { Country.AR, new Cache("Argentina", "AR", GDFDataArea.SouthAmerica_Argentina_LPDP) },
            { Country.AM, new Cache("Armenia", "AM", GDFDataArea.Asia) },
            { Country.AW, new Cache("Aruba", "AW", GDFDataArea.NorthAmerica) },
            { Country.AU, new Cache("Australia", "AU", GDFDataArea.Oceania_Australia) },
            { Country.AT, new Cache("Austria", "AT", GDFDataArea.Europe_GDPR) },
            { Country.AZ, new Cache("Azerbaijan", "AZ", GDFDataArea.Asia) },
            { Country.BS, new Cache("Bahamas", "BS", GDFDataArea.NorthAmerica) },
            { Country.BH, new Cache("Bahrain", "BH", GDFDataArea.Asia) },
            { Country.BD, new Cache("Bangladesh", "BD", GDFDataArea.Asia) },
            { Country.BB, new Cache("Barbados", "BB", GDFDataArea.NorthAmerica) },
            { Country.BY, new Cache("Belarus", "BY", GDFDataArea.Europe) },
            { Country.BE, new Cache("Belgium", "BE", GDFDataArea.Europe_GDPR) },
            { Country.BZ, new Cache("Belize", "BZ", GDFDataArea.NorthAmerica) },
            { Country.BJ, new Cache("Benin", "BJ", GDFDataArea.Africa) },
            { Country.BM, new Cache("Bermuda", "BM", GDFDataArea.NorthAmerica) },
            { Country.BT, new Cache("Bhutan", "BT", GDFDataArea.Asia) },
            { Country.BO, new Cache("Bolivia, Plurinational State of", "BO", GDFDataArea.SouthAmerica) },
            { Country.BQ, new Cache("Bonaire, Sint Eustatius and Saba", "BQ", GDFDataArea.NorthAmerica) },
            { Country.BA, new Cache("Bosnia and Herzegovina", "BA", GDFDataArea.Europe) },
            { Country.BW, new Cache("Botswana", "BW", GDFDataArea.Africa) },
            { Country.BV, new Cache("Bouvet Island", "BV", GDFDataArea.Antarctica) },
            { Country.BR, new Cache("Brazil", "BR", GDFDataArea.SouthAmerica_Brazil_LGPD) },
            { Country.IO, new Cache("British Indian Ocean Territory", "IO", GDFDataArea.Africa) },
            { Country.BN, new Cache("Brunei Darussalam", "BN", GDFDataArea.Asia) },
            { Country.BG, new Cache("Bulgaria", "BG", GDFDataArea.Europe_GDPR) },
            { Country.BF, new Cache("Burkina Faso", "BF", GDFDataArea.Africa) },
            { Country.BI, new Cache("Burundi", "BI", GDFDataArea.Africa) },
            { Country.CV, new Cache("Cabo Verde", "CV", GDFDataArea.Africa) },
            { Country.KH, new Cache("Cambodia", "KH", GDFDataArea.Asia) },
            { Country.CM, new Cache("Cameroon", "CM", GDFDataArea.Africa) },
            { Country.CA, new Cache("Canada", "CA", GDFDataArea.NorthAmerica_Canada_PIPEDA) },
            { Country.KY, new Cache("Cayman Islands", "KY", GDFDataArea.NorthAmerica) },
            { Country.CF, new Cache("Central African Republic", "CF", GDFDataArea.Africa) },
            { Country.TD, new Cache("Chad", "TD", GDFDataArea.Africa) },
            { Country.CL, new Cache("Chile", "CL", GDFDataArea.SouthAmerica) },
            { Country.CN, new Cache("China", "CN", GDFDataArea.Asia_China_PIPL) },
            { Country.CX, new Cache("Christmas Island", "CX", GDFDataArea.Oceania_Australia) },
            { Country.CC, new Cache("Cocos (Keeling) Islands", "CC", GDFDataArea.Oceania_Australia) },
            { Country.CO, new Cache("Colombia", "CO", GDFDataArea.SouthAmerica) },
            { Country.KM, new Cache("Comoros", "KM", GDFDataArea.Africa) },
            { Country.CG, new Cache("Congo", "CG", GDFDataArea.Africa) },
            { Country.CD, new Cache("Congo, the Democratic Republic of the", "CD", GDFDataArea.Africa) },
            { Country.CK, new Cache("Cook Islands", "CK", GDFDataArea.Oceania_NewZealand) },
            { Country.CR, new Cache("Costa Rica", "CR", GDFDataArea.NorthAmerica) },
            { Country.CI, new Cache("Côte d'Ivoire", "CI", GDFDataArea.Africa) },
            { Country.HR, new Cache("Croatia", "HR", GDFDataArea.Europe_GDPR) },
            { Country.CU, new Cache("Cuba", "CU", GDFDataArea.NorthAmerica) },
            { Country.CW, new Cache("Curaçao", "CW", GDFDataArea.NorthAmerica) },
            { Country.CY, new Cache("Cyprus", "CY", GDFDataArea.Europe_GDPR) },
            { Country.CZ, new Cache("Czechia", "CZ", GDFDataArea.Europe_GDPR) },
            { Country.DK, new Cache("Denmark", "DK", GDFDataArea.Europe_GDPR) },
            { Country.DJ, new Cache("Djibouti", "DJ", GDFDataArea.Africa) },
            { Country.DM, new Cache("Dominica", "DM", GDFDataArea.NorthAmerica) },
            { Country.DO, new Cache("Dominican Republic", "DO", GDFDataArea.NorthAmerica) },
            { Country.EC, new Cache("Ecuador", "EC", GDFDataArea.SouthAmerica) },
            { Country.EG, new Cache("Egypt", "EG", GDFDataArea.Africa) },
            { Country.SV, new Cache("El Salvador", "SV", GDFDataArea.NorthAmerica) },
            { Country.GQ, new Cache("Equatorial Guinea", "GQ", GDFDataArea.Africa) },
            { Country.ER, new Cache("Eritrea", "ER", GDFDataArea.Africa) },
            { Country.EE, new Cache("Estonia", "EE", GDFDataArea.Europe_GDPR) },
            { Country.SZ, new Cache("Eswatini", "SZ", GDFDataArea.Africa) },
            { Country.ET, new Cache("Ethiopia", "ET", GDFDataArea.Africa) },
            { Country.FK, new Cache("Falkland Islands (Malvinas)", "FK", GDFDataArea.SouthAmerica) },
            { Country.FO, new Cache("Faroe Islands", "FO", GDFDataArea.Europe) },
            { Country.FJ, new Cache("Fiji", "FJ", GDFDataArea.Oceania) },
            { Country.FI, new Cache("Finland", "FI", GDFDataArea.Europe_GDPR) },
            { Country.FR, new Cache("France", "FR", GDFDataArea.Europe_GDPR) },
            { Country.GF, new Cache("French Guiana", "GF", GDFDataArea.Europe_GDPR) },
            { Country.PF, new Cache("French Polynesia", "PF", GDFDataArea.Oceania) },
            { Country.TF, new Cache("French Southern Territories", "TF", GDFDataArea.Antarctica) },
            { Country.GA, new Cache("Gabon", "GA", GDFDataArea.Africa) },
            { Country.GM, new Cache("Gambia", "GM", GDFDataArea.Africa) },
            { Country.GE, new Cache("Georgia", "GE", GDFDataArea.Asia) },
            { Country.DE, new Cache("Germany", "DE", GDFDataArea.Europe_GDPR) },
            { Country.GH, new Cache("Ghana", "GH", GDFDataArea.Africa) },
            { Country.GI, new Cache("Gibraltar", "GI", GDFDataArea.Europe) },
            { Country.GR, new Cache("Greece", "GR", GDFDataArea.Europe_GDPR) },
            { Country.GL, new Cache("Greenland", "GL", GDFDataArea.NorthAmerica) },
            { Country.GD, new Cache("Grenada", "GD", GDFDataArea.NorthAmerica) },
            { Country.GP, new Cache("Guadeloupe", "GP", GDFDataArea.Europe_GDPR) },
            { Country.GU, new Cache("Guam", "GU", GDFDataArea.NorthAmerica) },
            { Country.GT, new Cache("Guatemala", "GT", GDFDataArea.NorthAmerica) },
            { Country.GG, new Cache("Guernsey", "GG", GDFDataArea.Europe) },
            { Country.GN, new Cache("Guinea", "GN", GDFDataArea.Africa) },
            { Country.GW, new Cache("Guinea-Bissau", "GW", GDFDataArea.Africa) },
            { Country.GY, new Cache("Guyana", "GY", GDFDataArea.SouthAmerica) },
            { Country.HT, new Cache("Haiti", "HT", GDFDataArea.NorthAmerica) },
            { Country.HM, new Cache("Heard Island and McDonald Islands", "HM", GDFDataArea.Antarctica) },
            { Country.VA, new Cache("Holy See", "VA", GDFDataArea.Europe) },
            { Country.HN, new Cache("Honduras", "HN", GDFDataArea.NorthAmerica) },
            { Country.HK, new Cache("Hong Kong", "HK", GDFDataArea.Asia) },
            { Country.HU, new Cache("Hungary", "HU", GDFDataArea.Europe_GDPR) },
            { Country.IS, new Cache("Iceland", "IS", GDFDataArea.Europe_GDPR) },
            { Country.IN, new Cache("India", "IN", GDFDataArea.Asia_India_PDPB) },
            { Country.ID, new Cache("Indonesia", "ID", GDFDataArea.Asia) },
            { Country.IR, new Cache("Iran, Islamic Republic of", "IR", GDFDataArea.Asia) },
            { Country.IQ, new Cache("Iraq", "IQ", GDFDataArea.Asia) },
            { Country.IE, new Cache("Ireland", "IE", GDFDataArea.Europe_GDPR) },
            { Country.IM, new Cache("Isle of Man", "IM", GDFDataArea.Europe) },
            { Country.IL, new Cache("Israel", "IL", GDFDataArea.Asia) },
            { Country.IT, new Cache("Italy", "IT", GDFDataArea.Europe_GDPR) },
            { Country.JM, new Cache("Jamaica", "JM", GDFDataArea.NorthAmerica) },
            { Country.JP, new Cache("Japan", "JP", GDFDataArea.Asia_Japan_APPI) },
            { Country.JE, new Cache("Jersey", "JE", GDFDataArea.Europe) },
            { Country.JO, new Cache("Jordan", "JO", GDFDataArea.Asia) },
            { Country.KZ, new Cache("Kazakhstan", "KZ", GDFDataArea.Asia) },
            { Country.KE, new Cache("Kenya", "KE", GDFDataArea.Africa) },
            { Country.KI, new Cache("Kiribati", "KI", GDFDataArea.Oceania) },
            { Country.KP, new Cache("Korea, Democratic People's Republic of", "KP", GDFDataArea.Asia) },
            { Country.KR, new Cache("Korea, Republic of", "KR", GDFDataArea.Asia_SouthKorea_PIPA) },
            { Country.KW, new Cache("Kuwait", "KW", GDFDataArea.Asia) },
            { Country.KG, new Cache("Kyrgyzstan", "KG", GDFDataArea.Asia) },
            { Country.LA, new Cache("Lao People's Democratic Republic", "LA", GDFDataArea.Asia) },
            { Country.LV, new Cache("Latvia", "LV", GDFDataArea.Europe_GDPR) },
            { Country.LB, new Cache("Lebanon", "LB", GDFDataArea.Asia) },
            { Country.LS, new Cache("Lesotho", "LS", GDFDataArea.Africa) },
            { Country.LR, new Cache("Liberia", "LR", GDFDataArea.Africa) },
            { Country.LY, new Cache("Libya", "LY", GDFDataArea.Africa) },
            { Country.LI, new Cache("Liechtenstein", "LI", GDFDataArea.Europe_GDPR) },
            { Country.LT, new Cache("Lithuania", "LT", GDFDataArea.Europe_GDPR) },
            { Country.LU, new Cache("Luxembourg", "LU", GDFDataArea.Europe_GDPR) },
            { Country.MO, new Cache("Macao", "MO", GDFDataArea.Asia_China_PIPL) },
            { Country.MG, new Cache("Madagascar", "MG", GDFDataArea.Africa) },
            { Country.MW, new Cache("Malawi", "MW", GDFDataArea.Africa) },
            { Country.MY, new Cache("Malaysia", "MY", GDFDataArea.Asia) },
            { Country.MV, new Cache("Maldives", "MV", GDFDataArea.Asia) },
            { Country.ML, new Cache("Mali", "ML", GDFDataArea.Africa) },
            { Country.MT, new Cache("Malta", "MT", GDFDataArea.Europe_GDPR) },
            { Country.MH, new Cache("Marshall Islands", "MH", GDFDataArea.Oceania) },
            { Country.MQ, new Cache("Martinique", "MQ", GDFDataArea.Europe_GDPR) },
            { Country.MR, new Cache("Mauritania", "MR", GDFDataArea.Africa) },
            { Country.MU, new Cache("Mauritius", "MU", GDFDataArea.Africa) },
            { Country.YT, new Cache("Mayotte", "YT", GDFDataArea.Europe_GDPR) },
            { Country.MX, new Cache("Mexico", "MX", GDFDataArea.NorthAmerica) },
            { Country.FM, new Cache("Micronesia, Federated States of", "FM", GDFDataArea.Oceania) },
            { Country.MD, new Cache("Moldova, Republic of", "MD", GDFDataArea.Europe) },
            { Country.MC, new Cache("Monaco", "MC", GDFDataArea.Europe_GDPR) },
            { Country.MN, new Cache("Mongolia", "MN", GDFDataArea.Asia) },
            { Country.ME, new Cache("Montenegro", "ME", GDFDataArea.Europe) },
            { Country.MS, new Cache("Montserrat", "MS", GDFDataArea.NorthAmerica) },
            { Country.MA, new Cache("Morocco", "MA", GDFDataArea.Africa) },
            { Country.MZ, new Cache("Mozambique", "MZ", GDFDataArea.Africa) },
            { Country.MM, new Cache("Myanmar", "MM", GDFDataArea.Asia) },
            { Country.NA, new Cache("Namibia", "NA", GDFDataArea.Africa) },
            { Country.NR, new Cache("Nauru", "NR", GDFDataArea.Oceania) },
            { Country.NP, new Cache("Nepal", "NP", GDFDataArea.Asia) },
            { Country.NL, new Cache("Netherlands", "NL", GDFDataArea.Europe_GDPR) },
            { Country.NC, new Cache("New Caledonia", "NC", GDFDataArea.Oceania) },
            { Country.NZ, new Cache("New Zealand", "NZ", GDFDataArea.Oceania_NewZealand) },
            { Country.NI, new Cache("Nicaragua", "NI", GDFDataArea.NorthAmerica) },
            { Country.NE, new Cache("Niger", "NE", GDFDataArea.Africa) },
            { Country.NG, new Cache("Nigeria", "NG", GDFDataArea.Africa_Nigeria_NDPR) },
            { Country.NU, new Cache("Niue", "NU", GDFDataArea.Oceania) },
            { Country.NF, new Cache("Norfolk Island", "NF", GDFDataArea.Oceania) },
            { Country.MP, new Cache("Northern Mariana Islands", "MP", GDFDataArea.NorthAmerica) },
            { Country.MK, new Cache("North Macedonia", "MK", GDFDataArea.Europe) },
            { Country.NO, new Cache("Norway", "NO", GDFDataArea.Europe_GDPR) },
            { Country.OM, new Cache("Oman", "OM", GDFDataArea.Asia) },
            { Country.PK, new Cache("Pakistan", "PK", GDFDataArea.Asia) },
            { Country.PW, new Cache("Palau", "PW", GDFDataArea.Oceania) },
            { Country.PS, new Cache("Palestine, State of", "PS", GDFDataArea.Asia) },
            { Country.PA, new Cache("Panama", "PA", GDFDataArea.NorthAmerica) },
            { Country.PG, new Cache("Papua New Guinea", "PG", GDFDataArea.Oceania) },
            { Country.PY, new Cache("Paraguay", "PY", GDFDataArea.SouthAmerica) },
            { Country.PE, new Cache("Peru", "PE", GDFDataArea.SouthAmerica) },
            { Country.PH, new Cache("Philippines", "PH", GDFDataArea.Asia) },
            { Country.PN, new Cache("Pitcairn", "PN", GDFDataArea.Oceania) },
            { Country.PL, new Cache("Poland", "PL", GDFDataArea.Europe_GDPR) },
            { Country.PT, new Cache("Portugal", "PT", GDFDataArea.Europe_GDPR) },
            { Country.PR, new Cache("Puerto Rico", "PR", GDFDataArea.NorthAmerica) },
            { Country.QA, new Cache("Qatar", "QA", GDFDataArea.Asia) },
            { Country.RE, new Cache("Réunion", "RE", GDFDataArea.Europe_GDPR) },
            { Country.RO, new Cache("Romania", "RO", GDFDataArea.Europe_GDPR) },
            { Country.RU, new Cache("Russian Federation", "RU", GDFDataArea.Asia_Russia) },
            { Country.RW, new Cache("Rwanda", "RW", GDFDataArea.Africa) },
            { Country.BL, new Cache("Saint Barthélemy", "BL", GDFDataArea.Europe_GDPR) },
            { Country.SH, new Cache("Saint Helena, Ascension and Tristan da Cunha", "SH", GDFDataArea.Africa) },
            { Country.KN, new Cache("Saint Kitts and Nevis", "KN", GDFDataArea.NorthAmerica) },
            { Country.LC, new Cache("Saint Lucia", "LC", GDFDataArea.NorthAmerica) },
            { Country.MF, new Cache("Saint Martin (French part)", "MF", GDFDataArea.Europe_GDPR) },
            { Country.PM, new Cache("Saint Pierre and Miquelon", "PM", GDFDataArea.NorthAmerica) },
            { Country.VC, new Cache("Saint Vincent and the Grenadines", "VC", GDFDataArea.NorthAmerica) },
            { Country.WS, new Cache("Samoa", "WS", GDFDataArea.Oceania) },
            { Country.SM, new Cache("San Marino", "SM", GDFDataArea.Europe_GDPR) },
            { Country.ST, new Cache("Sao Tome and Principe", "ST", GDFDataArea.Africa) },
            { Country.SA, new Cache("Saudi Arabia", "SA", GDFDataArea.Asia) },
            { Country.SN, new Cache("Senegal", "SN", GDFDataArea.Africa) },
            { Country.RS, new Cache("Serbia", "RS", GDFDataArea.Europe) },
            { Country.SC, new Cache("Seychelles", "SC", GDFDataArea.Africa) },
            { Country.SL, new Cache("Sierra Leone", "SL", GDFDataArea.Africa) },
            { Country.SG, new Cache("Singapore", "SG", GDFDataArea.Asia_Singapore_PDPA) },
            { Country.SX, new Cache("Sint Maarten (Dutch part)", "SX", GDFDataArea.NorthAmerica) },
            { Country.SK, new Cache("Slovakia", "SK", GDFDataArea.Europe_GDPR) },
            { Country.SI, new Cache("Slovenia", "SI", GDFDataArea.Europe_GDPR) },
            { Country.SB, new Cache("Solomon Islands", "SB", GDFDataArea.Oceania) },
            { Country.SO, new Cache("Somalia", "SO", GDFDataArea.Africa) },
            { Country.ZA, new Cache("South Africa", "ZA", GDFDataArea.Africa_SouthAfrica_POPIA) },
            { Country.GS, new Cache("South Georgia and the South Sandwich Islands", "GS", GDFDataArea.Antarctica) },
            { Country.SS, new Cache("South Sudan", "SS", GDFDataArea.Africa) },
            { Country.ES, new Cache("Spain", "ES", GDFDataArea.Europe_GDPR) },
            { Country.LK, new Cache("Sri Lanka", "LK", GDFDataArea.Asia) },
            { Country.SD, new Cache("Sudan", "SD", GDFDataArea.Africa) },
            { Country.SR, new Cache("Suriname", "SR", GDFDataArea.SouthAmerica) },
            { Country.SJ, new Cache("Svalbard and Jan Mayen", "SJ", GDFDataArea.Europe_GDPR) },
            { Country.SE, new Cache("Sweden", "SE", GDFDataArea.Europe_GDPR) },
            { Country.CH, new Cache("Switzerland", "CH", GDFDataArea.Europe) },
            { Country.SY, new Cache("Syrian Arab Republic", "SY", GDFDataArea.Asia) },
            { Country.TW, new Cache("Taiwan, Province of China", "TW", GDFDataArea.Asia) },
            { Country.TJ, new Cache("Tajikistan", "TJ", GDFDataArea.Asia) },
            { Country.TZ, new Cache("Tanzania, United Republic of", "TZ", GDFDataArea.Africa) },
            { Country.TH, new Cache("Thailand", "TH", GDFDataArea.Asia) },
            { Country.TL, new Cache("Timor-Leste", "TL", GDFDataArea.Asia) },
            { Country.TG, new Cache("Togo", "TG", GDFDataArea.Africa) },
            { Country.TK, new Cache("Tokelau", "TK", GDFDataArea.Oceania) },
            { Country.TO, new Cache("Tonga", "TO", GDFDataArea.Oceania) },
            { Country.TT, new Cache("Trinidad and Tobago", "TT", GDFDataArea.NorthAmerica) },
            { Country.TN, new Cache("Tunisia", "TN", GDFDataArea.Africa) },
            { Country.TR, new Cache("Turkey", "TR", GDFDataArea.Europe) },
            { Country.TM, new Cache("Turkmenistan", "TM", GDFDataArea.Asia) },
            { Country.TC, new Cache("Turks and Caicos Islands", "TC", GDFDataArea.NorthAmerica) },
            { Country.TV, new Cache("Tuvalu", "TV", GDFDataArea.Oceania) },
            { Country.UG, new Cache("Uganda", "UG", GDFDataArea.Africa) },
            { Country.UA, new Cache("Ukraine", "UA", GDFDataArea.Europe) },
            { Country.AE, new Cache("United Arab Emirates", "AE", GDFDataArea.Asia) },
            { Country.GB, new Cache("United Kingdom of Great Britain and Northern Ireland", "GB", GDFDataArea.Europe) },
            { Country.US, new Cache("United States of America", "US", GDFDataArea.NorthAmerica_California_CCPA) },
            { Country.UM, new Cache("United States Minor Outlying Islands", "UM", GDFDataArea.NorthAmerica) },
            { Country.UY, new Cache("Uruguay", "UY", GDFDataArea.SouthAmerica) },
            { Country.UZ, new Cache("Uzbekistan", "UZ", GDFDataArea.Asia) },
            { Country.VU, new Cache("Vanuatu", "VU", GDFDataArea.Oceania) },
            { Country.VE, new Cache("Venezuela, Bolivarian Republic of", "VE", GDFDataArea.SouthAmerica) },
            { Country.VN, new Cache("Viet Nam", "VN", GDFDataArea.Asia) },
            { Country.VG, new Cache("Virgin Islands, British", "VG", GDFDataArea.NorthAmerica) },
            { Country.VI, new Cache("Virgin Islands, U.S.", "VI", GDFDataArea.NorthAmerica) },
            { Country.WF, new Cache("Wallis and Futuna", "WF", GDFDataArea.Oceania) },
            { Country.EH, new Cache("Western Sahara", "EH", GDFDataArea.Africa) },
            { Country.YE, new Cache("Yemen", "YE", GDFDataArea.Asia) },
            { Country.ZM, new Cache("Zambia", "ZM", GDFDataArea.Africa) },
            { Country.ZW, new Cache("Zimbabwe", "ZW", GDFDataArea.Africa) },
            { Country.AX, new Cache("Åland Islands", "AX", GDFDataArea.Europe_GDPR) },
        };

        #endregion

        #region Static methods

        static public string ToDisplayString(this Country self)
        {
            if (cache.TryGetValue(self, out Cache result))
            {
                return result.name;
            }

            return null;
        }

        static public string ToCodeString(this Country self)
        {
            if (cache.TryGetValue(self, out Cache result))
            {
                return result.code;
            }

            return null;
        }

        static public string ToIntString(this Country self)
        {
            return ((int)self).ToString();
        }

        static public GDFDataArea GetArea(this Country self)
        {
            if (cache.TryGetValue(self, out Cache result))
            {
                return result.area;
            }

            return GDFDataArea.Unknown;
        }

        #endregion
    }
}