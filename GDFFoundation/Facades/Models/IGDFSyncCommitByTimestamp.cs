#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFSyncCommitByTimestamp.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Interface for syncing data commit with a timestamp.
    /// </summary>
    [Obsolete("Use IGDFSyncableData instead !")]
    public interface IGDFSyncCommitByTimestamp
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the synchronization commit.
        /// </summary>
        public long SyncCommit { set; get; }

        /// <summary>
        ///     Gets or sets the synchronization datetime.
        /// </summary>
        public DateTime SyncDatetime { set; get; }

        #endregion
    }
}