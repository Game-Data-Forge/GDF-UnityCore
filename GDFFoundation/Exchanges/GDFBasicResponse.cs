#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFBasicResponse.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Diagnostics;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a basic response object for network communication.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicResponse : GDFBasicExchange
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the debug information for network communication.
        /// </summary>
        protected string Debug { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the server identity.
        /// </summary>
        public string ServerIdentity { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the specific error associated with a request.
        /// </summary>
        public GDFSpecificErrorKind SpecificError { set; get; } = GDFSpecificErrorKind.NoError;

        /// <summary>
        ///     Represents the status of a request.
        /// </summary>
        public GDFRequestStatus Status { set; get; } = GDFRequestStatus.None;

        #endregion

        #region Instance methods

        /// <summary>
        ///     Add a debug message to the Debug property of the GDFBasicResponse object.
        /// </summary>
        /// <param name="sText">The debug message to be added.</param>
        [Conditional("DEBUG")]
        public void AddDebug(string sText)
        {
            Debug = Debug + sText + "\r\n";
        }

        /// <summary>
        ///     Gets the debug information.
        /// </summary>
        /// <returns>The debug information.</returns>
        public string GetDebug()
        {
            return Debug;
        }

        #endregion
    }
}