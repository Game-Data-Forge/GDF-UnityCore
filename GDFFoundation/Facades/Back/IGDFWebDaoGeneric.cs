

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a generic web-based data access object.
    /// </summary>
    public interface IGDFWebDaoGeneric : IGDFAbstractDao
    {
        /// <summary>
        /// Retrieves the credentials for the database.
        /// </summary>
        /// <returns>The credentials for the database.</returns>
        public GDFDatabaseCredentials GetCredential();

        /// <summary>
        /// Generates a fingerprint of the specified table for the given environment.
        /// </summary>
        /// <typeparam name="T">The type of the table.</typeparam>
        /// <param name="sEnvironment">The environment for which the fingerprint needs to be generated.</param>
        /// <returns>A string representing the fingerprint of the table for the given environment.</returns>
        public string FingerPrintTable<T>(GDFEnvironmentKind sEnvironment) where T : GDFLocalWebData;

        /// <summary>
        /// Generates the fingerprint table name based on the generic type and the environment.
        /// </summary>
        /// <typeparam name="T">The type of the GDFLocalWebData subclass.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <returns>The generated fingerprint table name.</returns>
        public string FingerPrintTableName<T>(GDFEnvironmentKind sEnvironment) where T : GDFLocalWebData;

        /// <summary>
        /// Check if a table with specified model exists in the specified environment.
        /// </summary>
        /// <typeparam name="T">The type of the model representing the table.</typeparam>
        /// <param name="sEnvironment">The environment to check.</param>
        /// <returns>True if the table exists, false otherwise.</returns>
        public bool TableExists<T>(GDFEnvironmentKind sEnvironment) where T : GDFLocalWebData;

        /// <summary>
        /// Creates a table in the specified environment for a given model class.
        /// </summary>
        /// <typeparam name="T">The type of the model class to create a table for. Must inherit from GDFLocalWebData.</typeparam>
        /// <param name="sEnvironment">The environment in which the table should be created.</param>
        public void CreateTable<T>(GDFEnvironmentKind sEnvironment) where T : GDFLocalWebData;

        /// <summary>
        /// Deletes all records from the specified table in the specified environment.
        /// </summary>
        /// <typeparam name="T">The type of the model representing the table.</typeparam>
        /// <param name="sEnvironment">The environment in which to delete the records.</param>
        public void DeleteTable<T>(GDFEnvironmentKind sEnvironment) where T : GDFLocalWebData;

        /// <summary>
        /// Deletes a record from the database.
        /// </summary>
        /// <typeparam name="T">The type of the record to delete. Must inherit from GDFLocalWebData.</typeparam>
        /// <param name="sEnvironment">The environment in which the record exists.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sObject">The record object to delete.</param>
        /// <returns><c>true</c> if the record was successfully deleted; otherwise, <c>false</c>.</returns>
        public bool Delete<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, T sObject) where T : GDFLocalWebData;

        /// <summary>
        /// Retrieves a record from the database by reference.
        /// </summary>
        /// <typeparam name="T">The type of the record.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference of the record.</param>
        /// <returns>The record if found; otherwise, null.</returns>
        public T GetByReference<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, string sReference) where T : GDFLocalWebData;

        /// <summary>
        /// Retrieves the first record of type T from the specified environment, project, and where clause.
        /// </summary>
        /// <typeparam name="T">The type of record to retrieve. Must inherit from GDFLocalWebData.</typeparam>
        /// <param name="sEnvironment">The environment to retrieve the record from.</param>
        /// <param name="sProjectReference">The project ID to retrieve the record from.</param>
        /// <param name="sWhereClause">The list of where clauses to filter the records.</param>
        /// <returns>The first record of type T that matches the specified criteria, or null if no matching record is found.</returns>
        public T GetFirstBy<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFLocalWebData;

        /// <summary>
        /// Retrieves a list of objects of type T from the specified environment and project, according to the given where clauses.
        /// </summary>
        /// <typeparam name="T">The type of objects to retrieve.</typeparam>
        /// <param name="sEnvironment">The environment to retrieve the objects from.</param>
        /// <param name="sProjectReference">The project id to retrieve the objects from.</param>
        /// <param name="sWhereClause">The list of where clauses to filter the objects.</param>
        /// <returns>A list of objects of type T that match the specified conditions.</returns>
        public List<T> GetBy<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFLocalWebData;

        /// <summary>
        /// Generates a random string containing only numbers.
        /// </summary>
        /// <param name="sLength">The length of the random string to generate.</param>
        /// <returns>A random string of numbers.</returns>
        public string RandomStringNumber(int sLength);

        /// <summary>
        /// Generates a new valid reference for a given type in a specified environment and project.
        /// </summary>
        /// <typeparam name="T">The type of the reference.</typeparam>
        /// <param name="sEnvironment">The environment to generate the reference in.</param>
        /// <param name="sProjectReference">The project ID to generate the reference for.</param>
        /// <returns>A new valid reference.</returns>
        public long NewValidReference<T>(GDFEnvironmentKind sEnvironment, long sProjectReference) where T : GDFLocalWebData;

        /// <summary>
        /// Checks if a reference exists for the specified environment, project ID and reference ID.
        /// </summary>
        /// <typeparam name="T">A type that inherits from GDFLocalWebData.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference ID.</param>
        /// <returns>True if the reference exists, otherwise false.</returns>
        public bool TestIfReferenceExists<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference) where T : GDFLocalWebData;

        /// <summary>
        /// Test the connection to the database.
        /// </summary>
        /// <returns>Returns true if the connection is successful, otherwise false.</returns>
        public bool TestConnexion();

        /// <summary>
        /// Creates a new instance of the specified model and inserts it into the database.
        /// </summary>
        /// <param name="sEnvironment">The environment to create the instance.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The model instance to create.</param>
        /// <param name="sWithNewReference">Indicates whether a new reference should be generated.</param>
        /// <returns>Returns the created model instance.</returns>
        public T Create<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, T sModel, bool sWithNewReference) where T : GDFLocalWebData;

        /// <summary>
        /// Deletes an instance of the specified generic type from the database.
        /// </summary>
        /// <typeparam name="T">The type of the instance to delete. Must be a subclass of GDFLocalWebData.</typeparam>
        /// <param name="sEnvironment">The environment kind of the database.</param>
        /// <param name="sProjectReference">The project ID of the database.</param>
        /// <param name="sReference">The reference ID of the instance to delete.</param>
        /// <returns>True if the instance was successfully deleted, otherwise false.</returns>
        public bool Delete<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference) where T : GDFLocalWebData;

        /// <summary>
        /// Finds all instances of type T in the specified environment and project.
        /// </summary>
        /// <typeparam name="T">The type of objects to find.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of instances of type T.</returns>
        public List<T> FindAll<T>(GDFEnvironmentKind sEnvironment, long sProjectReference) where T : GDFLocalWebData;

        /// <summary>
        /// Find all modified instances of the given type T in a specific environment, project, and sync date.
        /// </summary>
        /// <typeparam name="T">The type of instances to find.</typeparam>
        /// <param name="sEnvironment">The environment in which to search for modified instances.</param>
        /// <param name="sProjectReference">The project ID of the instances to find.</param>
        /// <param name="sSyncDate">The sync date of the instances to find.</param>
        /// <returns>A list of modified instances of type T.</returns>
        /// <exception cref="System.ArgumentException">Thrown when sEnvironment is invalid.</exception>
        /// <exception cref="System.Exception">Thrown when an error occurs during the search.</exception>
        public List<T> FindAllModified<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate) where T : GDFLocalWebData;

        /// <summary>
        /// Insert or update the given model in the specified environment and project with optional new reference creation.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="sEnvironment">The environment.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The model to insert or update.</param>
        /// <param name="sWithNewReference">Flag indicating whether to create a new reference.</param>
        /// <returns>The inserted or updated model.</returns>
        public T InsertOrUpdate<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, T sModel, bool sWithNewReference) where T : GDFLocalWebData;

    }
}

