

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class that contains information about the average value of a set of numbers.
    /// </summary>
    [Serializable]
    public class GDFAverage
    {
        /// <summary>
        /// Represents the total value.
        /// </summary>
        public float Total { set; get; }

        /// <summary>
        /// Represents a counter property used in the GDFFoundation library.
        /// </summary>
        public float Counter { set; get; }

        /// <summary>
        /// Represents the average value calculated from a collection of values.
        /// </summary>
        public float Average { set; get; }

        /// /
        public GDFAverage()
        {
            Total = 0.0F;
            Counter = 0.0F;
            Average = 0.0F;
        }
    }

    /// <summary>
    /// Represents a class that calculates the average of references in a dictionary. </summary> <typeparam name="T">The type of the references.</typeparam>
    /// /
    [Serializable]
    // TODO change for structure
    public class GDFReferencesAverage<T> : GDFDataType where T : GDFDatabaseObject
    {
        public Dictionary<ulong, GDFAverage> ReferenceAverage { set; get; } = new Dictionary<ulong, GDFAverage>();

    }
}

