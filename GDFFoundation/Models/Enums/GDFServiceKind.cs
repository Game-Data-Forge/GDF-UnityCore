#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServiceKind.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing different kinds of GDF services.
    /// </summary>
    [Serializable]
    public enum GDFServiceKind
    {
        /// <summary>
        ///     Represents a session service in the GDF system.
        /// </summary>
        Session = 0,

        /// <summary>
        ///     Represents the "Cookie" service kind in the GDF system.
        /// </summary>
        Cookie = 1,

        /// <summary>
        ///     Represents an enum member for specifying the unique IP service kind.
        /// </summary>
        IpUnique = 2,

        /// <summary>
        ///     Represents a class D IP address in the GDF system.
        /// </summary>
        IpClassD = 10,

        /// <summary>
        ///     Enum member representing an IP class C in the GDFServiceKind enum.
        /// </summary>
        IpClassC = 11,

        /// <summary>
        ///     Represents an IP class B service kind in the GDF system.
        /// </summary>
        IpClassB = 12,

        /// <summary>
        ///     Represents the IP class A for the service kind in the GDF system.
        /// </summary>
        IpClassA = 13,
    }
}