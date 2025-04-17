using System;

namespace GDFEditor
{
    /// <summary>
    /// Represents a payload editor used in the GDFRequestEditor class.
    /// </summary>
    public class GDFUpPayloadSyncEditor : GDFUpPayloadEditor
    {
        /// <summary>
        /// Represents the synchronization timestamp for payload.
        /// </summary>
        public DateTime SyncTimestamp { set; get; }

    }
}