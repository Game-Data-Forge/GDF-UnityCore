#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAccountOrderDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Interface for accessing GDFAccountOrderDao functionality.
    /// </summary>
    public interface IGDFAccountOrderDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Create a new GDFAccountOrder object in the given environment and project with the provided model.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to create the GDFAccountOrder.</param>
        /// <param name="sProjectReference">The ID of the project in which to create the GDFAccountOrder.</param>
        /// <param name="sModel">The GDFAccountOrder model to create.</param>
        /// <returns>The created GDFAccountOrder object.</returns>
        public GDFAccountOrder Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountOrder sModel);

        /// <summary>
        ///     Deletes an account order from the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference of the account order to delete.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Find all GDFAccountOrder objects for a given environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">ID of the project.</param>
        /// <returns>A list of GDFAccountOrder objects.</returns>
        public List<GDFAccountOrder> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Finds all modified GDFAccountOrder objects based on the provided parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The synchronization date.</param>
        /// <returns>A list of GDFAccountOrder objects that have been modified.</returns>
        public List<GDFAccountOrder> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFAccountOrder objects based on the specified parameters.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of database where conditions.</param>
        /// <returns>A list of GDFAccountOrder objects.</returns>
        public List<GDFAccountOrder> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Inserts or updates a GDFAccountOrder object in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFAccountOrder object.</param>
        /// <returns>The inserted or updated GDFAccountOrder object.</returns>
        public GDFAccountOrder InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountOrder sModel);

        /// <summary>
        ///     Updates a GDFAccountOrder model in the specified environment.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to update the model.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sModel">The GDFAccountOrder model to update.</param>
        /// <returns>The updated GDFAccountOrder model.</returns>
        public GDFAccountOrder Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFAccountOrder sModel);

        #endregion
    }
}