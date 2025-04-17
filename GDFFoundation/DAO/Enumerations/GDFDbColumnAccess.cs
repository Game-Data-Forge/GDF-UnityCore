namespace GDFFoundation
{
    /// <summary>
    /// Enumeration storing the access rights for a column in a given request.
    /// </summary>
    public enum GDFDbColumnAccess
    {
        /// <summary>
        /// the column cannot be used in the request.
        /// </summary>
        Deny = 0,
        /// <summary>
        /// The column can be used in the request.
        /// </summary>
        Can = 1,
        /// <summary>
        /// The column must be used in the request.
        /// </summary>
        Must = 2,
    }
}