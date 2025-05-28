#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj Pagination.cs create at 2025/04/03 09:04:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Pagination payload base.
    /// </summary>
    /// <typeparam name="T">The type of data to be paginated.</typeparam>
    public class Pagination<T>
    {
        #region Instance fields and properties

        /// <summary>
        ///     The paginated items.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();

        /// <summary>
        ///     The total amount of items that matched the search.
        /// </summary>
        public int Total { get; set; } = 0;

        #endregion
    }
}