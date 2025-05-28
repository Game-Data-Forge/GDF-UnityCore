#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDataBasicStorageModel.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Abstract class representing a basic storage model for GDF data.
    /// </summary>
    /// <remarks>
    ///     This class provides properties and methods for storing and managing GDF data in a database.
    /// </remarks>
    [Serializable]
    [Obsolete("Use IGDFStorageData instead !")]
    public abstract class GDFDataBasicDataStorage : GDFBasicData, IGDFSyncCommitByTimestamp
    {
        #region Instance fields and properties

        /// <summary>
        ///     The channel the data is accessible from.
        /// </summary>
        public int Channel { set; get; } = 0;

        /// <summary>
        ///     Represents a basic storage model for data.
        /// </summary>
        /// <remarks>
        ///     This class is inherited from GDFBasicData and implements IGDFAvailableForTarget and IGDFSyncCommitByTimestamp interfaces.
        /// </remarks>
        public string ClassName { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a data model with four index properties and synchronization properties.
        /// </summary>
        public string IndexFour { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a basic storage model in the GDF system.
        /// </summary>
        public string IndexOne { set; get; } = string.Empty;

        /// <summary>
        ///     The IndexThree property of a GDFDataBasicDataStorage.
        /// </summary>
        /// <remarks>
        ///     This property represents the value of the IndexThree field in the GDFDataBasicDataStorage class.
        /// </remarks>
        /// <example>
        ///     This property can be used to store additional information related to the GDFDataBasicDataStorage object.
        /// </example>
        public string IndexThree { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the value of IndexTwo.
        /// </summary>
        /// <remarks>
        ///     This property represents the value of IndexTwo in the GDFDataBasicDataStorage class.
        /// </remarks>
        public string IndexTwo { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a class that defines a property for storing JSON data.
        /// </summary>
        /// <remarks>
        ///     This property is used in various storage models to store JSON data.
        /// </remarks>
        public string Json { set; get; } = string.Empty;

        #region From interface IGDFSyncCommitByTimestamp

        /// <summary>
        ///     Gets or sets the SyncCommit value.
        /// </summary>
        public long SyncCommit { set; get; }

        /// <summary>
        ///     Gets or sets the synchronization datetime.
        /// </summary>
        public DateTime SyncDatetime { set; get; }

        #endregion

        #endregion

        #region Instance methods

        /// <summary>
        ///     Copy the values from another GDFDataBasicDataStorage object.
        /// </summary>
        /// <param name="sOther">The GDFDataBasicDataStorage object to copy from.</param>
        public void CopyFrom(GDFDataBasicDataStorage sOther)
        {
            base.CopyFrom(sOther);

            Channel = sOther.Channel;
            SyncDatetime = sOther.SyncDatetime;
            SyncCommit = sOther.SyncCommit;
            ClassName = sOther.ClassName;
            Json = sOther.Json;
            IndexOne = sOther.IndexOne;
            IndexTwo = sOther.IndexTwo;
            IndexThree = sOther.IndexThree;
            IndexFour = sOther.IndexFour;
        }

        #endregion
    }
}