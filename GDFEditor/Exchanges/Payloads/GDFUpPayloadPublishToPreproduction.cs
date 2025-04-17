

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload used to publish to preproduction in the GDFEditorManager.
    /// </summary>
    public class GDFUpPayloadPublishToPreproduction : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// The MetaData class represents metadata information for a project.
        /// </summary>
        public GDFMetaData MetaData { set; get; }

    }
}

