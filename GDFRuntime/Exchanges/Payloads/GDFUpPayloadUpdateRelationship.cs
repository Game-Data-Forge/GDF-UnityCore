using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing an GDFUpPayloadUpdateRelationship.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadUpdateRelationship : GDFUpPayload
    {
        /// <summary>
        /// Represents a relationship between two accounts.
        /// </summary>
        public GDFRelationship Relationship;

        /// <summary>
        /// Represents an GDFUpPayloadUpdateRelationship.
        /// </summary>
        public GDFUpPayloadUpdateRelationship()
        {
        }

        /// <summary>
        /// Represents an update payload for a relationship in an GDFRequestRuntime.
        /// </summary>
        public GDFUpPayloadUpdateRelationship(GDFRelationship sRelationship)
        {
            Relationship = sRelationship;
        }


    }
}