using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an advanced console logger that implements the IGDFLogger interface.
    /// </summary>
    public class GDFAdvancedConsoleLogger : IGDFLogger
    {
        private readonly object _locker = new object();

        /// <summary>
        /// Represents the logging level for the GDFAdvancedConsoleLogger class.
        /// </summary>
        private GDFLogLevel _Level = GDFLogLevel.None;

        /// <summary>
        /// The indentation string used for formatting log messages.
        /// </summary>
        private const string _INDENT = " ";

        /// <summary>
        /// The _PADDING variable is used to represent a string of spaces that is used for indentation or spacing.
        /// </summary>
        private const string _PADDING = "  ";

        /// <summary>
        /// Represents a constant string used as the left border in the GDFAdvancedConsoleLogger class.
        /// </summary>
        private const string _BORDER_LEFT = " ";

        /// <summary>
        /// Represents the separator used in the GDFAdvancedConsoleLogger class.
        /// </summary>
        private const string _SEPARATOR = "--------------------------------------------------------------------------------------------------------------------------------";

        /// <summary>
        /// Represents an advanced console logger for GDFFoundation.
        /// </summary>
        public GDFAdvancedConsoleLogger()
        {
            _Level = GDFLogLevel.Trace;
        }

        /// <summary>
        /// A class that provides advanced console logging functionality.
        /// </summary>
        public GDFAdvancedConsoleLogger(GDFLogLevel sLogLevel)
        {
            _Level = sLogLevel;
        }

        /// <summary>
        /// Sets the log level to be displayed by the logger.
        /// </summary>
        /// <param name="sLogLevel">The log level to be set.</param>
        public void SetLogLevel(GDFLogLevel sLogLevel)
        {
            _Level = sLogLevel;
        }

        /// <summary>
        /// Loads the log level for the logger.
        /// </summary>
        public void LoadLogLevel()
        {
        }

        /// <summary>
        /// Gets the default log level to be displayed by the logger.
        /// </summary>
        /// <returns>The default log level.</returns>
        public GDFLogLevel DefaultLogLevel()
        {
            return GDFLogLevel.Information;
        }

        /// <summary>
        /// Determines if the debugger is active or not.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the debugger is active; otherwise, <c>false</c>.
        /// </returns>
        public bool IsActivated()
        {
            return true;
        }

        /// <summary>
        /// Retrieves the log level to be displayed by the logger.
        /// </summary>
        /// <returns>The log level to be displayed.</returns>
        public GDFLogLevel LogLevel()
        {
            return _Level;
        }

        /// <summary>
        /// Writes the category of a log message to the console.
        /// </summary>
        /// <param name="sLogCategory">The log category to write.</param>
        private void WriteCategory(GDFLogCategory sLogCategory)
        {
            //lock (_locker)
            {
                Console.ResetColor();
                switch (sLogCategory)
                {
                    case GDFLogCategory.No:
                        break;
                    case GDFLogCategory.Todo:
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("    TODO    ");
                        break;
                    case GDFLogCategory.Success:
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   SUCCESS   ");
                        break;
                    case GDFLogCategory.Error:
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   ERROR    ");
                        break;
                    case GDFLogCategory.Attention:
                        Console.Write(" ");
                        // Console.Write(" ⚠️ ");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  WARNING   ");
                        break;
                    case GDFLogCategory.Exception:
                        Console.Write(" ");
                        // Console.Write(" 💀 ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" EXCEPTION  ");
                        break;
                    case GDFLogCategory.Failed:
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("   FAILED   ");
                        break;
                }

                Console.ResetColor();
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Writes an icon representing the log level to the console.
        /// </summary>
        /// <param name="sLogLevel">The log level.</param>
        /// <param name="sAdd">Additional information to be displayed.</param>
        private void WriteIcon(GDFLogLevel sLogLevel, string sAdd = "")
        {
            //lock (_locker)
            {
                Console.ResetColor();
                switch (sLogLevel)
                {
                    case GDFLogLevel.Trace:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" 🤖   trace" + sAdd + " ");
                        break;
                    case GDFLogLevel.Debug:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" 🤔   debug" + sAdd + " ");
                        break;
                    case GDFLogLevel.Information:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" 🧐    info" + sAdd + " ");
                        break;
                    case GDFLogLevel.Warning:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" 😰 warning" + sAdd + " ");
                        break;
                    case GDFLogLevel.Error:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" 🤬   error" + sAdd + " ");
                        break;
                    case GDFLogLevel.Critical:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" 💀critical" + sAdd + " ");
                        break;
                    case GDFLogLevel.None:
                        break;
                }

                Console.ResetColor();
            }
        }

        /// <summary>
        /// Writes the given object to the console based on the provided log level.
        /// </summary>
        /// <param name="sObject">The object to write to the console.</param>
        private void WriteObject(object sObject)
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

        /// <summary>
        /// Writes a log message with the specified log level, log category, string message, and optional object.
        /// </summary>
        /// <param name="sLogLevel">The log level of the message.</param>
        /// <param name="sLogCategory">The log category of the message.</param>
        /// <param name="sString">The string message to write.</param>
        /// <param name="sObject">An optional object to include in the log message.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject)
        {
            lock (_locker)
            {
                WriteIcon(sLogLevel, ":");
                WriteCategory(sLogCategory);
                Console.ResetColor();
                switch (sLogLevel)
                {
                    case GDFLogLevel.Trace:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(sString);
                        WriteObject(sObject);
                        break;
                    case GDFLogLevel.Debug:
                        // GDFLogger.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(sString);
                        WriteObject(sObject);
                        break;
                    case GDFLogLevel.Information:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(sString);
                        WriteObject(sObject);
                        Console.ResetColor();
                        break;
                    case GDFLogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(sString);
                        WriteObject(sObject);
                        break;
                    case GDFLogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(sString);
                        WriteObject(sObject);
                        break;
                    case GDFLogLevel.Critical:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
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

        /// <summary>
        /// Writes log messages to the console.
        /// </summary>
        /// <param name="sLogLevel">The log level of the message.</param>
        /// <param name="sLogCategory">The category of the log message.</param>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sObject">The object associated with the log message.</param>
        /// <param name="sMessages">The array of messages to be logged.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, string[] sMessages)
        {
            lock (_locker)
            {
                WriteIcon(sLogLevel, ">");
                WriteCategory(sLogCategory);
                Console.ResetColor();
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
                        foreach (string tStr in sMessages)
                        {
                            Console.Write(_PADDING);
                            Console.BackgroundColor = tBack;
                            Console.ForegroundColor = tFore;
                            Console.Write(_BORDER_LEFT);
                            Console.ResetColor();
                            Console.WriteLine(_INDENT + tStr);
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
    }
}