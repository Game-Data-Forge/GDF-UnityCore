#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServiceStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the Service status in GDFServer: active, inactive
    /// </summary>
    [Serializable]
    public enum GDFServiceStatus
    {
        /// <summary>
        ///     Service is active
        /// </summary>
        Active = 0,

        /// <summary>
        ///     The inactive status of a service.
        /// </summary>
        Inactive = 2,
    }
}