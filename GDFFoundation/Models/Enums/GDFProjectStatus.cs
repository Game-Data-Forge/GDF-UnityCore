

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Define the project status in GDFServer : active, inactive, upgrading data
    /// </summary>
    [Serializable]
    public enum GDFProjectStatus
    {
        /// <summary>
        /// Project is active
        /// </summary>
        Active = 0,
        /// <summary>
        /// Project is upgrading studio data ... come back later
        /// </summary>
        Upgrading = 1,
        /// <summary>
        /// Project is inactive
        /// </summary>
        Inactive = 2,
    }
}

