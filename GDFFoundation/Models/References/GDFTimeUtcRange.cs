#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTimeUtcRange.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a range of UTC time.
    /// </summary>
    [Serializable]
    public class GDFTimeUtcRange : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Max { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the minimum value for the GDFTimeUtcRange.
        /// </summary>
        /// <remarks>
        ///     This property represents the minimum value for the GDFTimeUtcRange class.
        ///     It specifies the lower bound of the range.
        /// </remarks>
        public int Min { set; get; } = 0;

        #endregion
    }
}