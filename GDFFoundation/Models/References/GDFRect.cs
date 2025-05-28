#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRect.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a rectangle with position and size.
    /// </summary>
    [Serializable]
    public class GDFRect : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the height of a rectangle in the GDFFoundation library.
        /// </summary>
        /// <remarks>
        ///     This property is part of the <see cref="GDFRect" /> class, which is used to represent rectangular shapes.
        ///     The height of the rectangle is defined by this property.
        /// </remarks>
        public float H { set; get; }

        /// <summary>
        ///     Gets or sets the width of the GDFFoundation rectangle.
        /// </summary>
        public float W { set; get; }

        /// <summary>
        ///     Gets or sets the X value of the GDFRect.
        /// </summary>
        public float X { set; get; }

        /// <summary>
        ///     Gets or sets the Y-component of the GDFRect.
        /// </summary>
        /// <value>The Y-component of the GDFRect.</value>
        public float Y { set; get; }

        #endregion
    }
}