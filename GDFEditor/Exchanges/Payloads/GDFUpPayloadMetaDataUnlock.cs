

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload metadata unlock used in the GDFUpPayloadMetaDataUnlock class.
    /// </summary>
    public class GDFUpPayloadMetaDataUnlock : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// The metadata class represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

        /// <summary>
        /// Represents a property used to store the name of a locker.
        /// </summary>
        public string LockerName { set; get; } = GDFUpPayloadMetaDataLock.K_UNKNOWN;

        public int TrackId { set; get; }

    }
}

