namespace GDFFoundation
{
    /// Represents a random floating-point value generator.
    /// /
    public class GDFRandomFloat : IGDFSubModel
    {
        /// <summary>
        /// Represents the behavior options for generating random values.
        /// </summary>
        public GDFRandomBehavior Behavior { set; get; }

        /// <summary>
        /// Gets or sets the minimum value for generating random floats.
        /// </summary>
        public float Min { set; get; }

        /// <summary>
        /// Represents the maximum value for the random float generation.
        /// </summary>
        public float Max { set; get; }
    }
}
