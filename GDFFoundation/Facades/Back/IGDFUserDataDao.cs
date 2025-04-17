

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a data access object for IGDFUserDataDao.
    /// </summary>
    public interface IGDFUserDataDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFUserDataDataStorage object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to create the object.</param>
        /// <param name="sProjectReference">The ID of the project in which to create the object.</param>
        /// <param name="sModel">The GDFUserDataDataStorage object to create.</param>
        /// <returns>The newly created GDFUserDataDataStorage object.</returns>
        public GDFUserDataDataStorage Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFUserDataDataStorage sModel);

        /// <summary>
        /// Update method for updating the GDFUserDataDataStorage model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the update is performed.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFUserDataDataStorage model to update.</param>
        /// <returns>The updated GDFUserDataDataStorage model.</returns>
        public GDFUserDataDataStorage Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFUserDataDataStorage sModel);

        /// <summary>
        /// Deletes a specific record from the database based on the environment, project ID, and reference.
        /// </summary>
        /// <param name="sEnvironment">The environment of the record.</param>
        /// <param name="sProjectReference">The project ID of the record.</param>
        /// <param name="sReference">The reference ID of the record.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Finds all GDFUserDataDataStorage objects based on the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to search for data.</param>
        /// <param name="sProjectReference">The project ID to filter the data.</param>
        /// <returns>A list of GDFUserDataDataStorage objects found.</returns>
        public List<GDFUserDataDataStorage> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// FindAllModified method returns a list of GDFUserDataDataStorage objects that have been modified.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The synchronization date.</param>
        /// <returns>A list of GDFUserDataDataStorage objects.</returns>
        public List<GDFUserDataDataStorage> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates the specified GDFUserDataDataStorage object into the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the data should be inserted or updated.</param>
        /// <param name="sProjectReference">The ID of the project in which the data should be inserted or updated.</param>
        /// <param name="sModel">The GDFUserDataDataStorage object to insert or update.</param>
        /// <returns>The updated GDFUserDataDataStorage object.</returns>
        public GDFUserDataDataStorage InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFUserDataDataStorage sModel);

        /// <summary>
        /// Retrieves a list of GDFUserDataDataStorage objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of database where models for filtering criteria.</param>
        /// <returns>A list of GDFUserDataDataStorage objects that match the specified criteria.</returns>
        public List<GDFUserDataDataStorage> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
        // public List<GDFUserDataDataStorage> GetBySync(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime);
        // public List<GDFUserDataDataStorage> GetBySyncCommit(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime, long sCommit);
        /// <summary>
        /// Calculate the sum of a specific column in the database for the given conditions.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the calculation should be performed.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sColumn">The name of the column to calculate the sum for.</param>
        /// <param name="sWhereClause">The conditions to filter the data.</param>
        /// <returns>The sum of the specified column for the given conditions.</returns>
        public long Sum(GDFEnvironmentKind sEnvironment, long sProjectReference, string sColumn, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        /// Returns the count of records matching the specified conditions.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of where clauses.</param>
        /// <returns>The count of matching records.</returns>
        public long Count(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

