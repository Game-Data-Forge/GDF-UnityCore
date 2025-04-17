using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing the payload data for synchronizing data by increment.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadDataSyncByIncrement : GDFDownPayload
    {
        /// <summary>
        /// Represents the last synchronization information for a user.
        /// </summary>
        public GDFSyncInformation UserLastSync { set; get; }

        /// <summary>
        /// Represents a list of user data.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Represents the last synchronization information for a player.
        /// </summary>
        public GDFSyncInformation PlayerLastSync { set; get; }

        /// <summary>
        /// Represents a list of player data storage.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Represents the last synchronization information for the StudioDataList.
        /// </summary>
        public GDFSyncInformation StudioLastSync { set; get; }

        /// <summary>
        /// Represents a data synchronization payload class for syncing data by increment.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}