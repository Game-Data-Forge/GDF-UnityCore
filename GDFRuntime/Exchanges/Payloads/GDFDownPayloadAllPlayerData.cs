using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadAllPlayerData class represents the payload object for down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAllPlayerData : GDFDownPayload
    {
        /// <summary>
        /// Represents the last sync time for a user.
        /// </summary>
        public long UserLastSync { set; get; }

        /// <summary>
        /// Represents a list of user data.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; } = new List<GDFUserDataDataStorage>();

        /// <summary>
        /// Represents the last synchronization time of the player data.
        /// </summary>
        public long PlayerLastSync { set; get; }

        /// <summary>
        /// Class for storing player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; } = new List<GDFPlayerDataStorage>();
    }
}