#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFGeoloc.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a geolocation data type.
    /// </summary>
    [Serializable]
    public class GDFGeolocation : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the altitude property of a geolocation.
        /// </summary>
        public float Altitude { set; get; }

        /// <summary>
        ///     Represents the latitude of a geolocation.
        /// </summary>
        public float Latitude { set; get; }

        /// <summary>
        ///     Represents the longitude of a location.
        /// </summary>
        public float Longitude { set; get; }

        #endregion
    }
}