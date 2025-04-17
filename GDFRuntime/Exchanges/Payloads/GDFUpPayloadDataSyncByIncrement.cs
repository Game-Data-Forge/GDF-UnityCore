using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// This class represents the payload data used for synchronizing data by increment.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadDataSyncByIncrement : GDFUpPayload
    {
        /// <summary>
        /// Represents the sync information for user data.
        /// </summary>
        /// <remarks>
        /// The UserDataSyncInformation property is used in the GDFUpPayloadDataSyncByIncrement class
        /// to store the sync information for user data. It is of type GDFSyncInformation.
        /// </remarks>
        public GDFSyncInformation UserDataSyncInformation { set; get; }

        /// <summary>
        /// Represents a list of user data storage objects.
        /// </summary>
        public List<GDFUserDataDataStorage> UserDataList { set; get; }

        /// <summary>
        /// Represents the sync information for player data.
        /// </summary>
        public GDFSyncInformation PlayerDataSyncInformation { set; get; }

        /// <summary>
        /// List of <see cref="GDFPlayerDataStorage"/> objects representing player data.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }

        /// <summary>
        /// Represents the sync information for studio data.
        /// </summary>
        public GDFSyncInformation StudioDataSyncInformation { set; get; }

        /// <summary>
        /// Represents a list of GDFStudioDataDataStorage objects.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }

        /// <summary>
        /// Represents a list of <see cref="GDFVolatileDataStorage"/> objects.
        /// </summary>
        public List<GDFVolatileDataStorage> VolatileDataList { set; get; }
    }
}