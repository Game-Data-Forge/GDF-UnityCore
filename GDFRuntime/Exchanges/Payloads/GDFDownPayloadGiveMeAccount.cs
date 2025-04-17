using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadGiveMeAccount class represents the payload object for the down communication between the server and client when requesting account information.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadGiveMeAccount : GDFDownPayload
    {
        /// <summary>
        /// Gets or sets the list of account sign information.
        /// </summary>
        /// <value>The list of account sign information.</value>
        public List<GDFAccountSign> AccountSignList { set; get; }

        /// <summary>
        /// Represents the last synchronization time of the player.
        /// </summary>
        public long PlayerLastSync { set; get; }

        /// <summary>
        /// Class that represents the list of player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Represents the last synchronization time of the studio data.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of GDFStudioDataDataStorage objects.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}