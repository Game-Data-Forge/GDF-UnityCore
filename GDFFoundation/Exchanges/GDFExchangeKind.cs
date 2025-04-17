

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Enumeration of exchange kinds.
    /// </summary>
    [Serializable]
    public enum GDFExchangeKind
    {
        /// <summary>
        /// No exchange kind (!)
        /// </summary>
        None = -9,

        /// <summary>
        /// Test exchange kind
        /// </summary>
        Test = -1,

        /// <summary>
        /// Represents an unknown exchange kind.
        /// </summary>
        Unknown = 0,
    }
}

