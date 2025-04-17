

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Interface representing the data access object for account synchronization statistics.
    /// </summary>
    /// <remarks>
    /// This interface provides methods to create, update, delete, and find account synchronization statistics.
    /// It also provides methods to insert or update a record, and to get records based on specified conditions.
    /// </remarks>
    public interface IGDFAccountSyncStatDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFAccountSyncStat object.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountSyncStat model.</param>
        /// <returns>A new GDFAccountSyncStat object.</returns>
        public GDFAccountSyncStat Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSyncStat sModel);

        /// <summary>
        /// Updates the account sync stat.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The account sync stat model.</param>
        /// <returns>The updated account sync stat.</returns>
        public GDFAccountSyncStat Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSyncStat sModel);

        /// <summary>
        /// Deletes a record from the GDFAccountSyncStat table based on the specified environment, project ID, and reference.
        /// </summary>
        /// <param name="sEnvironment">The environment of the record.</param>
        /// <param name="sProjectReference">The ID of the project that the record belongs to.</param>
        /// <param name="sReference">The reference of the record.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Finds all GDFAccountSyncStat objects based on the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of GDFAccountSyncStat objects.</returns>
        public List<GDFAccountSyncStat> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Finds all modified <see cref="GDFAccountSyncStat"/> objects.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified <see cref="GDFAccountSyncStat"/> objects.</returns>
        public List<GDFAccountSyncStat> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates the GDFAccountSyncStat object in the database based on the given environment, project ID, and GDFAccountSyncStat instance.
        /// </summary>
        /// <param name="sEnvironment">The environment to insert or update the record in.</param>
        /// <param name="sProjectReference">The project ID to insert or update the record for.</param>
        /// <param name="sModel">The GDFAccountSyncStat instance to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountSyncStat instance.</returns>
        public GDFAccountSyncStat InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSyncStat sModel);

        /// <summary>
        /// Gets a list of GDFAccountSyncStat objects based on the specified environment, project ID, and where clause.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the where clause.</param>
        /// <returns>A list of GDFAccountSyncStat objects.</returns>
        public List<GDFAccountSyncStat> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

