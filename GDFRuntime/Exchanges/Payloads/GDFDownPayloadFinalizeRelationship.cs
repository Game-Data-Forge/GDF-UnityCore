using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadFinalizeRelationship represents the payload object for finalizing a relationship
    /// between the server and the client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadFinalizeRelationship : GDFDownPayload
    {
        /// <summary>
        /// Represents the finalize status of a relationship.
        /// </summary>
        public GDFRelationshipFinalizeStatus FinalizeStatus { set; get; }
    }
}