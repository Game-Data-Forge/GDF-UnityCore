#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFStudioDataStorage.cs create at 2025/04/03 09:04:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class GDFStudioDataSync : IGDFWritableLongReference, IGDFDbStorage, IGDFData, IGDFWritableData
    {
        #region Instance fields and properties

        #region From interface IGDFData

        public DateTime Creation { get; set; }
        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance methods

        #region From interface IGDFData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }


    /// <summary>
    ///     Represents a data storage class for GDFStudioDataDataStorage.
    /// </summary>
    [Serializable]
    public class GDFStudioDataStorage : IGDFWritableData, IGDFDataTrack, IGDFWritableLongReference, IGDFDbStorage, IGDFSyncableData
    {
        #region Instance fields and properties

        public string ClassName { set; get; }
        public string Json { set; get; }

        #region From interface IGDFDataTrack

        /// <summary>
        ///     Represents a data storage model with a data track attribute.
        /// </summary>
        public Int64 DataTrack { set; get; }

        #endregion

        #region From interface IGDFDbStorage

        public long Project { get; set; }

        public long RowId { get; set; }

        #endregion

        #region From interface IGDFSyncableData

        public int Channels { get; set; }
        public long SyncCommit { get; }
        public DateTime SyncDateTime { get; }

        #endregion

        #region From interface IGDFWritableData

        public DateTime Creation { get; set; }

        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a data storage class for GDFStudioDataDataStorage.
        /// </summary>
        public GDFStudioDataStorage()
        {
        }

        #endregion

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}