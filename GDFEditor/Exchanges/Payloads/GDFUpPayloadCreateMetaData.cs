namespace GDFEditor
{
    /// <summary>
    /// Represents the payload class for creating meta data.
    /// </summary>
    public class GDFUpPayloadCreateMetaData : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// Represents a payload used to create metadata in the GDFEditorManager.
        /// </summary>
        public string TypeCLass { set; get; }

        /// <summary>
        /// Represents the metadata for creating an GDFUpPayload object.
        /// </summary>
        public GDFUpPayloadCreateMetaData(string sTypeClass)
        {
            TypeCLass = sTypeClass;
        }
    }
}