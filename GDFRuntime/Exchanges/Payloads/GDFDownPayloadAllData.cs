using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadAllData class represents a payload object for down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAllData : GDFDownPayload
    {
        /// <summary>
        /// Represents the last sync time of a user.
        /// </summary>
        public long UserLastSync { set; get; }

        /// <summary>
        /// Represents a list of user data in the GDFDownPayloadAllData class.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; } = new List<GDFUserDataDataStorage>();

        /// <summary>
        /// Represents the last synchronization time for the player data.
        /// </summary>
        public long PlayerLastSync { set; get; }

        /// <summary>
        /// Class for storing player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; } = new List<GDFPlayerDataStorage>();

        /// <summary>
        /// Represents the last synchronization timestamp for Studio data.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of studio data.
        /// </summary>
        /// <remarks>
        /// This list contains studio data objects of type <see cref="GDFStudioDataStorage"/>.
        /// </remarks>
        public List<GDFStudioDataStorage> StudioDataList { set; get; } = new List<GDFStudioDataStorage>();
    }
}