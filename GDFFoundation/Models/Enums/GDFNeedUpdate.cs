

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Define the status of upgrade.
    /// </summary>
    [Serializable]
    public enum GDFNeedUpdate
    {
        /// <summary>
        /// Specifies that the status of the upgrade is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents the status indicating that the software is up to date.
        /// </summary>
        UpToDate = 1,

        /// <summary>
        /// Represents the member 'Update' of the 'GDFNeedUpdate' enum.
        /// </summary>
        /// <remarks>
        /// This member indicates that an update is available for the system.
        /// </remarks>
        Update = 2,

        /// <summary>
        /// Specifies that an immediate upgrade is required.
        /// </summary>
        UpgradeNow = 4,
    }
}

