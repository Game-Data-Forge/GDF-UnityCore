#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTimeRange.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a time range.
    /// </summary>
    [Serializable]
    public class GDFTimeRange : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the maximum value for the GDFTimeRange.
        /// </summary>
        /// <remarks>
        ///     This property represents the maximum value for a range of time.
        ///     It is used in conjunction with the Min property to define the boundaries of the range.
        /// </remarks>
        /// <value>
        ///     The maximum value for the GDFTimeRange.
        /// </value>
        public int Max { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the minimum value for the time range.
        /// </summary>
        /// <remarks>
        ///     The minimum value is used to define the lower bound of the time range.
        /// </remarks>
        public int Min { set; get; } = 0;

        #endregion
    }
}