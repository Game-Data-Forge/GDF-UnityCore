using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a rescue sign payload for an account.
    /// Inherits from GDFDownPayload class.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignRescue : GDFDownPayload
    {
        /// <summary>
        /// The Success property indicates whether the operation was successful or not.
        /// </summary>
        public bool Success { set; get; }
        // public string RescueFormUrl { set; get; }
    }
}