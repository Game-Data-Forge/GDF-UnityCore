

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload lock metadata object for downloading data from the server.
    /// </summary>
    public class GDFDownPayloadLockMetaData : GDFDownPayloadSyncEditor
    {
        /// <summary>
        /// The GDFMetaData class represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

        /// <summary>
        /// The GDFDownPayloadLockMetaData class represents a down payload for locking the metadata of a project.
        /// </summary>
        public GDFDownPayloadLockMetaData(GDFMetaData sMetaData)
        {
            MetaData = sMetaData;
        }
    }
}

