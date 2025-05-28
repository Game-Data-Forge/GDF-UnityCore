#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDatabaseIndexAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a database index attribute for a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class GDFDatabaseIndexAttribute : Attribute
    {
        #region Instance fields and properties

        public string[] Columns;

        /// <summary>
        ///     Represents the name of an index in the database.
        /// </summary>
        public string IndexName;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a database index attribute for GDFFoundation classes.
        /// </summary>
        public GDFDatabaseIndexAttribute(string sIndexName, params string[] sColumns)
        {
            IndexName = sIndexName;
            Columns = sColumns;
        }

        #endregion
    }

    /// <summary>
    ///     Represents a custom attribute used to mark a class for dropping database index.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class GDFDatabaseDropIndexAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     The name of the index.
        /// </summary>
        public string IndexName;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents an attribute used to specify the name of an index to drop from the database table.
        /// </summary>
        public GDFDatabaseDropIndexAttribute(string sIndexName)
        {
            IndexName = sIndexName;
        }

        #endregion
    }
}