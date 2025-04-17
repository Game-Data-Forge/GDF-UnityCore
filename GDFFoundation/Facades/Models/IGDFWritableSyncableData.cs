using System;

namespace GDFFoundation
{
    public interface IGDFWritableSyncableData : IGDFWritableData, IGDFSyncableData
    {
        public new DateTime SyncDateTime { get; set; }
        public new long SyncCommit { get; set; }
    }
}


