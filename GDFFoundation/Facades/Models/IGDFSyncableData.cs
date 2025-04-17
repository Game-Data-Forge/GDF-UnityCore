using System;

namespace GDFFoundation
{
    public interface IGDFSyncableData : IGDFData
    {
        public DateTime SyncDateTime { get; }
        public long SyncCommit { get; }
        public int Channels { get; set; }
    }
}


