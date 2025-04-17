using System;

namespace GDFFoundation
{
    /// <summary>
    /// GDFUserDataDataStorage class represents a storage model for user data.
    /// </summary>
    [Serializable]
    public class GDFUserDataDataStorage : IGDFStorageData, IGDFWritableAccountData, IGDFWritableStringReference
    {
        /// <summary>
        /// Represents the unit storage size for user data.
        /// </summary>
        public const int K_UNIT_STORAGE_SIZE = 1024 * 2;

        /// <summary>
        /// Represents the size of the storage head unit in a user data storage.
        /// </summary>
        public const int K_UNIT_STORAGE_HEAD = 128;
        //public const int K_UNIT_STORAGE_SIZE = 128;

        public const int K_UNIT_MAX = 32;

        public long Project { get; set; }

        [GDFDbLength(50)]
        public string Reference { get; set; }
        /// <summary>
        /// Represents a user data storage in the GDF system.
        /// </summary>
        public long Account { set; get; }

        /// <summary>
        /// Represents a data storage for user accounts.
        /// </summary>
        public int Storage { set; get; } = 1;

        public string ClassName { get; set; }

        public string Json { get; set; }

        /// <summary>
        /// Represents a user data storage.
        /// </summary>
        public GDFUserDataProcessKind Process { set; get; } = GDFUserDataProcessKind.None;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public DateTime Modification { get; set; }
        public DateTime SyncDateTime { get; set; }
        public long SyncCommit { get; set; }
        public int Channels { get; set; }

        public bool Trashed { get; set; }

        public long RowId { get; set; }

        public long DataVersion { get; set; }

        /// <summary>
        /// Represents a storage class for user data.
        /// </summary>
        public GDFUserDataDataStorage()
        {
        }

        /// <summary>
        /// Estimates the storage required for the user data.
        /// </summary>
        /// <returns>The estimated storage size in units.</returns>
        private int StorageEstimate()
        {
            return (int)(MathF.Floor(Json.Length / K_UNIT_STORAGE_SIZE) + 1);
        }

        /// <summary>
        /// Calculates the storage size of the GDFUserDataDataStorage object.
        /// </summary>
        public void StorageSize()
        {
            Storage = StorageEstimate();
        }

        /// <summary>
        /// Checks if the storage for the user data is okay.
        /// </summary>
        /// <returns>Returns true if the storage is okay, false otherwise.</returns>
        public bool StorageIsOk()
        {
            return StorageEstimate() < K_UNIT_MAX;
        }

        public object GetReference() => Reference;
    }
}


