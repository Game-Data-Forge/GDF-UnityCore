#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFExchangeKind.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration of exchange kinds.
    /// </summary>
    [Serializable]
    public enum GDFExchangeKind
    {
        /// <summary>
        ///     No exchange kind (!)
        /// </summary>
        None = -9,

        /// <summary>
        ///     Test exchange kind
        /// </summary>
        Test = -1,

        /// <summary>
        ///     Represents an unknown exchange kind.
        /// </summary>
        Unknown = 0,
    }
}