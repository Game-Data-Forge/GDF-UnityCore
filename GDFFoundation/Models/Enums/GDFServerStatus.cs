#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServerStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the Server status in GDFServer : active, inactive, upgrading database
    /// </summary>
    [Serializable]
    public enum GDFServerStatus
    {
        /// <summary>
        ///     Server is active
        /// </summary>
        Active = 0,

        /// <summary>
        ///     Server is upgrading databases ... come back later
        /// </summary>
        Upgrading = 1,

        /// <summary>
        ///     Server is inactive
        /// </summary>
        Inactive = 2,
    }
}