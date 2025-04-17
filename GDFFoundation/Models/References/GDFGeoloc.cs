

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a geolocation data type.
    /// </summary>
    [Serializable]
    public class GDFGeolocation : GDFDataType
    {
        /// <summary>
        /// Represents the latitude of a geolocation.
        /// </summary>
        public float Latitude { set; get; }

        /// <summary>
        /// Represents the longitude of a location.
        /// </summary>
        public float Longitude { set; get; }

        /// <summary>
        /// Represents the altitude property of a geolocation.
        /// </summary>
        public float Altitude { set; get; }
    }
}



