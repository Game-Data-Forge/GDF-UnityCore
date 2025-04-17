

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a localizable text.
    /// </summary>
    [Serializable]
    [Obsolete("Use GDFStringLocalization instead!")]
    public class GDFLocalizableText : IGDFSubModel, IGDFLocalizable
    {
        /// <summary>
        /// The Context property represents the context of the GDFLocalizableText object.
        /// </summary>
        /// <remarks>
        /// This property is used to indicate the context in which the localized text will be used.
        /// </remarks>
        /// <value>
        /// A string representing the context of the GDFLocalizableText object.
        /// </value>
        public string Context { set; get; } = string.Empty;

        /// <summary>
        /// Represents a localizable text.
        /// </summary>
        public Dictionary<GDFLanguageEnum, string> Values { set; get; } = new Dictionary<GDFLanguageEnum, string>();

        /// <summary>
        /// Gets the context of the localizable text.
        /// </summary>
        /// <returns>The context of the localizable text.</returns>
        public string GetContext()
        {
            return Context;
        }

        /// <summary>
        /// Sets the context of the localizable text.
        /// </summary>
        /// <param name="sContext">The context to set.</param>
        /// <remarks>
        /// Use this method to assign a context to a localizable text.
        /// </remarks>
        public void SetContext(string sContext)
        {
            if (string.IsNullOrEmpty(sContext))
            {
                sContext = string.Empty;
            }
            Context = sContext;
        }

        /// <summary>
        /// Get the translated value for a specific language.
        /// </summary>
        /// <param name="sLanguage">The language enum value for which translation is needed.</param>
        /// <returns>The translated value as a string. If no translation is available, an empty string is returned.</returns>
        public string GetTranslate(GDFLanguageEnum sLanguage)
        {
            string rReturn = String.Empty;
            if (Values.ContainsKey(sLanguage) == true)
            {
                rReturn = Values[sLanguage];
                if (string.IsNullOrEmpty(rReturn))
                {
                    rReturn = String.Empty;
                }
            }
            return rReturn;
        }

        /// <summary>
        /// Sets the translation for a specific language in the GDFLocalizableText class.
        /// </summary>
        /// <param name="sLanguage">The language for which to set the translation.</param>
        /// <param name="sTranslate">The translation to set.</param>
        public void SetTranslate(GDFLanguageEnum sLanguage, string sTranslate)
        {
            if (string.IsNullOrEmpty(sTranslate))
            {
                sTranslate = string.Empty;
            }
            if (Values.ContainsKey(sLanguage) == true)
            {
                Values[sLanguage] = sTranslate;
            }
            else
            {
                Values.Add(sLanguage, sTranslate);
            }
        }
    }
}


