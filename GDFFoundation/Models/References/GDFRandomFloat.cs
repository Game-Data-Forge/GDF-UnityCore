#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRandomFloat.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// Represents a random floating-point value generator.
    /// /
    public class GDFRandomFloat : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the behavior options for generating random values.
        /// </summary>
        public GDFRandomBehavior Behavior { set; get; }

        /// <summary>
        ///     Represents the maximum value for the random float generation.
        /// </summary>
        public float Max { set; get; }

        /// <summary>
        ///     Gets or sets the minimum value for generating random floats.
        /// </summary>
        public float Min { set; get; }

        #endregion
    }
}