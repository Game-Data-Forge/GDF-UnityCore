using System;
using Newtonsoft.Json;

namespace GDFFoundation
{
    /// The GDFPlayerData class is an abstract class that represents common properties and methods for player data in a game.
    /// It extends the GDFBasicData class.
    /// @inherit GDFBasicData
    /// @modifiers [Serializable]
    public abstract class GDFPlayerData : IGDFAccountData, IGDFSyncableData, IGDFStringReference
    {
        [JsonIgnore]
        public string Reference => _reference;
        /// <summary>
        /// Represents an account in the game.
        /// </summary>
        [JsonIgnore]
        public long Account => _account;


        /// <summary>
        /// Represents a game save for a player.
        /// </summary>
        [JsonIgnore]
        public byte GameSave => _gameSave;

        /// <summary>
        /// The channel the data is accessible from.
        /// </summary>
        [JsonIgnore]
        public int Channels { get; set; } = 0;

        /// <summary>
        /// Gets or sets the synchronization datetime of the player data.
        /// </summary>
        [JsonIgnore]
        public DateTime SyncDateTime => _syncTime;

        /// <summary>
        /// Represents a property indicating whether the commit is synchronized or not based on timestamp.
        /// </summary>
        [JsonIgnore]
        public long SyncCommit => _syncCommit;

        /// <summary>
        /// Represents a player data in the system.
        /// </summary>
        [JsonIgnore]
        public GDFPlayerDataProcessKind Process { set; get; } = GDFPlayerDataProcessKind.None;
        [JsonIgnore]
        public long DataVersion => _dataVersion;
        [JsonIgnore]
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation => _creation;
        [JsonIgnore]
        public DateTime Modification => _modification;
        [JsonIgnore]
        public bool Trashed { get; set; }

        private string _reference;
        private long _account;
        private byte _gameSave;
        private DateTime _syncTime;
        private long _syncCommit;
        private long _dataVersion;
        private DateTime _creation;
        private DateTime _modification;

        public GDFPlayerData() { }

        /// <summary>
        /// Copies the data from another GDFPlayerData object.
        /// </summary>
        /// <param name="sOther">The GDFPlayerData object to copy the data from.</param>
        public void CopyFrom(GDFPlayerData sOther)
        {
            // Channel = sOther.Channel;
            Process = sOther.Process;
            Trashed = sOther.Trashed;

            _reference = sOther._reference;
            _account = sOther._account;
            _gameSave = sOther._gameSave;
            _syncTime = sOther._syncTime;
            _syncCommit = sOther._syncCommit;
            _dataVersion = sOther._dataVersion;
            _creation = sOther._creation;
            _modification = sOther._modification;
        }

        public object GetReference()
        {
            return Reference;
        }
    }
}

