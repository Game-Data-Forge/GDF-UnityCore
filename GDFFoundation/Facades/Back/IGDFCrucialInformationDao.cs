

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Interface for accessing crucial information data.
    /// </summary>
    public interface IGDFCrucialInformationDao : IGDFDao
    {
        /// <summary>
        /// Creates a new instance of GDFCrucialInformation with the given environment, project ID and model.
        /// </summary>
        /// <param name="sEnvironment">The environment of the GDF server.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The model to create.</param>
        /// <returns>A new instance of GDFCrucialInformation.</returns>
        public GDFCrucialInformation Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFCrucialInformation sModel);

        /// <summary>
        /// Updates the GDFCrucialInformation object with the given environment, project ID, and model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the crucial information.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The model to update.</param>
        /// <returns>The updated GDFCrucialInformation object.</returns>
        public GDFCrucialInformation Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFCrucialInformation sModel);

        /// <summary>
        /// Deletes a crucial information based on the given environment, project ID, and reference.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID of the crucial information.</param>
        /// <param name="sReference">The reference of the crucial information.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Finds all GDFCrucialInformation objects in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment to search in.</param>
        /// <param name="sProjectReference">The project ID to search for.</param>
        /// <returns>A list of GDFCrucialInformation objects found in the specified environment and project.</returns>
        public List<GDFCrucialInformation> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Finds all modified GDFCrucialInformation objects based on the specified environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind to filter by.</param>
        /// <param name="sProjectReference">The project ID to filter by.</param>
        /// <param name="sSyncDate">The sync date to filter by.</param>
        /// <returns>A list of GDFCrucialInformation objects that have been modified.</returns>
        public List<GDFCrucialInformation> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates a crucial information model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The crucial information model to insert or update.</param>
        /// <returns>The inserted or updated crucial information model.</returns>
        public GDFCrucialInformation InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFCrucialInformation sModel);

        /// <summary>
        /// Retrieves a list of GDFCrucialInformation objects based on the specified parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The where clause for filtering the results.</param>
        /// <returns>A list of GDFCrucialInformation objects.</returns>
        public List<GDFCrucialInformation> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        /// Generates a new valid reference number.
        /// </summary>
        /// <param name="sEnvironmentKind">The environment kind to generate the reference for.</param>
        /// <param name="sProjectReference">The project ID associated with the reference (Optional).</param>
        /// <returns>A long value representing the new valid reference number.</returns>
        public long NewValidReference(GDFEnvironmentKind sEnvironmentKind, long sProjectReference);
    }
}

