using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for modifying an account sign in the server.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignModify : GDFUpPayload
    {
        /// <summary>
        /// Gets or sets the old account sign.
        /// </summary>
        public GDFAccountSign OldAccountSign { set; get; }

        /// <summary>
        /// Represents the new account sign.
        /// </summary>
        public GDFAccountSign NewAccountSign { set; get; }
    }
}