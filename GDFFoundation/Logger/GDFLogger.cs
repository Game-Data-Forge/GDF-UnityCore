using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
#if UNITY_EDITOR
using UnityEngine;
#endif


namespace GDFFoundation
{
    /// <summary>
    /// GDFLogger class provides logging functionalities.
    /// </summary>
    public static class GDFLogger
    {
        /// <summary>
        /// The Writer class provides methods for logging messages using the chosen logger.
        /// </summary>
        private static IGDFLogger Writer = new GDFConsoleLogger();

        /// <summary>
        /// The constant string that represents the message template for when a configuration is already loaded.
        /// </summary>
        public const string K_CONFIG_ALREADY_LOADED = "{0} already loaded before!";

        /// <summary>
        /// Represents a constant string for enable the Razor Runtime Compilation.
        /// </summary>
        public const string K_RAZOR_RUNTIME_COMPILATION_ENABLE = "{0} active Razor Runtime Compilation by {1} configuration!";

        /// <summary>
        /// Represents the configuration to disable Razor runtime compilation.
        /// </summary>
        public const string K_RAZOR_RUNTIME_COMPILATION_DISABLE = "{0} disable Razor Runtime Compilation by {1} configuration (IsDevelopment = false)!";

        /// <summary>
        /// The K_RAZOR_COMPILE_NOT_FOR_DEV constant is used to disable Razor Runtime Compilation in development mode.
        /// </summary>
        public const string K_RAZOR_COMPILE_NOT_FOR_DEV = "{0} disable Razor Runtime from parameter : sRuntimeCompileForDev";

        /// <summary>
        /// The configuration key for finding a value in the app settings file or in a specific JSON file.
        /// </summary>
        public const string K_FOUND_IN_APP_SETTINGS = "{0} config found in app" + "settings.json or in {0}.json!";

        /// <summary>
        /// The constant string used when a configuration is not found in the app settings.
        /// </summary>
        public const string K_NOT_FOUND_IN_APP_SETTINGS = "{0} config not found in app" + "settings.json or in {0}.json!";

        /// <summary>
        /// Represents the example value for the K_CONFIG_JSON_EXAMPLE constant.
        /// </summary>
        public const string K_CONFIG_JSON_EXAMPLE = "{0}.json Example";

        /// <summary>
        /// Sets the writer for the GDFLogger.
        /// </summary>
        /// <param name="sWriter">The writer implementing the IGDFLogger interface.</param>
        public static void SetWriter(IGDFLogger sWriter)
        {
            Writer = sWriter;
        }

        /// <summary>
        /// Splits a JSON string into an array of strings, separating each element, object, and value with a delimiter.
        /// </summary>
        /// <param name="sJson">The JSON string to split.</param>
        /// <returns>An array of strings with each element, object, and value separated by the delimiter.</returns>
        private static string[] SplitJson(string sJson)
        {
            return sJson.Replace(",", ",•").Replace("{", "{•").Replace("}", "•}").Split('•');
        }

        /// <summary>
        /// Splits a serialized object into an array of strings, where each string represents a separate line in the serialized format.
        /// </summary>
        /// <param name="sObject">The object to be serialized and split.</param>
        /// <returns>An array of strings representing the serialized object split by lines.</returns>
        public static string[] SplitObjectSerializable(object sObject)
        {
            return JsonConvert.SerializeObject(sObject, Formatting.Indented).Replace(",\\\"", ",\n\\\"").Replace("{\\\"", "{\n\\\"").Replace("\\\"}", "\\\"\n}").Split('\n');
        }

        /// <summary>
        /// Checks if a log for a given <see cref="GDFLogLevel"/> can be written by the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sLogLevel">The log level to check</param>
        /// <returns>True if a log with the specified log level can be written, false otherwise</returns>
        private static bool CanWrite(GDFLogLevel sLogLevel)
        {
            return CanWrite(Writer, sLogLevel);
        }

