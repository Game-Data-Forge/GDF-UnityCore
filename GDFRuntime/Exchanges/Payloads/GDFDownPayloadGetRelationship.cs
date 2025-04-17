using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadGetRelationship represents the payload object for getting relationships in the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadGetRelationship : GDFDownPayload
    {
        /// <summary>
        /// A list of GDFRelationship objects.
        /// </summary>
        public List<GDFRelationship> RelationshipList { set; get; } = new List<GDFRelationship>();
    }
}