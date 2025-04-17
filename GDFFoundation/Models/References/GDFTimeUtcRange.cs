

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a range of UTC time.
    /// </summary>
    [Serializable]
    public class GDFTimeUtcRange : GDFDataType
    {
        /// <summary>
        /// Gets or sets the minimum value for the GDFTimeUtcRange.
        /// </summary>
        /// <remarks>
        /// This property represents the minimum value for the GDFTimeUtcRange class.
        /// It specifies the lower bound of the range.
        /// </remarks>
        public int Min { set; get; } = 0;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Max { set; get; } = 0;
    }
}


