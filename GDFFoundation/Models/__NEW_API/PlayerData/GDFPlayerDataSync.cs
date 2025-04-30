using System;

namespace GDFFoundation
{
    [Serializable]
    public class GDFPlayerDataSync : IGDFDbStorage, IGDFRangedData, IGDFWritableAccountData, IGDFWritableLongReference
    {
        public short Channel { get; set; }
        
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Account { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public int Range { get; set; }

        public object GetReference() => Reference;
        public long RowId { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Project { get; set; }
    }
}