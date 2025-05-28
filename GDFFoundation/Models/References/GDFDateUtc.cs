#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateUtc.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a date and time value in Coordinated Universal Time (UTC).
    /// </summary>
    [Serializable]
    public class GDFDateUtc : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFDateUtc object.
        /// </summary>
        /// <returns>A randomly generated GDFDateUtc object.</returns>
        public static GDFDateUtc Random()
        {
            return new GDFDateUtc()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a GDFDateUtc data type.
        /// </summary>
        public int Timestamp { set; get; } = 0;

        #endregion
    }
}