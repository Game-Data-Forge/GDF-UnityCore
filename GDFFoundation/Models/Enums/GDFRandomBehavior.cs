#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRandomBehavior.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// GDFRandomBehavior defines the behavior options for generating random values.
    /// /
    public enum GDFRandomBehavior
    {
        /// <summary>
        ///     Represents the behavior of always generating different values.
        /// </summary>
        AlwaysDifferent = 0,

        /// <summary>
        ///     Specifies that the random value should be generated only once.
        /// </summary>
        GenerateOnce = 1,
    }
}