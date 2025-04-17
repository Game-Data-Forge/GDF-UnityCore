using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing an GDFUpPayloadAccountSignAdd.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignAdd : GDFUpPayload
    {
        /// <summary>
        /// Represents an account sign.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; }
    }
}