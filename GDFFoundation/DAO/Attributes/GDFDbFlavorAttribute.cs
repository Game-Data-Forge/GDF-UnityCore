using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to set the flavor to be used to store and retrieve data from a SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbFlavorAttribute : Attribute
    {
        /// <summary>
        /// The type to define a flavor.
        /// </summary>
        public GDFDbType dbType;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dbType">The type to define a flavor.</param>
        public GDFDbFlavorAttribute(GDFDbType dbType)
        {
            this.dbType = dbType;
        }
    }
}