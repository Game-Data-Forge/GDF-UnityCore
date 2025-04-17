using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an abstract data access object.
    /// </summary>
    public interface IGDFAbstractDao
    {

    }

    /// <summary>
    /// Interface for GDFDao objects that provides database access functionality.
    /// </summary>
    public interface IGDFDao : IGDFAbstractDao
    {
        /// <summary>
        /// Retrieves the database credentials that are required to connect to a database.
        /// </summary>
        /// <returns>The database credentials.</returns>
        public GDFDatabaseCredentials GetCredential();

        /// <summary>
        /// Calculates the fingerprint of a table for the given environment.
        /// </summary>
        /// <param name="sEnvironment">The environment for which to calculate the fingerprint.</param>
        /// <returns>The calculated fingerprint of the table.</returns>
        public string FingerPrintTable(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Retrieves the name of the fingerprint table based on the given environment.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <returns>The name of the fingerprint table.</returns>
        public string FingerPrintTableName(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Checks if a table exists in the specified environment.
        /// </summary>
        /// <param name="sEnvironment">The environment to check the table in.</param>
        /// <returns>
        /// Returns true if the table exists in the specified environment;
        /// otherwise, false.
        /// </returns>
        public bool TableExists(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Creates a table in the database based on the provided environment.
        /// </summary>
        /// <param name="sEnvironment">The environment to create the table in.</param>
        public void CreateTable(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Deletes a table based on the given environment.
        /// </summary>
        /// <param name="sEnvironment">The environment to delete the table from.</param>
        public void DeleteTable(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Creates an index for a specific environment.
        /// </summary>
        /// <param name="sEnvironment">The environment for which the index should be created.</param>
        public void CreateIndex(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Deletes the index for a specific environment.
        /// </summary>
        /// <param name="sEnvironment">The environment for which to delete the index.</param>
        public void DeleteIndex(GDFEnvironmentKind sEnvironment);

        /// <summary>
        /// Retrieves the range of the dao.
        /// </summary>
        /// <returns>The range of the dao.</returns>
        public short GetRange();

        /// <summary>
        /// Test the connection to the database.
        /// </summary>
        /// <returns>True if the connection is successful; otherwise, false.</returns>
        public bool TestConnexion();

        /// <summary>
        /// Retrieves information about the current database connection.
        /// </summary>
        /// <returns>A string containing information about the current database connection.</returns>
        public string GetInfos();

        /// <summary>
        /// Gets the current system date and time.
        /// </summary>
        /// <returns>The current system date and time.</returns>
        public DateTime GetCurrentDatetime();

        /// <summary>
        /// Generates a new commit ID.
        /// </summary>
        /// <returns>A new commit ID as a signed 64-bit integer.</returns>
        public Int64 GenerateNewCommitId();
    }
}

