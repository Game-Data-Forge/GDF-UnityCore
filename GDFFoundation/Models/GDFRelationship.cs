

namespace GDFFoundation
{
    /// <summary>
    /// Represents a relationship between two accounts.
    /// </summary>
    public class GDFRelationship : GDFBasicData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents a reference to an GDFAccount object in the GDF foundation.
        /// </summary>
        public GDFLongReference<GDFAccount> AccountA { set; get; } = new GDFLongReference<GDFAccount>();

        /// <summary>
        /// Represents the second account in the GDF foundation relationship.
        /// </summary>
        public GDFLongReference<GDFAccount> AccountB { set; get; } = new GDFLongReference<GDFAccount>();

        /// <summary>
        /// Represents the name of an account in the GDF relationship.
        /// </summary>
        public string AccountAName { set; get; } = string.Empty;

        /// <summary>
        /// Represents the name of Account B in a relationship in the GDFFoundation.
        /// </summary>
        public string AccountBName { set; get; } = string.Empty;

        /// <summary>
        /// Represents the state of a relationship.
        /// </summary>
        public GDFRelationshipState RelationshipState { set; get; }

        /// <summary>
        /// Represents the type of relationship between accounts.
        /// </summary>
        public GDFRelationshipType RelationshipType { set; get; } = GDFRelationshipType.Friend;

        /// <summary>
        /// Gets or sets the modification date of the GDFRelationship.
        /// </summary>
        /// <value>The modification date in Unix timestamp format.</value>
        public int ModificationDate { set; get; }

        /// <summary>
        /// Represents a code used in the GDFRelationship class.
        /// </summary>
        public string Code { set; get; } = string.Empty;

        /// <summary>
        /// Represents the expiry date of a code in a relationship object.
        /// </summary>
        public uint CodeExpiryDate { set; get; }


        /// <summary>
        /// Gets the reference to the other account in the relationship.
        /// </summary>
        /// <param name="sReference">The reference to one of the accounts in the relationship.</param>
        /// <returns>The reference to the other account in the relationship.</returns>
        public GDFLongReference<GDFAccount> GetOtherAccount(GDFLongReference<GDFAccount> sReference)
        {
            if (sReference.Reference == AccountA.Reference) return AccountB;
            return AccountA;
        }

        /// <summary>
        /// Gets the name of the account referenced by the given reference.
        /// </summary>
        /// <param name="sReference">The reference to one of the accounts in the relationship.</param>
        /// <returns>The name of the account referenced by the given reference. If the reference matches AccountA.Reference, AccountAName is returned. Otherwise, AccountBName is returned.</returns>
        public string GetName(GDFLongReference<GDFAccount> sReference)
        {
            if (sReference.Reference == AccountA.Reference) return AccountAName;
            return AccountBName;
        }

        /// <summary>
        /// Gets the name of the account referenced by <paramref name="sReference"/>.
        /// </summary>
        /// <param name="sReference">The reference to the account.</param>
        /// <returns>The name of the account referenced by <paramref name="sReference"/>.</returns>
        public string GetName(long sReference)
        {
            if (sReference == AccountA.Reference) return AccountAName;
            return AccountBName;
        }


        /// <summary>
        /// Gets the reference to the other account in the relationship.
        /// </summary>
        /// <param name="sReference">The reference to one of the accounts in the relationship.</param>
        /// <returns>The reference to the other account in the relationship.</returns>
        public long GetOtherAccount(long sReference)
        {
            if (sReference == AccountA.Reference) return AccountB.Reference;
            return AccountA.Reference;
        }

        /// <summary>
        /// Determines whether the current instance is equal to the specified object.
        /// </summary>
        /// <param name="sObj">The object to compare with the current instance.</param>
        /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
        public override bool Equals(object sObj)
        {
            return sObj != null && sObj.GetType().IsInstanceOfType(typeof(GDFRelationship)) && Reference == ((GDFRelationship)sObj).Reference;
        }

        /// <summary>
        /// Computes a hash code for the current instance.
        /// </summary>
        /// <returns>
        /// A hash code for the current instance.
        /// </returns>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// Sets the name of the specified account reference in the relationship.
        /// </summary>
        /// <param name="sProfileInfoPlayerReference">The reference to the account in the relationship.</param>
        /// <param name="sNewName">The new name to set for the account.</param>
        public void SetName(long sProfileInfoPlayerReference, string sNewName)
        {
            if (sProfileInfoPlayerReference == AccountA.Reference)
            { AccountAName = sNewName; }
            else if (sProfileInfoPlayerReference == AccountB.Reference) { AccountBName = sNewName; }
        }

    }
}

