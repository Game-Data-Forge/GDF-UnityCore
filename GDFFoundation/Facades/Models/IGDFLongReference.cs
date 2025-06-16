#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFLongReference.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IGDFLongReference
    {
        #region Instance fields and properties

        /// <summary>
        /// Gets or sets the unique identifier for the entity. This property represents a reference of type <see cref="long"/>.
        /// Access to modify this property is restricted by the <see cref="GDFDbAccessAttribute"/> with <see cref="GDFDbColumnAccess"/> set to <see cref="GDFDbColumnAccess.Deny"/> for updates.
        /// </summary>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; }

        #endregion
    }
}