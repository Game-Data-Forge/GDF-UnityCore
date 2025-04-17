using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents an GDFUpPayload used to check if an email is used.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadCheckIfEmailIsUsed : GDFUpPayload
    {
        /// <summary>
        /// Represents the email hash used for checking if an email is already in use.
        /// </summary>
        public string EmailHash{ set; get; }

        /// <summary>
        /// Represents a payload for checking if an email is used.
        /// </summary>
        /// <remarks>
        /// This class is used in the GDFRuntime namespace.
        /// </remarks>
        public GDFUpPayloadCheckIfEmailIsUsed()
        {
        }

        /// <summary>
        /// Represents an update payload used to check if an email is already used.
        /// </summary>
        public GDFUpPayloadCheckIfEmailIsUsed(string sEmailHash)
        {
            EmailHash = sEmailHash;
        }
    }
}