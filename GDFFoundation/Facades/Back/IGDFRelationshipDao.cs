#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFRelationshipDao.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a data access object for managing GDFRelationships.
    /// </summary>
    public interface IGDFRelationshipDao : IGDFDao
    {
        #region Instance methods

        /// <summary>
        ///     Creates a new GDFRelationship instance in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to create the GDFRelationship.</param>
        /// <param name="sProjectReference">The ID of the project in which to create the GDFRelationship.</param>
        /// <param name="sModel">The GDFRelationship instance to create.</param>
        /// <returns>The created GDFRelationship instance.</returns>
        public GDFRelationship Create(ProjectEnvironment sEnvironment, long sProjectReference, GDFRelationship sModel);

        /// <summary>
        ///     Deletes a relationship from the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind where the relationship exists.</param>
        /// <param name="sProjectReference">The ID of the project where the relationship exists.</param>
        /// <param name="sReference">The reference of the relationship to delete.</param>
        public void Delete(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Retrieves a list of all GDFRelationship objects.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of GDFRelationship objects.</returns>
        public List<GDFRelationship> FindAll(ProjectEnvironment sEnvironment, long sProjectReference);

        /// <summary>
        ///     Finds all modified GDFRelationships based on the specified environment, project ID, and sync date.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of GDFRelationship objects that were modified.</returns>
        public List<GDFRelationship> FindAllModified(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        ///     Retrieves a list of GDFRelationship objects based on the specified environment, project ID, and optional where clauses.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of where clauses.</param>
        /// <returns>A list of GDFRelationship objects.</returns>
        public List<GDFRelationship> GetBy(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        ///     Retrieves a GDFRelationship object by its reference in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which to search for the relationship.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sReference">The reference of the relationship.</param>
        /// <returns>
        ///     The GDFRelationship object that matches the specified reference, or null
        ///     if no match was found.
        /// </returns>
        public GDFRelationship GetByReference(ProjectEnvironment sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        ///     Inserts or updates a GDFRelationship object in the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFRelationship object to be inserted or updated.</param>
        /// <returns>The inserted or updated GDFRelationship object.</returns>
        public GDFRelationship InsertOrUpdate(ProjectEnvironment sEnvironment, long sProjectReference, GDFRelationship sModel);

        /// <summary>
        ///     Updates the GDFRelationship model in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the update should be performed.</param>
        /// <param name="sProjectReference">The ID of the project in which the update should be performed.</param>
        /// <param name="sModel">The GDFRelationship model to update.</param>
        /// <returns>The updated GDFRelationship model.</returns>
        public GDFRelationship Update(ProjectEnvironment sEnvironment, long sProjectReference, GDFRelationship sModel);

        #endregion
    }
}