#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFPing.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides a class for pinging a server and retrieving its status.
    /// </summary>
    [Serializable]
    public class GDFPing
    {
        #region Instance fields and properties

        /// <summary>
        ///     Status of server
        /// </summary>
        public GDFServerStatus ServerStatus { set; get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a ping to return the status of a server.
        /// </summary>
        public GDFPing()
        {
        }

        /// <summary>
        ///     Ping to return status of server
        /// </summary>
        public GDFPing(GDFServerStatus sServerStatus)
        {
            ServerStatus = sServerStatus;
        }

        #endregion
    }
}