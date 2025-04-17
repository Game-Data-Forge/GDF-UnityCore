using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for finalizing a relationship.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadFinalizeRelationship : GDFUpPayload
    {
        /// <summary>
        /// Represents a payload for finalizing a relationship.
        /// </summary>
        public long RelationshipReference { set; get; }

        /// <summary>
        /// Gets or sets the value indicating whether the relationship is accepted or not.
        /// </summary>
        public bool IsAccepted { set; get; }

        /// <summary>
        /// Class representing a finalization relationship payload for an update request.
        /// </summary>
        public GDFUpPayloadFinalizeRelationship()
        {

        }

        /// <summary>
        /// This class represents a payload for finalizing a relationship.
        /// </summary>
        /// <remarks>
        /// Use this payload class when you want to send a request to finalize a relationship.
        /// </remarks>
        public GDFUpPayloadFinalizeRelationship(long sRelationshipReference, bool sIsAccepted)
        {
            RelationshipReference = sRelationshipReference;
            IsAccepted = sIsAccepted;
        }
    }
}