#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbFlavorAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to set the flavor to be used to store and retrieve data from a SQL table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbFlavorAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     The type to define a flavor.
        /// </summary>
        public GDFDbType dbType;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dbType">The type to define a flavor.</param>
        public GDFDbFlavorAttribute(GDFDbType dbType)
        {
            this.dbType = dbType;
        }

        #endregion
    }
}