#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFDaoGeneric.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a generic data access object for GDFFoundation.
    /// </summary>
    public interface IGDFDaoGeneric : IGDFAbstractDao
    {
        #region Instance methods

        /// <summary>
        ///     Count the number of records in the database that satisfy the given conditions.
        /// </summary>
        /// <typeparam name="T">The generic type parameter T.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sWhereClause">The list of database where models.</param>
        /// <returns>The number of records that satisfy the conditions.</returns>
        public long Count<T>(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Creates a new instance of the specified model in the specified environment and project.
        /// </summary>
        /// <typeparam name="T">The type of the model to create. Must inherit from GDFBasicData.</typeparam>
        /// <param name="sEnvironment">The environment in which to create the model instance.</param>
        /// <param name="sProjectReference">The project ID for the model instance.</param>
        /// <param name="sModel">The model instance to create.</param>
        /// <param name="sRangeDependent">A boolean indicating if the model instance is range dependent.</param>
        /// <param name="sWithNewReference">A boolean indicating if the model instance has a new reference.</param>
        /// <returns>The created model instance.</returns>
        public T Create<T>(ProjectEnvironment sEnvironment, long sProjectReference, T sModel, bool sRangeDependent, bool sWithNewReference) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Creates an index for the specified model in the specified environment.
        /// </summary>
        /// <typeparam name="T">The model type. Must be derived from GDFBasicData.</typeparam>
        /// <param name="sEnvironment">The environment in which the index should be created.</param>
        /// <remarks>
        ///     Only models derived from GDFBasicData can have indexes created for them. The index is created based on the properties specified in the <see cref="GDFBasicData" /> class using the <see cref="GDFDatabaseIndexAttribute" />.
        /// </remarks>
        public void CreateIndex<T>(ProjectEnvironment sEnvironment) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Creates a table in the database for the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type of the model for which the table should be created. Must be a subtype of GDFBasicData.</typeparam>
        /// <param name="sEnvironment">The environment kind to determine the database in which the table should be created.</param>
        public void CreateTable<T>(ProjectEnvironment sEnvironment) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Deletes the specified object from the database.
        /// </summary>
        /// <typeparam name="T">The type of object to delete.</typeparam>
        /// <param name="sEnvironment">The environment in which to delete the object.</param>
        /// <param name="sProjectReference">The ID of the project containing the object.</param>
        /// <param name="sModel">The object to delete.</param>
        /// <returns>True if the object is successfully deleted, false otherwise.</returns>
        public bool Delete<T>(ProjectEnvironment sEnvironment, long sProjectReference, T sModel) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Deletes the entity with the specified reference in the specified environment and project.
        /// </summary>
        /// <typeparam name="T">The type of entity to delete. It must be a subclass of GDFBasicData.</typeparam>
        /// <param name="sEnvironment">The environment in which the entity should be deleted.</param>
        /// <param name="sProjectReference">The ID of the project in which the entity should be deleted.</param>
        /// <param name="sReference">The reference of the entity to delete.</param>
        /// <returns>Returns true if the delete operation was successful, false otherwise.</returns>
        public bool Delete<T>(ProjectEnvironment sEnvironment, long sProjectReference, long sReference) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Deletes the index for a specific model in the specified environment.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="sEnvironment">The environment in which the index should be deleted.</param>
        /// <remarks>
        ///     This method deletes the index associated with a specific model in the specified environment. The model must be a subclass of <see cref="GDFBasicData" /> and it must have an index defined using the <see cref="GDFDatabaseIndexAttribute" /> attribute.
        /// </remarks>
        public void DeleteIndex<T>(ProjectEnvironment sEnvironment) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Deletes the table for a given model in the specified environment.
        /// </summary>
        /// <typeparam name="T">The type of model.</typeparam>
        /// <param name="sEnvironment">The environment to delete the table from.</param>
        public void DeleteTable<T>(ProjectEnvironment sEnvironment) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Retrieves all instances of a specific type of object from the database.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>A list of objects of the specified type.</returns>
        public List<T> FindAll<T>(ProjectEnvironment sEnvironment, long sProjectReference) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Find all modified instances of a given type in the database based on the environment, project ID, and sync date.
        /// </summary>
        /// <typeparam name="T">The type of the instances to find.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sSyncDate">The sync date.</param>
        /// <returns>A list of modified instances of the given type.</returns>
        /// <remarks>
        ///     This method searches for instances of the given type that have been modified in the database.
        ///     The search is performed based on the specified environment, project ID, and sync date.
        ///     The method returns a list of all the modified instances found.
        ///     The returned list may be empty if no modified instances are found in the database.
        /// </remarks>
        public List<T> FindAllModified<T>(ProjectEnvironment sEnvironment, long sProjectReference, long sSyncDate)
            where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Generates a new commit ID.
        /// </summary>
        /// <returns>A unique identifier for a commit.</returns>
        public Int64 GenerateNewCommitId();

        /// <summary>
        ///     Retrieves a list of objects of type T from the database based on the specified conditions.
        /// </summary>
        /// <typeparam name="T">The type of objects to retrieve.</typeparam>
        /// <param name="sEnvironment">The environment kind to use for the database query.</param>
        /// <param name="sProjectReference">The project ID to use for the database query.</param>
        /// <param name="sWhereClause">The list of where clauses to apply to the database query.</param>
        /// <returns>A list of objects of type T that match the specified conditions.</returns>
        public List<T> GetBy<T>(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Retrieves an instance of type T by its reference, project ID, and environment.
        /// </summary>
        /// <typeparam name="T">The type of the instance to retrieve.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sReference">The reference of the instance.</param>
        /// <returns>The instance of type T if found; otherwise, null.</returns>
        public T GetByReference<T>(ProjectEnvironment sEnvironment, long sProjectReference, string sReference) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Retrieves the current datetime.
        /// </summary>
        /// <returns>The current datetime.</returns>
        public DateTime GetCurrentDatetime();

        /// <summary>
        ///     Gets the first instance of a specific type from the database based on the given criteria.
        /// </summary>
        /// <typeparam name="T">The type of the object to get.</typeparam>
        /// <param name="sEnvironment">The environment kind of the database.</param>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sWhereClause">The list of where clause conditions.</param>
        /// <returns>The first instance of the specified type from the database, or null if not found.</returns>
        public T GetFirstBy<T>(ProjectEnvironment sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Retrieves the information about the method.
        /// </summary>
        /// <returns>The information about the method.</returns>
        public string GetInfos();

        /// <summary>
        ///     Gets the range.
        /// </summary>
        /// <returns>The range.</returns>
        public short GetRange();

        /// <summary>
        ///     Inserts or updates a model in the database.
        /// </summary>
        /// <typeparam name="T">The type of the model to insert or update.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project identifier.</param>
        /// <param name="sModel">The model to insert or update.</param>
        /// <param name="sRangeDependent">Determines if the model is range dependent.</param>
        /// <param name="sWithNewReference">Determines if the model has a new reference.</param>
        /// <param name="sWhereClause">The optional where clause.</param>
        /// <returns>The inserted or updated model.</returns>
        public T InsertOrUpdate<T>(
            ProjectEnvironment sEnvironment,
            long sProjectReference,
            T sModel,
            bool sRangeDependent,
            bool sWithNewReference,
            List<GDFDatabaseWhereModel> sWhereClause
        ) where T : GDFBasicData, IGDFWritableLongReference;

        // public List<T> GetBySync<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime) where T : GDFBasicData;
        // public List<T> GetBySyncCommit<T>(GDFEnvironmentKind sEnvironment, long sProjectReference, List<GDFDatabaseWhereModel> sWhereClause, DateTime sDateTime, long sCommit) where T : GDFBasicData;
        /// <summary>
        ///     Calculates the sum of the values in the specified column for the given environment, project ID, and where clause.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sColumn">The column to calculate the sum for.</param>
        /// <param name="sWhereClause">The where clause to filter the records.</param>
        /// <returns>The sum of the values in the specified column.</returns>
        public long Sum<T>(ProjectEnvironment sEnvironment, long sProjectReference, string sColumn, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Checks if a table exists for the given model type and environment.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <returns>True if the table exists, false otherwise.</returns>
        public bool TableExists<T>(ProjectEnvironment sEnvironment) where T : GDFBasicData, IGDFWritableLongReference;

        /// <summary>
        ///     Test the connection to the database.
        /// </summary>
        /// <returns>Returns true if the connection is successful, otherwise false.</returns>
        public bool TestConnexion();

        /// <summary>
        ///     Updates a model in the specified environment and project with the provided data, using the specified where clause.
        /// </summary>
        /// <typeparam name="T">The type of the model to update. Must inherit from GDFBasicData.</typeparam>
        /// <param name="sEnvironment">The environment in which the update will be performed.</param>
        /// <param name="sProjectReference">The ID of the project in which the update will be performed.</param>
        /// <param name="sModel">The model to update.</param>
        /// <param name="sWhereClause">Optional where clause to identify the models to update.</param>
        /// <returns>The updated model.</returns>
        public T Update<T>(ProjectEnvironment sEnvironment, long sProjectReference, T sModel, List<GDFDatabaseWhereModel> sWhereClause) where T : GDFBasicData, IGDFWritableLongReference;

        #endregion
    }
}