using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for updating the account change range.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountChangeRange : GDFUpPayload
    {
        /// <summary>
        /// Represents a payload for an account change range in the GDFRuntime.
        /// </summary>
        /// <remarks>
        /// This payload is used in the GDFRuntime for storing and transferring
        /// information related to account change ranges.
        /// </remarks>
        public ushort NewRange { set; get; }
    }
}