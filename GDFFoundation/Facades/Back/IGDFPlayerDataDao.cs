

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Interface for accessing and manipulating player data in the game.
    /// </summary>
    public interface IGDFPlayerDataDao : IGDFDao
    {
        /// <summary>
        /// Create a new GDFPlayerDataStorage object with the provided environment, project ID, and model.
        /// </summary>
        /// <param name="sEnvironment">The environment kind of the player data.</param>
        /// <param name="sProjectReference">The project ID where the player data belongs to.</param>
        /// <param name="sModel">The GDFPlayerDataStorage model to create.</param>
        /// <returns>The created GDFPlayerDataStorage object.</returns>
        public GDFPlayerDataStorage Create(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFPlayerDataStorage sModel);

        /// <summary>
        /// Updates the GDFPlayerDataStorage in the specified environment and project.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFPlayerDataStorage to update.</param>
        /// <returns>The updated GDFPlayerDataStorage.</returns>
        public GDFPlayerDataStorage Update(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFPlayerDataStorage sModel);

        /// <summary>
        /// Deletes a player data by reference.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference of the player data to delete.</param>
        /// <returns>None</returns>
        public void Delete(GDFEnvironmentKind sEnvironment, long sProjectReference, long sReference);

        /// <summary>
        /// Retrieves a list of all GDFPlayerDataStorage objects based on the specified environment and project ID.
        /// </summary>
        /// <param name="sEnvironment">The environment kind (e.g. Development, Production).</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <returns>A list of GDFPlayerDataStorage objects.</returns>
        public List<GDFPlayerDataStorage> FindAll(GDFEnvironmentKind sEnvironment, long sProjectReference);

        /// <summary>
        /// Retrieves a list of GDFPlayerDataStorage instances that have been modified based on the specified parameters.
        /// </summary>
        /// <param name="sEnvironment">An GDFEnvironmentKind enum value representing the environment.</param>
        /// <param name="sProjectReference">The unique identifier of the project.</param>
        /// <param name="sSyncDate">The sync date in Unix timestamp format.</param>
        /// <returns>
        /// A list of GDFPlayerDataStorage instances that have been modified based on the specified parameters.
        /// </returns>
        public List<GDFPlayerDataStorage> FindAllModified(GDFEnvironmentKind sEnvironment, long sProjectReference, long sSyncDate);

        /// <summary>
        /// Inserts or updates a GDFPlayerDataStorage model in the database.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sModel">The GDFPlayerDataStorage model to insert or update.</param>
        /// <returns>Returns the inserted or updated GDFPlayerDataStorage model.</returns>
        public GDFPlayerDataStorage InsertOrUpdate(GDFEnvironmentKind sEnvironment, long sProjectReference, GDFPlayerDataStorage sModel);

        /// <summary>
        /// Retrieves a list of GDFPlayerDataStorage objects based on the specified environment, project ID, and where clause.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of GDFDatabaseWhereModel objects representing the where clause.</param>
        /// <returns>The list of GDFPlayerDataStorage objects.</returns>
        public List<GDFPlayerDataStorage> GetBy(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
        // public List<GDFPlayerDataStorage> GetBySync(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime);
        // public List<GDFPlayerDataStorage> GetBySyncCommit(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime, long sCommit);
        /// <summary>
        /// Calculates the sum of a column in the player data table.
        /// </summary>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sColumn">The column name.</param>
        /// <param name="sWhereClause">The list of conditions to filter the data.</param>
        /// <returns>The sum of the specified column.</returns>
        public long Sum(GDFEnvironmentKind sEnvironment, long sProjectReference, string sColumn, List<GDFDatabaseWhereModel> sWhereClause);

        /// <summary>
        /// Counts the number of records in the database that match the given criteria.
        /// </summary>
        /// <param name="sEnvironment">The environment in which the data is stored.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sWhereClause">The list of criteria to filter the records.</param>
        /// <returns>The number of records that match the given criteria.</returns>
        public long Count(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause);
    }
}

