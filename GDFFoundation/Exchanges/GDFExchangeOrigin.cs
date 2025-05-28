#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFExchangeOrigin.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents the origin of the GDF exchange.
    /// </summary>
    [Serializable]
    public enum GDFExchangeOrigin
    {
        /// <summary>
        ///     Represents an unknown origin of the exchange in the GDFServerMiddleConfiguration.
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     Represents the origin of the game exchange.
        /// </summary>
        Game = 1,

        /// <summary>
        ///     Represents the origin of the mobile application exchange.
        /// </summary>
        App = 2,

        /// <summary>
        ///     Represents the origin of the web exchange.
        /// </summary>
        Web = 4,

        /// <summary>
        ///     Represents the UnityEditor origin of the exchange in GDFServerMiddle.
        /// </summary>
        UnityEditor = 8,
    }
}