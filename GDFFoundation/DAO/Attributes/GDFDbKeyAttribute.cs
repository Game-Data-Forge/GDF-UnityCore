#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbKeyAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to declare a primary key.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbKeyAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Has this primary key an auto increment ?
        /// </summary>
        public bool autoIncrement;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="autoIncrement">Has this primary key an auto increment ?</param>
        public GDFDbKeyAttribute(bool autoIncrement = false)
        {
            this.autoIncrement = autoIncrement;
        }

        #endregion
    }
}