using System;

namespace GDFEditor
{
    /// <summary>
    /// Represents a class used to edit down payloads for synchronization.
    /// </summary>
    public class GDFDownPayloadSyncEditor : GDFDownPayloadEditor
    {
        /// <summary>
        /// Represents the synchronization timestamp of a payload in the GDFEditor system.
        /// </summary>
        public DateTime SyncTimestamp { set; get; }
    }
}