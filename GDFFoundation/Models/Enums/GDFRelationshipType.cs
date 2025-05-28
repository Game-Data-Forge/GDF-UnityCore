#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRelationshipType.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the type of a relationship.
    /// </summary>
    public enum GDFRelationshipType
    {
        /// Friend relationship.
        /// Represents a friend relationship between two accounts.
        /// [GDFDatabaseIndex("RefAndProjectIndex", nameof(Reference), nameof(ProjectReference))]
        /// public class GDFRelationship : GDFBasicData
        Friend = 0
    }
}