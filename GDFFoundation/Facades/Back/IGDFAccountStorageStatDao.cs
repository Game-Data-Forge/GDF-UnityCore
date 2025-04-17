

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a data access object for managing the storage statistics of an account.
    /// </summary>
    public interface IGDFAccountStorageStatDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFAccountStorageStat object and saves it in the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat object to create.</param>
        /// <returns>The created GDFAccountStorageStat object.</returns>
        public GDFAccountStorageStat Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        /// <summary>
        /// Updates the GDFAccountStorageStat object in the specified environment and project with the provided data model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat object to be updated.</param>
        /// <returns>The updated GDFAccountStorageStat object.</returns>
        public GDFAccountStorageStat Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        /// <summary>
        /// Deletes a record from the account storage statistics table.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference ID of the record to delete.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Finds all GDFAccountStorageStat objects based on the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to filter the results.</param>
        /// <param name="sProjectReference">The project ID to filter the results.</param>
        /// <returns>A list of GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Finds all modified GDFAccountStorageStat objects based on the specified environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates the GDFAccountStorageStat model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat model to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountStorageStat model.</returns>
        public GDFAccountStorageStat InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        /// <summary>
        /// Retrieves a list of GDFAccountStorageStat objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of database where models.</param>
        /// <returns>A list of GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

