using System;
using System.Diagnostics;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a basic response object for network communication.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicResponse : GDFBasicExchange
    {
        /// <summary>
        /// Represents the status of a request.
        /// </summary>
        public GDFRequestStatus Status { set; get; } = GDFRequestStatus.None;

        /// <summary>
        /// Represents the specific error associated with a request.
        /// </summary>
        public GDFSpecificErrorKind SpecificError { set; get; } = GDFSpecificErrorKind.NoError;

        /// <summary>
        /// Represents the server identity.
        /// </summary>
        public string ServerIdentity { set; get; } = string.Empty;

        /// <summary>
        /// Represents the debug information for network communication.
        /// </summary>
        protected string Debug { set; get; } = string.Empty;

        /// <summary>
        /// Add a debug message to the Debug property of the GDFBasicResponse object.
        /// </summary>
        /// <param name="sText">The debug message to be added.</param>
        [Conditional("DEBUG")]
        public void AddDebug(string sText)
        {
            Debug = Debug + sText + "\r\n";
        }

        /// <summary>
        /// Gets the debug information.
        /// </summary>
        /// <returns>The debug information.</returns>
        public string GetDebug()
        {
            return Debug;
        }
    }
}


