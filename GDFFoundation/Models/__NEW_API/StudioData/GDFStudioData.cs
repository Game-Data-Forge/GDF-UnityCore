using System;

namespace GDFFoundation
{
    /// <summary>
    /// Base class for all GDFStudioData objects.
    /// </summary>
    [Serializable]
    public abstract class GDFStudioData : GDFBasicData, IGDFSyncCommitByTimestamp, IGDFDataTrack, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents a data track property.
        /// </summary>
        public Int64 DataTrack { set; get; }
        
        /// <summary>
        /// The channel the data is accessible from.
        /// </summary>
        public int Channel { set; get; } = 0;

        /// <summary>
        /// The SyncDatetime property represents the synchronization date and time of the data.
        /// </summary>
        public DateTime SyncDatetime { set; get; }

        /// <summary>
        /// Gets or sets the SyncCommit property of the GDFStudioData class.
        /// </summary>
        /// <remarks>
        /// The SyncCommit property represents the commit identifier used for syncing the data with a timestamp. It is used to track changes made to the data and to ensure consistency with other synced data.
        /// </remarks>
        public long SyncCommit { set; get; }
    }
}


