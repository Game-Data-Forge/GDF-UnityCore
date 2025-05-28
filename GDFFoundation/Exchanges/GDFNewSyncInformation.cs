#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFNewSyncInformation.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents the information about a new synchronization.
    /// </summary>
    [Serializable]
    public class GDFNewSyncInformation
    {
        #region Instance fields and properties

        /// <summary>
        ///     Sync Commit Id
        /// </summary>
        public long SyncCommit { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the synchronization DateTime.
        /// </summary>
        public DateTime SyncTime { set; get; } = DateTime.UnixEpoch;

        #endregion
    }
}