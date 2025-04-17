using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadPlayerDataByBundle class represents the payload object for the down communication between the server and client, specifically for player data by bundle.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadPlayerDataByBundle : GDFDownPayload
    {
        /// <summary>
        /// Represents a list of user data.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Class for storing the list of player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Gets or sets the last synchronization timestamp for the studio.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of studio data for a down payload.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}