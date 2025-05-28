#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalWebData.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// Represents a basic model for GDFLocalWebData.
    /// /
    [Serializable]
    public abstract class GDFLocalWebData : IGDFWritableData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        public long RowId { get; set; }

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

        #region Instance constructors and destructors

        /// <summary>
        ///     The abstract base class for a web-based basic model in the GDFFoundation database.
        ///     This class extends the GDFDatabaseObject class and adds a ProjectReference property.
        /// </summary>
        protected GDFLocalWebData()
        {
        }

        /// <summary>
        ///     Represents a basic model for GDFFoundation web applications.
        /// </summary>
        protected GDFLocalWebData(GDFLocalWebData sData)
            : base()
        {
            RowId = sData.RowId;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Method to copy the values from another <see cref="GDFLocalWebData" /> object.
        /// </summary>
        /// <param name="sOther">The <see cref="GDFLocalWebData" /> object from which to copy the values.</param>
        public void CopyFrom(GDFLocalWebData sOther)
        {
            RowId = sOther.RowId;
            DataVersion = sOther.DataVersion;
            Creation = sOther.Creation;
            Modification = sOther.Modification;
            Trashed = sOther.Trashed;
            Reference = sOther.Reference;
        }

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }
}