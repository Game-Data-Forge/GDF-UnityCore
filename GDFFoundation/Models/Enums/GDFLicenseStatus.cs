

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Define the status of upgrade.
    /// </summary>
    [Serializable]
    public enum GDFLicenseStatus
    {
        /// <summary>
        /// Represents an unknown license status.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents the validity status of an upgrade license.
        /// </summary>
        Valid = 1,

        /// <summary>
        /// Represents the invalid status of a license.
        /// </summary>
        Invalid = 2,
    }
}

