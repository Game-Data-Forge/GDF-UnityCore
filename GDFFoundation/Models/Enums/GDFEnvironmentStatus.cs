#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFEnvironmentStatus.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the Environment status in GDFServer: active, inactive
    /// </summary>
    [Serializable]
    // TODO Rename it ProjectStatus
    public enum GDFEnvironmentStatus
    {
        /// <summary>
        ///     Environment is active
        /// </summary>
        Active = 0,

        /// <summary>
        ///     Represents the inactive status of an environment in the GDFServer.
        /// </summary>
        Inactive = 2,

        InTransfert = 3,
    }
}