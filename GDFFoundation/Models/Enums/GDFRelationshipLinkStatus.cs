


namespace GDFFoundation
{
    /// <summary>
    /// Enum representing the status of a relationship link.
    /// </summary>
    public enum GDFRelationshipLinkStatus
    {
        /// <summary>
        /// Represents the link status of a relationship.
        /// </summary>
        Valid = 0,

        /// <summary>
        /// Represents the self-association status of a relationship link.
        /// </summary>
        SelfAssociation = 1,

        /// <summary>
        /// Represents the status of a relationship link.
        /// </summary>
        AlreadyExisting = 2,

        /// <summary>
        /// Represents the relationship link status of an GDFRelationship.
        /// </summary>
        Expired = 3,

        /// <summary>
        /// Represents an error status in the GDFRelationshipLinkStatus enum.
        /// </summary>
        Error = 4,

    }
}

