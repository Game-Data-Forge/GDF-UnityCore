#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFLogger.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Interface for creating classes that can be used as debuggers in specific environments.
    /// </summary>
    public interface IGDFLogger
    {
        #region Instance methods

        /// <summary>
        ///     Gets the default log level to be displayed by the logger.
        /// </summary>
        /// <returns>The default log level.</returns>
        public GDFLogLevel DefaultLogLevel();

        /// <summary>
        ///     Determines if the debugger is active or not.
        /// </summary>
        /// <returns><c>true</c> if the debugger is active; otherwise, <c>false</c>.</returns>
        public bool IsActivated();

        /// <summary>
        ///     Retrieves the log level to be displayed by the logger.
        /// </summary>
        /// <returns>The log level to be displayed.</returns>
        public GDFLogLevel LogLevel();

        /// <summary>
        ///     Sets the log level to be displayed by the logger.
        /// </summary>
        /// <param name="sLogLevel">The log level to be set.</param>
        public void SetLogLevel(GDFLogLevel sLogLevel);

        /// <summary>
        ///     Method to write message in console
        /// </summary>
        /// <param name="sLogLevel">The log level of the message</param>
        /// <param name="sLogCategory">The log category of the message</param>
        /// <param name="sString">The message string to be logged</param>
        /// <param name="sObject">Optional object to be logged</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject);

        /// <summary>
        ///     Method to write a log message.
        /// </summary>
        /// <param name="sLogLevel">The log level of the message</param>
        /// <param name="sLogCategory">The category of the log message</param>
        /// <param name="sTitle">The title of the log message</param>
        /// <param name="sObject">The object associated with the log message</param>
        /// <param name="sMessages">The array of messages to be logged</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, string[] sMessages);

        #endregion
    }
}