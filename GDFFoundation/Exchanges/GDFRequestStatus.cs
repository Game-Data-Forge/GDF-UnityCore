#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRequestStatus.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents the status of a request in the GDFFoundation.
    /// </summary>
    [Serializable]
    public enum GDFRequestStatus
    {
        /// <summary>
        ///     Answer Error.
        ///     Represents an error status of a network request.
        /// </summary>
        Error = -9,

        /// <summary>
        ///     Represents the status of an GDF request when the server is disabled.
        /// </summary>
        ServerIsDisabled = -3,

        /// <summary>
        ///     Represents the request status when the server needs to be changed.
        /// </summary>
        PleaseChangeServer = -2,

        /// <summary>
        ///     Represents a status of a request in GDFFoundation.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Represents the OK status of an GDFRequest.
        /// </summary>
        Ok = 1,

        /// <summary>
        ///     Enum member of GDFRequestStatus indicating that the version is invalid.
        /// </summary>
        VersionInvalid = 98,

        /// <summary>
        ///     Represents the status of a project publishing in the GDFRequestStatus enum.
        /// </summary>
        ProjectIsPublishing = 99,


        /// <summary>
        ///     Represents the request status when there is no network connection available.
        /// </summary>
        NoNetwork = 700,


        // move that in Specific Error when status is Error ?

        //
        // AccountUnknown = 89,
        //
        // AccountError = 90,
        //
        // AccountNotUnique = 91,
        //
        // AccountBan = 12,
        //
        // AccountTrashed = 13,
        //
        // DaoError = 800,
        //
        // TokenError = 900,
        //
        // HashInvalid = 901,
        //
        // TokenNull = 902,
        //
        // TokenEmpty = 903,
    }
}