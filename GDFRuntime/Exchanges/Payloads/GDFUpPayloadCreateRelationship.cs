using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing a payload for creating a relationship.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadCreateRelationship : GDFUpPayload
    {
        /// <summary>
        /// Enum representing the type of a relationship.
        /// </summary>
        public GDFRelationshipType RelationshipType { set; get; } = GDFRelationshipType.Friend;
    }
}