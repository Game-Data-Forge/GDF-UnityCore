using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload used when requesting account sign lost in GDFU
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignLost : GDFUpPayload
    {
        /// <summary>
        /// Represents a rescue email for account sign lost payload.
        /// </summary>
        public string RescueEmail { set; get; }
    }
}