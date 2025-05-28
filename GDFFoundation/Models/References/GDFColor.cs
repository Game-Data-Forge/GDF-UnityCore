#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFColor.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a color with RGBA components.
    /// </summary>
    [Serializable]
    public class GDFColor : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the alpha channel value of the color.
        /// </summary>
        public float Alpha { set; get; }

        /// <summary>
        ///     Gets or sets the value of the Blue component in the GDFColor object.
        /// </summary>
        /// <remarks>
        ///     The Blue component represents the intensity of the blue color in the GDFColor.
        ///     It ranges from 0.0 to 1.0, with 0.0 representing no blue and 1.0 representing maximum blue intensity.
        /// </remarks>
        public float Blue { set; get; }

        /// <summary>
        ///     Gets or sets the value of Green for the GDFColor.
        /// </summary>
        public float Green { set; get; }

        /// <summary>
        ///     Gets or sets the value of Red for the GDFColor.
        /// </summary>
        public float Red { set; get; }

        #endregion
    }
}