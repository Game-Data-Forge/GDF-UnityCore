using System;

namespace GDFFoundation
{
    [Serializable]
    public class GDFDashboardData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }
        
        public string SignUpApiUrl { get; set; } = string.Empty;
        public string SignLostApiUrl { get; set; } = string.Empty;
        public string EmailFrom { get; set; } = string.Empty;

        #endregion

        #region From interface IGDFWritableData

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
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

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }
}