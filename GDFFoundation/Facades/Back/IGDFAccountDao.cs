

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a data access object (DAO) interface for GDFAccount entities.
    /// </summary>
    public interface IGDFAccountDao : IGDFDao
    {
        /// <summary>
        /// Creates a new GDFAccount instance in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind where the account will be created.</param>
        /// <param name="sProjectReference">The ID of the project where the account will be created.</param>
        /// <param name="sModel">The GDFAccount instance to be created.</param>
        /// <returns>The created GDFAccount instance.</returns>
        public GDFAccount Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccount sModel);

        /// <summary>
        /// Updates an GDFAccount in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the account will be updated.</param>
        /// <param name="sProjectReference">The ID of the project to which the account belongs.</param>
        /// <param name="sModel">The GDFAccount object to be updated.</param>
        /// <returns>The updated GDFAccount object.</returns>
        public GDFAccount Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccount sModel);

        /// <summary>
        /// Deletes an account from the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the account exists.</param>
        /// <param name="sProjectReference">The ID of the project to which the account belongs.</param>
        /// <param name="sReference">The reference ID of the account to delete.</param>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Returns a list of GDFAccount objects based on the provided environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind. Must be one of the values defined in GDFEnvironmentKind enum.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of GDFAccount objects.</returns>
        public List<GDFAccount> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Finds all modified GDFAccount objects based on the given parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>The list of modified GDFAccount objects.</returns>
        public List<GDFAccount> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates an GDFAccount model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccount model to insert or update.</param>
        /// <returns>The inserted or updated GDFAccount model.</returns>
        public GDFAccount InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFAccount sModel);

        /// <summary>
        /// Retrieves a list of GDFAccount objects based on the specified parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the where clause.</param>
        /// <returns>Returns a list of GDFAccount objects.</returns>
        public List<GDFAccount> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

