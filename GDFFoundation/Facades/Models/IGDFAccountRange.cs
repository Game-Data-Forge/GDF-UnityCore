using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an interface for objects that have an account range.
    /// </summary>
    ///  TODO rename?
    [Obsolete("Use IGDFRangedData instead !")]
    public interface IGDFAccountRange
    {
        /// <summary>
        /// Represents a property that defines the range of a value.
        /// This property is used in various classes to define the range of a value.
        /// </summary>
        public short Range { set; get; }
    }
}


