using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload object for the down communication between the server and client when an account sign is lost.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignLost : GDFDownPayload
    {
        /// <summary>
        /// Represents the property indicating whether the rescue token is secured.
        /// </summary>
        public string RescueTokenSecured { set; get; } = string.Empty;

        /// <summary>
        /// Represents the type of account sign-in.
        /// </summary>
        public GDFAccountSignType SignType { set; get; } = GDFAccountSignType.None;
        public long Limit { set; get; } = 0;
    }
}