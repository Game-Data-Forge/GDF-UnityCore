using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload object for signing out an account.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignOut : GDFDownPayload
    {
        /// <summary>
        /// Represents the device sign information in the GDFDownPayloadAccountSignOut class.
        /// </summary>
        public GDFAccountSign DeviceSign { set; get; }
    }
}