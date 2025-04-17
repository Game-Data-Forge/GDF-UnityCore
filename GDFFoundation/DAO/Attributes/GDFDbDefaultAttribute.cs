using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to define a default value for the column in an SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbDefaultAttribute : Attribute
    {
        /// <summary>
        /// The default value.
        /// </summary>
        public object value = null;

        /// <inheritdoc cref="GDFDbDefaultAttribute(object)"/>
        public GDFDbDefaultAttribute() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The default value.</param>
        public GDFDbDefaultAttribute(object value)
        {
            this.value = value;
        }
    }
}