#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFPreOperationType.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration of pre operation types for data pre operations.
    /// </summary>
    public enum GDFPreOperationType
    {
        /// <summary>
        ///     The <see cref="InsertOrUpdate" /> enumeration member of the <see cref="GDFPreOperationType" /> enum.
        ///     This member is used to indicate that the pre-operation is an Insert or Update operation.
        /// </summary>
        InsertOrUpdate = 0,

        /// <summary>
        ///     Represents the Delete member of the GDFPreOperationType enumeration.
        /// </summary>
        Delete = 1,

        /// <summary>
        ///     CreateTable is a member of the enum GDFPreOperationType.
        ///     It is used to indicate that a create table operation is being performed in the context of a pre-operation.
        /// </summary>
        CreateTable = 2,
    }
}