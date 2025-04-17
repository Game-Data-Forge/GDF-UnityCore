using System;



namespace GDFFoundation
{
    /// <summary>
    /// Complex ping to return more information about server
    /// </summary>
    [Serializable]
    public class GDFPingComplex : GDFPing
    {
        /// <summary>
        /// Status of the server as text.
        /// </summary>
        /// <value>
        /// The status of the server represented as text.
        /// </value>
        public string AnswerText { set; get; }

        /// <summary>
        /// A class representing the timestamp property of the GDFPingComplex class.
        /// </summary>
        public long Timestamp { set; get; }

        /// <summary>
        /// Version of the GDFPingComplex class
        /// </summary>
        public string Version { set; get; }

        /// <summary>
        /// Complex ping to return more information about the server.
        /// </summary>
        public GDFPingComplex()
        {
            ServerStatus = GDFServerStatus.Inactive;
            AnswerText = ServerStatus.ToString();
            Timestamp = GDFTimestamp.Timestamp();
            Version = GDFFoundation.GDFVersionDll.VersionDll.Version;
        }

        /// <summary>
        /// Complex ping to return more information about server
        /// </summary>
        public GDFPingComplex(GDFServerStatus sServerStatus)
        {
            ServerStatus = sServerStatus;
            AnswerText = ServerStatus.ToString();
            Timestamp = GDFTimestamp.Timestamp();
            Version = GDFFoundation.GDFVersionDll.VersionDll.Version;
        }
    }
}
