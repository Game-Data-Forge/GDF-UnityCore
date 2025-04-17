using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the license information of a down payload.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadLicense //: GDFDownPayload not necessary, don't need services 
    {
        /// <summary>
        /// Gets or sets the success status of the property.
        /// </summary>
        /// <value>
        /// <c>true</c> if the property is successful; otherwise, <c>false</c>.
        /// </value>
        public bool Success { set; get; } = false;

        /// <summary>
        /// Gets or sets the license status.
        /// </summary>
        public GDFLicenseStatus LicenseValid { set; get; } = GDFLicenseStatus.Unknown;

        /// <summary>
        /// Gets or sets the value indicating whether the property needs to be updated.
        /// </summary>
        /// <value>
        /// The current status of the property. Default value is Unknown.
        /// </value>
        public GDFNeedUpdate NeedUpdate { set; get; } = GDFNeedUpdate.Unknown;

        /// <summary>
        /// Gets or sets the version of the property.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { set; get; } = string.Empty;
    }
}