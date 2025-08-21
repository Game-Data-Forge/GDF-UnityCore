#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFConsoleLogger.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Console logger for GDFFoundation.
    /// </summary>
    public class GDFConsoleLogger : IGDFLogger
    {
        #region Constants

        /// <summary>
        ///     Represents the left border character used for formatting in the GDFConsoleLogger class.
        /// </summary>
        private const string _BORDER_LEFT = " ";

        /// <summary>
        ///     Represents the indentation used for logging.
        /// </summary>
        private const string _INDENT = " ";

        /// <summary>
        ///     Represents the padding used for indenting text in the <see cref="GDFConsoleLogger" /> class.
        /// </summary>
        private const string _PADDING = "  ";

        /// <summary>
        ///     Represents the separator used in the <see cref="GDFConsoleLogger" /> class.
        /// </summary>
        private const string _SEPARATOR = "--------------------------------------------------------------------------------------------------------------------------------";

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents the log level for logging messages.
        /// </summary>
        private GDFLogLevel _Level = GDFLogLevel.None;

        private readonly object _locker = new object();

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a console logger for the GDFFoundation.
        /// </summary>
        public GDFConsoleLogger()
        {
            _Level = GDFLogLevel.Trace;
        }

        public GDFConsoleLogger(GDFLogLevel sLogLevel)
        {
            _Level = sLogLevel;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Loads the log level for the logger.
        /// </summary>
        public void LoadLogLevel()
        {
        }

        /// <summary>
        ///     Writes the category of the log to the console.
        /// </summary>
        /// <param name="sLogCategory">The log category.</param>
        private void WriteCategory(GDFLogCategory sLogCategory)
        {
            //lock (_locker)
            {
                switch (sLogCategory)
                {
                    case GDFLogCategory.No:
                    break;
                    case GDFLogCategory.Todo:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("TODO ");
                    break;
                    case GDFLogCategory.Success:

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("SUCCESS ");
                    break;
                    case GDFLogCategory.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ERROR ");
                    break;
                    case GDFLogCategory.Attention:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("WARNING ");
                    break;
                    case GDFLogCategory.Exception:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("EXCEPTION ");
                    break;
                    case GDFLogCategory.Failed:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("FAILED ");
                    break;
                }
            }
        }

        /// <summary>
        ///     Writes an icon according to the specified log level with additional information.
        /// </summary>
        /// <param name="sLogLevel">The log level to determine the icon and color.</param>
        /// <param name="sAdd">Additional information to display.</param>
        private void WriteIcon(GDFLogLevel sLogLevel, string sAdd = "")
        {
            //lock (_locker)
            {
                switch (sLogLevel)
                {
                    case GDFLogLevel.Trace:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("TRACE " + sAdd + " ");
                    break;
                    case GDFLogLevel.Debug:
                        // Console.BackgroundColor = ConsoleColor.Black;
                        // Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("DEBUG " + sAdd + " ");
                    break;
                    case GDFLogLevel.Information:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        // Console.BackgroundColor = ConsoleColor.Blue;
                        // Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("INFORMATION " + sAdd + " ");
                    break;
                    case GDFLogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        // Console.BackgroundColor = ConsoleColor.Yellow;
                        // Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("WARNING " + sAdd + " ");
                    break;
                    case GDFLogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        // Console.BackgroundColor = ConsoleColor.Red;
                        // Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("ERROR " + sAdd + " ");
                    break;
                    case GDFLogLevel.Critical:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        // Console.BackgroundColor = ConsoleColor.DarkRed;
                        // Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("CRITICAL " + sAdd + " ");
                    break;
                    case GDFLogLevel.None:
                    break;
                }
                //Console.ResetColor();
            }
        }

        /// <summary>
        ///     Writes the given object to the console.
        /// </summary>
        /// <param name="sObject">The object to be written.</param>
        public void WriteObject(object sObject)
        {
            if (sObject != null)
            {
                Exception tException = sObject as Exception;
                if (tException != null)
                {
                    //lock (_locker)
                    {
                        Console.Write(_PADDING);
                        Console.WriteLine(tException.ToString());
                    }
                }
            }
        }

        #region From interface IGDFLogger

        /// <summary>
        ///     Gets the default log level to be displayed by the logger.
        /// </summary>
        /// <returns>The default log level.</returns>
        public GDFLogLevel DefaultLogLevel()
        {
            return GDFLogLevel.Information;
        }

        /// <summary>
        ///     Determines if the debugger is active or not.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the debugger is active; otherwise, <c>false</c>.
        /// </returns>
        public bool IsActivated()
        {
            return true;
        }

        /// <summary>
        ///     Retrieves the log level to be displayed by the logger.
        /// </summary>
        /// <returns>The log level to be displayed.</returns>
        public GDFLogLevel LogLevel()
        {
            return _Level;
        }

        /// <summary>
        ///     Sets the log level to be displayed by the logger.
        /// </summary>
        /// <param name="sLogLevel">The log level to be set.</param>
        public void SetLogLevel(GDFLogLevel sLogLevel)
        {
            _Level = sLogLevel;
        }

        /// <summary>
        ///     Writes a log message with the specified log level, log category, string, and optional object.
        /// </summary>
        /// <param name="sLogLevel">The log level of the message.</param>
        /// <param name="sLogCategory">The log category of the message.</param>
        /// <param name="sString">The log message string.</param>
        /// <param name="sObject">The optional object to include in the log message.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject)
        {
            lock (_locker)
            {
                if (sLogCategory == GDFLogCategory.Exception)
                {
                    sLogLevel = GDFLogLevel.Warning;
                    if (string.IsNullOrEmpty(sString))
                    {
                        sString = "Exception!";
                    }
                    else
                    {
                        WriteLog(sLogLevel, sLogCategory, "Exception!", sObject, new string[] { sString });
                    }
                }
                else
                {
                    Console.ResetColor();
                    WriteIcon(sLogLevel, ":");
                    WriteCategory(sLogCategory);
                    switch (sLogLevel)
                    {
                        case GDFLogLevel.Trace:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                        break;
                        case GDFLogLevel.Debug:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                        break;
                        case GDFLogLevel.Information:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                            Console.ResetColor();
                        break;
                        case GDFLogLevel.Warning:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                        break;
                        case GDFLogLevel.Error:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                        break;
                        case GDFLogLevel.Critical:
                            Console.WriteLine(sString);
                            WriteObject(sObject);
                        break;
                        case GDFLogLevel.None:
                        break;
                    }

                    Console.ResetColor();
                    Console.Write(string.Empty);
                }
            }
        }

        /// <summary>
        ///     Writes log messages to the console.
        /// </summary>
        /// <param name="sLogLevel">The logging level of the message.</param>
        /// <param name="sLogCategory">The category of the log message.</param>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sObject">The object related to the log message (optional).</param>
        /// <param name="messages">The log messages to be written.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, string[] messages)
        {
            lock (_locker)
            {
                Console.ResetColor();
                WriteIcon(sLogLevel, ">");
                WriteCategory(sLogCategory);
                string tTitle = sTitle;
                if (tTitle.Length < _SEPARATOR.Length - 2)
                {
                    string tSeparator = _SEPARATOR.Substring(0, _SEPARATOR.Length - ((int)sTitle.Length + 2));
                    tTitle = tSeparator.Substring(0, (int)(tSeparator.Length / 2)) + " " + sTitle + " ";
                    tTitle = tTitle + _SEPARATOR.Substring(0, _SEPARATOR.Length - tTitle.Length);
                }

                ConsoleColor tBack = ConsoleColor.Black;
                ConsoleColor tFore = ConsoleColor.Gray;
                switch (sLogLevel)
                {
                    case GDFLogLevel.Trace:
                        tBack = ConsoleColor.Black;
                        tFore = ConsoleColor.Gray;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;

                    case GDFLogLevel.Debug:
                        tBack = ConsoleColor.Black;
                        tFore = ConsoleColor.Gray;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;
                    case GDFLogLevel.Information:
                        tBack = ConsoleColor.Blue;
                        tFore = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;
                    case GDFLogLevel.Warning:
                        tBack = ConsoleColor.Yellow;
                        tFore = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;
                    case GDFLogLevel.Error:
                        tBack = ConsoleColor.Red;
                        tFore = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;
                    case GDFLogLevel.Critical:
                        tBack = ConsoleColor.DarkRed;
                        tFore = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(tTitle);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.Write(string.Empty);
                        if (messages != null)
                        {
                            foreach (string tStr in messages)
                            {
                                Console.Write(_PADDING);
                                Console.BackgroundColor = tBack;
                                Console.ForegroundColor = tFore;
                                Console.Write(_BORDER_LEFT);
                                Console.ResetColor();
                                Console.WriteLine(_INDENT + tStr);
                            }
                        }

                        WriteObject(sObject);
                        Console.Write(_PADDING);
                        Console.BackgroundColor = tBack;
                        Console.ForegroundColor = tFore;
                        Console.Write(_SEPARATOR);
                        Console.ResetColor();
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                    break;
                    case GDFLogLevel.None:
                    break;
                }

                Console.ResetColor();
                Console.Write(string.Empty);
            }
        }

        #endregion

        #endregion
    }
}