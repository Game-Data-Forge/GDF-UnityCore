using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a down payload link relationship.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadLinkRelationship : GDFDownPayload
    {
        public GDFRelationshipLinkStatus LinkStatus { set; get; } = GDFRelationshipLinkStatus.Expired;
    }
}