

namespace GDFFoundation
{
    /// <summary>
    /// The different kinds of database where conditions.
    /// </summary>
    public enum GDFDatabaseWhereKind
    {
        Equal = 1, // ==

        /// <summary>
        /// Represents the "NotEqual" operation for database where clause.
        /// </summary>
        NotEqual = 2, // !=

        /// <summary>
        /// Represents the "GreaterThan" operation in a database query.
        /// </summary>
        /// <remarks>
        /// This operation checks if the value in the specified column is greater than the given value.
        /// </remarks>
        GreaterThan = 11, //>
        GreaterThanOrEqual = 12, // >=
        SmallerThan = 21, //<

        /// <summary>
        /// Represents the smaller than or equal operation in a database query.
        /// </summary>
        SmallerThanOrEqual = 22, //<=

        //InArray = 81, //in [,,,,]
    }
}

