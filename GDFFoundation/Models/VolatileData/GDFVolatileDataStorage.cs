using System;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a volatile data storage model.
    /// </summary>
    [Serializable]
    public class GDFVolatileDataStorage : GDFDataBasicDataStorage, IGDFAccountDependence, IGDFDataTrack, IGDFWritableLongReference
    {[GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents a data track that can be used to track changes in a data storage.
        /// </summary>
        public Int64 DataTrack { set; get; }

        /// <summary>
        /// Represents a volatile data storage for an account.
        /// </summary>
        public long Account { set; get; }

        /// <summary>
        /// Represents a range value.
        /// </summary>
        public short Range { set; get; }

        /// <summary>
        /// This class represents a volatile data storage model.
        /// </summary>
        public GDFVolatileDataStorage()
        {
        }

        /// <summary>
        /// Copies the values of the given GDFVolatileDataStorage object to this GDFVolatileDataStorage object.
        /// </summary>
        /// <param name="sOther">The GDFVolatileDataStorage object to copy from.</param>
        public void CopyFrom(GDFVolatileDataStorage sOther)
        {
            base.CopyFrom(sOther);
            DataTrack = sOther.DataTrack;
            Account = sOther.Account;
            Range = sOther.Range;
        }
    }
}

