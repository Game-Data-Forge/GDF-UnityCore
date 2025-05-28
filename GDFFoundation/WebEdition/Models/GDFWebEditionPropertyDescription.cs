#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebEditionPropertyDescription.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a description of a web edition property.
    /// </summary>
    [Serializable]
    public class GDFWebEditionPropertyDescription
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a property description for the web edition of a resource.
        /// </summary>
        /// <remarks>
        ///     This class is used to store the description of a property in the web edition of a resource.
        /// </remarks>
        public string Description = string.Empty;

        /// <summary>
        ///     Represents the drop-down values for a web edition property description.
        /// </summary>
        public List<string> DropDownValues = new List<string>();

        /// <summary>
        ///     Represents icon associated with a web edition property description.
        /// </summary>
        public string Icon = string.Empty;

        /// <summary>
        ///     Gets or sets a value indicating whether this property is the primary column.
        /// </summary>
        public bool IsPrimaryColumn = false;

        /// <summary>
        ///     Represents the style of a web edition property.
        /// </summary>
        public GDFWebEditionStyle Style = GDFWebEditionStyle.Hidden;

        /// <summary>
        ///     Represents a flag indicating whether the property should be used as a column in a web edition property description.
        /// </summary>
        public bool UseAsColumn = false;

        public bool UseAsSortBy = false;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a class that contains the description for a web edition property.
        /// </summary>
        public GDFWebEditionPropertyDescription()
        {
        }

        /// <summary>
        ///     Represents a description for a web edition property.
        /// </summary>
        public GDFWebEditionPropertyDescription(
            GDFWebEditionStyle style,
            string icon,
            string description,
            bool useAsSortBy = false,
            bool useAsDescription = false,
            bool useAsTitle = false,
            bool isPrimaryColumn = false
        )
        {
            Style = style;
            Icon = icon;
            Description = description;
            UseAsSortBy = useAsSortBy;
            UseAsColumn = useAsDescription;
            IsPrimaryColumn = useAsTitle;
            IsPrimaryColumn = isPrimaryColumn;
        }

        #endregion
    }
}