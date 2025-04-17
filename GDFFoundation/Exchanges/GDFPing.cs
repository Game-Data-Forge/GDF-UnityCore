

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Provides a class for pinging a server and retrieving its status.
    /// </summary>
    [Serializable]
    public class GDFPing
    {
        /// <summary>
        /// Status of server
        /// </summary>
        public GDFServerStatus ServerStatus { set; get; }

        /// <summary>
        /// Represents a ping to return the status of a server.
        /// </summary>
        public GDFPing()
        {
        }

        /// <summary>
        /// Ping to return status of server
        /// </summary>
        public GDFPing(GDFServerStatus sServerStatus)
        {
            ServerStatus = sServerStatus;
        }
    }
}
