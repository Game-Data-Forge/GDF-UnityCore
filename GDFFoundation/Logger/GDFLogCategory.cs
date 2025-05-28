#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLogCategory.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     GDFLogCategory enumeration represents the different categories of log messages.
    /// </summary>
    [Serializable]
    public enum GDFLogCategory : short
    {
        /// <summary>
        ///     Represents a log category for GDFLogger.
        /// </summary>
        No = 0,

        /// <summary>
        ///     Represents a log category for GDFLogger.
        /// </summary>
        Todo = 1,

        /// <summary>
        ///     Represents the log category for successful operations.
        /// </summary>
        Success = 2,

        /// <summary>
        ///     Represents the log category for a log message.
        /// </summary>
        Failed = 4,

        /// <summary>
        ///     Represents an error log category.
        /// </summary>
        Error = 8,

        /// <summary>
        ///     Represents different categories for logging messages.
        /// </summary>
        Attention = 16,

        /// <summary>
        ///     Represents an exception log category.
        /// </summary>
        Exception = 32,
    }
}