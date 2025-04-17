

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload editor used in the publishing process for production.
    /// </summary>
    public class GDFUpPayloadPublishToProduction : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// The MetaData class represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

    }
}

