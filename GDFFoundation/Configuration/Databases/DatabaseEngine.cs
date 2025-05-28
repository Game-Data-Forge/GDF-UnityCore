#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDatabaseEngine.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     The GDFDatabaseKind enum provides values representing different database types that can be used with the GDFFoundation.
    /// </summary>
    /// <remarks>
    ///     It is used to specify the type of database to connect to and perform database operations on.
    /// </remarks>
    [Serializable]
    public enum DatabaseEngine
    {
        /// <summary>
        ///     Represents the None member of the GDFDatabaseKind enum.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The enum member represents the MySql database engine.
        /// </summary>
        MySql = 1,

        /// <summary>
        ///     The enum member represents the MariaDb database engine.
        /// </summary>
        MariaDb = 2,
    }
}