#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFUserDataProcessKind.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration of different process kinds for user data.
    /// </summary>
    [Serializable]
    public enum GDFUserDataProcessKind
    {
        /// <summary>
        ///     Normal read write.
        /// </summary>
        None = 0,

        /// <summary>
        ///     OnlyOneData represents a type of data processing for GDFUserData.
        ///     This type indicates that only one instance of GDFUserData can exist in the database.
        /// </summary>
        OnlyOneData = 1,

        /// <summary>
        ///     Represents a unique field one for processing user data.
        /// </summary>
        UniqueFieldOne = 2,

        /// <summary>
        ///     Unique nickname process kind for GDFUserData.
        /// </summary>
        UniqueNickname = 3,

        /// <summary>
        ///     Represents a finder member in the GDFUserDataProcessKind enum.
        /// </summary>
        Finder = 9,
    }
}