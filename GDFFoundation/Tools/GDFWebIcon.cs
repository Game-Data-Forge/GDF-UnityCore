#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebIcon.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Represents a web icon for different file types.
    /// </summary>
    public class GDFWebIcon
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the icon for a document file.
        /// </summary>
        public string DocIcon { set; get; } = "bi-filetype-doc";

        /// <summary>
        ///     Represents the icon for a DOCX file.
        /// </summary>
        public string DocxIcon { set; get; } = "bi-filetype-docx";

        /// <summary>
        ///     Represents the PDF icon for a web page.
        /// </summary>
        public string PdfIcon { set; get; } = "bi-filetype-pdf";

        #endregion
    }
}