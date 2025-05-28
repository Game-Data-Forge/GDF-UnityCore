#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbColumnAccess.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration storing the access rights for a column in a given request.
    /// </summary>
    public enum GDFDbColumnAccess
    {
        /// <summary>
        ///     the column cannot be used in the request.
        /// </summary>
        Deny = 0,

        /// <summary>
        ///     The column can be used in the request.
        /// </summary>
        Can = 1,

        /// <summary>
        ///     The column must be used in the request.
        /// </summary>
        Must = 2,
    }
}