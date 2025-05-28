#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateTimeRange.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a date and time range.
    /// </summary>
    [Serializable]
    public class GDFDateTimeRange : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generate a random GDFDateTimeRange object with randomly generated TimestampMin and TimestampMax values.
        /// </summary>
        /// <returns>A new GDFDateTimeRange object with random TimestampMin and TimestampMax values.</returns>
        public static GDFDateTimeRange Random()
        {
            return new GDFDateTimeRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents the maximum timestamp of a datetime range.
        /// </summary>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        ///     Represents the minimum timestamp value of a GDFDateTimeRange object.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        #endregion
    }
}