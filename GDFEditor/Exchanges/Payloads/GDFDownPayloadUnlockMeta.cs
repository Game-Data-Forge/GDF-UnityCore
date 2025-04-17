

namespace GDFEditor
{
    /// <summary>
    /// Represents a class used for unlocking meta data in the down payload.
    /// </summary>
    public class GDFDownPayloadUnlockMeta : GDFDownPayloadSyncEditor
    {
        /// <summary>
        /// Represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

        /// <summary>
        /// Implementation of GDFDownPayloadSyncEditor used for unlocking metadata information.
        /// This class extends GDFDownPayloadSyncEditor.
        /// </summary>
        public GDFDownPayloadUnlockMeta(GDFMetaData sMetaData)
        {
            MetaData = sMetaData;
        }
    }
}

