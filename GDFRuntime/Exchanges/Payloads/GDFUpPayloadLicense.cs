using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload license for uploading data to the GDF Hub.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadLicense //: GDFUpPayload not necessary
    {
        /// <summary>
        /// Represents the HTTPS DNS property of the GDFUpPayloadLicense class.
        /// </summary>
        public string HttpsDns { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the version of the payload license.
        /// </summary>
        /// <remarks>
        /// This property stores the version of the payload license.
        /// </remarks>
        public string Version { set; get; } = string.Empty;

        /// <summary>
        /// The ProjectReference property represents the unique identifier of a project.
        /// </summary>
        /// <remarks>
        /// This property is used in various classes to identify a specific project.
        /// It is assigned a value from the configuration settings of the project.
        /// </remarks>
        public long ProjectReference { set; get; }
    }
}