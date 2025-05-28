#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectPartStatut.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the project part status in GDFServer : new, active, upgrading, inactive
    /// </summary>
    [Serializable]
    public enum GDFProjectPartStatus
    {
        /// <summary>
        ///     This part is new and no publish
        /// </summary>
        New = 0,

        /// <summary>
        ///     This part is active so published
        /// </summary>
        Active = 1,

        /// <summary>
        ///     This part is upgrading need to be publish
        /// </summary>
        Upgrading = 2,

        /// <summary>
        ///     This part is inactive
        /// </summary>
        Inactive = 3,
    }
}