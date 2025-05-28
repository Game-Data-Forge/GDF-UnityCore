#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDate.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a date data type in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFDate : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFDate with a random timestamp.
        /// </summary>
        /// <returns>A randomly generated GDFDate object.</returns>
        public static GDFDate Random()
        {
            return new GDFDate()
            {
                Timestamp = GDFRandom.IntNumeric(5)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a timestamp value.
        /// </summary>
        public int Timestamp { set; get; } = 0;

        #endregion
    }
}