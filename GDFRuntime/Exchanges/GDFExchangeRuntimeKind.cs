using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the kind of exchange in the GDF Runtime.
    /// </summary>
    [Serializable]
    public enum GDFExchangeRuntimeKind
    {
        /// <summary>
        /// No exchange kind (!)
        /// </summary>
        None = GDFExchangeKind.None,

        /// <summary>
        /// Test exchange kind.
        /// </summary>
        Test = GDFExchangeKind.Test,

        /// <summary>
        /// The Unknown exchange runtime kind.
        /// </summary>
        Unknown = GDFExchangeKind.Unknown,

        /// <summary>
        /// Represents the action of deleting an account.
        /// </summary>
        AccountDelete = 2, //=>Payload GDFUpPayloadAccountDelete, response GDFDownPayloadAccountDelete

        /// <summary>
        /// Represents the range of account change operations.
        /// </summary>
        AccountChangeRange = 3, //=>Payload GDFUpPayloadAccountChangeRange, response GDFDownPayloadAccountChangeRange

        /// <summary>
        /// SignOut
        /// </summary>
        SignOut = 10, //=>Payload GDFUpPayloadAccountSignOut, response GDFDownPayloadAccountSignOut

        /// <summary>
        /// Sign in exchange kind.
        /// </summary>
        SignIn = 11, //=>Payload GDFUpPayloadAccountSignIn, response GDFDownPayloadAccountSignIn

        /// <summary>
        /// Enum member representing the sign up action in the exchange runtime kind.
        /// </summary>
        SignUp = 12, //=>Payload GDFUpPayloadAccountSignUp, response GDFDownPayloadAccountSignUp

        /// <summary>
        /// SignLost exchange kind of the GDFExchangeRuntimeKind enum.
        /// </summary>
        SignLost = 13, //=>Payload GDFUpPayloadAccountSignLost, response GDFDownPayloadAccountSignLost

        /// <summary>
        /// Represents the sign add operation in the GDFExchangeRuntimeKind enum.
        /// </summary>
        SignAdd = 14, //=>Payload GDFUpPayloadAccountSignAdd, response GDFDownPayloadAccountSignAdd

        /// <summary>
        /// Represents the exchange kind for modifying a sign.
        /// </summary>
        SignModify = 15, //=>Payload GDFUpPayloadAccountSignModify, response GDFDownPayloadAccountSignModify

        /// <summary>
        /// Enum member representing the 'SignDelete' exchange runtime kind.
        /// </summary>
        SignDelete = 16, //=>Payload GDFUpPayloadAccountSignDelete, response GDFDownPayloadAccountSignDelete

        /// <summary>
        /// Get all sign exchange kind.
        /// </summary>
        GetAllSign = 17, //=>Payload GDFUpPayloadAccountSignAll, response GDFDownPayloadAccountSignAll

        /// <summary>
        /// Enum member SignRescue of enum GDFExchangeRuntimeKind.
        /// </summary>
        SignRescue = 18, //=>Payload GDFUpPayloadAccountSignRescue, response GDFDownPayloadAccountSignRescue


        /// <summary>
        /// Represents the exchange kind "SyncDataByIncrement".
        /// </summary>
        SyncDataByIncrement = 21, //=>Payload GDFUpPayloadDataSyncByIncrement, response GDFDownPayloadDataSyncByIncrement

        /// <summary>
        /// Exchange runtime kind representing getting all data.
        /// </summary>
        GetAllData = 22, //=>Payload GDFUpPayloadAllData, response GDFDownPayloadAllData

        /// <summary>
        /// Represents a runtime kind of exchange in GDF.
        /// </summary>
        CheckIfEmailIsUsed = 23, //=>Payload GDFUpPayloadCheckIfEmailIsUsed, response GDFDownPayloadCheckIfEmailIsUsed

        /// <summary>
        /// Retrieves all player data from the server.
        /// </summary>
        GetAllPlayerData = 31, //=>Payload GDFUpPayloadAllPlayerData, response GDFPayloadAllPlayerDataRespons

        /// <summary>
        /// Get player data by references exchange kind
        /// </summary>
        GetPlayerDataByReferences = 32, //=>Payload GDFUpPayloadPlayerDataByReferences, response PayloadPlayerDataByReferencesResponse

        /// <summary>
        /// Enum member representing the exchange kind for getting player data by bundle.
        /// </summary>
        /// <remarks>
        /// This exchange kind is used to request player data by bundle,
        /// where a bundle is a collection of related data.
        /// </remarks>
        GetPlayerDataByBundle = 33, //=> Payload GDFUpPayloadPlayerDataByBundle, response GDFDownPayloadPlayerDataByBundle

        /// <summary>
        /// Retrieves all studio data.
        /// </summary>
        /// <remarks>
        /// This member represents the enumeration value for retrieving all studio data.
        /// Studio data refers to information or records related to a studio or company.
        /// Use this value when needing to retrieve all available studio data in a specific context or operation.
        /// </remarks>
        GetAllStudioData = 41, //=>Payload GDFUpPayloadAllStudioData, response PayloadAllStudioDataResponse

        /// <summary>
        /// Retrieves studio data by references.
        /// </summary>
        GetStudioDataByReferences = 42, //=> Payload GDFUpPayloadStudioDataByReferences, response GDFDownPayloadStudioDataByReferences

        /// <summary>
        /// Represents the specific exchange kind for getting studio data by bundle.
        /// </summary>
        GetStudioDataByBundle = 43, //=> Payload GDFUpPayloadStudioDataByBundle, response GDFDownPayloadStudioDataByBundle

        /// <summary>
        /// Represents the type of exchange operation for creating a relationship.
        /// </summary>
        CreateRelationship = 50,

        /// <summary>
        /// Represents the relationship between two linked objects.
        /// </summary>
        LinkRelationship = 51,

        /// <summary>
        /// Enum member representing the finalization of a relationship exchange.
        /// </summary>
        /// <remarks>
        /// FinalizeRelationship is an enum member of the GDFExchangeRuntimeKind enum.
        /// It indicates that the exchange represents the finalization of a relationship
        /// between two entities.
        /// </remarks>
        FinalizeRelationship = 52,

        /// <summary>
        /// Represents the exchange runtime kind for retrieving relationship data.
        /// </summary>
        /// <remarks>
        /// This enumeration is part of the GDFExchangeRuntimeKind enum.
        /// </remarks>
        GetRelationship = 53,

        /// <summary>
        /// Represents the update relationship exchange kind.
        /// </summary>
        UpdateRelationship = 54,
    }
}