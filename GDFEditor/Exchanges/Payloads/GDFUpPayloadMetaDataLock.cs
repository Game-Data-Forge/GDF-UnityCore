namespace GDFEditor
{
    /// <summary>
    /// Represents a payload metadata lock used in the GDFUpPayloadMetaDataLock class.
    /// </summary>
    public class GDFUpPayloadMetaDataLock : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// Represents an unknown value for the LockerName property in various classes related to metadata management.
        /// </summary>
        public const string K_UNKNOWN = "unknown";

        /// <summary>
        /// Represents a reference to metadata in the GDFUpPayloadMetaDataLock class.
        /// </summary>
        public long MetaDataReference { set; get; }

        /// <summary>
        /// The name of the locker.
        /// </summary>
        public string LockerName { set; get; } = K_UNKNOWN;
    }
}
