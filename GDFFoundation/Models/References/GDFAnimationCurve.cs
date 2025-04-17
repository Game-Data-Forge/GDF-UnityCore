

using System;

namespace GDFFoundation
{
    /// <summary>
    /// GDFAnimationCurve is a class representing an animation curve.
    /// </summary>
    [Serializable]
    public class GDFAnimationCurve : GDFDataType
    {
        /// <summary>
        /// Represents a class that stores animation curve values.
        /// </summary>
        private string Values { set; get; } = string.Empty;

        /// <summary>
        /// Generates a random GDFAnimationCurve object.
        /// </summary>
        /// <returns>A new GDFAnimationCurve object with random values.</returns>
        public static GDFAnimationCurve Random()
        {
            return new GDFAnimationCurve()
            {
                Values = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}

