#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFWritableLongReference.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    /// Represents an interface that extends the functionality of <see cref="IGDFLongReference"/> to include writable capabilities for a long reference.
    /// </summary>
    public interface IGDFWritableLongReference : IGDFLongReference
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the unique long reference value associated with the object.
        /// This property is marked as unique with a constraint and has restricted update access defined through attributes.
        /// </summary>
        /// <remarks>
        /// The <see cref="Reference"/> property is commonly employed for unique identification purposes in database operations.
        /// Update access to this property is explicitly denied through the <see cref="GDFDbAccessAttribute"/> with
        /// <see cref="GDFDbColumnAccess.Deny"/> set for <see cref="GDFDbAccessAttribute.updateAccess"/>. Additionally, the property is
        /// enforced as unique through the <see cref="GDFDbUniqueAttribute"/> constraint.
        /// </remarks>
        /// <value>
        /// A <see cref="System.Int64"/> representing the unique identifier for the entity.
        /// </value>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public new long Reference { get; set; }

        #endregion
    }
}