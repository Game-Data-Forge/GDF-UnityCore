using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Pagination payload base.
    /// </summary>
    /// <typeparam name="T">The type of data to be paginated.</typeparam>
    public class Pagination<T>
    {
        /// <summary>
        /// The paginated items.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
        /// <summary>
        /// The total amount of items that matched the search.
        /// </summary>
        public int Total { get; set; } = 0;
    }
}

