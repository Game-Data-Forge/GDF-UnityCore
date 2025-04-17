

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an asset data used in the GDF system.
    /// </summary>
    [Serializable]
    public class GDFAssetData : IGDFSubModel
    {
        /// <summary>
        /// Represents a Unity asset data.
        /// </summary>
        public string UnityAsset { set; get; } = string.Empty;

        /// <summary>
        /// Generates a random instance of the <see cref="GDFAssetData"/> class.
        /// The generated instance will have a randomly generated Unity asset string.
        /// </summary>
        /// <returns>A random instance of the <see cref="GDFAssetData"/> class.</returns>
        public static GDFAssetData Random()
        {
            return new GDFAssetData()
            {
                UnityAsset = GDFRandom.RandomStringBase64(48)
            };
        }
    }
}


