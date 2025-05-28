#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateRange.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a date range with minimum and maximum timestamps.
    /// </summary>
    [Serializable]
    public class GDFDateRange : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFDateRange object.
        ///     The generated GDFDateRange object has its TimestampMin and TimestampMax properties set to random integer values.
        /// </summary>
        /// <returns>A new instance of the GDFDateRange class with randomly assigned TimestampMin and TimestampMax properties.</returns>
        public static GDFDateRange Random()
        {
            return new GDFDateRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the maximum timestamp value for the GDFDateRange object.
        /// </summary>
        /// <value>The maximum timestamp value.</value>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        ///     Represents the minimum timestamp value of a date range.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        #endregion
    }
}