#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFWritableSyncableData.cs create at 2025/04/03 09:04:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    public interface IGDFWritableSyncableData : IGDFWritableData, IGDFSyncableData
    {
        #region Instance fields and properties

        public new long SyncCommit { get; set; }
        public new DateTime SyncDateTime { get; set; }

        #endregion
    }
}