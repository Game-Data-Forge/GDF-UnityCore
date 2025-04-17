using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing an GDFUpPayloadAllPlayerData.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAllPlayerData : GDFUpPayload
    {
        /// <summary>
        /// Represents a list of user data storage.
        /// </summary>
        /// <remarks>
        /// This class is used to store a list of user data storage objects.
        /// It is typically used in the context of the GDFUpPayloadAllPlayerData class.
        /// </remarks>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Gets or sets the list of player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// The VolatileDataList property represents a list of volatile data objects.
        /// </summary>
        /// <remarks>
        /// The VolatileDataList property is defined in the <see cref="GDFUpPayloadAllPlayerData"/> class in the GDFRuntime namespace.
        /// </remarks>
        public List<GDFVolatileData> VolatileDataList { set; get; }
    }
}