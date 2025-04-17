

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Interface for accessing and manipulating volatile data storage objects.
    /// </summary>
    public interface IGDFVolatileDataDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFVolatileDataStorage object.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFVolatileDataStorage object to create.</param>
        /// <returns>A new GDFVolatileDataStorage object.</returns>
        public GDFVolatileDataStorage Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        /// <summary>
        /// Updates the volatile data storage for a specific environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The volatile data storage model to update.</param>
        /// <returns>The updated volatile data storage model.</returns>
        public GDFVolatileDataStorage Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        /// <summary>
        /// Deletes a record from the volatile data table based on the environment, project ID, and reference.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the deletion occurs.</param>
        /// <param name="sProjectReference">The ID of the project for which the deletion occurs.</param>
        /// <param name="sReference">The reference value used to identify the record to be deleted.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Returns a list of GDFVolatileDataStorage objects that match the given environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to filter the data by.</param>
        /// <param name="sProjectReference">The project ID to filter the data by.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that match the given environment and project ID.</returns>
        public List<GDFVolatileDataStorage> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Retrieves all modified GDFVolatileDataStorage objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The synchronization date.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that satisfy the specified criteria.</returns>
        public List<GDFVolatileDataStorage> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates the GDFVolatileDataStorage object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment to insert or update the object in.</param>
        /// <param name="sProjectReference">The project ID to insert or update the object in.</param>
        /// <param name="sModel">The GDFVolatileDataStorage object to insert or update.</param>
        /// <returns>The inserted or updated GDFVolatileDataStorage object.</returns>
        public GDFVolatileDataStorage InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        /// <summary>
        /// Retrieves a list of GDFVolatileDataStorage objects that match the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project id.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the search criteria.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that match the specified criteria.</returns>
        public List<GDFVolatileDataStorage> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

