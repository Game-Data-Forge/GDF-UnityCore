#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the project status in GDFServer : active, inactive, upgrading data
    /// </summary>
    [Serializable]
    public enum GDFProjectStatus
    {
        /// <summary>
        ///     Project is active
        /// </summary>
        Active = 0,

        /// <summary>
        ///     Project is upgrading studio data ... come back later
        /// </summary>
        Upgrading = 1,

        /// <summary>
        ///     Project is inactive
        /// </summary>
        Inactive = 2,
    }
}