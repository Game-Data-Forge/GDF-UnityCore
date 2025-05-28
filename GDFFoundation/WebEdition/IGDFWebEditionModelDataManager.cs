#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFWebEditionModelDataManager.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a data manager for managing models in the GDFWebEdition.
    /// </summary>
    /// <typeparam name="T">The type of model to manage.</typeparam>
    public interface IGDFWebEditionModelDataManager<T> where T : GDFBasicData
    {
        #region Instance methods

        /// <summary>
        ///     Adds a model to the dictionary and list of items.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="sModel">The model to add.</param>
        public void Add(T sModel);

        /// <summary>
        ///     Deletes a model from the data manager's dictionary.
        /// </summary>
        /// <param name="sReference">The reference of the model to delete.</param>
        public void Delete(long sReference);

        /// <summary>
        ///     Retrieves a list of items at the current page based on the provided pagination configuration.
        /// </summary>
        /// <typeparam name="TW">The type that extends the <typeparamref name="T" /> type.</typeparam>
        /// <param name="sPagination">The pagination configuration.</param>
        /// <returns>A list of items at the current page.</returns>
        public List<T> GetItemAtActualPage<TW>(GDFWebEditionPagination sPagination) where TW : T;

        /// <summary>
        ///     Returns the page index of the given item in the specified pagination.
        /// </summary>
        /// <typeparam name="TW">The type of the item.</typeparam>
        /// <param name="sModel">The item to get the page index for.</param>
        /// <param name="sPagination">The pagination configuration.</param>
        /// <returns>The page index of the item. Returns 0 if the item is null or the dictionary of items is null.</returns>
        public int GetPageOfItem<TW>(T sModel, GDFWebEditionPagination sPagination) where TW : T;

        /// <summary>
        ///     Retrieves the real instance of a model from the dictionary based on the given reference value.
        /// </summary>
        /// <typeparam name="TW">The type of model to retrieve.</typeparam>
        /// <param name="sReference">The reference value of the model to retrieve.</param>
        /// <returns>The real instance of the model as <typeparamref name="TW" /> if found, otherwise <c>null</c>.</returns>
        public T GetReal<TW>(long sReference) where TW : T;

        /// <summary>
        ///     Calculates the number of pages needed to display the items based on the specified number of items per page.
        /// </summary>
        /// <param name="sItemPerPage">The number of items to display per page.</param>
        /// <returns>The number of pages needed to display the items.</returns>
        public int PagesCount(int sItemPerPage);

        /// <summary>
        ///     Updates the item in the dictionary if it exists, otherwise adds it to the dictionary.
        /// </summary>
        /// <typeparam name="TW">The type of item to update. It must be a subclass of the basic model type.</typeparam>
        /// <param name="sModel">The item to update or add.</param>
        /// <returns>
        ///     The updated or added item if successful; otherwise null.
        /// </returns>
        public T Update<TW>(TW sModel) where TW : T;

        #endregion
    }
}