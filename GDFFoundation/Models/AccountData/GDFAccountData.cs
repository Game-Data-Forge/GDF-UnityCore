using System;

namespace GDFFoundation
{
    /// <summary>
    /// Data directly recorded in Database: no serialization storage.
    /// </summary>
    [Serializable]
    public abstract class GDFAccountData : IGDFDbStorage, IGDFRangedData, IGDFWritableAccountData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        /// <summary>
        /// Abstract class representing an account in the system.
        /// </summary>
        [GDFDbUnique(constraintName = "Identity")]
        public long Account { set; get; }

        public long RowId { get; set; }
        public long Project { get; set; }
        public long DataVersion { get; set; }

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public short Range { get; set; }

        public object GetReference() => Reference;
    }
}