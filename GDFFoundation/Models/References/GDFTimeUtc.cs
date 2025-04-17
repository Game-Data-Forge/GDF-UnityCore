

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class for storing UTC time values.
    /// </summary>
    [Serializable]
    public class GDFTimeUtc : GDFDataType
    {
        /// <summary>
        /// Represents a property for storing a value of type int.
        /// </summary>
        public int Value { set; get; } = 0;
    }
}

