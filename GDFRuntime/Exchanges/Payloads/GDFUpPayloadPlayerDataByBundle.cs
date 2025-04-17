using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing a payload for updating player data by bundle.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadPlayerDataByBundle : GDFUpPayload
    {
        /// <summary>
        /// Gets or sets the BundleId of the GDFUpPayloadPlayerDataByBundle.
        /// </summary>
        public int BundleId { set; get; }

        /// <summary>
        /// Gets or sets the timestamp of the last synchronization with the studio.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a payload for updating player data by bundle.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Represents a list of player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Represents a list of volatile data objects.
        /// </summary>
        /// <remarks>
        /// This class is used to store and manage a collection of volatile data objects.
        /// </remarks>
        public List<GDFVolatileData> VolatileDataList { set; get; }
    }
}