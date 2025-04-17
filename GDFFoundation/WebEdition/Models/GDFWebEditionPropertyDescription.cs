

using System;
using System.Collections.Generic;
using System.Linq;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a description of a web edition property.
    /// </summary>
    [Serializable]
    public class GDFWebEditionPropertyDescription
    {
        /// <summary>
        /// Represents the style of a web edition property.
        /// </summary>
        public GDFWebEditionStyle Style = GDFWebEditionStyle.Hidden;

        /// <summary>
        /// Represents icon associated with a web edition property description.
        /// </summary>
        public string Icon = string.Empty;

        /// <summary>
        /// Represents a property description for the web edition of a resource.
        /// </summary>
        /// <remarks>
        /// This class is used to store the description of a property in the web edition of a resource.
        /// </remarks>
        public string Description = string.Empty;

        public bool UseAsSortBy = false;

        /// <summary>
        /// Represents a flag indicating whether the property should be used as a column in a web edition property description.
        /// </summary>
        public bool UseAsColumn = false;

        /// <summary>
        /// Gets or sets a value indicating whether this property is the primary column.
        /// </summary>
        public bool IsPrimaryColumn = false;

        /// <summary>
        /// Represents the drop-down values for a web edition property description.
        /// </summary>
        public List<string> DropDownValues = new List<string>();

        /// <summary>
        /// Represents a class that contains the description for a web edition property.
        /// </summary>
        public GDFWebEditionPropertyDescription()
        {
        }

        /// <summary>
        /// Represents a description for a web edition property.
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
    }
}

