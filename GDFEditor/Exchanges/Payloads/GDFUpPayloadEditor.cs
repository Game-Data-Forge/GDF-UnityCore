using System;

namespace GDFEditor
{
    /// <summary>
    /// Representation of a payload editor used in the GDFRequestEditor class.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadEditor
    {
        /// <summary>
        /// Represents the public key for a role in the GDFUpPayloadEditor class.
        /// </summary>
        public ulong RolePublicKey { set; get; }
    }
}