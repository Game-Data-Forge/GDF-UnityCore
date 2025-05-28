#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFSyncableData.cs create at 2025/04/03 09:04:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    public interface IGDFSyncableData : IGDFData
    {
        #region Instance fields and properties

        public int Channels { get; set; }
        public long SyncCommit { get; }
        public DateTime SyncDateTime { get; }

        #endregion
    }
}