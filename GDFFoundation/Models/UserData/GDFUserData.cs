using System;

namespace GDFFoundation
{
    /// <summary>
    /// Base class for user data in the GDF system.
    /// </summary>
    [Serializable]
    public abstract class GDFUserData : IGDFWritableAccountData, IGDFWritableSyncableData, IGDFWritableStringReference
    {
        /// **Account***
        /// *Namespace:** GDFFoundation
        public long Account { set; get; }

        public string Reference { get; set; }

        /// <summary>
        /// The channel the data is accessible from.
        /// </summary>
        public int Channels { set; get; } = 0;

        /// <summary>
        /// Represents a process kind for user data.
        /// </summary>
        public GDFUserDataProcessKind Process { set; get; } = GDFUserDataProcessKind.None;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public DateTime Modification { get; set; }

        /// <summary>
        /// Gets or sets the synchronization datetime.
        /// </summary>
        /// <value>The synchronization datetime.</value>
        public DateTime SyncDateTime { get; set; }

        /// <summary>
        /// Interface to indicate that a class has a SyncCommit property.
        /// </summary>
        public long SyncCommit { set; get; }

        public long DataVersion { get; set; }

        public bool Trashed { get; set; }

        /// <summary>
        /// Copy the data from another GDFUserData object to this object.
        /// </summary>
        /// <param name="sOther">The GDFUserData object to copy from</param>
        public void CopyFrom(GDFUserData sOther)
        {
            Account = sOther.Account;
            Reference = sOther.Reference;
            Channels = sOther.Channels;
            Process = sOther.Process;
            Creation = sOther.Creation;
            Modification = sOther.Modification;
            SyncDateTime = sOther.SyncDateTime;
            SyncCommit = sOther.SyncCommit;
            DataVersion = sOther.DataVersion;
            Trashed = sOther.Trashed;
        }

        public object GetReference()
        {
            return Reference;
        }
    }
}

