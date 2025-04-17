using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing an GDFUpPayloadAllData.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAllData : GDFUpPayload
    {
        /// <summary>
        /// Represents a list of user data.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Class that represents a list of player data storage.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Represents a list of studio data storage objects.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }

        /// <summary>
        /// The VolatileDataList property represents a list of volatile data objects.
        /// </summary>
        public List<GDFVolatileData> VolatileDataList { set; get; }
    }
}