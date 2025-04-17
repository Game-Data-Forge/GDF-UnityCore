using System;

namespace GDFFoundation
{
    [Serializable]
    public class  GDFStudioDataSync : IGDFWritableLongReference, IGDFDbStorage, IGDFData, IGDFWritableData
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public long Project { get; set; }
        public long RowId { get; set; }
        public long DataVersion { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public object GetReference() => Reference;
    }

        
    /// <summary>
    /// Represents a data storage class for GDFStudioDataDataStorage.
    /// </summary>
    [Serializable]
    public class GDFStudioDataStorage : IGDFWritableData, IGDFDataTrack, IGDFWritableLongReference, IGDFDbStorage, IGDFSyncableData
    {
        
        public string ClassName { set; get; }
        public string Json { set; get; }
        
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents a data storage model with a data track attribute.
        /// </summary>
        public Int64 DataTrack { set; get; }
        public long Project { get; set; }

        /// <summary>
        /// Represents a data storage class for GDFStudioDataDataStorage.
        /// </summary>
        public GDFStudioDataStorage()
        {
        }

        public long DataVersion { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public object GetReference()
        {
            throw new NotImplementedException();
        }

        public long RowId { get; set; }
        public DateTime SyncDateTime { get; }
        public long SyncCommit { get; }
        public int Channels { get; set; }
    }
}


