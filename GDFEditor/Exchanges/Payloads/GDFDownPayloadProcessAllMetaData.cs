using System.Collections.Generic;

namespace GDFEditor
{
    /// <summary>
    /// Represents the state and information of a running process to process all metadata.
    /// </summary>
    public class GDFDownPayloadProcessAllMetaData : GDFDownPayloadSyncEditor
    {
        /// <summary>
        /// Represents the state and information of a running process to process all metadata.
        /// </summary>
        public bool Running = false;

        /// <summary>
        /// Represents the maximum value for processing all metadata.
        /// </summary>
        /// <remarks>
        /// The value of this variable is used to indicate the total number of metadata items to be processed.
        /// </remarks>
        public uint Max = 0;

        /// <summary>
        /// Represents the current value of a running process to process all metadata.
        /// </summary>
        public uint Current = 0;

        /// <summary>
        /// Represents a class for processing all metadata in GDFEditor.
        /// </summary>
        public string MainText = "Not started";

        /// <summary>
        /// Represents the state and information of a running process to process all metadata.
        /// </summary>
        public string Info = "No operation in progress";

        /// <summary>
        /// Represents the list of errors that occur during the process of processing all metadata.
        /// </summary>
        public List<string> Errors = new List<string>();
    }
}