

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload to create metadata in the GDFEditor.
    /// </summary>
    public class GDFDownPayloadCreateMetaData : GDFDownPayloadSyncEditor
    {
        /// <summary>
        /// Represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

        /// <summary>
        /// Represents a payload for creating metadata in the server.
        /// </summary>
        public GDFDownPayloadCreateMetaData(GDFMetaData sMetaData)
        {
            MetaData = sMetaData;
        }

        /// <summary>
        /// The GDFDownPayloadCreateMetaData class represents a payload for creating metadata in the server.
        /// </summary>
        public GDFDownPayloadCreateMetaData()
        {
        }
    }
}

