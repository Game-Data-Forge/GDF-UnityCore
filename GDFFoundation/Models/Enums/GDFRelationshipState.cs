


namespace GDFFoundation
{
    /// <summary>
    /// The state of a relationship.
    /// </summary>
    public enum GDFRelationshipState
    {
        /// <summary>
        /// Enum member representing the state of a relationship as pending.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Represents the state of a relationship that is waiting for confirmation.
        /// </summary>
        WaitingConfirmation = 1,

        /// <summary>
        /// Represents the accepted state of a relationship.
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// Represents the refusal state of a relationship.
        /// </summary>
        Refused = 3,

        /// <summary>
        /// Represents the state of a relationship being deleted.
        /// </summary>
        Deleted = 4,

        /// <summary>
        /// Represents the timeout state of a relationship.
        /// </summary>
        Timeout = 5,

        /// <summary>
        /// Represents the None member of the GDFRelationshipState enum.
        /// </summary>
        /// <remarks>
        /// This member represents a relationship state of None.
        /// </remarks>
        None = 6,
    }
}


