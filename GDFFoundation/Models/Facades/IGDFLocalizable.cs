#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFLocalizable.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Represents a localizable text.
    /// </summary>
    public interface IGDFLocalizable
    {
        #region Instance methods

        /// <summary>
        ///     Gets the context of the localizable text.
        /// </summary>
        /// <returns>The context of the localizable text.</returns>
        public string GetContext();

        /// <summary>
        ///     Retrieves the translated text for a given language.
        /// </summary>
        /// <param name="sLanguage">The language to retrieve the translation for.</param>
        /// <returns>The translated text for the given language.</returns>
        /// /
        public string GetTranslate(GDFLanguageEnum sLanguage);

        /// <summary>
        ///     Sets the context of the localizable text.
        /// </summary>
        /// <param name="sContext">The context to set.</param>
        /// <remarks>
        ///     Use this method to assign a context to a localizable text.
        /// </remarks>
        public void SetContext(string sContext);

        /// <summary>
        ///     Sets the translation for a specific language.
        /// </summary>
        /// <param name="sLanguage">The language enum value.</param>
        /// <param name="sTranslate">The translated string.</param>
        public void SetTranslate(GDFLanguageEnum sLanguage, string sTranslate);

        #endregion
    }
}