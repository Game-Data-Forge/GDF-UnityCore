

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents crucial information for the GDF database.
    /// </summary>
    [Serializable]
    public class GDFCrucialInformation : GDFBasicData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { set; get; }

        /// <summary>
        /// Represents a unique identity for a table.
        /// </summary>
        public string TableKey { set; get; } = string.Empty;

        /// <summary>
        /// Represents the hash value of a table in the GDFCrucialInformation class.
        /// </summary>
        /// <remarks>
        /// This property is used to store the hash value of a table in the GDFCrucialInformation class.
        /// The hash value represents a fingerprint of the table's data, which can be used for comparison or verification purposes.
        /// </remarks>
        public string TableHash { set; get; } = string.Empty;

        /// <summary>
        /// GDFCrucialInformation class represents crucial information used in the application.
        /// It extends the GDFBasicData class and provides properties for table key and table hash.
        /// </summary>
        public GDFCrucialInformation()
        {
        }
    }
}

