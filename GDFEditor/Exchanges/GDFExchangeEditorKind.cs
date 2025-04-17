using System;
using GDFFoundation;

namespace GDFEditor
{
    /// <summary>
    /// Enum defining the kinds of exchange editors.
    /// </summary>
    [Serializable]
    public enum GDFExchangeEditorKind
    {
        /// <summary>
        /// No exchange kind.
        /// </summary>
        None = GDFExchangeKind.None,

        /// <summary>
        /// Test exchange kind
        /// </summary>
        Test = GDFExchangeKind.Test,

        /// <summary>
        /// Not yet specified
        /// </summary>
        Unknown = GDFExchangeKind.Unknown,

        /// <summary>
        /// Authenticate by role or account and get project settings json with rights
        /// </summary>
        GetProjectSettings = 100,

        /// <summary>
        /// Synchronizes the meta data between the client and the server.
        /// </summary>
        SyncMetaData = 200,

        /// <summary>
        /// Represents the metadata lock exchange kind.
        /// </summary>
        MetaDataLock = 201,

        /// <summary>
        /// Represents the exchange kind for unlocking metadata in the GDFEditorController.
        /// </summary>
        MetaDataUnlock = 202,

        /// <summary>
        /// Switch lock metadata exchange kind.
        /// </summary>
        MetaDataSwitchLock = 203,

        /// <summary>
        /// Creates metadata for the exchange.
        /// </summary>
        /// <remarks>
        /// This enum member is used to specify that metadata should be created as part of the exchange process.
        /// </remarks>
        CreateMetaData = 300,

        /// <summary>
        /// Qualification exchange kind.
        /// </summary>
        Qualification = 400,

        /// <summary>
        /// PublishToPreproduction exchange kind.
        /// </summary>
        PublishToPreproduction = 500,

        /// <summary>
        /// PublishToProduction exchange kind. This enum member is used to specify the exchange kind for publishing data to the production environment.
        /// </summary>
        PublishToProduction = 600,

        /// <summary>
        /// Enum member representing the exchange process for processing all meta data.
        /// </summary>
        /// <remarks>
        /// This enum member is used in the context of exchanging meta data in the GDF system.
        /// When this member is used, it indicates that all meta data should be processed in the exchange process.
        /// </remarks>
        ProcessAllMetaData = 999,
    }
}