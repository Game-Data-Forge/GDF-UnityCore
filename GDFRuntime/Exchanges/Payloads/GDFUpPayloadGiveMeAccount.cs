using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload for requesting an account with additional properties.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadGiveMeAccount : GDFUpPayload
    {
        /// <summary>
        /// Represents the device fingerprint of an GDFUpPayloadGiveMeAccount.
        /// </summary>
        public string DeviceFingerPrint { set; get; }

        /// <summary>
        /// Gets or sets the value representing the StudioLastSync of the GDFUpPayloadGiveMeAccount object.
        /// </summary>
        public long StudioLastSync { set; get; }
    }
}