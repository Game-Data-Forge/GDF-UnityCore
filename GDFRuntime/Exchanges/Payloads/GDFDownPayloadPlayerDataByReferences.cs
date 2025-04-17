using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadPlayerDataByReferences represents the payload object for the down communication to request player data by references.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadPlayerDataByReferences : GDFDownPayload
    {
        /// <summary>
        /// Represents a list of user data storage.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Represents a list of player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Gets or sets the last sync timestamp of the studio.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of GDFStudioDataDataStorage objects.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}