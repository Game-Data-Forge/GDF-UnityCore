using System;

namespace GDFFoundation
{
    /// <summary>
    /// Interface for syncing data commit with a timestamp.
    /// </summary>
    [Obsolete("Use IGDFSyncableData instead !")]
    public interface IGDFSyncCommitByTimestamp
    {
        /// <summary>
        /// Gets or sets the synchronization datetime.
        /// </summary>
        public DateTime SyncDatetime { set; get; }

        /// <summary>
        /// Gets or sets the synchronization commit.
        /// </summary>
        public long SyncCommit { set; get; }

    }
}


