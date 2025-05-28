#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRelationshipLinkStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the status of a relationship link.
    /// </summary>
    public enum GDFRelationshipLinkStatus
    {
        /// <summary>
        ///     Represents the link status of a relationship.
        /// </summary>
        Valid = 0,

        /// <summary>
        ///     Represents the self-association status of a relationship link.
        /// </summary>
        SelfAssociation = 1,

        /// <summary>
        ///     Represents the status of a relationship link.
        /// </summary>
        AlreadyExisting = 2,

        /// <summary>
        ///     Represents the relationship link status of an GDFRelationship.
        /// </summary>
        Expired = 3,

        /// <summary>
        ///     Represents an error status in the GDFRelationshipLinkStatus enum.
        /// </summary>
        Error = 4,
    }
}