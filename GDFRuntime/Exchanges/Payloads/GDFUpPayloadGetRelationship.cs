using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for getting relationships.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadGetRelationship : GDFUpPayload
    {
        /// <summary>
        /// Represents the state of a relationship.
        /// </summary>
        public GDFRelationshipState RelationshipState { set; get; } = GDFRelationshipState.None;

        /// <summary>
        /// Enum representing the type of a relationship.
        /// </summary>
        public GDFRelationshipType? RelationshipType { set; get; } = null;
    }
}