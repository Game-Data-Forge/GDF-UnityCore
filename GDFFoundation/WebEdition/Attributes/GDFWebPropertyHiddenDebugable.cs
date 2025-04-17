namespace GDFFoundation
{
    /// <summary>
    /// Specifies that the property should be hidden and made debuggable in the web edition.
    /// </summary>
    public class GDFWebPropertyHiddenDebugable : GDFWebPropertyDescriptionAttribute
    {
        /// <summary>
        /// Represents an attribute that provides a description for a web property and specifies whether it should be hidden in debug mode.
        /// </summary>
        public GDFWebPropertyHiddenDebugable()
        {
            Infos.Icon = string.Empty;
            Infos.Description = string.Empty;
            Infos.UseAsSortBy = false;
            Infos.UseAsColumn = false;
            Infos.IsPrimaryColumn = false;
        }
    }
}