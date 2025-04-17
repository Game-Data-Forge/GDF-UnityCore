using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to define the maximum leght of a string when storing in a SQl table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbLengthAttribute : Attribute
    {
        /// <summary>
        /// The maximum length of the string.
        /// </summary>
        public int length;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="length">The maximum length of the string.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if length is inferior or equal to 0.</exception>
        public GDFDbLengthAttribute(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length");

            this.length = length;
        }
    }
}