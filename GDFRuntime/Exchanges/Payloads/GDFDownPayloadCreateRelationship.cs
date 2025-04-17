using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload used in down communication between server and client
    /// to create a relationship.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadCreateRelationship : GDFDownPayload
    {
        /// <summary>
        /// Represents a relationship between two accounts.
        /// </summary>
        public GDFRelationship Relationship { set; get; }

        /// <summary>
        /// Represents a payload object for creating a relationship between two accounts in the down communication between the server and client.
        /// </summary>
        public GDFDownPayloadCreateRelationship()
        {
        }

        /// Represents a payload for creating a relationship.
        /// /
        public GDFDownPayloadCreateRelationship(GDFRelationship sRelationship)
        {
            Relationship = sRelationship;
        }
    }
}