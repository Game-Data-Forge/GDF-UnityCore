#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServiceOfflineUsage.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the offline usage options for a service in the GDF system.
    /// </summary>
    public enum GDFServiceOfflineUsage
    {
        /// <summary>
        ///     Represents the offline usage behavior of a service in the GDF system.
        /// </summary>
        OffLineUnlimited = 0,

        /// <summary>
        ///     Represents the offline usage limitation of a service.
        /// </summary>
        OffLineLimited = 1,
    }
}