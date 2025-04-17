using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an GDFAccount.
    /// </summary>
    public class GDFAccount : IGDFDbStorage, IGDFRangedData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Project { get; set; }

        /// <summary>
        /// Represents the reference property of the account.
        /// </summary>
        /// <remarks>
        /// This property serves as a unique long identifier for the account.
        /// It is used across various components to establish and manage account references within the system.
        /// </remarks>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents the range property of an account.
        /// </summary>
        /// <remarks>
        /// This property represents the range of an account. The range is a short value that determines the level or tier of the account.
        /// </remarks>
        public short Range { set; get; }

        /// <summary>
        /// Represents the ban property of an account.
        /// </summary>
        /// <remarks>
        /// The ban property indicates whether an account is banned or not.
        /// </remarks>
        public bool Ban { set; get; } = false;

        /// <summary>
        /// Represents the timestamp when the object will be deleted.
        /// </summary>
        public int WillBeDeleteAtTimestamp { set; get; }

        /// <summary>
        /// Represents the Migration property of an GDFAccount object.
        /// </summary>
        /// <value>
        /// The Migration property indicates whether the account is being migrated or not.
        /// </value>
        public bool Migration { set; get; } = false;

        /// <summary>
        /// Represents the message property of an GDFAccount.
        /// </summary>
        public string Message { set; get; } = string.Empty;

        /// <summary>
        /// Represents the payload property of an account in the GDFAccount class.
        /// </summary>
        public string Payload { set; get; } = string.Empty;
        
        public string Country { set; get; } = string.Empty;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public DateTime Modification { get; set; }

        public bool Trashed { get; set; }

        public long RowId { get; set; }

        public long DataVersion { get; set; }
        
        public object GetReference() => Reference;
    }
}

