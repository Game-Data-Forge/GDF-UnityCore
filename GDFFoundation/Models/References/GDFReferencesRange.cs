

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a range of values with minimum, maximum, and average values.
    /// </summary>
    [Serializable]
    public class GDFRange
    {
        /// <summary>
        /// Represents the minimum value in a range.
        /// </summary>
        public float Min { set; get; }

        /// <summary>
        /// Represents the maximum value of a range.
        /// </summary>
        /// <remarks>
        /// This property is defined in the <see cref="GDFRange"/> class.
        /// It specifies the maximum value of a range.
        /// </remarks>
        public float Max { set; get; }

        /// <summary>
        /// Represents a range with minimum, maximum, and average values.
        /// </summary>
        public float Average { set; get; }

        /// <summary>
        /// Represents a range of values for a specific data type in GDFFoundation.
        /// </summary>
        public GDFRange()
        {
            Min = 0.0F;
            Max = 0.0F;
            Average = 0.0F;
        }
    }

    /// <summary>
    /// Represents a generic class for storing reference ranges.
    /// </summary>
    /// <typeparam name="T">The type of the referenced objects.</typeparam>
    [Serializable]
    public class GDFReferencesRange<T> : GDFDataType where T : GDFDatabaseObject
    {
        /// <summary>
        /// Represents a reference range for a specific data type.
        /// </summary>
        /// <typeparam name="T">The data type that the reference range applies to. Must inherit from GDFDatabaseObject.</typeparam>
        public Dictionary<ulong, GDFRange> ReferenceRange { set; get; } = new Dictionary<ulong, GDFRange>();

    }
}

