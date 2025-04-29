using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class that provides ISO country codes and related information.
    /// </summary>
    public class GDFCountryISO
    {
        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the two-letter code for the country.
        /// </summary>
        public string TwoLetterCode { get; private set; }

        /// <summary>
        /// Class representing a three-letter code for a country.
        /// </summary>
        /// <remarks>
        /// This class is part of the GDFFoundation namespace and is utilized in the GDFCountryISO class.
        /// </remarks>
        /// <example>
        /// The following is an example of how to use the ThreeLetterCode property:
        /// <code>
        /// // Instantiate a new GDFCountryISO object
        /// GDFCountryISO country = new GDFCountryISO();
        /// // Set the three-letter code for the country
        /// country.ThreeLetterCode = "USA";
        /// // Access the three-letter code for the country
        /// string code = country.ThreeLetterCode;
        /// </code>
        /// </example>
        public string ThreeLetterCode { get; private set; }

        /// <summary>
        /// Gets the numeric code for the country.
        /// </summary>
        public string NumericCode { get; private set; }

        public GDFDataArea DataArea { get; private set; }

        /// <summary>
        /// The GDFCountryISO class represents a country ISO code.
        /// It provides methods to retrieve a country based on its two-letter or three-letter code.
        /// </summary>
        private GDFCountryISO(string name, string shortCode, string code, string numericCode, GDFDataArea dataArea)
        {
            Name = name;
            TwoLetterCode = shortCode;
            ThreeLetterCode = code;
            NumericCode = numericCode;
            DataArea = dataArea;
        }

        /// <summary>
        /// Represents a list of country names as strings.
        /// </summary>
        /// <remarks>
        /// This class provides a list of country names as strings.
        /// </remarks>
        private static List<string> CountryListString;

        /// <summary>
        /// Class representing a list of country codes with their respective three-letter codes.
        /// </summary>
        private static List<string> CountryListThreeLetterCode;

        /// <summary>
        /// Class representing a list of two-letter country codes.
        /// </summary>
        private static List<string> CountryListTwoLetterCode;

        /// <summary>
        /// Class representing a dictionary of country codes with their respective two-letter codes.
        /// </summary>
        private static Dictionary<string, GDFCountryISO> TwoLetterCodeCountryDictionary;

        /// <summary>
        /// Class representing a dictionary of country codes with their respective three-letter codes.
        /// </summary>
        private static Dictionary<string, GDFCountryISO> ThreeLetterCodeCountryDictionary;

        /// <summary>
        /// Retrieves a <see cref="GDFCountryISO"/> object based on the two-letter country code.
        /// </summary>
        /// <param name="sCode">The two-letter country code.</param>
        /// <returns>A <see cref="GDFCountryISO"/> object representing the country with the specified two-letter code.</returns>
        public static GDFCountryISO GetFromTwoLetterCode(string sCode)
        {
            if (TwoLetterCodeCountryDictionary == null)
            {
                TwoLetterCodeCountryDictionary = new Dictionary<string, GDFCountryISO>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    TwoLetterCodeCountryDictionary.Add(tCountry.TwoLetterCode, tCountry);
                }
            }

            if (TwoLetterCodeCountryDictionary.ContainsKey(sCode))
            {
                return TwoLetterCodeCountryDictionary[sCode];
            }

            return new GDFCountryISO("", "", "", "", GDFDataArea.Unknown);
        }

        public static Dictionary<string, GDFCountryISO> GetTwoLetterCodeCountryDictionary()
        {
            if (TwoLetterCodeCountryDictionary == null)
            {
                TwoLetterCodeCountryDictionary = new Dictionary<string, GDFCountryISO>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    TwoLetterCodeCountryDictionary.Add(tCountry.TwoLetterCode, tCountry);
                }
            }
            return new Dictionary<string, GDFCountryISO>(TwoLetterCodeCountryDictionary);
        }

        /// <summary>
        /// Retrieves a country from its three-letter code.
        /// </summary>
        /// <param name="sCode">The three-letter code representing the country.</param>
        /// <returns>
        /// The <see cref="GDFCountryISO"/> object representing the country. If the country with the given code is found,
        /// the object is returned. Otherwise, a new <see cref="GDFCountryISO"/> object with empty properties is returned.
        /// </returns>
        public static GDFCountryISO GetFromThreeLetterCode(string sCode)
        {
            if (ThreeLetterCodeCountryDictionary == null)
            {
                ThreeLetterCodeCountryDictionary = new Dictionary<string, GDFCountryISO>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    ThreeLetterCodeCountryDictionary.Add(tCountry.ThreeLetterCode, tCountry);
                }
            }

            if (ThreeLetterCodeCountryDictionary.ContainsKey(sCode))
            {
                return ThreeLetterCodeCountryDictionary[sCode];
            }

            return new GDFCountryISO("", "", "", "", GDFDataArea.Unknown);
        }

        /// <summary>
        /// Retrieves a list of countries.
        /// </summary>
        /// <returns>A list of country names.</returns>
        public static List<string> GetNames()
        {
            if (CountryListString == null)
            {
                CountryListString = new List<string>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    CountryListString.Add(tCountry.Name);
                }
            }

            return CountryListString;
        }

        /// <summary>
        /// Returns a list of three-letter country codes.
        /// </summary>
        /// <returns>A list of three-letter country codes.</returns>
        public static List<string> GetThreeLetterCodeCountries()
        {
            if (CountryListThreeLetterCode == null)
            {
                CountryListThreeLetterCode = new List<string>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    CountryListThreeLetterCode.Add(tCountry.ThreeLetterCode);
                }
            }

            return CountryListThreeLetterCode;
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
            if (CountryListTwoLetterCode == null)
            {
                CountryListTwoLetterCode = new List<string>();
                foreach (GDFCountryISO tCountry in Countries)
                {
                    CountryListTwoLetterCode.Add(tCountry.TwoLetterCode);
                }
            }

            return CountryListTwoLetterCode;
        }

        /// <summary>
        /// Represents a collection of objects that can be accessed by index and provides methods to search, sort, and manipulate the list.
        /// </summary>
        public static readonly GDFCountryISO[] Countries = new[]
        {
            new GDFCountryISO("Afghanistan", "AF", "AFG", "004", GDFDataArea.Asia),
            new GDFCountryISO("Albania", "AL", "ALB", "008", GDFDataArea.European),
            new GDFCountryISO("Algeria", "DZ", "DZA", "012", GDFDataArea.Africa),
            new GDFCountryISO("American Samoa", "AS", "ASM", "016", GDFDataArea.NorthAmerica), // US territory
            new GDFCountryISO("Andorra", "AD", "AND", "020", GDFDataArea.European),
            new GDFCountryISO("Angola", "AO", "AGO", "024", GDFDataArea.Africa),
            new GDFCountryISO("Anguilla", "AI", "AIA", "660", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Antarctica", "AQ", "ATA", "010", GDFDataArea.Antarctica),
            new GDFCountryISO("Antigua and Barbuda", "AG", "ATG", "028", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Argentina", "AR", "ARG", "032", GDFDataArea.SouthAmerica_Argentina_LPDP),
            new GDFCountryISO("Armenia", "AM", "ARM", "051", GDFDataArea.Asia),
            new GDFCountryISO("Aruba", "AW", "ABW", "533", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Australia", "AU", "AUS", "036", GDFDataArea.Oceania_Australia),
            new GDFCountryISO("Austria", "AT", "AUT", "040", GDFDataArea.European_GDPR),
            new GDFCountryISO("Azerbaijan", "AZ", "AZE", "031", GDFDataArea.Asia),
            new GDFCountryISO("Bahamas", "BS", "BHS", "044", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Bahrain", "BH", "BHR", "048", GDFDataArea.Asia),
            new GDFCountryISO("Bangladesh", "BD", "BGD", "050", GDFDataArea.Asia),
            new GDFCountryISO("Barbados", "BB", "BRB", "052", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Belarus", "BY", "BLR", "112", GDFDataArea.European),
            new GDFCountryISO("Belgium", "BE", "BEL", "056", GDFDataArea.European_GDPR),
            new GDFCountryISO("Belize", "BZ", "BLZ", "084", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Benin", "BJ", "BEN", "204", GDFDataArea.Africa),
            new GDFCountryISO("Bermuda", "BM", "BMU", "060", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Bhutan", "BT", "BTN", "064", GDFDataArea.Asia),
            new GDFCountryISO("Bolivia, Plurinational State of", "BO", "BOL", "068", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Bonaire, Sint Eustatius and Saba", "BQ", "BES", "535", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Bosnia and Herzegovina", "BA", "BIH", "070", GDFDataArea.European),
            new GDFCountryISO("Botswana", "BW", "BWA", "072", GDFDataArea.Africa),
            new GDFCountryISO("Bouvet Island", "BV", "BVT", "074", GDFDataArea.Antarctica),
            new GDFCountryISO("Brazil", "BR", "BRA", "076", GDFDataArea.SouthAmerica_Brazil_LGPD),
            new GDFCountryISO("British Indian Ocean Territory", "IO", "IOT", "086", GDFDataArea.Africa),
            new GDFCountryISO("Brunei Darussalam", "BN", "BRN", "096", GDFDataArea.Asia),
            new GDFCountryISO("Bulgaria", "BG", "BGR", "100", GDFDataArea.European_GDPR),
            new GDFCountryISO("Burkina Faso", "BF", "BFA", "854", GDFDataArea.Africa),
            new GDFCountryISO("Burundi", "BI", "BDI", "108", GDFDataArea.Africa),
            new GDFCountryISO("Cabo Verde", "CV", "CPV", "132", GDFDataArea.Africa),
            new GDFCountryISO("Cambodia", "KH", "KHM", "116", GDFDataArea.Asia),
            new GDFCountryISO("Cameroon", "CM", "CMR", "120", GDFDataArea.Africa),
            new GDFCountryISO("Canada", "CA", "CAN", "124", GDFDataArea.NorthAmerica_Canada_PIPEDA),
            new GDFCountryISO("Cayman Islands", "KY", "CYM", "136", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Central African Republic", "CF", "CAF", "140", GDFDataArea.Africa),
            new GDFCountryISO("Chad", "TD", "TCD", "148", GDFDataArea.Africa),
            new GDFCountryISO("Chile", "CL", "CHL", "152", GDFDataArea.SouthAmerica),
            new GDFCountryISO("China", "CN", "CHN", "156", GDFDataArea.Asia_China_PIPL),
            new GDFCountryISO("Christmas Island", "CX", "CXR", "162", GDFDataArea.Oceania_Australia),
            new GDFCountryISO("Cocos (Keeling) Islands", "CC", "CCK", "166", GDFDataArea.Oceania_Australia),
            new GDFCountryISO("Colombia", "CO", "COL", "170", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Comoros", "KM", "COM", "174", GDFDataArea.Africa),
            new GDFCountryISO("Congo", "CG", "COG", "178", GDFDataArea.Africa),
            new GDFCountryISO("Congo, the Democratic Republic of the", "CD", "COD", "180", GDFDataArea.Africa),
            new GDFCountryISO("Cook Islands", "CK", "COK", "184", GDFDataArea.Oceania_NewZealand),
            new GDFCountryISO("Costa Rica", "CR", "CRI", "188", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Côte d'Ivoire", "CI", "CIV", "384", GDFDataArea.Africa),
            new GDFCountryISO("Croatia", "HR", "HRV", "191", GDFDataArea.European_GDPR),
            new GDFCountryISO("Cuba", "CU", "CUB", "192", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Curaçao", "CW", "CUW", "531", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Cyprus", "CY", "CYP", "196", GDFDataArea.European_GDPR),
            new GDFCountryISO("Czechia", "CZ", "CZE", "203", GDFDataArea.European_GDPR),
            new GDFCountryISO("Denmark", "DK", "DNK", "208", GDFDataArea.European_GDPR),
            new GDFCountryISO("Djibouti", "DJ", "DJI", "262", GDFDataArea.Africa),
            new GDFCountryISO("Dominica", "DM", "DMA", "212", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Dominican Republic", "DO", "DOM", "214", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Ecuador", "EC", "ECU", "218", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Egypt", "EG", "EGY", "818", GDFDataArea.Africa),
            new GDFCountryISO("El Salvador", "SV", "SLV", "222", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Equatorial Guinea", "GQ", "GNQ", "226", GDFDataArea.Africa),
            new GDFCountryISO("Eritrea", "ER", "ERI", "232", GDFDataArea.Africa),
            new GDFCountryISO("Estonia", "EE", "EST", "233", GDFDataArea.European_GDPR),
            new GDFCountryISO("Eswatini", "SZ", "SWZ", "748", GDFDataArea.Africa),
            new GDFCountryISO("Ethiopia", "ET", "ETH", "231", GDFDataArea.Africa),
            new GDFCountryISO("Falkland Islands (Malvinas)", "FK", "FLK", "238", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Faroe Islands", "FO", "FRO", "234", GDFDataArea.European),
            new GDFCountryISO("Fiji", "FJ", "FJI", "242", GDFDataArea.Oceania),
            new GDFCountryISO("Finland", "FI", "FIN", "246", GDFDataArea.European_GDPR),
            new GDFCountryISO("France", "FR", "FRA", "250", GDFDataArea.European_GDPR),
            new GDFCountryISO("French Guiana", "GF", "GUF", "254", GDFDataArea.European_GDPR),
            new GDFCountryISO("French Polynesia", "PF", "PYF", "258", GDFDataArea.Oceania),
            new GDFCountryISO("French Southern Territories", "TF", "ATF", "260", GDFDataArea.Antarctica),
            new GDFCountryISO("Gabon", "GA", "GAB", "266", GDFDataArea.Africa),
            new GDFCountryISO("Gambia", "GM", "GMB", "270", GDFDataArea.Africa),
            new GDFCountryISO("Georgia", "GE", "GEO", "268", GDFDataArea.Asia),
            new GDFCountryISO("Germany", "DE", "DEU", "276", GDFDataArea.European_GDPR),
            new GDFCountryISO("Ghana", "GH", "GHA", "288", GDFDataArea.Africa),
            new GDFCountryISO("Gibraltar", "GI", "GIB", "292", GDFDataArea.European),
            new GDFCountryISO("Greece", "GR", "GRC", "300", GDFDataArea.European_GDPR),
            new GDFCountryISO("Greenland", "GL", "GRL", "304", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Grenada", "GD", "GRD", "308", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Guadeloupe", "GP", "GLP", "312", GDFDataArea.European_GDPR),
            new GDFCountryISO("Guam", "GU", "GUM", "316", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Guatemala", "GT", "GTM", "320", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Guernsey", "GG", "GGY", "831", GDFDataArea.European),
            new GDFCountryISO("Guinea", "GN", "GIN", "324", GDFDataArea.Africa),
            new GDFCountryISO("Guinea-Bissau", "GW", "GNB", "624", GDFDataArea.Africa),
            new GDFCountryISO("Guyana", "GY", "GUY", "328", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Haiti", "HT", "HTI", "332", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Heard Island and McDonald Islands", "HM", "HMD", "334", GDFDataArea.Antarctica),
            new GDFCountryISO("Holy See", "VA", "VAT", "336", GDFDataArea.European),
            new GDFCountryISO("Honduras", "HN", "HND", "340", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Hong Kong", "HK", "HKG", "344", GDFDataArea.Asia),
            new GDFCountryISO("Hungary", "HU", "HUN", "348", GDFDataArea.European_GDPR),
            new GDFCountryISO("Iceland", "IS", "ISL", "352", GDFDataArea.European_GDPR),
            new GDFCountryISO("India", "IN", "IND", "356", GDFDataArea.Asia_India_PDPB),
            new GDFCountryISO("Indonesia", "ID", "IDN", "360", GDFDataArea.Asia),
            new GDFCountryISO("Iran, Islamic Republic of", "IR", "IRN", "364", GDFDataArea.Asia),
            new GDFCountryISO("Iraq", "IQ", "IRQ", "368", GDFDataArea.Asia),
            new GDFCountryISO("Ireland", "IE", "IRL", "372", GDFDataArea.European_GDPR),
            new GDFCountryISO("Isle of Man", "IM", "IMN", "833", GDFDataArea.European),
            new GDFCountryISO("Israel", "IL", "ISR", "376", GDFDataArea.Asia),
            new GDFCountryISO("Italy", "IT", "ITA", "380", GDFDataArea.European_GDPR),
            new GDFCountryISO("Jamaica", "JM", "JAM", "388", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Japan", "JP", "JPN", "392", GDFDataArea.Asia_Japan_APPI),
            new GDFCountryISO("Jersey", "JE", "JEY", "832", GDFDataArea.European),
            new GDFCountryISO("Jordan", "JO", "JOR", "400", GDFDataArea.Asia),
            new GDFCountryISO("Kazakhstan", "KZ", "KAZ", "398", GDFDataArea.Asia),
            new GDFCountryISO("Kenya", "KE", "KEN", "404", GDFDataArea.Africa),
            new GDFCountryISO("Kiribati", "KI", "KIR", "296", GDFDataArea.Oceania),
            new GDFCountryISO("Korea, Democratic People's Republic of", "KP", "PRK", "408", GDFDataArea.Asia),
            new GDFCountryISO("Korea, Republic of", "KR", "KOR", "410", GDFDataArea.Asia_SouthKorea_PIPA),
            new GDFCountryISO("Kuwait", "KW", "KWT", "414", GDFDataArea.Asia),
            new GDFCountryISO("Kyrgyzstan", "KG", "KGZ", "417", GDFDataArea.Asia),
            new GDFCountryISO("Lao People's Democratic Republic", "LA", "LAO", "418", GDFDataArea.Asia),
            new GDFCountryISO("Latvia", "LV", "LVA", "428", GDFDataArea.European_GDPR),
            new GDFCountryISO("Lebanon", "LB", "LBN", "422", GDFDataArea.Asia),
            new GDFCountryISO("Lesotho", "LS", "LSO", "426", GDFDataArea.Africa),
            new GDFCountryISO("Liberia", "LR", "LBR", "430", GDFDataArea.Africa),
            new GDFCountryISO("Libya", "LY", "LBY", "434", GDFDataArea.Africa),
            new GDFCountryISO("Liechtenstein", "LI", "LIE", "438", GDFDataArea.European_GDPR),
            new GDFCountryISO("Lithuania", "LT", "LTU", "440", GDFDataArea.European_GDPR),
            new GDFCountryISO("Luxembourg", "LU", "LUX", "442", GDFDataArea.European_GDPR),
            new GDFCountryISO("Macao", "MO", "MAC", "446", GDFDataArea.Asia_China_PIPL),
            new GDFCountryISO("Madagascar", "MG", "MDG", "450", GDFDataArea.Africa),
            new GDFCountryISO("Malawi", "MW", "MWI", "454", GDFDataArea.Africa),
            new GDFCountryISO("Malaysia", "MY", "MYS", "458", GDFDataArea.Asia),
            new GDFCountryISO("Maldives", "MV", "MDV", "462", GDFDataArea.Asia),
            new GDFCountryISO("Mali", "ML", "MLI", "466", GDFDataArea.Africa),
            new GDFCountryISO("Malta", "MT", "MLT", "470", GDFDataArea.European_GDPR),
            new GDFCountryISO("Marshall Islands", "MH", "MHL", "584", GDFDataArea.Oceania),
            new GDFCountryISO("Martinique", "MQ", "MTQ", "474", GDFDataArea.European_GDPR),
            new GDFCountryISO("Mauritania", "MR", "MRT", "478", GDFDataArea.Africa),
            new GDFCountryISO("Mauritius", "MU", "MUS", "480", GDFDataArea.Africa),
            new GDFCountryISO("Mayotte", "YT", "MYT", "175", GDFDataArea.European_GDPR),
            new GDFCountryISO("Mexico", "MX", "MEX", "484", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Micronesia, Federated States of", "FM", "FSM", "583", GDFDataArea.Oceania),
            new GDFCountryISO("Moldova, Republic of", "MD", "MDA", "498", GDFDataArea.European),
            new GDFCountryISO("Monaco", "MC", "MCO", "492", GDFDataArea.European_GDPR),
            new GDFCountryISO("Mongolia", "MN", "MNG", "496", GDFDataArea.Asia),
            new GDFCountryISO("Montenegro", "ME", "MNE", "499", GDFDataArea.European),
            new GDFCountryISO("Montserrat", "MS", "MSR", "500", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Morocco", "MA", "MAR", "504", GDFDataArea.Africa),
            new GDFCountryISO("Mozambique", "MZ", "MOZ", "508", GDFDataArea.Africa),
            new GDFCountryISO("Myanmar", "MM", "MMR", "104", GDFDataArea.Asia),
            new GDFCountryISO("Namibia", "NA", "NAM", "516", GDFDataArea.Africa),
            new GDFCountryISO("Nauru", "NR", "NRU", "520", GDFDataArea.Oceania),
            new GDFCountryISO("Nepal", "NP", "NPL", "524", GDFDataArea.Asia),
            new GDFCountryISO("Netherlands", "NL", "NLD", "528", GDFDataArea.European_GDPR),
            new GDFCountryISO("New Caledonia", "NC", "NCL", "540", GDFDataArea.Oceania),
            new GDFCountryISO("New Zealand", "NZ", "NZL", "554", GDFDataArea.Oceania_NewZealand),
            new GDFCountryISO("Nicaragua", "NI", "NIC", "558", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Niger", "NE", "NER", "562", GDFDataArea.Africa),
            new GDFCountryISO("Nigeria", "NG", "NGA", "566", GDFDataArea.Africa_Nigeria_NDPR),
            new GDFCountryISO("Niue", "NU", "NIU", "570", GDFDataArea.Oceania),
            new GDFCountryISO("Norfolk Island", "NF", "NFK", "574", GDFDataArea.Oceania),
            new GDFCountryISO("Northern Mariana Islands", "MP", "MNP", "580", GDFDataArea.NorthAmerica),
            new GDFCountryISO("North Macedonia", "MK", "MKD", "807", GDFDataArea.European),
            new GDFCountryISO("Norway", "NO", "NOR", "578", GDFDataArea.European_GDPR),
            new GDFCountryISO("Oman", "OM", "OMN", "512", GDFDataArea.Asia),
            new GDFCountryISO("Pakistan", "PK", "PAK", "586", GDFDataArea.Asia),
            new GDFCountryISO("Palau", "PW", "PLW", "585", GDFDataArea.Oceania),
            new GDFCountryISO("Palestine, State of", "PS", "PSE", "275", GDFDataArea.Asia),
            new GDFCountryISO("Panama", "PA", "PAN", "591", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Papua New Guinea", "PG", "PNG", "598", GDFDataArea.Oceania),
            new GDFCountryISO("Paraguay", "PY", "PRY", "600", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Peru", "PE", "PER", "604", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Philippines", "PH", "PHL", "608", GDFDataArea.Asia),
            new GDFCountryISO("Pitcairn", "PN", "PCN", "612", GDFDataArea.Oceania),
            new GDFCountryISO("Poland", "PL", "POL", "616", GDFDataArea.European_GDPR),
            new GDFCountryISO("Portugal", "PT", "PRT", "620", GDFDataArea.European_GDPR),
            new GDFCountryISO("Puerto Rico", "PR", "PRI", "630", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Qatar", "QA", "QAT", "634", GDFDataArea.Asia),
            new GDFCountryISO("Réunion", "RE", "REU", "638", GDFDataArea.European_GDPR),
            new GDFCountryISO("Romania", "RO", "ROU", "642", GDFDataArea.European_GDPR),
            new GDFCountryISO("Russian Federation", "RU", "RUS", "643", GDFDataArea.Asia_Russia),
            new GDFCountryISO("Rwanda", "RW", "RWA", "646", GDFDataArea.Africa),
            new GDFCountryISO("Saint Barthélemy", "BL", "BLM", "652", GDFDataArea.European_GDPR),
            new GDFCountryISO("Saint Helena, Ascension and Tristan da Cunha", "SH", "SHN", "654", GDFDataArea.Africa),
            new GDFCountryISO("Saint Kitts and Nevis", "KN", "KNA", "659", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Saint Lucia", "LC", "LCA", "662", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Saint Martin (French part)", "MF", "MAF", "663", GDFDataArea.European_GDPR),
            new GDFCountryISO("Saint Pierre and Miquelon", "PM", "SPM", "666", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Saint Vincent and the Grenadines", "VC", "VCT", "670", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Samoa", "WS", "WSM", "882", GDFDataArea.Oceania),
            new GDFCountryISO("San Marino", "SM", "SMR", "674", GDFDataArea.European_GDPR),
            new GDFCountryISO("Sao Tome and Principe", "ST", "STP", "678", GDFDataArea.Africa),
            new GDFCountryISO("Saudi Arabia", "SA", "SAU", "682", GDFDataArea.Asia),
            new GDFCountryISO("Senegal", "SN", "SEN", "686", GDFDataArea.Africa),
            new GDFCountryISO("Serbia", "RS", "SRB", "688", GDFDataArea.European),
            new GDFCountryISO("Seychelles", "SC", "SYC", "690", GDFDataArea.Africa),
            new GDFCountryISO("Sierra Leone", "SL", "SLE", "694", GDFDataArea.Africa),
            new GDFCountryISO("Singapore", "SG", "SGP", "702", GDFDataArea.Asia_Singapore_PDPA),
            new GDFCountryISO("Sint Maarten (Dutch part)", "SX", "SXM", "534", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Slovakia", "SK", "SVK", "703", GDFDataArea.European_GDPR),
            new GDFCountryISO("Slovenia", "SI", "SVN", "705", GDFDataArea.European_GDPR),
            new GDFCountryISO("Solomon Islands", "SB", "SLB", "090", GDFDataArea.Oceania),
            new GDFCountryISO("Somalia", "SO", "SOM", "706", GDFDataArea.Africa),
            new GDFCountryISO("South Africa", "ZA", "ZAF", "710", GDFDataArea.Africa_SouthAfrica_POPIA),
            new GDFCountryISO("South Georgia and the South Sandwich Islands", "GS", "SGS", "239", GDFDataArea.Antarctica),
            new GDFCountryISO("South Sudan", "SS", "SSD", "728", GDFDataArea.Africa),
            new GDFCountryISO("Spain", "ES", "ESP", "724", GDFDataArea.European_GDPR),
            new GDFCountryISO("Sri Lanka", "LK", "LKA", "144", GDFDataArea.Asia),
            new GDFCountryISO("Sudan", "SD", "SDN", "729", GDFDataArea.Africa),
            new GDFCountryISO("Suriname", "SR", "SUR", "740", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Svalbard and Jan Mayen", "SJ", "SJM", "744", GDFDataArea.European_GDPR),
            new GDFCountryISO("Sweden", "SE", "SWE", "752", GDFDataArea.European_GDPR),
            new GDFCountryISO("Switzerland", "CH", "CHE", "756", GDFDataArea.European),
            new GDFCountryISO("Syrian Arab Republic", "SY", "SYR", "760", GDFDataArea.Asia),
            new GDFCountryISO("Taiwan, Province of China", "TW", "TWN", "158", GDFDataArea.Asia),
            new GDFCountryISO("Tajikistan", "TJ", "TJK", "762", GDFDataArea.Asia),
            new GDFCountryISO("Tanzania, United Republic of", "TZ", "TZA", "834", GDFDataArea.Africa),
            new GDFCountryISO("Thailand", "TH", "THA", "764", GDFDataArea.Asia),
            new GDFCountryISO("Timor-Leste", "TL", "TLS", "626", GDFDataArea.Asia),
            new GDFCountryISO("Togo", "TG", "TGO", "768", GDFDataArea.Africa),
            new GDFCountryISO("Tokelau", "TK", "TKL", "772", GDFDataArea.Oceania),
            new GDFCountryISO("Tonga", "TO", "TON", "776", GDFDataArea.Oceania),
            new GDFCountryISO("Trinidad and Tobago", "TT", "TTO", "780", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Tunisia", "TN", "TUN", "788", GDFDataArea.Africa),
            new GDFCountryISO("Turkey", "TR", "TUR", "792", GDFDataArea.European),
            new GDFCountryISO("Turkmenistan", "TM", "TKM", "795", GDFDataArea.Asia),
            new GDFCountryISO("Turks and Caicos Islands", "TC", "TCA", "796", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Tuvalu", "TV", "TUV", "798", GDFDataArea.Oceania),
            new GDFCountryISO("Uganda", "UG", "UGA", "800", GDFDataArea.Africa),
            new GDFCountryISO("Ukraine", "UA", "UKR", "804", GDFDataArea.European),
            new GDFCountryISO("United Arab Emirates", "AE", "ARE", "784", GDFDataArea.Asia),
            new GDFCountryISO("United Kingdom of Great Britain and Northern Ireland", "GB", "GBR", "826", GDFDataArea.European),
            new GDFCountryISO("United States of America", "US", "USA", "840", GDFDataArea.NorthAmerica_California_CCPA),
            new GDFCountryISO("United States Minor Outlying Islands", "UM", "UMI", "581", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Uruguay", "UY", "URY", "858", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Uzbekistan", "UZ", "UZB", "860", GDFDataArea.Asia),
            new GDFCountryISO("Vanuatu", "VU", "VUT", "548", GDFDataArea.Oceania),
            new GDFCountryISO("Venezuela, Bolivarian Republic of", "VE", "VEN", "862", GDFDataArea.SouthAmerica),
            new GDFCountryISO("Viet Nam", "VN", "VNM", "704", GDFDataArea.Asia),
            new GDFCountryISO("Virgin Islands, British", "VG", "VGB", "092", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Virgin Islands, U.S.", "VI", "VIR", "850", GDFDataArea.NorthAmerica),
            new GDFCountryISO("Wallis and Futuna", "WF", "WLF", "876", GDFDataArea.Oceania),
            new GDFCountryISO("Western Sahara", "EH", "ESH", "732", GDFDataArea.Africa),
            new GDFCountryISO("Yemen", "YE", "YEM", "887", GDFDataArea.Asia),
            new GDFCountryISO("Zambia", "ZM", "ZMB", "894", GDFDataArea.Africa),
            new GDFCountryISO("Zimbabwe", "ZW", "ZWE", "716", GDFDataArea.Africa),
            new GDFCountryISO("Åland Islands", "AX", "ALA", "248", GDFDataArea.European_GDPR)
        };
    }
}