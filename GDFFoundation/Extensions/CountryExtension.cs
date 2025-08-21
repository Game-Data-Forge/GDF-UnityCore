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
            public Continent continent;
            public DataRegion region;

            public Cache(string name, string code, Continent continent)
                : this(name, code, continent, null)
            {

            }

            public Cache(string name, string code, Continent continent, DataRegion? region)
            {
                this.name = name;
                this.code = code;
                this.continent = continent;
                this.region = region ?? (DataRegion)continent;
            }
        }

        #region Static fields and properties

        internal static readonly Dictionary<Country, Cache> cache = new Dictionary<Country, Cache>
        {
            { Country.None, new Cache("None", "None", Continent.Unknown) },

            { Country.AF, new Cache("Afghanistan",                                          "AF", Continent.Asia) },
            { Country.AL, new Cache("Albania",                                              "AL", Continent.Europe) },
            { Country.DZ, new Cache("Algeria",                                              "DZ", Continent.Africa) },
            { Country.AS, new Cache("American Samoa",                                       "AS", Continent.NorthAmerica) },
            { Country.AD, new Cache("Andorra",                                              "AD", Continent.Europe) },
            { Country.AO, new Cache("Angola",                                               "AO", Continent.Africa) },
            { Country.AI, new Cache("Anguilla",                                             "AI", Continent.NorthAmerica) },
            { Country.AQ, new Cache("Antarctica",                                           "AQ", Continent.Antarctica) },
            { Country.AG, new Cache("Antigua and Barbuda",                                  "AG", Continent.NorthAmerica) },
            { Country.AR, new Cache("Argentina",                                            "AR", Continent.SouthAmerica, DataRegion.SouthAmerica_Argentina_LPDP) },
            { Country.AM, new Cache("Armenia",                                              "AM", Continent.Asia) },
            { Country.AW, new Cache("Aruba",                                                "AW", Continent.NorthAmerica) },
            { Country.AU, new Cache("Australia",                                            "AU", Continent.Oceania, DataRegion.Oceania_Australia) },
            { Country.AT, new Cache("Austria",                                              "AT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.AZ, new Cache("Azerbaijan",                                           "AZ", Continent.Asia) },
            { Country.BS, new Cache("Bahamas",                                              "BS", Continent.NorthAmerica) },
            { Country.BH, new Cache("Bahrain",                                              "BH", Continent.Asia) },
            { Country.BD, new Cache("Bangladesh",                                           "BD", Continent.Asia) },
            { Country.BB, new Cache("Barbados",                                             "BB", Continent.NorthAmerica) },
            { Country.BY, new Cache("Belarus",                                              "BY", Continent.Europe) },
            { Country.BE, new Cache("Belgium",                                              "BE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.BZ, new Cache("Belize",                                               "BZ", Continent.NorthAmerica) },
            { Country.BJ, new Cache("Benin",                                                "BJ", Continent.Africa) },
            { Country.BM, new Cache("Bermuda",                                              "BM", Continent.NorthAmerica) },
            { Country.BT, new Cache("Bhutan",                                               "BT", Continent.Asia) },
            { Country.BO, new Cache("Bolivia, Plurinational State of",                      "BO", Continent.SouthAmerica) },
            { Country.BQ, new Cache("Bonaire, Sint Eustatius and Saba",                     "BQ", Continent.NorthAmerica) },
            { Country.BA, new Cache("Bosnia and Herzegovina",                               "BA", Continent.Europe) },
            { Country.BW, new Cache("Botswana",                                             "BW", Continent.Africa) },
            { Country.BV, new Cache("Bouvet Island",                                        "BV", Continent.Antarctica) },
            { Country.BR, new Cache("Brazil",                                               "BR", Continent.SouthAmerica, DataRegion.SouthAmerica_Brazil_LGPD) },
            { Country.IO, new Cache("British Indian Ocean Territory",                       "IO", Continent.Africa) },
            { Country.BN, new Cache("Brunei Darussalam",                                    "BN", Continent.Asia) },
            { Country.BG, new Cache("Bulgaria",                                             "BG", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.BF, new Cache("Burkina Faso",                                         "BF", Continent.Africa) },
            { Country.BI, new Cache("Burundi",                                              "BI", Continent.Africa) },
            { Country.CV, new Cache("Cabo Verde",                                           "CV", Continent.Africa) },
            { Country.KH, new Cache("Cambodia",                                             "KH", Continent.Asia) },
            { Country.CM, new Cache("Cameroon",                                             "CM", Continent.Africa) },
            { Country.CA, new Cache("Canada",                                               "CA", Continent.NorthAmerica, DataRegion.NorthAmerica_Canada_PIPEDA) },
            { Country.KY, new Cache("Cayman Islands",                                       "KY", Continent.NorthAmerica) },
            { Country.CF, new Cache("Central African Republic",                             "CF", Continent.Africa) },
            { Country.TD, new Cache("Chad",                                                 "TD", Continent.Africa) },
            { Country.CL, new Cache("Chile",                                                "CL", Continent.SouthAmerica) },
            { Country.CN, new Cache("China",                                                "CN", Continent.Asia, DataRegion.Asia_China_PIPL) },
            { Country.CX, new Cache("Christmas Island",                                     "CX", Continent.Oceania, DataRegion.Oceania_Australia) },
            { Country.CC, new Cache("Cocos (Keeling) Islands",                              "CC", Continent.Oceania, DataRegion.Oceania_Australia) },
            { Country.CO, new Cache("Colombia",                                             "CO", Continent.SouthAmerica) },
            { Country.KM, new Cache("Comoros",                                              "KM", Continent.Africa) },
            { Country.CG, new Cache("Congo",                                                "CG", Continent.Africa) },
            { Country.CD, new Cache("Congo, the Democratic Republic of the",                "CD", Continent.Africa) },
            { Country.CK, new Cache("Cook Islands",                                         "CK", Continent.Oceania, DataRegion.Oceania_NewZealand) },
            { Country.CR, new Cache("Costa Rica",                                           "CR", Continent.NorthAmerica) },
            { Country.CI, new Cache("Côte d'Ivoire",                                        "CI", Continent.Africa) },
            { Country.HR, new Cache("Croatia",                                              "HR", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.CU, new Cache("Cuba",                                                 "CU", Continent.NorthAmerica) },
            { Country.CW, new Cache("Curaçao",                                              "CW", Continent.NorthAmerica) },
            { Country.CY, new Cache("Cyprus",                                               "CY", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.CZ, new Cache("Czechia",                                              "CZ", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.DK, new Cache("Denmark",                                              "DK", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.DJ, new Cache("Djibouti",                                             "DJ", Continent.Africa) },
            { Country.DM, new Cache("Dominica",                                             "DM", Continent.NorthAmerica) },
            { Country.DO, new Cache("Dominican Republic",                                   "DO", Continent.NorthAmerica) },
            { Country.EC, new Cache("Ecuador",                                              "EC", Continent.SouthAmerica) },
            { Country.EG, new Cache("Egypt",                                                "EG", Continent.Africa) },
            { Country.SV, new Cache("El Salvador",                                          "SV", Continent.NorthAmerica) },
            { Country.GQ, new Cache("Equatorial Guinea",                                    "GQ", Continent.Africa) },
            { Country.ER, new Cache("Eritrea",                                              "ER", Continent.Africa) },
            { Country.EE, new Cache("Estonia",                                              "EE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.SZ, new Cache("Eswatini",                                             "SZ", Continent.Africa) },
            { Country.ET, new Cache("Ethiopia",                                             "ET", Continent.Africa) },
            { Country.FK, new Cache("Falkland Islands (Malvinas)",                          "FK", Continent.SouthAmerica) },
            { Country.FO, new Cache("Faroe Islands",                                        "FO", Continent.Europe) },
            { Country.FJ, new Cache("Fiji",                                                 "FJ", Continent.Oceania) },
            { Country.FI, new Cache("Finland",                                              "FI", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.FR, new Cache("France",                                               "FR", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.GF, new Cache("French Guiana",                                        "GF", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.PF, new Cache("French Polynesia",                                     "PF", Continent.Oceania) },
            { Country.TF, new Cache("French Southern Territories",                          "TF", Continent.Antarctica) },
            { Country.GA, new Cache("Gabon",                                                "GA", Continent.Africa) },
            { Country.GM, new Cache("Gambia",                                               "GM", Continent.Africa) },
            { Country.GE, new Cache("Georgia",                                              "GE", Continent.Asia) },
            { Country.DE, new Cache("Germany",                                              "DE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.GH, new Cache("Ghana",                                                "GH", Continent.Africa) },
            { Country.GI, new Cache("Gibraltar",                                            "GI", Continent.Europe) },
            { Country.GR, new Cache("Greece",                                               "GR", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.GL, new Cache("Greenland",                                            "GL", Continent.NorthAmerica) },
            { Country.GD, new Cache("Grenada",                                              "GD", Continent.NorthAmerica) },
            { Country.GP, new Cache("Guadeloupe",                                           "GP", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.GU, new Cache("Guam",                                                 "GU", Continent.NorthAmerica) },
            { Country.GT, new Cache("Guatemala",                                            "GT", Continent.NorthAmerica) },
            { Country.GG, new Cache("Guernsey",                                             "GG", Continent.Europe) },
            { Country.GN, new Cache("Guinea",                                               "GN", Continent.Africa) },
            { Country.GW, new Cache("Guinea-Bissau",                                        "GW", Continent.Africa) },
            { Country.GY, new Cache("Guyana",                                               "GY", Continent.SouthAmerica) },
            { Country.HT, new Cache("Haiti",                                                "HT", Continent.NorthAmerica) },
            { Country.HM, new Cache("Heard Island and McDonald Islands",                    "HM", Continent.Antarctica) },
            { Country.VA, new Cache("Holy See",                                             "VA", Continent.Europe) },
            { Country.HN, new Cache("Honduras",                                             "HN", Continent.NorthAmerica) },
            { Country.HK, new Cache("Hong Kong",                                            "HK", Continent.Asia) },
            { Country.HU, new Cache("Hungary",                                              "HU", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.IS, new Cache("Iceland",                                              "IS", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.IN, new Cache("India",                                                "IN", Continent.Asia, DataRegion.Asia_India_PDPB) },
            { Country.ID, new Cache("Indonesia",                                            "ID", Continent.Asia) },
            { Country.IR, new Cache("Iran, Islamic Republic of",                            "IR", Continent.Asia) },
            { Country.IQ, new Cache("Iraq",                                                 "IQ", Continent.Asia) },
            { Country.IE, new Cache("Ireland",                                              "IE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.IM, new Cache("Isle of Man",                                          "IM", Continent.Europe) },
            { Country.IL, new Cache("Israel",                                               "IL", Continent.Asia) },
            { Country.IT, new Cache("Italy",                                                "IT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.JM, new Cache("Jamaica",                                              "JM", Continent.NorthAmerica) },
            { Country.JP, new Cache("Japan",                                                "JP", Continent.Asia, DataRegion.Asia_Japan_APPI) },
            { Country.JE, new Cache("Jersey",                                               "JE", Continent.Europe) },
            { Country.JO, new Cache("Jordan",                                               "JO", Continent.Asia) },
            { Country.KZ, new Cache("Kazakhstan",                                           "KZ", Continent.Asia) },
            { Country.KE, new Cache("Kenya",                                                "KE", Continent.Africa) },
            { Country.KI, new Cache("Kiribati",                                             "KI", Continent.Oceania) },
            { Country.KP, new Cache("Korea, Democratic People's Republic of",               "KP", Continent.Asia) },
            { Country.KR, new Cache("Korea, Republic of",                                   "KR", Continent.Asia, DataRegion.Asia_SouthKorea_PIPA) },
            { Country.KW, new Cache("Kuwait",                                               "KW", Continent.Asia) },
            { Country.KG, new Cache("Kyrgyzstan",                                           "KG", Continent.Asia) },
            { Country.LA, new Cache("Lao People's Democratic Republic",                     "LA", Continent.Asia) },
            { Country.LV, new Cache("Latvia",                                               "LV", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.LB, new Cache("Lebanon",                                              "LB", Continent.Asia) },
            { Country.LS, new Cache("Lesotho",                                              "LS", Continent.Africa) },
            { Country.LR, new Cache("Liberia",                                              "LR", Continent.Africa) },
            { Country.LY, new Cache("Libya",                                                "LY", Continent.Africa) },
            { Country.LI, new Cache("Liechtenstein",                                        "LI", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.LT, new Cache("Lithuania",                                            "LT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.LU, new Cache("Luxembourg",                                           "LU", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.MO, new Cache("Macao",                                                "MO", Continent.Asia, DataRegion.Asia_China_PIPL) },
            { Country.MG, new Cache("Madagascar",                                           "MG", Continent.Africa) },
            { Country.MW, new Cache("Malawi",                                               "MW", Continent.Africa) },
            { Country.MY, new Cache("Malaysia",                                             "MY", Continent.Asia) },
            { Country.MV, new Cache("Maldives",                                             "MV", Continent.Asia) },
            { Country.ML, new Cache("Mali",                                                 "ML", Continent.Africa) },
            { Country.MT, new Cache("Malta",                                                "MT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.MH, new Cache("Marshall Islands",                                     "MH", Continent.Oceania) },
            { Country.MQ, new Cache("Martinique",                                           "MQ", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.MR, new Cache("Mauritania",                                           "MR", Continent.Africa) },
            { Country.MU, new Cache("Mauritius",                                            "MU", Continent.Africa) },
            { Country.YT, new Cache("Mayotte",                                              "YT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.MX, new Cache("Mexico",                                               "MX", Continent.NorthAmerica) },
            { Country.FM, new Cache("Micronesia, Federated States of",                      "FM", Continent.Oceania) },
            { Country.MD, new Cache("Moldova, Republic of",                                 "MD", Continent.Europe) },
            { Country.MC, new Cache("Monaco",                                               "MC", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.MN, new Cache("Mongolia",                                             "MN", Continent.Asia) },
            { Country.ME, new Cache("Montenegro",                                           "ME", Continent.Europe) },
            { Country.MS, new Cache("Montserrat",                                           "MS", Continent.NorthAmerica) },
            { Country.MA, new Cache("Morocco",                                              "MA", Continent.Africa) },
            { Country.MZ, new Cache("Mozambique",                                           "MZ", Continent.Africa) },
            { Country.MM, new Cache("Myanmar",                                              "MM", Continent.Asia) },
            { Country.NA, new Cache("Namibia",                                              "NA", Continent.Africa) },
            { Country.NR, new Cache("Nauru",                                                "NR", Continent.Oceania) },
            { Country.NP, new Cache("Nepal",                                                "NP", Continent.Asia) },
            { Country.NL, new Cache("Netherlands",                                          "NL", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.NC, new Cache("New Caledonia",                                        "NC", Continent.Oceania) },
            { Country.NZ, new Cache("New Zealand",                                          "NZ", Continent.Oceania, DataRegion.Oceania_NewZealand) },
            { Country.NI, new Cache("Nicaragua",                                            "NI", Continent.NorthAmerica) },
            { Country.NE, new Cache("Niger",                                                "NE", Continent.Africa) },
            { Country.NG, new Cache("Nigeria",                                              "NG", Continent.Africa, DataRegion.Africa_Nigeria_NDPR) },
            { Country.NU, new Cache("Niue",                                                 "NU", Continent.Oceania) },
            { Country.NF, new Cache("Norfolk Island",                                       "NF", Continent.Oceania) },
            { Country.MP, new Cache("Northern Mariana Islands",                             "MP", Continent.NorthAmerica) },
            { Country.MK, new Cache("North Macedonia",                                      "MK", Continent.Europe) },
            { Country.NO, new Cache("Norway",                                               "NO", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.OM, new Cache("Oman",                                                 "OM", Continent.Asia) },
            { Country.PK, new Cache("Pakistan",                                             "PK", Continent.Asia) },
            { Country.PW, new Cache("Palau",                                                "PW", Continent.Oceania) },
            { Country.PS, new Cache("Palestine, State of",                                  "PS", Continent.Asia) },
            { Country.PA, new Cache("Panama",                                               "PA", Continent.NorthAmerica) },
            { Country.PG, new Cache("Papua New Guinea",                                     "PG", Continent.Oceania) },
            { Country.PY, new Cache("Paraguay",                                             "PY", Continent.SouthAmerica) },
            { Country.PE, new Cache("Peru",                                                 "PE", Continent.SouthAmerica) },
            { Country.PH, new Cache("Philippines",                                          "PH", Continent.Asia) },
            { Country.PN, new Cache("Pitcairn",                                             "PN", Continent.Oceania) },
            { Country.PL, new Cache("Poland",                                               "PL", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.PT, new Cache("Portugal",                                             "PT", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.PR, new Cache("Puerto Rico",                                          "PR", Continent.NorthAmerica) },
            { Country.QA, new Cache("Qatar",                                                "QA", Continent.Asia) },
            { Country.RE, new Cache("Réunion",                                              "RE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.RO, new Cache("Romania",                                              "RO", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.RU, new Cache("Russian Federation",                                   "RU", Continent.Asia, DataRegion.Asia_Russia) },
            { Country.RW, new Cache("Rwanda",                                               "RW", Continent.Africa) },
            { Country.BL, new Cache("Saint Barthélemy",                                     "BL", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.SH, new Cache("Saint Helena, Ascension and Tristan da Cunha",         "SH", Continent.Africa) },
            { Country.KN, new Cache("Saint Kitts and Nevis",                                "KN", Continent.NorthAmerica) },
            { Country.LC, new Cache("Saint Lucia",                                          "LC", Continent.NorthAmerica) },
            { Country.MF, new Cache("Saint Martin (French part)",                           "MF", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.PM, new Cache("Saint Pierre and Miquelon",                            "PM", Continent.NorthAmerica) },
            { Country.VC, new Cache("Saint Vincent and the Grenadines",                     "VC", Continent.NorthAmerica) },
            { Country.WS, new Cache("Samoa",                                                "WS", Continent.Oceania) },
            { Country.SM, new Cache("San Marino",                                           "SM", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.ST, new Cache("Sao Tome and Principe",                                "ST", Continent.Africa) },
            { Country.SA, new Cache("Saudi Arabia",                                         "SA", Continent.Asia) },
            { Country.SN, new Cache("Senegal",                                              "SN", Continent.Africa) },
            { Country.RS, new Cache("Serbia",                                               "RS", Continent.Europe) },
            { Country.SC, new Cache("Seychelles",                                           "SC", Continent.Africa) },
            { Country.SL, new Cache("Sierra Leone",                                         "SL", Continent.Africa) },
            { Country.SG, new Cache("Singapore",                                            "SG", Continent.Asia, DataRegion.Asia_Singapore_PDPA) },
            { Country.SX, new Cache("Sint Maarten (Dutch part)",                            "SX", Continent.NorthAmerica) },
            { Country.SK, new Cache("Slovakia",                                             "SK", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.SI, new Cache("Slovenia",                                             "SI", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.SB, new Cache("Solomon Islands",                                      "SB", Continent.Oceania) },
            { Country.SO, new Cache("Somalia",                                              "SO", Continent.Africa) },
            { Country.ZA, new Cache("South Africa",                                         "ZA", Continent.Africa, DataRegion.Africa_SouthAfrica_POPIA) },
            { Country.GS, new Cache("South Georgia and the South Sandwich Islands",         "GS", Continent.Antarctica) },
            { Country.SS, new Cache("South Sudan",                                          "SS", Continent.Africa) },
            { Country.ES, new Cache("Spain",                                                "ES", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.LK, new Cache("Sri Lanka",                                            "LK", Continent.Asia) },
            { Country.SD, new Cache("Sudan",                                                "SD", Continent.Africa) },
            { Country.SR, new Cache("Suriname",                                             "SR", Continent.SouthAmerica) },
            { Country.SJ, new Cache("Svalbard and Jan Mayen",                               "SJ", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.SE, new Cache("Sweden",                                               "SE", Continent.Europe, DataRegion.Europe_GDPR) },
            { Country.CH, new Cache("Switzerland",                                          "CH", Continent.Europe) },
            { Country.SY, new Cache("Syrian Arab Republic",                                 "SY", Continent.Asia) },
            { Country.TW, new Cache("Taiwan, Province of China",                            "TW", Continent.Asia) },
            { Country.TJ, new Cache("Tajikistan",                                           "TJ", Continent.Asia) },
            { Country.TZ, new Cache("Tanzania, United Republic of",                         "TZ", Continent.Africa) },
            { Country.TH, new Cache("Thailand",                                             "TH", Continent.Asia) },
            { Country.TL, new Cache("Timor-Leste",                                          "TL", Continent.Asia) },
            { Country.TG, new Cache("Togo",                                                 "TG", Continent.Africa) },
            { Country.TK, new Cache("Tokelau",                                              "TK", Continent.Oceania) },
            { Country.TO, new Cache("Tonga",                                                "TO", Continent.Oceania) },
            { Country.TT, new Cache("Trinidad and Tobago",                                  "TT", Continent.NorthAmerica) },
            { Country.TN, new Cache("Tunisia",                                              "TN", Continent.Africa) },
            { Country.TR, new Cache("Turkey",                                               "TR", Continent.Europe) },
            { Country.TM, new Cache("Turkmenistan",                                         "TM", Continent.Asia) },
            { Country.TC, new Cache("Turks and Caicos Islands",                             "TC", Continent.NorthAmerica) },
            { Country.TV, new Cache("Tuvalu",                                               "TV", Continent.Oceania) },
            { Country.UG, new Cache("Uganda",                                               "UG", Continent.Africa) },
            { Country.UA, new Cache("Ukraine",                                              "UA", Continent.Europe) },
            { Country.AE, new Cache("United Arab Emirates",                                 "AE", Continent.Asia) },
            { Country.GB, new Cache("United Kingdom of Great Britain and Northern Ireland", "GB", Continent.Europe) },
            { Country.US, new Cache("United States of America",                             "US", Continent.NorthAmerica, DataRegion.NorthAmerica_California_CCPA) },
            { Country.UM, new Cache("United States Minor Outlying Islands",                 "UM", Continent.NorthAmerica) },
            { Country.UY, new Cache("Uruguay",                                              "UY", Continent.SouthAmerica) },
            { Country.UZ, new Cache("Uzbekistan",                                           "UZ", Continent.Asia) },
            { Country.VU, new Cache("Vanuatu",                                              "VU", Continent.Oceania) },
            { Country.VE, new Cache("Venezuela, Bolivarian Republic of",                    "VE", Continent.SouthAmerica) },
            { Country.VN, new Cache("Viet Nam",                                             "VN", Continent.Asia) },
            { Country.VG, new Cache("Virgin Islands, British",                              "VG", Continent.NorthAmerica) },
            { Country.VI, new Cache("Virgin Islands, U.S.",                                 "VI", Continent.NorthAmerica) },
            { Country.WF, new Cache("Wallis and Futuna",                                    "WF", Continent.Oceania) },
            { Country.EH, new Cache("Western Sahara",                                       "EH", Continent.Africa) },
            { Country.YE, new Cache("Yemen",                                                "YE", Continent.Asia) },
            { Country.ZM, new Cache("Zambia",                                               "ZM", Continent.Africa) },
            { Country.ZW, new Cache("Zimbabwe",                                             "ZW", Continent.Africa) },
            { Country.AX, new Cache("Åland Islands",                                        "AX", Continent.Europe, DataRegion.Europe_GDPR) },
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

        static public DataRegion GetRegion(this Country self)
        {
            if (cache.TryGetValue(self, out Cache result))
            {
                return result.region;
            }

            return DataRegion.Unknown;
        }

        static public Continent GetContinent(this Country self)
        {
            if (cache.TryGetValue(self, out Cache result))
            {
                return result.continent;
            }

            return Continent.Unknown;
        }

        #endregion
    }
}