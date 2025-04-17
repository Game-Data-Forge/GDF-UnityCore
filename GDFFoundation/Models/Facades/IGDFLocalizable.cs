

namespace GDFFoundation
{
    /// <summary>
    /// Represents a localizable text.
    /// </summary>
    public interface IGDFLocalizable
    {
        /// <summary>
        /// Gets the context of the localizable text.
        /// </summary>
        /// <returns>The context of the localizable text.</returns>
        public string GetContext();

        /// <summary>
        /// Sets the context of the localizable text.
        /// </summary>
        /// <param name="sContext">The context to set.</param>
        /// <remarks>
        /// Use this method to assign a context to a localizable text.
        /// </remarks>
        public void SetContext(string sContext);

        /// <summary>
        /// Retrieves the translated text for a given language. </summary> <param name="sLanguage">The language to retrieve the translation for.</param> <returns>The translated text for the given language.</returns>
        /// /
        public string GetTranslate(GDFLanguageEnum sLanguage);

        /// <summary>
        /// Sets the translation for a specific language.
        /// </summary>
        /// <param name="sLanguage">The language enum value.</param>
        /// <param name="sTranslate">The translated string.</param>
        public void SetTranslate(GDFLanguageEnum sLanguage, string sTranslate);
    }
}

