

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a data access object for managing account sign data.
    /// </summary>
    public interface IGDFAccountSignDao : IGDFDao
    {
        /// <summary>
        /// Creates a new instance of the GDFAccountSign class.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The model to create.</param>
        /// <returns>The created instance of GDFAccountSign.</returns>
        public GDFAccountSign Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSign sModel);

        /// <summary>
        /// Updates the GDFAccountSign model in the specified environment and project
        /// </summary>
        /// <param name="sEnvironment">The environment in which to update the model</param>
        /// <param name="sProjectReference">The ID of the project</param>
        /// <param name="sModel">The GDFAccountSign model to update</param>
        /// <returns>The updated GDFAccountSign model</returns>
        public GDFAccountSign Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSign sModel);

        /// <summary>
        /// Deletes an account sign based on the given parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account sign.</param>
        /// <param name="sProjectReference">The project ID of the account sign.</param>
        /// <param name="sReference">The reference ID of the account sign.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Returns a list of GDFAccountSign objects.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project id.</param>
        /// <returns>A list of GDFAccountSign objects.</returns>
        public List<GDFAccountSign> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Finds all modified GDFAccountSign objects based on the specified environment, ProjectReference, and syncDate.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified GDFAccountSign objects.</returns>
        public List<GDFAccountSign> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates a GDFAccountSign in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the operation is performed.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFAccountSign object to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountSign object.</returns>
        public GDFAccountSign InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccountSign sModel);

        /// <summary>
        /// Retrieves a list of GDFAccountSign objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account sign.</param>
        /// <param name="sProjectReference">The project ID of the account sign.</param>
        /// <param name="sWhereClause">The list of database where clauses to filter the account signs.</param>
        /// <returns>A list of GDFAccountSign objects that match the specified criteria.</returns>
        public List<GDFAccountSign> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}


