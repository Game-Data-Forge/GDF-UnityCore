#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServiceKeyDescription.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a description of a service key in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFServiceKeyDescription
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the description of the service key.
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the name of the service key description.
        /// </summary>
        /// <remarks>
        ///     This property represents the name of the service key description.
        /// </remarks>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the reserve value for the offline counter.
        /// </summary>
        public uint OfflineCounterReserve { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the offline usage mode of the service key description.
        /// </summary>
        public GDFServiceOfflineUsage OfflineUsage { set; get; } = GDFServiceOfflineUsage.OffLineUnlimited;

        /// <summary>
        ///     Represents the service identifier.
        /// </summary>
        public long ServiceId { set; get; }

        /// <summary>
        ///     Represents the kind of service provided.
        /// </summary>
        public GDFServiceKind ServiceKind { set; get; } = GDFServiceKind.Session;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a service key description.
        /// </summary>
        public GDFServiceKeyDescription(GDFProjectServiceKey sProjectServiceKey)
        {
        }

        #endregion
    }
}