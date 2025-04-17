using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing an GDFUpPayloadStudioDataByBundle.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadStudioDataByBundle : GDFUpPayload
    {
        /// <summary>
        /// Gets or sets the Bundle Id of the GDFUpPayloadStudioDataByBundle object.
        /// </summary>
        /// <remarks>
        /// The Bundle Id is used to identify the studio data bundle associated with the GDFUpPayloadStudioDataByBundle object.
        /// </remarks>
        /// <value>The Bundle Id of the GDFUpPayloadStudioDataByBundle object.</value>
        public int BundleId { set; get; }
    }
}