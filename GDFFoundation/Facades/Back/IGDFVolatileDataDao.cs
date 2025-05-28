#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFVolatileDataDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Interface for accessing and manipulating volatile data storage objects.
    /// </summary>
    public interface IGDFVolatileDataDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Creates a new GDFVolatileDataStorage object.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFVolatileDataStorage object to create.</param>
        /// <returns>A new GDFVolatileDataStorage object.</returns>
        public GDFVolatileDataStorage Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        /// <summary>
        ///     Deletes a record from the volatile data table based on the environment, project ID, and reference.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the deletion occurs.</param>
        /// <param name="sProjectReference">The ID of the project for which the deletion occurs.</param>
        /// <param name="sReference">The reference value used to identify the record to be deleted.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Returns a list of GDFVolatileDataStorage objects that match the given environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to filter the data by.</param>
        /// <param name="sProjectReference">The project ID to filter the data by.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that match the given environment and project ID.</returns>
        public List<GDFVolatileDataStorage> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Retrieves all modified GDFVolatileDataStorage objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The synchronization date.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that satisfy the specified criteria.</returns>
        public List<GDFVolatileDataStorage> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFVolatileDataStorage objects that match the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project id.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the search criteria.</param>
        /// <returns>A list of GDFVolatileDataStorage objects that match the specified criteria.</returns>
        public List<GDFVolatileDataStorage> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Inserts or updates the GDFVolatileDataStorage object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment to insert or update the object in.</param>
        /// <param name="sProjectReference">The project ID to insert or update the object in.</param>
        /// <param name="sModel">The GDFVolatileDataStorage object to insert or update.</param>
        /// <returns>The inserted or updated GDFVolatileDataStorage object.</returns>
        public GDFVolatileDataStorage InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        /// <summary>
        ///     Updates the volatile data storage for a specific environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The volatile data storage model to update.</param>
        /// <returns>The updated volatile data storage model.</returns>
        public GDFVolatileDataStorage Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFVolatileDataStorage sModel);

        #endregion
    }
}