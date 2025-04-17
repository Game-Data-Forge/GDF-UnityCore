


namespace GDFFoundation
{
    /// <summary>
    /// Enum representing specific GDFError kinds.
    /// </summary>
    public enum GDFSpecificErrorKind
    {
        /// <summary>
        /// Represents an error in the GDFSpecificErrorKind enum.
        /// </summary>
        Error = -9,

        /// <summary>
        /// Represents the absence of an error in the GDFFoundation.GDFSpecificErrorKind enumeration.
        /// </summary>
        NoError, // rename OK ? 

        /// <summary>
        /// Represents the specific error kind when the version is invalid.
        /// </summary>
        VersionInvalid, // force update 

        /// <summary>
        /// Unknown exchange runtime error kind.
        /// </summary>
        ExchangeRuntimeKindUnknown,

        /// <summary>
        /// Represents an invalid request error.
        /// </summary>
        RequestNotValid,

        /// <summary>
        /// Represents a specific error kind that indicates that the server is disabled.
        /// </summary>
        ServerIsDisabled,

        /// <summary>
        /// Represents an error related to the specific token.
        /// </summary>
        ErrorToken,

        /// <summary>
        /// Enum member representing the error kind of "Transferred".
        /// </summary>
        Transferred,

        /// <summary>
        /// Represents a specific kind of error related to getting relationship.
        /// </summary>
        GetRelationship,

        /// <summary>
        /// Represents the enumeration member CreateRelationship.
        /// </summary>
        CreateRelationship,

        /// <summary>
        /// Represents the relationship between two links.
        /// </summary>
        LinkRelationship,

        /// <summary>
        /// Represents the enum member FinalizeRelationship of the GDFSpecificErrorKind enumeration.
        /// </summary>
        FinalizeRelationship,

        /// <summary>
        /// Enum member representing the action of updating a relationship.
        /// </summary>
        UpdateRelationship,

        /// <summary>
        /// Represents a test specific error kind in GDFSpecificErrorKind enum.
        /// </summary>
        Test,

        /// <summary>
        /// Represents a specific error kind for a network request.
        /// </summary>
        None,

        /// <summary>
        /// SignOut represents the specific error kind for signing out of an application or system.
        /// </summary>
        SignOut,

        /// <summary>
        /// Represents the Sign-in member of the GDFSpecificErrorKind enumeration.
        /// </summary>
        SignIn,

        /// <summary>
        /// Represents a specific error kind for sign up operations.
        /// </summary>
        SignUp,
        
        /// <summary>
        /// Represents a specific error kind when a sign is lost.
        /// </summary>
        SignLost,

        /// <summary>
        /// SignRescue. Represents a specific error kind
        /// </summary>
        SignRescue,

        /// <summary>
        /// Enum member representing the action of adding a sign.
        /// </summary>
        SignAdd,

        /// <summary>
        /// Represents the signing of a modification.
        /// </summary>
        SignModify,

        /// <summary>
        /// Enum member representing a sign of all signs.
        /// </summary>
        SignAllSign,

        /// <summary>
        /// Member representing the deletion of a sign.
        /// </summary>
        SignDelete,

        /// <summary>
        /// Represents the sign out process specific error kind.
        /// </summary>
        ProcessSignOut,

        /// <summary>
        /// Represents a specific error kind related to player token being empty.
        /// </summary>
        PlayerTokenEmpty,

        /// <summary>
        /// Represents the specific error kind AccountDelete in GDFFoundation.
        /// </summary>
        AccountDelete,

        /// <summary>
        /// Enum member representing the range of account changes.
        /// </summary>
        AccountChangeRange,

        /// <summary>
        /// The specific error kind for all player data.
        /// </summary>
        AllPlayerData,

        /// <summary>
        /// Enum representing specific error kinds related to player data retrieval by references.
        /// </summary>
        PlayerDataByReferences,

        /// <summary>
        /// Enum member representing an error that occurs when retrieving player data based on a bundle.
        /// </summary>
        PlayerDataByBundle,

        /// <summary>
        /// Represents the specific error kind when synchronizing data by increment.
        /// </summary>
        SyncDataByIncrement,

        /// <summary>
        /// Represents an error indicating that all data should be returned.
        /// </summary>
        AllData,

        /// <summary>
        /// Represents a specific error kind related to AllStudioData.
        /// </summary>
        AllStudioData,

        /// <remarks>
        /// Represents a specific kind of error that can occur during a studio data operation.
        /// </remarks>
        StudioDataByReferences,

        /// <summary>
        /// Studio specific data by bundle.
        /// </summary>
        StudioDataByBundle,

        /// <summary>
        /// Enum member representing an empty token.
        /// </summary>
        TokenEmpty,

        /// <summary>
        /// Represents a specific error kind that can occur in the GDFFoundation framework when using the Data Access Object (DAO).
        /// </summary>
        DaoError,

        /// <summary>
        /// Represents specific account errors that can occur in the GDFSpecificErrorKind enumeration.
        /// </summary>
        AccountError,

        /// <summary>
        /// Enum member for account sign error in GDFSpecificErrorKind enum.
        /// </summary>
        AccountSignError,

        /// <summary>
        /// Represents an unknown error related to an account.
        /// </summary>
        AccountUnknown,

        /// <summary>
        /// This enum member represents that the upload is empty. It is used as a specific error kind in the GDFBasicResponse class.
        /// </summary>
        UploadEmpty,

        /// <summary>
        /// The account has been trashed.
        /// </summary>
        AccountTrashed,

        /// <summary>
        /// Enum member representing a specific error kind related to account banning.
        /// </summary>
        AccountBan,

        /// <summary>
        /// AccountInconsistance is a member of the GDFSpecificErrorKind enum.
        /// It represents an error that occurs when there is an inconsistency in the account.
        /// </summary>
        AccountInconsistance,

        /// <summary>
        /// Represents an error indicating that the account is not unique.
        /// </summary>
        AccountNotUnique,

        /// <summary>
        /// Represents the specific error kind for SignDeleteLastSignImpossible.
        /// </summary>
        SignDeleteLastSignImpossible,

        /// <summary>
        /// Error that occurs when attempting to delete a sign.
        /// </summary>
        SignDeleteError,

        /// <summary>
        /// The sign is not valid.
        /// </summary>
        SignNotValid,

        /// <summary>
        /// Represents a specific error kind of a publishing process in the GDFFoundation.
        /// </summary>
        /// <remarks>
        /// This enum member is used to indicate that a publishing process is currently in progress.
        /// </remarks>
        PublishInProgress,
    }
}

