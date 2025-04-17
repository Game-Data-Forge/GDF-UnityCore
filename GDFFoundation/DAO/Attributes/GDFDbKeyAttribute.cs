using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to declare a primary key.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbKeyAttribute : Attribute
    {
        /// <summary>
        /// Has this primary key an auto increment ?
        /// </summary>
        public bool autoIncrement;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="autoIncrement">Has this primary key an auto increment ?</param>
        public GDFDbKeyAttribute(bool autoIncrement = false)
        {
            this.autoIncrement = autoIncrement;
        }
    }
}