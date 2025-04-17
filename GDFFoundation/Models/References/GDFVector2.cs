


using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a two-dimensional vector.
    /// </summary>
    [Serializable]
    public class GDFVector2 : IGDFSubModel
    {
        /// <summary>
        /// Represents an X property.
        /// </summary>
        /// <remarks>
        /// This property is used in various classes to represent the value of the X coordinate.
        /// </remarks>
        /// <example>
        /// The X property can be used in the following way:
        /// <code>
        /// GDFVector2 vector = new GDFVector2();
        /// vector.X = 10f;
        /// </code>
        /// </example>
        public float X { set; get; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public float Y { set; get; }
    }

}


