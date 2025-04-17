

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a color with RGBA components.
    /// </summary>
    [Serializable]
    public class GDFColor : IGDFSubModel
    {
        /// <summary>
        /// Gets or sets the value of Red for the GDFColor.
        /// </summary>
        public float Red { set; get; }

        /// <summary>
        /// Gets or sets the value of Green for the GDFColor.
        /// </summary>
        public float Green { set; get; }

        /// <summary>
        /// Gets or sets the value of the Blue component in the GDFColor object.
        /// </summary>
        /// <remarks>
        /// The Blue component represents the intensity of the blue color in the GDFColor.
        /// It ranges from 0.0 to 1.0, with 0.0 representing no blue and 1.0 representing maximum blue intensity.
        /// </remarks>
        public float Blue { set; get; }

        /// <summary>
        /// Gets or sets the alpha channel value of the color.
        /// </summary>
        public float Alpha { set; get; }
    }
}

