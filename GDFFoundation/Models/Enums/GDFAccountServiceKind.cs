


namespace GDFFoundation
{
    /// <summary>
    /// Enum representing the kind of account service.
    /// </summary>
    public enum GDFAccountServiceKind
    {
        /// <summary>
        /// The original kind of GDFAccountService.
        /// </summary>
        Original = 0,

        /// <summary>
        /// Represents the status of a granted account service.
        /// </summary>
        Granted = 1,

        /// <summary>
        /// Represents the Transferred member of the GDFAccountServiceKind enum.
        /// </summary>
        /// <remarks>
        /// This member is used to indicate that a service has been transferred to another account.
        /// </remarks>
        Transferred = 2,

    }
}

