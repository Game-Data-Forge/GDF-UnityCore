using System;

namespace GDFFoundation
{
    [Serializable]
    public abstract class GDFLocalPlayerData : IGDFDbStorage, IGDFWritableAccountData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        public long AccountReference { get; set; }
        public long RowId { get; set; }
        public long Project { get; set; }
        public long Account { get; set; }
        public long DataVersion { get; set; }

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        public object GetReference() => Reference;
    }
}