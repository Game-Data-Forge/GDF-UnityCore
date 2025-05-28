#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebEditionSortDirection.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents the sort direction for web edition purposes.
    /// </summary>
    [Serializable]
    public enum GDFWebEditionSortDirection
    {
        /// <summary>
        ///     Represents the sort direction for the GDFWebEditionSortDirection enum.
        /// </summary>
        Ascending = 0,

        /// <summary>
        ///     Represents the sort direction of a web edition.
        /// </summary>
        /// <remarks>
        ///     The sort direction can be either ascending or descending.
        /// </remarks>
        Descending = 1,
    }
}