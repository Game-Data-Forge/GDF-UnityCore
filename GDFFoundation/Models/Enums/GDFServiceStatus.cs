

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Define the Service status in GDFServer: active, inactive
    /// </summary>
    [Serializable]
    public enum GDFServiceStatus
    {
        /// <summary>
        /// Service is active
        /// </summary>
        Active = 0,

        /// <summary>
        /// The inactive status of a service.
        /// </summary>
        Inactive = 2,
    }
}

