#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalizationISO.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an ISO localization containing information such as name, short code, long code, and language.
    /// </summary>
    public class GDFLocalizationISO
    {
        #region Static fields and properties

        /// <summary>
        ///     Represents a dictionary containing localization ISO objects indexed by GDFLanguageEnum.
        /// </summary>
        private static readonly Dictionary<GDFLanguageEnum, GDFLocalizationISO> ByEnumDictionary = new Dictionary<GDFLanguageEnum, GDFLocalizationISO>();

        /// <summary>
        ///     Represents a dictionary that maps long codes to GDFLocalizationISO objects.
        /// </summary>
        private static readonly Dictionary<string, GDFLocalizationISO> ByLongCodeDictionary = new Dictionary<string, GDFLocalizationISO>();

        /// <summary>
        ///     Represents a dictionary that allows retrieval of GDFLocalizationISO objects by name.
        /// </summary>
        private static readonly Dictionary<string, GDFLocalizationISO> ByNameDictionary = new Dictionary<string, GDFLocalizationISO>();

        /// <summary>
        ///     Represents a dictionary that maps a short code to a localization ISO object.
        /// </summary>
        private static readonly Dictionary<string, GDFLocalizationISO> ByShortCodeDictionary = new Dictionary<string, GDFLocalizationISO>();

        /// <summary>
        ///     Represents a dictionary of language localization ISO objects.
        /// </summary>
        public static GDFLocalizationISO[] LanguageDictionary;

        #endregion

        #region Static constructors and destructors

        /// <summary>
        ///     The GDFLocalizationISO class is responsible for handling ISO localization.
        /// </summary>
        static GDFLocalizationISO()
        {
            LanguageDictionary = new GDFLocalizationISO[]
            {
                new GDFLocalizationISO("English", "en", "en_US", GDFLanguageEnum.English),
                //new GDFLocalizationISO("English (U.S.)", "en", "en_US", GDFLanguageEnum.English),
                //new GDFLocalizationISO("English (British)", "en", "en_GB", GDFLanguageEnum.English),
                //new GDFLocalizationISO("English (Australian)", "en", "en_AU", GDFLanguageEnum.English),
                //new GDFLocalizationISO("English (Canadian)", "en", "en_CA", GDFLanguageEnum.English),
                //new GDFLocalizationISO("English (Indian)", "en", "en_IN", GDFLanguageEnum.English),
                new GDFLocalizationISO("French", "fr", "fr_FR", GDFLanguageEnum.French),
                //new GDFLocalizationISO("French (Canadian)", "fr", "fr_CA", GDFLanguageEnum.French),
                new GDFLocalizationISO("Spanish", "es", "es_ES", GDFLanguageEnum.Spanish),
                //new GDFLocalizationISO("Spanish (Mexico)", "es", "es_MX", GDFLanguageEnum.Spanish),
                new GDFLocalizationISO("Portuguese", "pt", "pt_PT", GDFLanguageEnum.Portuguese),
                //new GDFLocalizationISO("Portuguese (Brazil)", "pt", "pt_BR", GDFLanguageEnum.Portuguese),
                new GDFLocalizationISO("Italian", "it", "it_IT", GDFLanguageEnum.Italian),
                new GDFLocalizationISO("German", "de", "de_DE", GDFLanguageEnum.German),
                new GDFLocalizationISO("Chinese (Simplified)", "zhs", "zh_CN", GDFLanguageEnum.Chinese_Simplified),
                new GDFLocalizationISO("Chinese (Traditional)", "zht", "zh_TW", GDFLanguageEnum.Chinese_Traditional),
                new GDFLocalizationISO("Dutch", "nl", "nl_NL", GDFLanguageEnum.Dutch),
                new GDFLocalizationISO("Japanese", "ja", "ja_JP", GDFLanguageEnum.Japanese),
                new GDFLocalizationISO("Korean", "ko", "ko_KR", GDFLanguageEnum.Korean),
                new GDFLocalizationISO("Vietnamese", "vi", "vi_VN", GDFLanguageEnum.Vietnamese),
                new GDFLocalizationISO("Russian", "ru", "ru_RU", GDFLanguageEnum.Russian),
                new GDFLocalizationISO("Swedish", "sv", "sv_SE", GDFLanguageEnum.Swedish),
                new GDFLocalizationISO("Danish", "da", "da_DK", GDFLanguageEnum.Danish),
                new GDFLocalizationISO("Finnish", "fi", "fi_FI", GDFLanguageEnum.Finnish),
                new GDFLocalizationISO("Norwegian (Bokmal)", "nb", "nb_NO", GDFLanguageEnum.Norwegian),
                //new GDFLocalizationISO("Norwegian (Nynorsk)", "nb", "nn_NO", GDFLanguageEnum.Norwegian),
                new GDFLocalizationISO("Turkish", "tr", "tr_TR", GDFLanguageEnum.Turkish),
                new GDFLocalizationISO("Greek", "el", "el_GR", GDFLanguageEnum.Greek),
                new GDFLocalizationISO("Indonesian", "id", "id_ID", GDFLanguageEnum.Indonesian),
                new GDFLocalizationISO("Malay", "ms", "ms_MY", GDFLanguageEnum.Malay),
                new GDFLocalizationISO("Thai", "th", "th_TH", GDFLanguageEnum.Thai),
                new GDFLocalizationISO("Hindi", "hi", "hi_IN", GDFLanguageEnum.Hindi),
                new GDFLocalizationISO("Hungarian", "hu", "hu_HU", GDFLanguageEnum.Hungarian),
                new GDFLocalizationISO("Polish", "pl", "pl_PL", GDFLanguageEnum.Polish),
                new GDFLocalizationISO("Czech", "cs", "cs_CZ", GDFLanguageEnum.Czech),
                new GDFLocalizationISO("Slovak", "sk", "sk_SK", GDFLanguageEnum.Slovak),
                new GDFLocalizationISO("Ukrainian", "uk", "uk_UA", GDFLanguageEnum.Ukrainian),
                new GDFLocalizationISO("Croatian", "hr", "hr_HR", GDFLanguageEnum.Croatian),
                new GDFLocalizationISO("Catalan", "ca", "ca_ES", GDFLanguageEnum.Catalan),
                new GDFLocalizationISO("Romanian", "ro", "ro_RO", GDFLanguageEnum.Romanian),
                new GDFLocalizationISO("Hebrew", "he", "he_IL", GDFLanguageEnum.Hebrew),
                new GDFLocalizationISO("Arabic", "ar", "ar_AR", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Algeria)", "ar", "ar_DZ", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Bahrain)", "ar", "ar_BH", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Egypt)", "ar", "ar_EG", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Iraq)", "ar", "ar_IQ", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Jordan)", "ar", "ar_JO", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Kuwait)", "ar", "ar_KW", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Lebanon)", "ar", "ar_LB", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Libya)", "ar", "ar_LY", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Morocco)", "ar", "ar_MA", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Oman)", "ar", "ar_OM", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Qatar)", "ar", "ar_QA", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Saudi Arabia)", "ar", "ar_SA", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Sudan)", "ar", "ar_SD", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Syria)", "ar", "ar_SY", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Tunisia)", "ar", "ar_TN", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Uae)", "ar", "ar_AE", GDFLanguageEnum.Arabic),
                //new GDFLocalizationISO("Arabic(Yemen)", "ar", "ar_YE", GDFLanguageEnum.Arabic),
            };
        }

        #endregion

        #region Static methods

        /// <summary>
        ///     Retrieves the GDFLocalizationISO object based on the specified GDFLanguageEnum.
        /// </summary>
        /// <param name="sEnum">The GDFLanguageEnum value.</param>
        /// <returns>The GDFLocalizationISO object associated with the specified GDFLanguageEnum, or null if not found.</returns>
        public static GDFLocalizationISO GetByEnum(GDFLanguageEnum sEnum)
        {
            GDFLocalizationISO rReturn = null;
            ByEnumDictionary.TryGetValue(sEnum, out rReturn);
            return rReturn;
        }

        /// <summary>
        ///     Retrieves the GDFLocalizationISO object based on the long code.
        /// </summary>
        /// <param name="sLongCode">The long code of the localization ISO object.</param>
        /// <returns>
        ///     The GDFLocalizationISO object with the given long code, or null if it doesn't exist.
        /// </returns>
        public static GDFLocalizationISO GetByLongCode(string sLongCode)
        {
            GDFLocalizationISO rReturn = null;
            ByLongCodeDictionary.TryGetValue(sLongCode, out rReturn);
            return rReturn;
        }

        /// <summary>
        ///     Returns the GDFLocalizationISO object by its name.
        /// </summary>
        /// <param name="sName">The name of the GDFLocalizationISO object.</param>
        /// <returns>The GDFLocalizationISO object if found, otherwise null.</returns>
        public static GDFLocalizationISO GetByName(string sName)
        {
            GDFLocalizationISO rReturn = null;
            ByNameDictionary.TryGetValue(sName, out rReturn);
            return rReturn;
        }

        /// <summary>
        ///     Get the GDFLocalizationISO object by its short code.
        /// </summary>
        /// <param name="sShortCode">The short code of the GDFLocalizationISO to retrieve.</param>
        /// <returns>The GDFLocalizationISO object with the given short code, or null if not found.</returns>
        public static GDFLocalizationISO GetByShortCode(string sShortCode)
        {
            GDFLocalizationISO rReturn = null;
            ByShortCodeDictionary.TryGetValue(sShortCode, out rReturn);
            return rReturn;
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a language property of a GDFLocalizationISO object.
        /// </summary>
        public GDFLanguageEnum Language { get; private set; }

        /// <summary>
        ///     Gets the long code representing the localization ISO object.
        /// </summary>
        /// <remarks>
        ///     This property represents the long code associated with a localization ISO object.
        /// </remarks>
        public string LongCode { get; private set; }

        /// <summary>
        ///     Gets the name of the GDFLocalizationISO object.
        /// </summary>
        /// <value>
        ///     The name of the GDFLocalizationISO object.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        ///     Represents the short code associated with a localization ISO object.
        /// </summary>
        public string ShortCode { get; private set; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     The GDFLocalizationISO class represents an ISO localization code.
        /// </summary>
        /// <param name="sName">The name of the GDFLocalizationISO object.</param>
        /// <param name="sShortCode">The short code of the GDFLocalizationISO object.</param>
        /// <param name="sLongCode">The long code of the GDFLocalizationISO object.</param>
        /// <param name="sLanguage">The language of the GDFLocalizationISO object.</param>
        public GDFLocalizationISO(string sName, string sShortCode, string sLongCode, GDFLanguageEnum sLanguage)
        {
            Name = sName;
            ShortCode = sShortCode;
            LongCode = sLongCode;
            Language = sLanguage;

            ByNameDictionary.Add(Name, this);
            ByShortCodeDictionary.Add(ShortCode, this);
            ByLongCodeDictionary.Add(LongCode, this);
            ByEnumDictionary.Add(Language, this);
        }

        #endregion
    }
}