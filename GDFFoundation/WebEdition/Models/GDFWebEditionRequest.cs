#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebEditionRequest.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Use for the web edition form request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GDFWebEditionRequest<T> where T : IGDFData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Controller name to use for async methods
        /// </summary>
        public string ControllerName { set; get; } = "Unknown";

        /// <summary>
        ///     Item instance use in web form
        /// </summary>
        public T Item { set; get; }

        /// <summary>
        ///     List of items use in list
        /// </summary>
        public List<T> ItemsList { set; get; }

        /// <summary>
        ///     Pagination information to layout the list page
        /// </summary>
        public GDFWebEditionPagination Pagination { set; get; } = new GDFWebEditionPagination();

        #endregion
    }
}