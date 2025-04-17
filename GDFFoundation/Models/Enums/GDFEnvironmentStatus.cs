

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Define the Environment status in GDFServer: active, inactive
    /// </summary>
    [Serializable]
    // TODO Rename it ProjectStatus
    public enum GDFEnvironmentStatus
    {
        /// <summary>
        /// Environment is active
        /// </summary>
        Active = 0,

        /// <summary>
        /// Represents the inactive status of an environment in the GDFServer.
        /// </summary>
        Inactive = 2,
        
        InTransfert = 3,
    }
}

