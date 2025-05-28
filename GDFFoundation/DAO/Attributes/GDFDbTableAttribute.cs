#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbTableAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Reflection;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to configure a SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GDFDbTableAttribute : Attribute
    {
        #region Static methods

        /// <summary>
        ///     Get the <see cref="GDFDbTableAttribute" /> for a <see cref="Type" />.
        /// </summary>
        /// <param name="type">The <see cref="Type" /> to get the attribute from.</param>
        /// <returns>The <see cref="GDFDbTableAttribute" /> for the <see cref="Type" />.</returns>
        static public GDFDbTableAttribute Get(Type type)
        {
            GDFDbTableAttribute tableAttribute = type.GetCustomAttribute<GDFDbTableAttribute>();
            if (tableAttribute != null)
            {
                return tableAttribute;
            }

            return new GDFDbTableAttribute(type.Name);
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     The name of the SQL table.
        /// </summary>
        public string name;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="name">The name of the SQL table.</param>
        public GDFDbTableAttribute(string name)
        {
            this.name = name;
        }

        #endregion
    }
}