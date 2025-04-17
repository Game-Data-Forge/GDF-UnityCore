using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload object for the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadPleaseChangeServer : GDFDownPayload
    {
        /// <summary>
        /// Represents a payload object for the down communication between the server and client.
        /// </summary>
        private List<string> ServerDomainNameList { set; get; }
    }
}