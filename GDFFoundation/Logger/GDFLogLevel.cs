#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLogLevel.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration representing different levels of logging for the GDFLogger.
    /// </summary>
    [Serializable]
    public enum GDFLogLevel : short
    {
        /// <summary>
        ///     No message shown.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Messages indicating where a process is.
        ///     Almost never used.
        /// </summary>
        Trace = 1,

        /// <summary>
        ///     Messages only visible by developers.
        /// </summary>
        Debug = 2,

        /// <summary>
        ///     Messages indicating what the app is doing.
        /// </summary>
        Information = 4,

        /// <summary>
        ///     Messages indicating a configuration errors or minor malfunction.
        /// </summary>
        Warning = 8,

        /// <summary>
        ///     Messages indicating an unexpected but handled process interruption.
        ///     Ex: you caught and handled an exception.
        /// </summary>
        Error = 16,

        /// <summary>
        ///     Messages indicating an unexpected and unhandled process interruption.
        ///     Ex: An uncaught exception occured.
        /// </summary>
        Critical = 32,
    }
}