

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents the information about a new synchronization.
    /// </summary>
    [Serializable]
    public class GDFNewSyncInformation
    {
        /// <summary>
        /// Gets or sets the synchronization DateTime.
        /// </summary>
        public DateTime SyncTime { set; get; } = DateTime.UnixEpoch;

        /// <summary>
        /// Sync Commit Id
        /// </summary>
        public long SyncCommit { set; get; } = 0;
    }
}

