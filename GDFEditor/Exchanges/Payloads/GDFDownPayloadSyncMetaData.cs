using System.Collections.Generic;

namespace GDFEditor
{
    /// <summary>
    /// Represents a class that holds the sync metadata for down payload synchronization.
    /// </summary>
    public class GDFDownPayloadSyncMetaData : GDFDownPayloadSyncEditor
    {
        /// <summary>
        /// Represents a list of metadata information for a project.
        /// </summary>
        public List<GDFMetaData> MetaDataList { set; get; } = new List<GDFMetaData>();

        /// <summary>
        /// The GDFDownPayloadSyncMetaData class represents a payload for synchronizing metadata between the editor and server.
        /// </summary>
        public GDFDownPayloadSyncMetaData(List<GDFMetaData> sSyncMetaData)
        {
            MetaDataList = sSyncMetaData;
        }
    }
}