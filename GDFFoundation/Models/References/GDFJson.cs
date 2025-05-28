#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFJson.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a class for serializing and deserializing JSON values.
    /// </summary>
    [Serializable]
    public class GDFJson : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFJson object with a randomly generated value.
        /// </summary>
        /// <returns>A randomly generated GDFJson object.</returns>
        public static GDFJson Random()
        {
            return new GDFJson()
            {
                Value = GDFRandom.RandomStringBase64(48)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a property for storing a JSON string value.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        #endregion
    }
}