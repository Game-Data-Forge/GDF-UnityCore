#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAccountRange.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an interface for objects that have an account range.
    /// </summary>
    /// TODO rename?
    [Obsolete("Use IGDFRangedData instead !")]
    public interface IGDFAccountRange
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a property that defines the range of a value.
        ///     This property is used in various classes to define the range of a value.
        /// </summary>
        public short Range { set; get; }

        #endregion
    }
}