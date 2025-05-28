#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateUtcRange.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a range of UTC dates and times.
    /// </summary>
    [Serializable]
    public class GDFDateUtcRange : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFDateUtcRange object with random TimestampMin and TimestampMax values.
        /// </summary>
        /// <returns>A random GDFDateUtcRange object.</returns>
        public static GDFDateUtcRange Random()
        {
            return new GDFDateUtcRange()
            {
                TimestampMin = GDFRandom.IntNumeric(5),
                TimestampMax = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the maximum timestamp for the GDFDateUtcRange.
        /// </summary>
        public int TimestampMax { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the minimum timestamp value.
        /// </summary>
        public int TimestampMin { set; get; } = 0;

        #endregion
    }
}