namespace GDFFoundation
{
    /// <summary>
    /// Attribute used to hide a property from web edition in the inspector.
    /// </summary>
    public class GDFWebPropertyHidden : GDFWebPropertyDescriptionAttribute
    {
        public GDFWebPropertyHidden()
        {
            Infos.Style = GDFWebEditionStyle.Hidden;
            Infos.Icon = string.Empty;
            Infos.Description = string.Empty;
            Infos.UseAsSortBy = false;
            Infos.UseAsColumn = false;
            Infos.IsPrimaryColumn = false;
        }
    }
}