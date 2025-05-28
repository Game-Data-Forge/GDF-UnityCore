#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebEditionModelDataManager.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides methods to manage models in the GDFWebEdition.
    /// </summary>
    /// <typeparam name="T">The type of model to manage.</typeparam>
    [Serializable]
    public class GDFWebEditionModelDataManager<T> : IGDFWebEditionModelDataManager<T> where T : GDFBasicData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a dictionary of items used in the GDFWebEditionModelDataManager class.
        /// </summary>
        /// <typeparam name="T">The type of items in the dictionary.</typeparam>
        private Dictionary<long, T> DictionaryOfItems { set; get; } = new Dictionary<long, T>();

        /// <summary>
        ///     Represents a list of items.
        /// </summary>
        private List<T> ListOfItems { set; get; } = new List<T>();

        #endregion

        #region Instance methods

        #region From interface IGDFWebEditionModelDataManager<T>

        /// <summary>
        ///     Adds a model to the dictionary and list of items.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="sModel">The model to add.</param>
        public void Add(T sModel)
        {
            if (DictionaryOfItems != null)
            {
                if (DictionaryOfItems.ContainsKey(sModel.Reference) == true)
                {
                    sModel.Reference = GDFRandom.LongNumeric(16);
                    while (DictionaryOfItems.ContainsKey(sModel.Reference))
                    {
                        sModel.Reference = GDFRandom.LongNumeric(16);
                    }

                    DictionaryOfItems[sModel.Reference] = sModel;
                }

                DictionaryOfItems.Add(sModel.Reference, sModel);
                if (ListOfItems != null)
                {
                    ListOfItems.Add(sModel);
                }
            }
        }

        /// <summary>
        ///     Deletes a model from the data manager's dictionary.
        /// </summary>
        /// <param name="sReference">The reference of the model to delete.</param>
        public void Delete(long sReference)
        {
            if (DictionaryOfItems != null)
            {
                if (DictionaryOfItems.ContainsKey(sReference) == true)
                {
                    T tItem = DictionaryOfItems[sReference];
                    DictionaryOfItems.Remove(tItem.Reference);
                    if (ListOfItems != null)
                    {
                        ListOfItems.Remove(tItem);
                    }
                }
            }
        }

        /// <summary>
        ///     Retrieves the items at the actual page based on the provided pagination settings.
        /// </summary>
        /// <typeparam name="TW">The type of the items to retrieve, deriving from GDFBasicData.</typeparam>
        /// <param name="sPagination">The pagination settings to apply.</param>
        /// <returns>A list of items of type TW representing the items at the actual page.</returns>
        public List<T> GetItemAtActualPage<TW>(GDFWebEditionPagination sPagination) where TW : T
        {
            List<T> tReturn = new List<T>();
            if (ListOfItems != null && DictionaryOfItems != null)
            {
                List<T> tListOfItems = ListOfItems as List<T>;
                if (tListOfItems != null)
                {
                    tReturn.AddRange(tListOfItems);
                }

                int tPageMax = Math.Min(PagesCount(sPagination.ItemPerPage), sPagination.ActivePage);
                int tMin = Math.Max(Math.Max((tPageMax - 1) * sPagination.ItemPerPage, 0), 0);
                int tMax = Math.Max(Math.Min(tMin + sPagination.ItemPerPage, DictionaryOfItems.Count), 0);
                string tSortBy = sPagination.SortBy;
                if (string.IsNullOrEmpty(tSortBy) == false)
                {
                    Type tType = typeof(T);
                    PropertyInfo tProp = tType.GetProperty(tSortBy);
                    if (tProp != null)
                    {
                        Comparison<T> tCompare = delegate(T a, T b)
                        {
                            bool tAsc = sPagination.SortDirection == GDFWebEditionSortDirection.Ascending;
                            object tValueA = tAsc ? tProp.GetValue(a, null) : tProp.GetValue(b, null);
                            object tValueB = tAsc ? tProp.GetValue(b, null) : tProp.GetValue(a, null);

                            return tValueA is IComparable ? ((IComparable)tValueA).CompareTo(tValueB) : 0;
                        };
                        tReturn.Sort(tCompare);
                    }
                }

                return tReturn.GetRange(tMin, Math.Min(tMax - tMin, sPagination.ItemPerPage));
            }
            else
            {
                return tReturn;
            }
        }

        /// <summary>
        ///     Gets the page number of an item in the data manager based on the specified model and pagination settings.
        /// </summary>
        /// <typeparam name="TW">The type of the model.</typeparam>
        /// <param name="sModel">The model to search for.</param>
        /// <param name="sPagination">The pagination settings to use.</param>
        /// <returns>The page number of the item.</returns>
        public int GetPageOfItem<TW>(T sModel, GDFWebEditionPagination sPagination) where TW : T
        {
            int rReturn = 0;
            if (sModel != null && DictionaryOfItems != null)
            {
                if (DictionaryOfItems.ContainsKey(sModel.Reference) == true)
                {
                    T tItem = DictionaryOfItems[sModel.Reference];
                    if (ListOfItems != null)
                    {
                        rReturn = (int)Math.Ceiling((double)ListOfItems.IndexOf(tItem) / (double)sPagination.ItemPerPage);
                    }
                }
            }

            return rReturn;
        }

        /// <summary>
        ///     Retrieves the real instance of a model from the dictionary based on the given reference value.
        /// </summary>
        /// <typeparam name="TW">The type of model to retrieve.</typeparam>
        /// <param name="sReference">The reference value of the model to retrieve.</param>
        /// <returns>The real instance of the model as <typeparamref name="TW" /> if found, otherwise <c>null</c>.</returns>
        public T GetReal<TW>(long sReference) where TW : T
        {
            T rReturn = null;
            if (DictionaryOfItems != null)
            {
                if (DictionaryOfItems.ContainsKey(sReference) == true)
                {
                    rReturn = DictionaryOfItems[sReference] as T;
                }
            }

            return rReturn;
        }

        /// <summary>
        ///     Calculates the number of pages needed to display the items based on the specified number of items per page.
        /// </summary>
        /// <param name="sItemPerPage">The number of items to display per page.</param>
        /// <returns>The number of pages needed to display the items.</returns>
        public int PagesCount(int sItemPerPage)
        {
            int rReturn = 0;
            if (DictionaryOfItems == null)
            {
                rReturn = 0;
            }
            else
            {
                rReturn = (int)Math.Ceiling((double)DictionaryOfItems.Count / (double)sItemPerPage);
            }

            return rReturn;
        }

        /// <summary>
        ///     Updates the item in the dictionary if it exists, otherwise adds it to the dictionary.
        /// </summary>
        /// <typeparam name="TW">The type of item to update. It must be a subclass of the basic model type.</typeparam>
        /// <param name="sModel">The item to update or add.</param>
        /// <returns>
        ///     The updated or added item if successful; otherwise null.
        /// </returns>
        public T Update<TW>(TW sModel) where TW : T
        {
            T tModel = sModel as T;
            if (DictionaryOfItems != null)
            {
                if (DictionaryOfItems.ContainsKey(sModel.Reference) == true)
                {
                    Delete(sModel.Reference);
                    if (tModel != null)
                    {
                        Add(tModel);
                    }
                }
                else
                {
                    sModel.Reference = GDFRandom.LongNumeric(16);
                    while (DictionaryOfItems.ContainsKey(sModel.Reference))
                    {
                        sModel.Reference = GDFRandom.LongNumeric(16);
                    }

                    Add(sModel as T);
                }
            }

            return tModel;
        }

        #endregion

        #endregion
    }
}