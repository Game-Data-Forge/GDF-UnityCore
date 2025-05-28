#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRandomInt.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     GDFRandomInt class is a model class representing a random integer value.
    /// </summary>
    public class GDFRandomInt : IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the behavior options for generating random values.
        /// </summary>
        public GDFRandomBehavior Behavior { set; get; }

        /// <summary>
        ///     Gets or sets the maximum value for generating random integers.
        /// </summary>
        /// <remarks>
        ///     This property represents the upper limit for generating random integers.
        /// </remarks>
        public int Max { set; get; }

        /// <summary>
        ///     Gets or sets the minimum value for generating random integers.
        /// </summary>
        /// <remarks>
        ///     This property is used in conjunction with the <see cref="GDFRandomInt.Max" /> property to specify the range of random integers to generate.
        ///     The random integer value generated will be greater than or equal to the minimum value.
        /// </remarks>
        public int Min { set; get; }

        #endregion
    }
}