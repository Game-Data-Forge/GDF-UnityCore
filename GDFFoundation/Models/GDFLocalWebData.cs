

using System;

namespace GDFFoundation
{

    /// Represents a basic model for GDFLocalWebData.
    /// /
    [Serializable]
    public abstract class GDFLocalWebData : IGDFWritableData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public long RowId { get; set; }
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        /// <summary>
        /// The abstract base class for a web-based basic model in the GDFFoundation database.
        /// This class extends the GDFDatabaseObject class and adds a ProjectReference property.
        /// </summary>
        protected GDFLocalWebData() { }

        /// <summary>
        /// Represents a basic model for GDFFoundation web applications.
        /// </summary>
        protected GDFLocalWebData(GDFLocalWebData sData) : base()
        {
            RowId = sData.RowId;
        }

        /// <summary>
        /// Method to copy the values from another <see cref="GDFLocalWebData"/> object.
        /// </summary>
        /// <param name="sOther">The <see cref="GDFLocalWebData"/> object from which to copy the values.</param>
        public void CopyFrom(GDFLocalWebData sOther)
        {
            RowId = sOther.RowId;
            DataVersion = sOther.DataVersion;
            Creation = sOther.Creation;
            Modification = sOther.Modification;
            Trashed = sOther.Trashed;
            Reference = sOther.Reference;
        }

        public object GetReference() => Reference;
    }
}

