#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLicenseStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the status of upgrade.
    /// </summary>
    [Serializable]
    public enum GDFLicenseStatus
    {
        /// <summary>
        ///     Represents an unknown license status.
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Represents the validity status of an upgrade license.
        /// </summary>
        Valid = 1,

        /// <summary>
        ///     Represents the invalid status of a license.
        /// </summary>
        Invalid = 2,
    }
}