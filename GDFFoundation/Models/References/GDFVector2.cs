#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVector2.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a two-dimensional vector.
    /// </summary>
    [Serializable]
    public class GDFVector2 : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents an X property.
        /// </summary>
        /// <remarks>
        ///     This property is used in various classes to represent the value of the X coordinate.
        /// </remarks>
        /// <example>
        ///     The X property can be used in the following way:
        ///     <code>
        /// GDFVector2 vector = new GDFVector2();
        /// vector.X = 10f;
        /// </code>
        /// </example>
        public float X { set; get; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the vector.
        /// </summary>
        public float Y { set; get; }

        #endregion
    }
}