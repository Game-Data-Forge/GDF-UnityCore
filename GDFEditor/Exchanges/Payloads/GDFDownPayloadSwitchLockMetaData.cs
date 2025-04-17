
namespace GDFEditor
{
    /// <summary>
    /// Represents a switch lock for meta data.
    /// </summary>
    public class GDFDownPayloadSwitchLockMetaData : GDFDownPayloadEditor
    {
        /// <summary>
        /// The <see cref="GDFDownPayloadSwitchLockMetaData"/> class represents a down payload used in the GDFEditor namespace.
        /// It is used to switch the lock state of a metadata object.
        /// </summary>
        public GDFMetaData MetaDataToUnlock { set; get; }

        /// <summary>
        /// Represents the metadata to be locked for a project.
        /// </summary>
        public GDFMetaData MetaDataToLock { set; get; }

        /// <summary>
        /// This class represents a payload for switching lock status of metadata.
        /// </summary>
        public GDFDownPayloadSwitchLockMetaData(GDFMetaData sMetaDataToLock, GDFMetaData sMetaDataToUnlock)
        {
            MetaDataToLock = sMetaDataToLock;
            MetaDataToUnlock = sMetaDataToUnlock;
        }
    }
}