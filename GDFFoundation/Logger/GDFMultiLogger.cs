using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// GDFMultiLogger class implements the IGDFLogger interface and provides a logger that writes log messages to multiple writers.
    /// </summary>
    public class GDFMultiLogger : IGDFLogger
    {
        private readonly object _locker = new object();

        /// <summary>
        /// Gets or sets the writers for the logger.
        /// </summary>
        private List<IGDFLogger> _Writers = new List<IGDFLogger>();

        private GDFLogLevel _Level = GDFLogLevel.None;

        /// <summary>
        /// Represents a multi-logger that can write logs to multiple writers.
        /// </summary>
        public GDFMultiLogger(params IGDFLogger[] sWriters)
        {
            SetLogLevel(GDFLogLevel.Trace);
            if (sWriters != null)
            {
                foreach (IGDFLogger sWriter in sWriters)
                {
                    AddWritter(sWriter);
                }
            }
        }

        /// <summary>
        /// Represents a logger that can write logs to multiple writers.
        /// </summary>
        public GDFMultiLogger(GDFLogLevel sLogLevel, params IGDFLogger[] sWriters)
        {
            SetLogLevel(sLogLevel);
            if (sWriters != null)
            {
                foreach (IGDFLogger tWriter in sWriters)
                {
                    AddWritter(tWriter);
                }
            }
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
        /// <returns><c>true</c> if the debugger is active; otherwise, <c>false</c>.</returns>
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
        /// Writes a log message to the registered log writers.
        /// </summary>
        /// <param name="sLogLevel">The level of the log message.</param>
        /// <param name="sLogCategory">The category of the log message.</param>
        /// <param name="sString">The log message string.</param>
        /// <param name="sObject">An optional object to include in the log message.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject)
        {
            foreach (IGDFLogger tWriter in _Writers)
            {
                if (GDFLogger.CanWrite(tWriter, sLogLevel))
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sString, sObject);
                }
            }
        }

        /// <summary>
        /// Writes log messages to multiple loggers based on the specified log level, log category, title, object, and messages.
        /// </summary>
        /// <param name="sLogLevel">The log level of the log message.</param>
        /// <param name="sLogCategory">The log category of the log message.</param>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sObject">The object associated with the log message.</param>
        /// <param name="sMessages">An array of log messages.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, string[] sMessages)
        {
            foreach (IGDFLogger tWriter in _Writers)
            {
                if (GDFLogger.CanWrite(tWriter, sLogLevel))
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sTitle, sObject, sMessages);
                }
            }
        }

        /// <summary>
        /// Add a writer to the multi-logger.
        /// </summary>
        /// <param name="sWriter">The writer to add.</param>
        /// <returns>Returns true if the writer was added successfully; otherwise, false.</returns>
        public bool AddWritter(IGDFLogger sWriter)
        {
            bool rReturn = false;
            if (sWriter != null && !_Writers.Contains(sWriter))
            {
                _Writers.Add(sWriter);
                rReturn = true;
            }

            return rReturn;
        }

        /// <summary>
        /// Removes the specified writer from the list of writers in the GDFMultiLogger.
        /// </summary>
        /// <param name="tWriter">The writer to remove.</param>
        /// <returns>True if the writer was successfully removed; otherwise, false.</returns>
        public bool RemoveWritter(IGDFLogger tWriter)
        {
            return _Writers.Remove(tWriter);
        }
    }
}