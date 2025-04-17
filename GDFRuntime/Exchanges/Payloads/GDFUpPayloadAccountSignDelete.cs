using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload used to delete a sign from an account.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignDelete : GDFUpPayload
    {
        /// <summary>
        /// Represents an account sign.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; }
    }
}