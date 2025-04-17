using System;

namespace GDFFoundation
{
    [Serializable]
    public class GDFPlayerDataReport : IGDFDbStorage, IGDFRangedData, IGDFWritableAccountData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public short Channel { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public string StatKey { get; set; }
        
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public int Year { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public int Month { get; set; }
        public long SyncCounter { get; set; }   
        public long RowUsed { get; set; }
        public long PlayerDataSyncCounter { get; set; }
        public long StudioDataSyncCounter { get; set; }
        public long VolatileDataSyncCounter { get; set; }
        
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Account { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public short Range { get; set; }


        public object GetReference() => Reference;
        public long RowId { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Project { get; set; }
    }
}