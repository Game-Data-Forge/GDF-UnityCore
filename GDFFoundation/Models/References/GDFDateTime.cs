#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDateTime.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a date and time in the GDF Foundation.
    /// </summary>
    [Serializable]
    public class GDFDateTime : IGDFSubModel
    {
        #region Static methods

        /// <summary>
        ///     Returns the current date and time as a GDFDateTime object.
        /// </summary>
        /// <returns>The current date and time as a GDFDateTime object.</returns>
        public static GDFDateTime Now()
        {
            return new GDFDateTime()
            {
                Timestamp = GDFTimestamp.Timestamp()
            };
        }

        /// <summary>
        ///     Generates a random GDFDateTime object.
        /// </summary>
        /// <returns>A randomly generated GDFDateTime object.</returns>
        public static GDFDateTime Random()
        {
            return new GDFDateTime()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a timestamp stored as a long integer value.
        /// </summary>
        public long Timestamp { set; get; } = 0;

        #endregion
    }
}