#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAccountSignDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a data access object for managing account sign data.
    /// </summary>
    public interface IGDFAccountSignDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Creates a new instance of the GDFAccountSign class.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The model to create.</param>
        /// <returns>The created instance of GDFAccountSign.</returns>
        public GDFAccountSign Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountSign sModel);

        /// <summary>
        ///     Deletes an account sign based on the given parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account sign.</param>
        /// <param name="sProjectReference">The project ID of the account sign.</param>
        /// <param name="sReference">The reference ID of the account sign.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Returns a list of GDFAccountSign objects.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project id.</param>
        /// <returns>A list of GDFAccountSign objects.</returns>
        public List<GDFAccountSign> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Finds all modified GDFAccountSign objects based on the specified environment, ProjectReference, and syncDate.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified GDFAccountSign objects.</returns>
        public List<GDFAccountSign> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFAccountSign objects based on the specified criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the account sign.</param>
        /// <param name="sProjectReference">The project ID of the account sign.</param>
        /// <param name="sWhereClause">The list of database where clauses to filter the account signs.</param>
        /// <returns>A list of GDFAccountSign objects that match the specified criteria.</returns>
        public List<GDFAccountSign> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Inserts or updates a GDFAccountSign in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the operation is performed.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFAccountSign object to insert or update.</param>
        /// <returns>The inserted or updated GDFAccountSign object.</returns>
        public GDFAccountSign InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountSign sModel);

        /// <summary>
        ///     Updates the GDFAccountSign model in the specified environment and project
        /// </summary>
        /// <param name="sEnvironment">The environment in which to update the model</param>
        /// <param name="sProjectReference">The ID of the project</param>
        /// <param name="sModel">The GDFAccountSign model to update</param>
        /// <returns>The updated GDFAccountSign model</returns>
        public GDFAccountSign Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountSign sModel);

        #endregion
    }
}