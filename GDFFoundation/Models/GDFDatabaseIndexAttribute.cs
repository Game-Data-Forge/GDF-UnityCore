

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a database index attribute for a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class GDFDatabaseIndexAttribute : Attribute
    {
        /// <summary>
        /// Represents the name of an index in the database.
        /// </summary>
        public string IndexName;
        public string[] Columns;

        /// <summary>
        /// Represents a database index attribute for GDFFoundation classes.
        /// </summary>
        public GDFDatabaseIndexAttribute(string sIndexName, params string[] sColumns)
        {
            IndexName = sIndexName;
            Columns = sColumns;
        }
    }

    /// <summary>
    /// Represents a custom attribute used to mark a class for dropping database index.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class GDFDatabaseDropIndexAttribute : Attribute
    {
        /// <summary>
        /// The name of the index.
        /// </summary>
        public string IndexName;

        /// <summary>
        /// Represents an attribute used to specify the name of an index to drop from the database table.
        /// </summary>
        public GDFDatabaseDropIndexAttribute(string sIndexName)
        {
            IndexName = sIndexName;
        }
    }
}