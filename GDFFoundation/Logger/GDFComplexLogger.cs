

using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// GDFComplexLogger class is an implementation of the IGDFLogger interface for logging purposes.
    /// It allows you to set the log level and write logs to multiple log writers.
    /// </summary>
    public class GDFComplexLogger : IGDFLogger
    {
        private readonly object _locker = new object();
        
        /// <summary>
        /// Represents a complex logger that implements the <see cref="IGDFLogger"/> interface.
        /// </summary>
        private List<IGDFLogger> _DefaultWriters = new List<IGDFLogger>();

        /// *Note**: The above information is based on the given code documentation. Any changes or additions to the code implementation may affect the functionality and behavior of the variable `_SpecificWriters`.
        private Dictionary<GDFLogLevel, List<IGDFLogger>> _SpecificWriters = new Dictionary<GDFLogLevel, List<IGDFLogger>>();

        /// <summary>
        /// Represents the logging level.
        /// </summary>
        private GDFLogLevel _Level = GDFLogLevel.None;

        /// <summary>
        /// Represents a complex logger that implements the <see cref="IGDFLogger"/> interface.
        /// </summary>
        public GDFComplexLogger(params IGDFLogger[] sWriters)
        {
            SetLogLevel(GDFLogLevel.Trace);
            if (sWriters != null)
            {
                foreach (IGDFLogger tWriter in sWriters)
                {
                    AddDefaultWriter(tWriter);
                }
            }
        }

        public GDFComplexLogger(GDFLogLevel sLogLevel, params IGDFLogger[] sWriters)
        {
            SetLogLevel(sLogLevel);
            if (sWriters != null)
            {
                foreach (IGDFLogger tWriter in sWriters)
                {
                    AddDefaultWriter(tWriter);
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
        /// Determines if the logger is activated or not.
        /// </summary>
        /// <returns>Returns true if the logger is activated; otherwise, false.</returns>
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
        /// Writes a log message with the specified log level, log category, string message, and optional data object.
        /// <param name="sLogLevel">The log level of the message.</param>
        /// <param name="sLogCategory">The log category of the message.</param>
        /// <param name="sString">The string message to be logged.</param>
        /// <param name="sObject">The optional data object to be logged.</param>
        /// </summary>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sString, object sObject)
        {
            foreach (IGDFLogger tWriter in _DefaultWriters)
            {
                if (GDFLogger.CanWrite(tWriter, sLogLevel))
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sString, sObject);
                }
            }

            if (_SpecificWriters.TryGetValue(sLogLevel, out List<IGDFLogger> tWriters))
            {
                foreach (IGDFLogger tWriter in tWriters)
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sString, sObject);
                }
            }
        }

        /// <summary>
        /// Writes a log message to the default writers and specific writers based on the log level.
        /// </summary>
        /// <param name="sLogLevel">The log level of the message.</param>
        /// <param name="sLogCategory">The category of the log message.</param>
        /// <param name="sTitle">The title of the log message.</param>
        /// <param name="sObject">The object associated with the log message.</param>
        /// <param name="sMessages">An array of additional messages to include in the log message.</param>
        public void WriteLog(GDFLogLevel sLogLevel, GDFLogCategory sLogCategory, string sTitle, object sObject, string[] sMessages)
        {
            foreach (IGDFLogger tWriter in _DefaultWriters)
            {
                if (GDFLogger.CanWrite(tWriter, sLogLevel))
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sTitle, sObject, sMessages);
                }
            }

            if (_SpecificWriters.TryGetValue(sLogLevel, out List<IGDFLogger> tWriters))
            {
                foreach (IGDFLogger tWriter in tWriters)
                {
                    tWriter.WriteLog(sLogLevel, sLogCategory, sTitle, sObject, sMessages);
                }
            }
        }

        /// <summary>
        /// Adds a default writer to the GDFComplexLogger.
        /// </summary>
        /// <param name="sWriter">The IGDFLogger instance to add as the default writer.</param>
        /// <returns>True if the writer is successfully added as the default writer, otherwise false.</returns>
        public bool AddDefaultWriter(IGDFLogger sWriter)
        {
            bool rReturn = false;
            if (sWriter != null && !_DefaultWriters.Contains(sWriter))
            {
                _DefaultWriters.Add(sWriter);
                rReturn = true;
            }
            return rReturn;
        }

        /// <summary>
        /// Removes a default writer from the list of default writers in the GDFComplexLogger instance.
        /// </summary>
        /// <param name="sWriter">The writer to be removed.</param>
        /// <returns>Returns true if the writer is successfully removed; otherwise, false.</returns>
        public bool RemoveDefaultWriter(IGDFLogger sWriter)
        {
            return _DefaultWriters.Remove(sWriter);
        }

        /// <summary>
        /// Adds a specific writer to the GDFComplexLogger instance for the given log levels.
        /// </summary>
        /// <param name="sWriter">The IGDFLogger instance to add as a specific writer.</param>
        /// <param name="sLogLevels">The log levels for which the specific writer should be added.</param>
        /// <returns>True if the specific writer was successfully added, false otherwise.</returns>
        public bool AddSpecificWriter(IGDFLogger sWriter, GDFLogLevel sLogLevels)
        {
            bool rReturn = false;
            if (sWriter != null)
            {
                if (sLogLevels.HasFlag(GDFLogLevel.Trace))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Trace);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Debug))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Debug);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Information))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Information);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Warning))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Warning);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Error))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Error);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Critical))
                {
                    rReturn |= AddSpecificWriterToDictionary(sWriter, GDFLogLevel.Critical);
                }
            }

            return rReturn;
        }

        /// <summary>
        /// Adds a specific writer to the dictionary of specific writers based on the specified log level.
        /// </summary>
        /// <param name="sWriter">The writer to add.</param>
        /// <param name="sLogLevel">The log level(s) for which the writer should be added.</param>
        /// <returns>True if the writer was added successfully, false otherwise.</returns>
        private bool AddSpecificWriterToDictionary(IGDFLogger sWriter, GDFLogLevel sLogLevel)
        {
            bool rReturn = false;
            if (sWriter != null)
            {
                if (!_SpecificWriters.ContainsKey(sLogLevel))
                {
                    _SpecificWriters.Add(sLogLevel, new List<IGDFLogger>());
                }

                if (!_SpecificWriters[sLogLevel].Contains(sWriter))
                {
                    _SpecificWriters[sLogLevel].Add(sWriter);
                    rReturn = true;
                }
            }

            return rReturn;
        }

        /// <summary>
        /// Removes the specified writer from all specific log levels.
        /// </summary>
        /// <param name="sWriter">The writer to remove.</param>
        /// <returns>True if the writer was removed from any log level, otherwise false.</returns>
        public bool RemoveSpecificWriter(IGDFLogger sWriter)
        {
            bool rReturn = false;
            if (sWriter != null)
            {
                foreach (KeyValuePair<GDFLogLevel, List<IGDFLogger>> tWriters in _SpecificWriters)
                {
                    rReturn |= tWriters.Value.Remove(sWriter);
                }
            }

            return rReturn;
        }

        /// <summary>
        /// Removes a specific writer from the GDFComplexLogger.
        /// </summary>
        /// <param name="sWriter">The specific writer to remove.</param>
        /// <param name="sLogLevels">The log levels for which the writer should be removed. Can be a combination of multiple log levels.</param>
        /// <returns>Returns true if the writer was successfully removed, false otherwise.</returns>
        public bool RemoveSpecificWriter(IGDFLogger sWriter, GDFLogLevel sLogLevels)
        {
            bool rReturn = false;
            if (sWriter != null)
            {
                if (sLogLevels.HasFlag(GDFLogLevel.Trace))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Trace);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Debug))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Debug);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Information))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Information);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Warning))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Warning);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Error))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Error);
                }
                if (sLogLevels.HasFlag(GDFLogLevel.Critical))
                {
                    rReturn |= RemoveSpecificWriterFromDictionary(sWriter, GDFLogLevel.Critical);
                }
            }

            return rReturn;
        }

        /// <summary>
        /// Removes a specific writer from the dictionary of writers based on the specified log level.
        /// </summary>
        /// <param name="sWriter">The IGDFLogger instance to remove from the dictionary of writers.</param>
        /// <param name="sLogLevel">The log level(s) associated with the writer to be removed.</param>
        /// <returns>True if the writer was successfully removed, false otherwise.</returns>
        private bool RemoveSpecificWriterFromDictionary(IGDFLogger sWriter, GDFLogLevel sLogLevel)
        {
            bool rReturn = false;
            if (sWriter != null)
            {
                if (_SpecificWriters.ContainsKey(sLogLevel))
                {
                    rReturn = _SpecificWriters[sLogLevel].Remove(sWriter);
                }
            }

            return rReturn;
        }
    }
}

