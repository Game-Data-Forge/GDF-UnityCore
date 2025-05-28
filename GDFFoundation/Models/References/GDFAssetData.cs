#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAssetData.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an asset data used in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFAssetData : IGDFSubModel
    {
        #region Static methods

        /// <summary>
        ///     Generates a random instance of the <see cref="GDFAssetData" /> class.
        ///     The generated instance will have a randomly generated Unity asset string.
        /// </summary>
        /// <returns>A random instance of the <see cref="GDFAssetData" /> class.</returns>
        public static GDFAssetData Random()
        {
            return new GDFAssetData()
            {
                UnityAsset = GDFRandom.RandomStringBase64(48)
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a Unity asset data.
        /// </summary>
        public string UnityAsset { set; get; } = string.Empty;

        #endregion
    }
}