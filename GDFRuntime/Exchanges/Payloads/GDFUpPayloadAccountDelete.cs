using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for deleting an account in GDF.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountDelete : GDFUpPayload
    {
        /// <summary>
        /// Represents an account sign information.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; }
    }
}