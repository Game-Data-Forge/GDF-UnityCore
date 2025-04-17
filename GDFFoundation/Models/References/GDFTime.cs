

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a time data type in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFTime : GDFDataType
    {
        /// <summary>
        /// Represents a data type for storing a value.
        /// </summary>
        public int Value { set; get; } = 0;
    }
}



