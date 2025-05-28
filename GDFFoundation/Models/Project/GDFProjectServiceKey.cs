#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectServiceKey.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a service key for a project in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFProjectServiceKey : GDFBasicData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        /// <summary>
        ///     The readable description
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        ///     Environment of this instance (use to change the table usage)
        /// </summary>
        public ProjectEnvironment EnvironmentKind { set; get; } = ProjectEnvironment.Development;

        /// <summary>
        ///     The readable name
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        ///     The reserve value for the offline counter of a project service key.
        /// </summary>
        /// <remarks>
        ///     This property represents the reserve value for the offline counter of a project service key. The offline counter is used to limit the usage of the service offline. The reserve is an additional value that can be subtracted from the offline counter to allow certain actions or access even when the offline counter reaches zero.
        /// </remarks>
        /// <value>
        ///     The reserve value for the offline counter. The default value is 0.
        /// </value>
        public uint OfflineCounterReserve { set; get; } = 0;

        /// <summary>
        ///     Enum representing the offline usage options for a service in the GDF system.
        /// </summary>
        public GDFServiceOfflineUsage OfflineUsage { set; get; } = GDFServiceOfflineUsage.OffLineUnlimited;

        // /// <summary>
        // /// The Apple ProductId  
        // /// </summary>
        // public string AppleProductId  { set; get; } = string.Empty;
        // /// <summary>
        // /// The Google ProductId  
        // /// </summary>
        // public string GoogleProductId  { set; get; } = string.Empty;
        /// <summary>
        ///     The unique identifier for a service.
        /// </summary>
        public long ServiceId { set; get; }

        /// <summary>
        ///     Gets or sets the service id for the sub-service.
        /// </summary>
        public long ServiceIdForSubService { set; get; }

        /// <summary>
        ///     Enum representing different kinds of GDF services.
        /// </summary>
        public GDFServiceKind ServiceKind { set; get; } = GDFServiceKind.Session;

        /// <summary>
        ///     The project status : active, inactive, upgrading data
        /// </summary>
        public GDFServiceStatus Status { set; get; } = GDFServiceStatus.Active;

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a service key for a project in the GDF system.
        /// </summary>
        public GDFProjectServiceKey()
        {
        }

        #endregion
    }
}