#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAccountStorageStatDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a data access object for managing the storage statistics of an account.
    /// </summary>
    public interface IGDFAccountStorageStatDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Creates a new GDFAccountStorageStat object and saves it in the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat object to create.</param>
        /// <returns>The created GDFAccountStorageStat object.</returns>
        public GDFAccountStorageStat Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        /// <summary>
        ///     Deletes a record from the account storage statistics table.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference ID of the record to delete.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Finds all GDFAccountStorageStat objects based on the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to filter the results.</param>
        /// <param name="sProjectReference">The project ID to filter the results.</param>
        /// <returns>A list of GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Finds all modified GDFAccountStorageStat objects based on the specified environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFAccountStorageStat objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of database where models.</param>
        /// <returns>A list of GDFAccountStorageStat objects.</returns>
        public List<GDFAccountStorageStat> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Inserts or updates the GDFAccountStorageStat model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat model to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountStorageStat model.</returns>
        public GDFAccountStorageStat InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        /// <summary>
        ///     Updates the GDFAccountStorageStat object in the specified environment and project with the provided data model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountStorageStat object to be updated.</param>
        /// <returns>The updated GDFAccountStorageStat object.</returns>
        public GDFAccountStorageStat Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountStorageStat sModel);

        #endregion
    }
}