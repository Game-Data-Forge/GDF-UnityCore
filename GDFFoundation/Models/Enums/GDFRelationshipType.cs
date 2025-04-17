


namespace GDFFoundation
{
    /// <summary>
    /// Enum representing the type of a relationship.
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

