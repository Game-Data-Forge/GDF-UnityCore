namespace GDFEditor
{
    /// <summary>
    /// Represents a payload for processing all meta data in the editor.
    /// </summary>
    public class GDFUpPayloadProcessAllMetaData : GDFUpPayloadSyncEditor
    {
        /// <summary>
        /// The unknown constant representing an unknown value.
        /// </summary>
        public const string K_UNKNOWN = "unknown";

        /// <summary>
        /// Represents a project reference.
        /// </summary>
        public long ProjectReference { set; get; }
    }
}
