#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateTimeUtc.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a UTC DateTime data type for GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFDateTimeUtc : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random instance of GDFDateTimeUtc.
        /// </summary>
        /// <returns>A random instance of GDFDateTimeUtc.</returns>
        public static GDFDateTimeUtc Random()
        {
            return new GDFDateTimeUtc()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a timestamp.
        /// </summary>
        public long Timestamp { set; get; } = 0;

        #endregion
    }
}