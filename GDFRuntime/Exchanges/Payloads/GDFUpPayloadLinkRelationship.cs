using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing a link relationship payload for a request
    /// </summary>
    [Serializable]
    public class GDFUpPayloadLinkRelationship : GDFUpPayload
    {
        /// <summary>
        /// Property representing the 'code' field of the GDFUpPayloadLinkRelationship class.
        /// </summary>
        /// <remarks>
        /// This property allows you to get or set the value of the 'code' field of the GDFUpPayloadLinkRelationship class.
        /// </remarks>
        /// <value>The value of the 'code' field.</value>
        public string code { set; get; }

        /// <summary>
        /// Class representing an GDFUpPayloadLinkRelationship.
        /// </summary>
        /// <remarks>
        /// This class is a subclass of the <see cref="GDFUpPayload"/> class.
        /// It represents a payload for a link relationship in the GDF system.
        /// </remarks>
        public GDFUpPayloadLinkRelationship()
        {

        }

        /// Used for representing a link relationship payload in a request.
        /// /
        public GDFUpPayloadLinkRelationship(string sCode)
        {
            code = sCode;
        }
    }
}