using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for signing up a new account.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignUp : GDFUpPayload
    {
        /// <summary>
        /// Gets or sets the account sign.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; } = new GDFAccountSign();
    }
}