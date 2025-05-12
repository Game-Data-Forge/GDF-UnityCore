using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class that provides ISO country codes and related information.
    /// </summary>
    public class Country
    {

        /// <summary>
        /// Represents a collection of objects that can be accessed by index and provides methods to search, sort, and manipulate the list.
        /// </summary>
        public static readonly Country[] COUNTRIES = new[]
        {
            new Country("Afghanistan", "AF", "004", GDFDataArea.Asia),
            new Country("Albania", "AL", "008", GDFDataArea.Europe),
            new Country("Algeria", "DZ", "012", GDFDataArea.Africa),
            new Country("American Samoa", "AS", "016", GDFDataArea.NorthAmerica), // US territory
            new Country("Andorra", "AD", "020", GDFDataArea.Europe),
            new Country("Angola", "AO", "024", GDFDataArea.Africa),
            new Country("Anguilla", "AI", "660", GDFDataArea.NorthAmerica),
            new Country("Antarctica", "AQ", "010", GDFDataArea.Antarctica),
            new Country("Antigua and Barbuda", "AG", "028", GDFDataArea.NorthAmerica),
            new Country("Argentina", "AR", "032", GDFDataArea.SouthAmerica_Argentina_LPDP),
            new Country("Armenia", "AM", "051", GDFDataArea.Asia),
            new Country("Aruba", "AW", "533", GDFDataArea.NorthAmerica),
            new Country("Australia", "AU", "036", GDFDataArea.Oceania_Australia),
            new Country("Austria", "AT", "040", GDFDataArea.Europe_GDPR),
            new Country("Azerbaijan", "AZ", "031", GDFDataArea.Asia),
            new Country("Bahamas", "BS", "044", GDFDataArea.NorthAmerica),
            new Country("Bahrain", "BH", "048", GDFDataArea.Asia),
            new Country("Bangladesh", "BD", "050", GDFDataArea.Asia),
            new Country("Barbados", "BB", "052", GDFDataArea.NorthAmerica),
            new Country("Belarus", "BY", "112", GDFDataArea.Europe),
            new Country("Belgium", "BE", "056", GDFDataArea.Europe_GDPR),
            new Country("Belize", "BZ", "084", GDFDataArea.NorthAmerica),
            new Country("Benin", "BJ", "204", GDFDataArea.Africa),
            new Country("Bermuda", "BM", "060", GDFDataArea.NorthAmerica),
            new Country("Bhutan", "BT", "064", GDFDataArea.Asia),
            new Country("Bolivia, Plurinational State of", "BO", "068", GDFDataArea.SouthAmerica),
            new Country("Bonaire, Sint Eustatius and Saba", "BQ", "535", GDFDataArea.NorthAmerica),
            new Country("Bosnia and Herzegovina", "BA", "070", GDFDataArea.Europe),
            new Country("Botswana", "BW", "072", GDFDataArea.Africa),
            new Country("Bouvet Island", "BV", "074", GDFDataArea.Antarctica),
            new Country("Brazil", "BR", "076", GDFDataArea.SouthAmerica_Brazil_LGPD),
            new Country("British Indian Ocean Territory", "IO", "086", GDFDataArea.Africa),
            new Country("Brunei Darussalam", "BN", "096", GDFDataArea.Asia),
            new Country("Bulgaria", "BG", "100", GDFDataArea.Europe_GDPR),
            new Country("Burkina Faso", "BF", "854", GDFDataArea.Africa),
            new Country("Burundi", "BI", "108", GDFDataArea.Africa),
            new Country("Cabo Verde", "CV", "132", GDFDataArea.Africa),
            new Country("Cambodia", "KH", "116", GDFDataArea.Asia),
            new Country("Cameroon", "CM", "120", GDFDataArea.Africa),
            new Country("Canada", "CA", "124", GDFDataArea.NorthAmerica_Canada_PIPEDA),
            new Country("Cayman Islands", "KY", "136", GDFDataArea.NorthAmerica),
            new Country("Central African Republic", "CF", "140", GDFDataArea.Africa),
            new Country("Chad", "TD", "148", GDFDataArea.Africa),
            new Country("Chile", "CL", "152", GDFDataArea.SouthAmerica),
            new Country("China", "CN", "156", GDFDataArea.Asia_China_PIPL),
            new Country("Christmas Island", "CX", "162", GDFDataArea.Oceania_Australia),
            new Country("Cocos (Keeling) Islands", "CC", "166", GDFDataArea.Oceania_Australia),
            new Country("Colombia", "CO", "170", GDFDataArea.SouthAmerica),
            new Country("Comoros", "KM", "174", GDFDataArea.Africa),
            new Country("Congo", "CG", "178", GDFDataArea.Africa),
            new Country("Congo, the Democratic Republic of the", "CD", "180", GDFDataArea.Africa),
            new Country("Cook Islands", "CK", "184", GDFDataArea.Oceania_NewZealand),
            new Country("Costa Rica", "CR", "188", GDFDataArea.NorthAmerica),
            new Country("Côte d'Ivoire", "CI", "384", GDFDataArea.Africa),
            new Country("Croatia", "HR", "191", GDFDataArea.Europe_GDPR),
            new Country("Cuba", "CU", "192", GDFDataArea.NorthAmerica),
            new Country("Curaçao", "CW", "531", GDFDataArea.NorthAmerica),
            new Country("Cyprus", "CY", "196", GDFDataArea.Europe_GDPR),
            new Country("Czechia", "CZ", "203", GDFDataArea.Europe_GDPR),
            new Country("Denmark", "DK", "208", GDFDataArea.Europe_GDPR),
            new Country("Djibouti", "DJ", "262", GDFDataArea.Africa),
            new Country("Dominica", "DM", "212", GDFDataArea.NorthAmerica),
            new Country("Dominican Republic", "DO", "214", GDFDataArea.NorthAmerica),
            new Country("Ecuador", "EC", "218", GDFDataArea.SouthAmerica),
            new Country("Egypt", "EG", "818", GDFDataArea.Africa),
            new Country("El Salvador", "SV", "222", GDFDataArea.NorthAmerica),
            new Country("Equatorial Guinea", "GQ", "226", GDFDataArea.Africa),
            new Country("Eritrea", "ER", "232", GDFDataArea.Africa),
            new Country("Estonia", "EE", "233", GDFDataArea.Europe_GDPR),
            new Country("Eswatini", "SZ", "748", GDFDataArea.Africa),
            new Country("Ethiopia", "ET", "231", GDFDataArea.Africa),
            new Country("Falkland Islands (Malvinas)", "FK", "238", GDFDataArea.SouthAmerica),
            new Country("Faroe Islands", "FO", "234", GDFDataArea.Europe),
            new Country("Fiji", "FJ", "242", GDFDataArea.Oceania),
            new Country("Finland", "FI", "246", GDFDataArea.Europe_GDPR),
            new Country("France", "FR", "250", GDFDataArea.Europe_GDPR),
            new Country("French Guiana", "GF", "254", GDFDataArea.Europe_GDPR),
            new Country("French Polynesia", "PF", "258", GDFDataArea.Oceania),
            new Country("French Southern Territories", "TF", "260", GDFDataArea.Antarctica),
            new Country("Gabon", "GA", "266", GDFDataArea.Africa),
            new Country("Gambia", "GM", "270", GDFDataArea.Africa),
            new Country("Georgia", "GE", "268", GDFDataArea.Asia),
            new Country("Germany", "DE", "276", GDFDataArea.Europe_GDPR),
            new Country("Ghana", "GH", "288", GDFDataArea.Africa),
            new Country("Gibraltar", "GI", "292", GDFDataArea.Europe),
            new Country("Greece", "GR", "300", GDFDataArea.Europe_GDPR),
            new Country("Greenland", "GL", "304", GDFDataArea.NorthAmerica),
            new Country("Grenada", "GD", "308", GDFDataArea.NorthAmerica),
            new Country("Guadeloupe", "GP", "312", GDFDataArea.Europe_GDPR),
            new Country("Guam", "GU", "316", GDFDataArea.NorthAmerica),
            new Country("Guatemala", "GT", "320", GDFDataArea.NorthAmerica),
            new Country("Guernsey", "GG", "831", GDFDataArea.Europe),
            new Country("Guinea", "GN", "324", GDFDataArea.Africa),
            new Country("Guinea-Bissau", "GW", "624", GDFDataArea.Africa),
            new Country("Guyana", "GY", "328", GDFDataArea.SouthAmerica),
            new Country("Haiti", "HT", "332", GDFDataArea.NorthAmerica),
            new Country("Heard Island and McDonald Islands", "HM", "334", GDFDataArea.Antarctica),
            new Country("Holy See", "VA", "336", GDFDataArea.Europe),
            new Country("Honduras", "HN", "340", GDFDataArea.NorthAmerica),
            new Country("Hong Kong", "HK", "344", GDFDataArea.Asia),
            new Country("Hungary", "HU", "348", GDFDataArea.Europe_GDPR),
            new Country("Iceland", "IS", "352", GDFDataArea.Europe_GDPR),
            new Country("India", "IN", "356", GDFDataArea.Asia_India_PDPB),
            new Country("Indonesia", "ID", "360", GDFDataArea.Asia),
            new Country("Iran, Islamic Republic of", "IR", "364", GDFDataArea.Asia),
            new Country("Iraq", "IQ", "368", GDFDataArea.Asia),
            new Country("Ireland", "IE", "372", GDFDataArea.Europe_GDPR),
            new Country("Isle of Man", "IM", "833", GDFDataArea.Europe),
            new Country("Israel", "IL", "376", GDFDataArea.Asia),
            new Country("Italy", "IT", "380", GDFDataArea.Europe_GDPR),
            new Country("Jamaica", "JM", "388", GDFDataArea.NorthAmerica),
            new Country("Japan", "JP", "392", GDFDataArea.Asia_Japan_APPI),
            new Country("Jersey", "JE", "832", GDFDataArea.Europe),
            new Country("Jordan", "JO", "400", GDFDataArea.Asia),
            new Country("Kazakhstan", "KZ", "398", GDFDataArea.Asia),
            new Country("Kenya", "KE", "404", GDFDataArea.Africa),
            new Country("Kiribati", "KI", "296", GDFDataArea.Oceania),
            new Country("Korea, Democratic People's Republic of", "KP", "408", GDFDataArea.Asia),
            new Country("Korea, Republic of", "KR", "410", GDFDataArea.Asia_SouthKorea_PIPA),
            new Country("Kuwait", "KW", "414", GDFDataArea.Asia),
            new Country("Kyrgyzstan", "KG", "417", GDFDataArea.Asia),
            new Country("Lao People's Democratic Republic", "LA", "418", GDFDataArea.Asia),
            new Country("Latvia", "LV", "428", GDFDataArea.Europe_GDPR),
            new Country("Lebanon", "LB", "422", GDFDataArea.Asia),
            new Country("Lesotho", "LS", "426", GDFDataArea.Africa),
            new Country("Liberia", "LR", "430", GDFDataArea.Africa),
            new Country("Libya", "LY", "434", GDFDataArea.Africa),
            new Country("Liechtenstein", "LI", "438", GDFDataArea.Europe_GDPR),
            new Country("Lithuania", "LT", "440", GDFDataArea.Europe_GDPR),
            new Country("Luxembourg", "LU", "442", GDFDataArea.Europe_GDPR),
            new Country("Macao", "MO", "446", GDFDataArea.Asia_China_PIPL),
            new Country("Madagascar", "MG", "450", GDFDataArea.Africa),
            new Country("Malawi", "MW", "454", GDFDataArea.Africa),
            new Country("Malaysia", "MY", "458", GDFDataArea.Asia),
            new Country("Maldives", "MV", "462", GDFDataArea.Asia),
            new Country("Mali", "ML", "466", GDFDataArea.Africa),
            new Country("Malta", "MT", "470", GDFDataArea.Europe_GDPR),
            new Country("Marshall Islands", "MH", "584", GDFDataArea.Oceania),
            new Country("Martinique", "MQ", "474", GDFDataArea.Europe_GDPR),
            new Country("Mauritania", "MR", "478", GDFDataArea.Africa),
            new Country("Mauritius", "MU", "480", GDFDataArea.Africa),
            new Country("Mayotte", "YT", "175", GDFDataArea.Europe_GDPR),
            new Country("Mexico", "MX", "484", GDFDataArea.NorthAmerica),
            new Country("Micronesia, Federated States of", "FM", "583", GDFDataArea.Oceania),
            new Country("Moldova, Republic of", "MD", "498", GDFDataArea.Europe),
            new Country("Monaco", "MC", "492", GDFDataArea.Europe_GDPR),
            new Country("Mongolia", "MN", "496", GDFDataArea.Asia),
            new Country("Montenegro", "ME", "499", GDFDataArea.Europe),
            new Country("Montserrat", "MS", "500", GDFDataArea.NorthAmerica),
            new Country("Morocco", "MA", "504", GDFDataArea.Africa),
            new Country("Mozambique", "MZ", "508", GDFDataArea.Africa),
            new Country("Myanmar", "MM", "104", GDFDataArea.Asia),
            new Country("Namibia", "NA", "516", GDFDataArea.Africa),
            new Country("Nauru", "NR", "520", GDFDataArea.Oceania),
            new Country("Nepal", "NP", "524", GDFDataArea.Asia),
            new Country("Netherlands", "NL", "528", GDFDataArea.Europe_GDPR),
            new Country("New Caledonia", "NC", "540", GDFDataArea.Oceania),
            new Country("New Zealand", "NZ", "554", GDFDataArea.Oceania_NewZealand),
            new Country("Nicaragua", "NI", "558", GDFDataArea.NorthAmerica),
            new Country("Niger", "NE", "562", GDFDataArea.Africa),
            new Country("Nigeria", "NG", "566", GDFDataArea.Africa_Nigeria_NDPR),
            new Country("Niue", "NU", "570", GDFDataArea.Oceania),
            new Country("Norfolk Island", "NF", "574", GDFDataArea.Oceania),
            new Country("Northern Mariana Islands", "MP", "580", GDFDataArea.NorthAmerica),
            new Country("North Macedonia", "MK", "807", GDFDataArea.Europe),
            new Country("Norway", "NO", "578", GDFDataArea.Europe_GDPR),
            new Country("Oman", "OM", "512", GDFDataArea.Asia),
            new Country("Pakistan", "PK", "586", GDFDataArea.Asia),
            new Country("Palau", "PW", "585", GDFDataArea.Oceania),
            new Country("Palestine, State of", "PS", "275", GDFDataArea.Asia),
            new Country("Panama", "PA", "591", GDFDataArea.NorthAmerica),
            new Country("Papua New Guinea", "PG", "598", GDFDataArea.Oceania),
            new Country("Paraguay", "PY", "600", GDFDataArea.SouthAmerica),
            new Country("Peru", "PE", "604", GDFDataArea.SouthAmerica),
            new Country("Philippines", "PH", "608", GDFDataArea.Asia),
            new Country("Pitcairn", "PN", "612", GDFDataArea.Oceania),
            new Country("Poland", "PL", "616", GDFDataArea.Europe_GDPR),
            new Country("Portugal", "PT", "620", GDFDataArea.Europe_GDPR),
            new Country("Puerto Rico", "PR", "630", GDFDataArea.NorthAmerica),
            new Country("Qatar", "QA", "634", GDFDataArea.Asia),
            new Country("Réunion", "RE", "638", GDFDataArea.Europe_GDPR),
            new Country("Romania", "RO", "642", GDFDataArea.Europe_GDPR),
            new Country("Russian Federation", "RU", "643", GDFDataArea.Asia_Russia),
            new Country("Rwanda", "RW", "646", GDFDataArea.Africa),
            new Country("Saint Barthélemy", "BL", "652", GDFDataArea.Europe_GDPR),
            new Country("Saint Helena, Ascension and Tristan da Cunha", "SH", "654", GDFDataArea.Africa),
            new Country("Saint Kitts and Nevis", "KN", "659", GDFDataArea.NorthAmerica),
            new Country("Saint Lucia", "LC", "662", GDFDataArea.NorthAmerica),
            new Country("Saint Martin (French part)", "MF", "663", GDFDataArea.Europe_GDPR),
            new Country("Saint Pierre and Miquelon", "PM", "666", GDFDataArea.NorthAmerica),
            new Country("Saint Vincent and the Grenadines", "VC", "670", GDFDataArea.NorthAmerica),
            new Country("Samoa", "WS", "882", GDFDataArea.Oceania),
            new Country("San Marino", "SM", "674", GDFDataArea.Europe_GDPR),
            new Country("Sao Tome and Principe", "ST", "678", GDFDataArea.Africa),
            new Country("Saudi Arabia", "SA", "682", GDFDataArea.Asia),
            new Country("Senegal", "SN", "686", GDFDataArea.Africa),
            new Country("Serbia", "RS", "688", GDFDataArea.Europe),
            new Country("Seychelles", "SC", "690", GDFDataArea.Africa),
            new Country("Sierra Leone", "SL", "694", GDFDataArea.Africa),
            new Country("Singapore", "SG", "702", GDFDataArea.Asia_Singapore_PDPA),
            new Country("Sint Maarten (Dutch part)", "SX", "534", GDFDataArea.NorthAmerica),
            new Country("Slovakia", "SK", "703", GDFDataArea.Europe_GDPR),
            new Country("Slovenia", "SI", "705", GDFDataArea.Europe_GDPR),
            new Country("Solomon Islands", "SB", "090", GDFDataArea.Oceania),
            new Country("Somalia", "SO", "706", GDFDataArea.Africa),
            new Country("South Africa", "ZA", "710", GDFDataArea.Africa_SouthAfrica_POPIA),
            new Country("South Georgia and the South Sandwich Islands", "GS", "239", GDFDataArea.Antarctica),
            new Country("South Sudan", "SS", "728", GDFDataArea.Africa),
            new Country("Spain", "ES", "724", GDFDataArea.Europe_GDPR),
            new Country("Sri Lanka", "LK", "144", GDFDataArea.Asia),
            new Country("Sudan", "SD", "729", GDFDataArea.Africa),
            new Country("Suriname", "SR", "740", GDFDataArea.SouthAmerica),
            new Country("Svalbard and Jan Mayen", "SJ", "744", GDFDataArea.Europe_GDPR),
            new Country("Sweden", "SE", "752", GDFDataArea.Europe_GDPR),
            new Country("Switzerland", "CH", "756", GDFDataArea.Europe),
            new Country("Syrian Arab Republic", "SY", "760", GDFDataArea.Asia),
            new Country("Taiwan, Province of China", "TW", "158", GDFDataArea.Asia),
            new Country("Tajikistan", "TJ", "762", GDFDataArea.Asia),
            new Country("Tanzania, United Republic of", "TZ", "834", GDFDataArea.Africa),
            new Country("Thailand", "TH", "764", GDFDataArea.Asia),
            new Country("Timor-Leste", "TL", "626", GDFDataArea.Asia),
            new Country("Togo", "TG", "768", GDFDataArea.Africa),
            new Country("Tokelau", "TK", "772", GDFDataArea.Oceania),
            new Country("Tonga", "TO", "776", GDFDataArea.Oceania),
            new Country("Trinidad and Tobago", "TT", "780", GDFDataArea.NorthAmerica),
            new Country("Tunisia", "TN", "788", GDFDataArea.Africa),
            new Country("Turkey", "TR", "792", GDFDataArea.Europe),
            new Country("Turkmenistan", "TM", "795", GDFDataArea.Asia),
            new Country("Turks and Caicos Islands", "TC", "796", GDFDataArea.NorthAmerica),
            new Country("Tuvalu", "TV", "798", GDFDataArea.Oceania),
            new Country("Uganda", "UG", "800", GDFDataArea.Africa),
            new Country("Ukraine", "UA", "804", GDFDataArea.Europe),
            new Country("United Arab Emirates", "AE", "784", GDFDataArea.Asia),
            new Country("United Kingdom of Great Britain and Northern Ireland", "GB", "826", GDFDataArea.Europe),
            new Country("United States of America", "US", "840", GDFDataArea.NorthAmerica_California_CCPA),
            new Country("United States Minor Outlying Islands", "UM", "581", GDFDataArea.NorthAmerica),
            new Country("Uruguay", "UY", "858", GDFDataArea.SouthAmerica),
            new Country("Uzbekistan", "UZ", "860", GDFDataArea.Asia),
            new Country("Vanuatu", "VU", "548", GDFDataArea.Oceania),
            new Country("Venezuela, Bolivarian Republic of", "VE", "862", GDFDataArea.SouthAmerica),
            new Country("Viet Nam", "VN", "704", GDFDataArea.Asia),
            new Country("Virgin Islands, British", "VG", "092", GDFDataArea.NorthAmerica),
            new Country("Virgin Islands, U.S.", "VI", "850", GDFDataArea.NorthAmerica),
            new Country("Wallis and Futuna", "WF", "876", GDFDataArea.Oceania),
            new Country("Western Sahara", "EH", "732", GDFDataArea.Africa),
            new Country("Yemen", "YE", "887", GDFDataArea.Asia),
            new Country("Zambia", "ZM", "894", GDFDataArea.Africa),
            new Country("Zimbabwe", "ZW", "716", GDFDataArea.Africa),
            new Country("Åland Islands", "AX", "248", GDFDataArea.Europe_GDPR)
        };

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the two-letter code for the country.
        /// </summary>
        public string TwoLetterCode { get; private set; }

        /// <summary>
        /// Gets the numeric code for the country.
        /// </summary>
        public string NumericCode { get; private set; }

        public GDFDataArea DataArea { get; private set; }

        /// <summary>
        /// The Country class represents a country ISO code.
        /// It provides methods to retrieve a country based on its two-letter or three-letter code.
        /// </summary>
        private Country(string name, string shortCode, string numericCode, GDFDataArea dataArea)
        {
            Name = name;
            TwoLetterCode = shortCode;
            NumericCode = numericCode;
            DataArea = dataArea;
        }

        /// <summary>
        /// Represents a list of country names as strings.
        /// </summary>
        /// <remarks>
        /// This class provides a list of country names as strings.
        /// </remarks>
        private static List<string> _countries;

        /// <summary>
        /// Class representing a list of country codes with their respective three-letter codes.
        /// </summary>
        private static List<string> _threeLettersCountries;

        /// <summary>
        /// Class representing a list of two-letter country codes.
        /// </summary>
        private static List<string> _twoLettersCountries;

        /// <summary>
        /// Class representing a dictionary of country codes with their respective two-letter codes.
        /// </summary>
        private static Dictionary<string, Country> _twoLettersCache;

        /// <summary>
        /// Retrieves a <see cref="Country"/> object based on the two-letter country code.
        /// </summary>
        /// <param name="code">The two-letter country code.</param>
        /// <returns>A <see cref="Country"/> object representing the country with the specified two-letter code.</returns>
        public static Country FromTwoLetterCode(string code)
        {
            code = code.ToUpper();
            if (_twoLettersCache == null)
            {
                _twoLettersCache = new Dictionary<string, Country>();
                foreach (Country country in COUNTRIES)
                {
                    _twoLettersCache.Add(country.TwoLetterCode, country);
                }
            }

            if (_twoLettersCache.ContainsKey(code))
            {
                return _twoLettersCache[code];
            }

            return new Country("", "", "", GDFDataArea.Unknown);
        }

        public static Dictionary<string, Country> GetTwoLetterCodeCountryDictionary()
        {
            if (_twoLettersCache == null)
            {
                _twoLettersCache = new Dictionary<string, Country>();
                foreach (Country tCountry in COUNTRIES)
                {
                    _twoLettersCache.Add(tCountry.TwoLetterCode, tCountry);
                }
            }
            return new Dictionary<string, Country>(_twoLettersCache);
        }

        /// <summary>
        /// Retrieves a list of countries.
        /// </summary>
        /// <returns>A list of country names.</returns>
        public static List<string> GetNames()
        {
            if (_countries == null)
            {
                _countries = new List<string>();
                foreach (Country tCountry in COUNTRIES)
                {
                    _countries.Add(tCountry.Name);
                }
            }

            return _countries;
        }

        /// <summary>
        /// Retrieves a list of all countries with their two-letter ISO codes.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="string"/> containing the two-letter ISO codes of countries.</returns>
        /// <remarks>
        /// This method retrieves a list of all countries with their two-letter ISO codes.
        /// If the list has not been initialized yet, it initializes the list by iterating over the available countries and populating the two-letter ISO codes.
        /// The method then returns the list of two-letter ISO codes.
        /// </remarks>
        public static List<string> GetTwoLetterCodeCountries()
        {
            if (_twoLettersCountries == null)
            {
                _twoLettersCountries = new List<string>();
                foreach (Country tCountry in COUNTRIES)
                {
                    _twoLettersCountries.Add(tCountry.TwoLetterCode);
                }
            }

            return _twoLettersCountries;
        }
    }
}