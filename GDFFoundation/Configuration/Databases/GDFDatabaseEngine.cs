using System;

namespace GDFFoundation
{
    /// <summary>
    /// The GDFDatabaseKind enum provides values representing different database types that can be used with the GDFFoundation.
    /// </summary>
    /// <remarks>
    /// It is used to specify the type of database to connect to and perform database operations on.
    /// </remarks>
    [Serializable]
    [Obsolete("to rename DatabaseEngine")]
    public enum GDFDatabaseEngine
    {
        /// <summary>
        /// Represents the None member of the GDFDatabaseKind enum.
        /// </summary>
        None = 0,
        /// <summary>
        /// The enum member represents the MySql database engine.
        /// </summary>
        MySql = 1,
        /// <summary>
        /// The enum member represents the MariaDb database engine.
        /// </summary>
        MariaDb = 2,
    }
}