

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents the origin of the GDF exchange.
    /// </summary>
    [Serializable]
    public enum GDFExchangeOrigin
    {
        /// <summary>
        /// Represents an unknown origin of the exchange in the GDFServerMiddleConfiguration.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Represents the origin of the game exchange.
        /// </summary>
        Game = 1,

        /// <summary>
        /// Represents the origin of the mobile application exchange.
        /// </summary>
        App = 2,

        /// <summary>
        /// Represents the origin of the web exchange.
        /// </summary>
        Web = 4,

        /// <summary>
        /// Represents the UnityEditor origin of the exchange in GDFServerMiddle.
        /// </summary>
        UnityEditor = 8,
    }
}

