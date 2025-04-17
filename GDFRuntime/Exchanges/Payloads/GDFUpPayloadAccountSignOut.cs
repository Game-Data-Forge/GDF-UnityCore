using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for signing out an account.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAccountSignOut : GDFUpPayload
    {
        /// <summary>
        /// Represents a device sign information associated with an account.
        /// </summary>
        public GDFAccountSign DeviceSign { set; get; }
    }
}