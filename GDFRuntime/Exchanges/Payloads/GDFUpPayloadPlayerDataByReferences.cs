using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for updating player data by references.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadPlayerDataByReferences : GDFUpPayload
    {
        /// <summary>
        /// Represents a list of references to user data.
        /// </summary>
        public List<long> UserDataReferencesList { set; get; }

        /// <summary>
        /// Represents a list of player data references.
        /// </summary>
        public List<long> PlayerDataReferencesList { set; get; }

        /// <summary>
        /// Gets or sets the last synchronization datetime of the studio.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of GDFVolatileData objects.
        /// </summary>
        public List<GDFVolatileData> VolatileDataList { set; get; }
    }
}