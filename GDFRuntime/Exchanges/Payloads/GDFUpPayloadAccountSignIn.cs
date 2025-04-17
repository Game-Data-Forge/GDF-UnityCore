using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing the payload for an account sign-in request.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignIn : GDFUpPayload
    {
        /// <summary>
        /// Account sign information for authentication and authorization.
        /// </summary>
        public GDFAccountSign AccountSign { set; get; }
    }
}