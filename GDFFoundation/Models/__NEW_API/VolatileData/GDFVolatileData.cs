using System;
namespace GDFFoundation
{
    /// <summary>
    /// The GDFVolatileData class represents a volatile data object in the GDFFoundation namespace.
    /// This class is an abstract class and cannot be instantiated directly.
    /// </summary>
    [Serializable]
    public abstract class GDFVolatileData : IGDFDbStorage, IGDFRangedData, IGDFWritableAccountData, IGDFWritableLongReference
    {
        private long _reference;
        private long _reference1;
        public long Project { get; set; }

        /// <summary>
        /// Represents session information for a specific user or device.
        /// </summary>
        public string Session { set; get; } = string.Empty;

        /// <summary>
        /// Represents the origin of the GDF exchange.
        /// </summary>
        public GDFExchangeOrigin Origin { set; get; } = GDFExchangeOrigin.Unknown;

        /// <summary>
        /// Represents a device used in the application.
        /// </summary>
        public string Device { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the BundleId associated with the GDFVolatileData object.
        /// </summary>
        /// <remarks>
        /// The BundleId represents the unique identifier for the bundle or application that the GDFVolatileData belongs to.
        /// </remarks>
        /// <value>The BundleId of the GDFVolatileData object.</value>
        public string BundleId { set; get; } = string.Empty;

        /// <summary>
        /// Represents a property that stores the path of a file or directory.
        /// </summary>
        public string Path { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the Harvest version of the data.
        /// </summary>
        public string HarvestVersion { set; get; } = string.Empty;

        /// <summary>
        /// Represents the version of the engine.
        /// </summary>
        /// <remarks>
        /// The engine version represents the version of the software engine being used.
        /// This property is used to track the version of the software for compatibility and debugging purposes.
        /// </remarks>
        public string EngineVersion { set; get; } = string.Empty;

        /// <summary>
        /// Represents the language of a volatile data object.
        /// </summary>
        public string Language { set; get; } = string.Empty;

        /// <summary>
        /// Represents a data track in the GDFVolatileData class.
        /// </summary>
        public Int64 DataTrack { set; get; }

        /// <summary>
        /// Represents an anonymous unique identity.
        /// </summary>
        /// <remarks>
        /// This property stores a string value that represents an anonymous unique identity. It is used for anonymizing data and ensuring privacy.
        /// </remarks>
        /// <value>The anonymous unique identity.</value>
        public string Anonymous { set; get; } = string.Empty; // Who ? => anonymous

        /// <summary>
        /// Represents the timestamp of a volatile data object.
        /// </summary>
        public long Timestamp { set; get; } = 0;                // When ? => DateTime

        /// <summary>
        /// Represents a category of data in the GDFFoundation system.
        /// </summary>
        public string Category { set; get; } = string.Empty;    // Why ? => category

        /// <summary>
        /// Represents additional information related to a volatile data model.
        /// </summary>
        public string Information { set; get; } = string.Empty; // How ? => information

        /// <summary>
        /// Represents a group of volatile data objects.
        /// </summary>
        public string Group { internal set; get; } = string.Empty;

        /// <summary>
        /// Calculates the hash value for an GDFAccount.
        /// </summary>
        /// <param name="sAccount">The GDFAccount object.</param>
        /// <returns>The hash value as a string.</returns>
        static public string Hash(GDFAccount sAccount)
        {
            return Hash(sAccount.Reference, sAccount.Project);
        }

        /// <summary>
        /// Generates a hash for the given account reference and project ID.
        /// </summary>
        /// <param name="sAccountReference">The account reference.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <returns>The generated hash.</returns>
        static public string Hash(long sAccountReference, long sProjectReference)
        {
            return GDFSecurityTools.GenerateSha(sAccountReference.ToString() + " " + sProjectReference.ToString());
        }

        /// <summary>
        /// Initializes the GDFVolatileData object with the information provided by the volatile manager.
        /// </summary>
        /// <param name="sVolatileManager">The volatile manager that provides the session information.</param>
        public void Init(IGDFVolatileAgent sVolatileManager)
        {
            Timestamp = GDFTimestamp.Timestamp();
            EngineVersion = GDFFoundation.GDFVersionDll.VersionDll.Version;
            if (sVolatileManager != null)
            {
                Session = sVolatileManager.GetSession();
                Device = sVolatileManager.GetDevice();
                Language = sVolatileManager.GetLanguage();
                HarvestVersion = sVolatileManager.GetHarvestVersion();
                Project = sVolatileManager.GetProjectReference();
                Account = sVolatileManager.GetAccount();
                DataTrack = sVolatileManager.GetDataTrack();
                Origin = sVolatileManager.GetOrigin();
                BundleId = sVolatileManager.GetBundleId();
                Path = sVolatileManager.GetPath();
                Anonymous = Hash(Account, Project);
            }
        }

        /// <summary>
        /// The GDFVolatileData class represents volatile data which can be stored in the database.
        /// </summary>
        public GDFVolatileData() { }

        /// <summary>
        /// Represents a volatile data for GDFFoundation.
        /// </summary>
        public GDFVolatileData(IGDFVolatileAgent sVolatileManager, Enum sCategory, string sInformation = "")
        {
            Init(sVolatileManager);
            Category = sCategory.ToString();
            Information = sInformation;
        }

        /// <summary>
        /// Represents volatile data used in GDFFoundation.
        /// </summary>
        public GDFVolatileData(IGDFVolatileAgent sVolatileManager, string sCategory, string sInformation = "")
        {
            Init(sVolatileManager);
            Category = sCategory;
            Information = sInformation;
        }

        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public DateTime SyncDateTime { get; set; }
        public bool Trashed { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Account { get; set; }
        public int Range { get; set; }
        public long RowId { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public object GetReference() => Reference;
    }
}

