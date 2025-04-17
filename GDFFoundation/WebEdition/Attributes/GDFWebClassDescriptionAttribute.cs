

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a custom attribute that provides description for a web class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class GDFWebClassDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Represents the additional web edition class description attributes.
        /// </summary>
        public GDFWebEditionClassDescription Infos = new GDFWebEditionClassDescription();

        /// <summary>
        /// Represents a custom attribute to describe a web class.
        /// </summary>
        public GDFWebClassDescriptionAttribute(string sTitle, string sBootstrapIcon, string sDescription, int[] sItemsPerPageOption, bool sShowReference, bool sShowButton = false, bool sJsonClipboard = false)
        {
            Infos.Title = sTitle;
            Infos.Icon = sBootstrapIcon;
            Infos.Description = sDescription;
            Infos.ItemsPerPageOption = sItemsPerPageOption;
            Infos.ShowReference = sShowReference;
            Infos.ShowButton = sShowButton;
            Infos.JsonClipboard = sJsonClipboard;
        }
    }
}

