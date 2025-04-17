

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a description of a service key in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFServiceKeyDescription
    {
        /// <summary>
        /// Gets or sets the name of the service key description.
        /// </summary>
        /// <remarks>
        /// This property represents the name of the service key description.
        /// </remarks>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the service key.
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        /// Represents the service identifier.
        /// </summary>
        public long ServiceId { set; get; }

        /// <summary>
        /// Represents the kind of service provided.
        /// </summary>
        public GDFServiceKind ServiceKind { set; get; } = GDFServiceKind.Session;

        /// <summary>
        /// Gets or sets the offline usage mode of the service key description.
        /// </summary>
        public GDFServiceOfflineUsage OfflineUsage { set; get; } = GDFServiceOfflineUsage.OffLineUnlimited;

        /// <summary>
        /// Gets or sets the reserve value for the offline counter.
        /// </summary>
        public uint OfflineCounterReserve { set; get; } = 0;

        /// <summary>
        /// Represents a service key description.
        /// </summary>
        public GDFServiceKeyDescription(GDFProjectServiceKey sProjectServiceKey)
        {

        }
    }
}

