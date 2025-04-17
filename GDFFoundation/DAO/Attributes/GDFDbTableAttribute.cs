using System;
using System.Reflection;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to configure a SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GDFDbTableAttribute : Attribute
    {
        /// <summary>
        /// Get the <see cref="GDFDbTableAttribute"/> for a <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to get the attribute from.</param>
        /// <returns>The <see cref="GDFDbTableAttribute"/> for the <see cref="Type"/>.</returns>
        static public GDFDbTableAttribute Get(Type type)
        {
            GDFDbTableAttribute tableAttribute = type.GetCustomAttribute<GDFDbTableAttribute>();
            if (tableAttribute != null)
            {
                return tableAttribute;
            }

            return new GDFDbTableAttribute(type.Name);
        }

        /// <summary>
        /// The name of the SQL table.
        /// </summary>
        public string name;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the SQL table.</param>
        public GDFDbTableAttribute(string name)
        {
            this.name = name;
        }
    }
}