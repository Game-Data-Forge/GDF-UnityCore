

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a service key for a project in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFProjectServiceKey : GDFBasicData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Environment of this instance (use to change the table usage)
        /// </summary>
        public GDFEnvironmentKind EnvironmentKind { set; get; } = GDFEnvironmentKind.Development;
        /// <summary>
        /// The project status : active, inactive, upgrading data
        /// </summary>
        public GDFServiceStatus Status { set; get; } = GDFServiceStatus.Active;
        /// <summary>
        /// The readable name
        /// </summary>
        public string Name { set; get; } = string.Empty;
        /// <summary>
        /// The readable description
        /// </summary>
        public string Description { set; get; } = string.Empty;
        // /// <summary>
        // /// The Apple ProductId  
        // /// </summary>
        // public string AppleProductId  { set; get; } = string.Empty;
        // /// <summary>
        // /// The Google ProductId  
        // /// </summary>
        // public string GoogleProductId  { set; get; } = string.Empty;
        /// <summary>
        /// The unique identifier for a service.
        /// </summary>
        public long ServiceId { set; get; }

        /// <summary>
        /// Enum representing different kinds of GDF services.
        /// </summary>
        public GDFServiceKind ServiceKind { set; get; } = GDFServiceKind.Session;

        /// <summary>
        /// Enum representing the offline usage options for a service in the GDF system.
        /// </summary>
        public GDFServiceOfflineUsage OfflineUsage { set; get; } = GDFServiceOfflineUsage.OffLineUnlimited;

        /// <summary>
        /// The reserve value for the offline counter of a project service key.
        /// </summary>
        /// <remarks>
        /// This property represents the reserve value for the offline counter of a project service key. The offline counter is used to limit the usage of the service offline. The reserve is an additional value that can be subtracted from the offline counter to allow certain actions or access even when the offline counter reaches zero.
        /// </remarks>
        /// <value>
        /// The reserve value for the offline counter. The default value is 0.
        /// </value>
        public uint OfflineCounterReserve { set; get; } = 0;

        /// <summary>
        /// Gets or sets the service id for the sub-service.
        /// </summary>
        public long ServiceIdForSubService { set; get; }

        /// <summary>
        /// Represents a service key for a project in the GDF system.
        /// </summary>
        public GDFProjectServiceKey()
        {

        }
    }
}

