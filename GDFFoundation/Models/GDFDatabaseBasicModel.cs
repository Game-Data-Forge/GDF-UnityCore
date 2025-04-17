using System;
using Newtonsoft.Json;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a basic model for GDFFoundation database.
    /// </summary>
    [Serializable]
    [Obsolete("Use the IGDFData structure instead !")]
    public abstract class GDFDatabaseObject // Cannot be abstract as must be unserialized for Unity propagation
    {
        /// <summary>
        /// Gets or sets the creation timestamp of the model.
        /// </summary>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { set; get; } //  -9223372036854775808 to 9223372036854775807

        /// <summary>
        /// Represents the modification property of a database record.
        /// </summary>
        public DateTime Modification { set; get; } //  -9223372036854775808 to 9223372036854775807

        /// <summary>
        /// Gets or sets a value indicating whether the item is trashed.
        /// </summary>
        public bool Trashed { set; get; } = false;
        
        /// <summary>
        /// Represents the unique identifier of a row in a database table.
        /// </summary>
        [JsonIgnore]
        public long RowId { set; get; } //  0 to 18 446 744 073 709 551 615

        /// The GDFDatabaseObject class represents a basic database model.
        /// It provides properties and methods to manage the basic attributes of a database model.
        /// /
        public GDFDatabaseObject() { }

        /// <summary>
        /// Class representing a basic model in the GDFDatabase.
        /// </summary>
        public GDFDatabaseObject(GDFDatabaseObject sOther)
        {
            Creation = sOther.Creation;
            Modification = sOther.Modification;
            Trashed = sOther.Trashed;
            RowId = sOther.RowId;
        }


        /// <summary>
        /// Method to copy the values from another <see cref="GDFDatabaseObject"/> object.
        /// </summary>
        /// <param name="sOther">The <see cref="GDFDatabaseObject"/> object from which to copy the values.</param>
        public void CopyFrom(GDFDatabaseObject sOther)
        {
            //Console.WriteLine("CopyFrom GDFDatabaseObject");
            Creation = sOther.Creation;
            Modification = sOther.Modification;
            Trashed = sOther.Trashed;
            RowId = sOther.RowId;
        }
    }
}

