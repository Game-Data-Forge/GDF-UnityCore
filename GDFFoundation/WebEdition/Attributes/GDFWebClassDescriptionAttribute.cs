#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebClassDescriptionAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a custom attribute that provides description for a web class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class GDFWebClassDescriptionAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the additional web edition class description attributes.
        /// </summary>
        public GDFWebEditionClassDescription Infos = new GDFWebEditionClassDescription();

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a custom attribute to describe a web class.
        /// </summary>
        public GDFWebClassDescriptionAttribute(
            string sTitle,
            string sBootstrapIcon,
            string sDescription,
            int[] sItemsPerPageOption,
            bool sShowReference,
            bool sShowButton = false,
            bool sJsonClipboard = false
        )
        {
            Infos.Title = sTitle;
            Infos.Icon = sBootstrapIcon;
            Infos.Description = sDescription;
            Infos.ItemsPerPageOption = sItemsPerPageOption;
            Infos.ShowReference = sShowReference;
            Infos.ShowButton = sShowButton;
            Infos.JsonClipboard = sJsonClipboard;
        }

        #endregion
    }
}