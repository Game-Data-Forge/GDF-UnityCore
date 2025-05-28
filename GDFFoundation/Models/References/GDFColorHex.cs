#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFColorHex.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a color in hexadecimal format.
    /// </summary>
    [Serializable]
    public class GDFColorHex : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random color in hexadecimal format (RGB or RGBA).
        /// </summary>
        /// <returns>A new instance of <see cref="GDFColorHex" /> with random color values.</returns>
        public static GDFColorHex Random()
        {
            return new GDFColorHex()
            {
                Red = GDFRandom.Int255Numeric(),
                Green = GDFRandom.Int255Numeric(),
                Blue = GDFRandom.Int255Numeric(),
                Alpha = GDFRandom.Int255Numeric(),
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Property Alpha represents the alpha value of a color in the GDFColorHex class.
        /// </summary>
        /// <remarks>
        ///     The Alpha property is used to control the transparency of a color. It represents the alpha channel value of the color, which determines how opaque or transparent the color appears.
        /// </remarks>
        public int Alpha { set; get; }

        /// <summary>
        ///     Represents the blue component of an RGB color.
        /// </summary>
        public int Blue { set; get; }

        /// <summary>
        ///     Gets or sets the Green value of the GDFColorHex.
        /// </summary>
        /// <value>The Green value.</value>
        public int Green { set; get; }

        /// <summary>
        ///     The Red property represents the value of the red channel in a color.
        /// </summary>
        public int Red { set; get; }

        #endregion
    }
}