        /// <summary>
        /// Checks if a log for a given <see cref="GDFLogLevel"/> can be written by the specified writer.
        /// </summary>
        /// <param name="sWriter">The writer implementing the <see cref="IGDFLogger"/> interface.</param>
        /// <param name="sLogLevel">The log level to check.</param>
        /// <returns>True if the log can be written, otherwise false.</returns>
        internal static bool CanWrite(IGDFLogger sWriter, GDFLogLevel sLogLevel)
        {
            // Cannot write a log if the writer is not set
            if (sWriter == null)
            {
                return false;
            }

            // Cannot write a Log if the writer is not activated
            if (!sWriter.IsActivated())
            {
                return false;
            }

            // Cannot write a log if logLevel is below the wanted one or if it is equal to none
            if (sLogLevel < sWriter.LogLevel() || sLogLevel == GDFLogLevel.None)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// [Insert brief description of the method's purpose]
        /// </summary>
        /// <param name="/*[Insert parameter name]*/">[Insert description of the parameter]</param>
        /// <remarks>
        /// [Insert any additional information about the method, such as side effects or limitations]
        /// </remarks>
        public static void TestLayout()
        {
            TraceAttention("test of layout");
            TraceError("test of layout");
            TraceFailed("test of layout");
            TraceSuccess("test of layout");
            TraceTodo("test of layout");
            Exception(null);
            Exception(new Exception("Exception's message"));
            Trace("test of layout");
            Information("test of layout number 1");
            Debug("test of layout for debug");
            Warning("test of layout !warning! ");
            Error("test of layout ... Arghhh an error");
            Critical("test of layout ... critical ... I'am dead!");

            Trace("test of layout");
            Trace("my title",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");


            Information("test of layout number 1");
            Information("my title number 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");


            Debug("test of layout for debug");
            Debug("my title for debug",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");


            Warning("test of layout !warning! ");
            Warning("my title !warning! ",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");


            Error("test of layout ... Arghhh an error");
            Error("my title ... Arghhh an error",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");


            Critical("test of layout ... critical ... I'am dead!");
            Critical("my title ... critical ... I'am dead!",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc luctus purus sed justo viverra cursus. Cras tincidunt risus a dui lacinia ",
                "convallis. Etiam tempor velit vitae mi pharetra mollis a vel purus. Aenean sem lorem, pharetra eget mauris eget, porta ornare urna. ",
                "Pellentesque feugiat, tellus sit amet tempus dictum, felis nisi porta enim, at tempus nibh lectus at mauris. Morbi tincidunt, lacus ac ",
                "pellentesque porta, ligula nisl consectetur nunc, eget ultrices dui nunc ut orci. Proin ac quam vitae lacus sollicitudin dictum eget ut justo. ");
        }

        /// <summary>
        /// Writes the log using the wanted <see cref="Writer"/>.
        /// </summary>
        /// <param name="sLogLevel">The <see cref="GDFLogLevel"/> indicating the severity level of the log.</param>
        /// <param name="sLogCategory">The <see cref="GDFLogCategory"/> indicating the category of the log.</param>
        /// <param name="sString">The string message to be logged.</param>
        /// <param name="sObject">The optional object to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        private static void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject)
        {
            if (CanWrite(sLogLevel))
            {
                Writer.WriteLog(sLogLevel, sLogCategory, sString, sObject);
            }
        }

        /// <summary>
        /// Writes a log using the specified log level, log category, title, object, and messages.
        /// </summary>
        /// <param name="sLogLevel">The log level of the log.</param>
        /// <param name="sLogCategory">The log category of the log.</param>
        /// <param name="sTitle">The title of the log.</param>
        /// <param name="sObject">The object associated with the log.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        private static void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, params string[] sMessages)
        {
            if (CanWrite(sLogLevel))
            {
                Writer.WriteLog(sLogLevel, sLogCategory, sTitle, sObject, sMessages);
            }
        }

        /// <summary>
        /// Writes the log using the wanted <see cref="Writer"/>.
        /// </summary>
        /// <param name="sLogLevel">The <see cref="GDFLogLevel"/> indicating the severity level of the log.</param>
        /// <param name="sLogCategory">The <see cref="GDFLogCategory"/> indicating the category of the log.</param>
        /// <param name="sString">The string message to be logged.</param>
        /// <param name="sObject">The optional object to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        private static void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, Func<string> sString, object sObject)
        {
            if (CanWrite(sLogLevel))
            {
                Writer.WriteLog(sLogLevel, sLogCategory, sString.Invoke(), sObject);
            }
        }

        /// <summary>
        /// Writes a log using the specified log level, log category, title, object, and messages.
        /// </summary>
        /// <param name="sLogLevel">The log level of the log.</param>
        /// <param name="sLogCategory">The log category of the log.</param>
        /// <param name="sTitle">The title of the log.</param>
        /// <param name="sObject">The object associated with the log.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        private static void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, Func<string> sTitle, object sObject, params string[] sMessages)
        {
            if (CanWrite(sLogLevel))
            {
                Writer.WriteLog(sLogLevel, sLogCategory, sTitle.Invoke(), sObject, sMessages);
            }
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Trace"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">The object associated with the log message (optional).</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Trace(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Logs detailed trace information, including caller file path, method name, and line number.
        /// </summary>
        /// <param name="message">optional message</param>
        /// <param name="callerFile">The file path of the calling method. Automatically populated by the runtime.</param>
        /// <param name="callerMethod">The name of the calling method. Automatically populated by the runtime.</param>
        /// <param name="callerLine">The line number in the file where the method is called. Automatically populated by the runtime.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TracePrint(string message = "", [CallerFilePath] string callerFile = "", [CallerMemberName] string callerMethod = "", [CallerLineNumber] int callerLine = 0)
        {
            WriteLog(GDFLogLevel.Warning, GDFLogCategory.Attention, $"file {callerFile}, method {callerMethod}, line {callerLine}, message: {message}", "");
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Trace"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">The object associated with the log message (optional).</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Trace(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a trace log message for a todo item.
        /// </summary>
        /// <param name="sMessage">The message describing the todo item.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TraceTodo(string sMessage)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.Todo, sMessage, null);
        }

        /// <summary>
        /// Logs a trace success message.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TraceSuccess(string sMessage)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.Success, sMessage, null);
        }

        /// <summary>
        /// Writes a log message with the specified message for a failed operation or event.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TraceFailed(string sMessage)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.Failed, sMessage, null);
        }

        /// <summary>
        /// Logs an attention message to the GDFLogger with the specified message.
        /// </summary>
        /// <param name="sMessage">The message to log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TraceAttention(string sMessage)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.Attention, sMessage, null);
        }

        /// <summary>
        /// Writes an error log message with a given message to the log file.
        /// </summary>
        /// <param name="sMessage">The error message to write.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void TraceError(string sMessage)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.Error, sMessage, null);
        }

        /// <summary>
        /// Writes a log message with the given title and messages to the log file with the <see cref="GDFLogLevel.Trace"/> level.
        /// The log message will have the <see cref="GDFLogCategory.No"/> category by default.
        /// </summary>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Trace(string sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Writes a log message with the given title and messages to the log file with the <see cref="GDFLogLevel.Trace"/> level.
        /// The log message will have the <see cref="GDFLogCategory.No"/> category by default.
        /// </summary>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Trace(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Trace, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Debug"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">The optional object associated with the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Debug(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Debug, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a debug log with the given title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the debug log.</param>
        /// <param name="sMessages">The messages to be included in the debug log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Debug(string sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Debug, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Debug"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">The optional object associated with the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Debug(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Debug, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a debug log with the given title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the debug log.</param>
        /// <param name="sMessages">The messages to be included in the debug log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Debug(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Debug, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a log with the level 'Information' using the Writer.
        /// </summary>
        /// <param name="sMessage">The log message.</param>
        /// <param name="sObject">Optional object related to the log message.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Information(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Information, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes an information log.
        /// </summary>
        /// <param name="title">The title of the log.</param>
        /// <param name="messages">Additional messages to include in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Information(string title, params string[] messages)
        {
            WriteLog(GDFLogLevel.Information, GDFLogCategory.No, title, null, messages);
        }

        /// <summary>
        /// Sends a log with the level 'Information' using the Writer.
        /// </summary>
        /// <param name="sMessage">The log message.</param>
        /// <param name="sObject">Optional object related to the log message.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Information(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Information, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes an information log.
        /// </summary>
        /// <param name="sTitle">The title of the log.</param>
        /// <param name="sMessages">Additional messages to include in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Information(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Information, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Logs an exception with the given error code and message.
        /// </summary>
        /// <param name="sObject">The exception object to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Exception(Exception sObject)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.Exception, string.Empty, sObject);
        }

        /// <summary>
        /// Logs an exception with the given message.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">The exception object to be logged.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Exception(string sMessage, Exception sObject)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.Exception, sMessage, sObject);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Warning"/> log using the WriteLog method.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">Optional object to be logged alongside the message.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Warning(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Warning, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a warning log with the specified title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the warning log.</param>
        /// <param name="sMessages">An optional list of messages to include in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Warning(string sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Warning, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Warning"/> log using the WriteLog method.
        /// </summary>
        /// <param name="sMessage">The message to be logged.</param>
        /// <param name="sObject">Optional object to be logged alongside the message.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Warning(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Warning, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a warning log with the specified title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the warning log.</param>
        /// <param name="sMessages">An optional list of messages to include in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Warning(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Warning, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends an error log using the GDFLogger.
        /// </summary>
        /// <param name="sException"></param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Error(object sException)
        {
            WriteLog(GDFLogLevel.Error, GDFLogCategory.Exception, string.Empty, sException);
        }


        /// <summary>
        /// Sends an error log using the GDFLogger.
        /// </summary>
        /// <param name="sMessage">The error message to be logged.</param>
        /// <param name="sObject">An optional object associated with the error log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Error(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Error, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Logs an error with the specified title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the error log.</param>
        /// <param name="sMessages">The messages to be included in the error log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Error(string sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Error, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends an error log using the GDFLogger.
        /// </summary>
        /// <param name="sMessage">The error message to be logged.</param>
        /// <param name="sObject">An optional object associated with the error log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Error(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Error, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Logs an error with the specified title and messages.
        /// </summary>
        /// <param name="sTitle">The title of the error log.</param>
        /// <param name="sMessages">The messages to be included in the error log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Error(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Error, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Critical"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to log.</param>
        /// <param name="sObject">The object associated with the log message (optional).</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Critical(string sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a log message with the given <paramref name="sTitle"/> and <paramref name="sMessages"/> as critical level.
        /// </summary>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Critical(string sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Sends a <see cref="GDFLogLevel.Critical"/> log using the <see cref="Writer"/>.
        /// </summary>
        /// <param name="sMessage">The message to log.</param>
        /// <param name="sObject">The object associated with the log message (optional).</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Critical(Func<string> sMessage, object sObject = null)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.No, sMessage, sObject);
        }

        /// <summary>
        /// Writes a log message with the given <paramref name="sTitle"/> and <paramref name="sMessages"/> as critical level.
        /// </summary>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sMessages">The messages to be included in the log.</param>
#if UNITY_EDITOR
        [HideInCallstack]
#endif
        public static void Critical(Func<string> sTitle, params string[] sMessages)
        {
            WriteLog(GDFLogLevel.Critical, GDFLogCategory.No, sTitle, null, sMessages);
        }

        /// <summary>
        /// Returns the current log level used by the <see cref="Writer"/>.
        /// </summary>
        /// <returns>The current log level as a member of the <see cref="GDFLogLevel"/> enum.</returns>
        public static GDFLogLevel LogLevel()
        {
            return Writer?.LogLevel() ?? GDFLogLevel.Information;
        }

        /// <summary>
        /// Sets the log level for the GDFLogger. The log level determines which log messages will be written by the Writer.
        /// </summary>
        /// <param name="sLevel">The log level to set. Must be one of the values defined in the GDFLogLevel enum.</param>
        public static void SetLogLevel(GDFLogLevel sLevel)
        {
            Writer?.SetLogLevel(sLevel);
        }
    }
}