#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFRangedData.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    /// Represents the interface for ranged data, extending the functionality of <see cref="IGDFWritableData"/>.
    /// </summary>
    public interface IGDFRangedData : IGDFWritableData
    {
        #region Instance fields and properties

        /// <summary>
        /// Represents a property to define the range for a given object. This property is implemented
        /// in classes and interfaces such as <see cref="GDFFoundation.IGDFRangedData"/> to handle
        /// the range information which may be relevant for database storage or other custom logic.
        /// </summary>
        /// <remarks>
        /// Classes implementing <see cref="GDFFoundation.IGDFRangedData"/>, such as
        /// <see cref="GDFFoundation.GDFReportData"/>, <see cref="GDFFoundation.GDFAccountData"/>,
        /// <see cref="GDFFoundation.GDFVolatileData"/>, and <see cref="GDFFoundation.GDFPlayerDataSync"/>,
        /// make use of this property.
        /// </remarks>
        /// <value>
        /// An integer that represents the range. This value is typically set and retrieved
        /// dynamically within the implementation.
        /// </value>
        public int Range { get; set; }

        #endregion
    }
}