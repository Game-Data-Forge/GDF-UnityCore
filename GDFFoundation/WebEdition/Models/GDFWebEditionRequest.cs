

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Use for the web edition form request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GDFWebEditionRequest<T> where T : IGDFData
    {
        /// <summary>
        /// Item instance use in web form
        /// </summary>
        public T Item { set; get; }
        /// <summary>
        /// List of items use in list
        /// </summary>
        public List<T> ItemsList { set; get; }
        /// <summary>
        /// Controller name to use for async methods
        /// </summary>
        public string ControllerName { set; get; } = "Unknown";
        /// <summary>
        /// Pagination information to layout the list page
        /// </summary>
        public GDFWebEditionPagination Pagination { set; get; } = new GDFWebEditionPagination();
    }
}

