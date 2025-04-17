using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing a payload for signing in with account rescue.
    /// </summary>
    /// <remarks>
    /// This class extends the GDFUpPayload class.
    /// </remarks>
    [Serializable]
    public class GDFUpPayloadAccountSignRescue : GDFUpPayload
    {
        /// <summary>
        /// Represents an account sign in the system.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; }
    }
}