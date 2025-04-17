using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadAccountSignIn class represents the payload object for signing in an account.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignIn : GDFDownPayload
    {
        /// <summary>
        /// Represents the success of an account sign-in.
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// Gets or sets the sign-in reference of the account.
        /// </summary>
        public long SignReference { set; get; }

        /// <summary>
        /// Gets or sets the last sync time for the player.
        /// </summary>
        public long PlayerLastSync { set; get; }

        /// <summary>
        /// Class for storing player data list.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; } = new List<GDFPlayerDataStorage>();

        /// <summary>
        /// Represents the last synchronization time of the studio.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of studio data.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; } = new List<GDFStudioDataStorage>();
    }
}