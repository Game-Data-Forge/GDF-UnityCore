#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFStudioDataDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     The IGDFStudioDataDao interface defines the methods for interacting with the GDFStudioDataDataStorage objects in the database.
    /// </summary>
    public interface IGDFStudioDataDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Creates a new GDFStudioDataDataStorage object.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The model object to create.</param>
        /// <returns>The newly created GDFStudioDataDataStorage object.</returns>
        public GDFStudioDataStorage Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFStudioDataStorage sModel);

        /// <summary>
        ///     Method to delete a record from the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to use.</param>
        /// <param name="sProjectReference">The project ID of the record to delete.</param>
        /// <param name="sReference">The reference of the record to delete.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Retrieves all instances of GDFStudioDataDataStorage for a given environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of GDFStudioDataDataStorage instances.</returns>
        public List<GDFStudioDataStorage> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Finds all modified GDFStudioDataDataStorage objects based on environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of GDFStudioDataDataStorage objects that were modified.</returns>
        public List<GDFStudioDataStorage> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFStudioDataDataStorage objects based on specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The GDFEnvironmentKind value indicating the environment.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">A list of GDFDatabaseWhereModel objects representing the filter criteria.</param>
        /// <returns>A list of GDFStudioDataDataStorage objects that match the specified criteria.</returns>
        public List<GDFStudioDataStorage> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Inserts or updates a GDFStudioDataDataStorage object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to insert or update the object.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFStudioDataDataStorage object to insert or update.</param>
        /// <returns>Returns the inserted or updated GDFStudioDataDataStorage object.</returns>
        public GDFStudioDataStorage InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFStudioDataStorage sModel);

        /// <summary>
        ///     Generates a new valid reference for the given environment and project ID.
        /// </summary>
        /// <param name="sEnvironmentKind">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A new valid reference as a long.</returns>
        public long NewValidReference(ProjectEnvironment sEnvironmentKind, long sProjectReference);

        /// <summary>
        ///     Updates the GDFStudioDataDataStorage model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to perform the update.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFStudioDataDataStorage object to update.</param>
        /// <returns>The updated GDFStudioDataDataStorage model.</returns>
        public GDFStudioDataStorage Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFStudioDataStorage sModel);

        #endregion
    }
}