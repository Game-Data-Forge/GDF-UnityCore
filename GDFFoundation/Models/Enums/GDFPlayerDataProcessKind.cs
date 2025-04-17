

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Enum representing the kind of process for GDFPlayerData.
    /// </summary>
    [Serializable]
    public enum GDFPlayerDataProcessKind
    {
        /// <summary>
        /// Represents the None member of the GDFPlayerDataProcessKind enum.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enum member OnlyOneData of enum GDFPlayerDataProcessKind
        /// </summary>
        OnlyOneData = 1,

        /// <summary>
        /// Represents a unique field that requires validation
        /// </summary>
        UniqueFieldOne = 2,

        /// <summary>
        /// Represents a player's unique nickname for data processing.
        /// </summary>
        UniqueNickname = 3,

        /// <summary>
        /// Represents a finder for GDFPlayerData instances.
        /// </summary>
        Finder = 9,
    }
}

