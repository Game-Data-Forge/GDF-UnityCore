#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAnimationCurve.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     GDFAnimationCurve is a class representing an animation curve.
    /// </summary>
    [Serializable]
    public class GDFAnimationCurve : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFAnimationCurve object.
        /// </summary>
        /// <returns>A new GDFAnimationCurve object with random values.</returns>
        public static GDFAnimationCurve Random()
        {
            return new GDFAnimationCurve()
            {
                Values = GDFRandom.RandomStringBase64(48)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a class that stores animation curve values.
        /// </summary>
        private string Values { set; get; } = string.Empty;

        #endregion
    }
}