#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbDefaultAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to define a default value for the column in an SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbDefaultAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     The default value.
        /// </summary>
        public object value = null;

        #endregion

        #region Instance constructors and destructors

        /// <inheritdoc cref="GDFDbDefaultAttribute(object)" />
        public GDFDbDefaultAttribute()
        {
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="value">The default value.</param>
        public GDFDbDefaultAttribute(object value)
        {
            this.value = value;
        }

        #endregion
    }
}