

using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a response for a project license request.
    /// </summary>
    public class GDFResponseProjectLicense : GDFBasicResponse
    {
        /// <summary>
        /// Gets or sets the kind of the GDF exchange license.
        /// </summary>
        /// <remarks>
        /// The GDF exchange license kind is used to determine the type of license for the GDF exchange.
        /// </remarks>
        public GDFExchangeLicenseKind Kind { set; get; } = GDFExchangeLicenseKind.Unknown;

        /// <summary>
        /// Constructor for GDFResponseProjectLicense class.
        /// </summary>
        public GDFResponseProjectLicense()
        {
            Timestamp = GDFTimestamp.Timestamp();
        }

        /// <summary>
        /// Represents a response to a project license request.
        /// </summary>
        public GDFResponseProjectLicense(IGDFProjectKey sProjectKeyManager, long sProjectReference, ProjectEnvironment sEnvironment, GDFExchangeLicenseKind sKind, GDFDownPayloadLicense sDownPayload, GDFRequestStatus sStatus)
        {
            ProjectReference = sProjectReference;
            Environment = sEnvironment;
            Timestamp = GDFTimestamp.Timestamp();
            Kind = sKind;
            if (sDownPayload != null)
            {
                SetPayload(sDownPayload);
            }
            if (string.IsNullOrEmpty(Payload))
            {
                Payload = string.Empty;
            }
            Status = sStatus;
            Secure(sProjectKeyManager, GDFRandom.RandomStringCypher(32));
        }

        /// <summary>
        /// Sets the payload value for the given GDFDownPayloadLicense object.
        /// </summary>
        /// <param name="sDownPayload">The GDFDownPayloadLicense object to set the payload from.</param>
        protected void SetPayload(GDFDownPayloadLicense sDownPayload)
        {
            Payload = JsonConvert.SerializeObject(sDownPayload);
        }

        /// <summary>
        /// Return the payload as an instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <returns>The payload as an instance of type T, or null if the payload is not valid or cannot be deserialized.</returns>
        public T GetPayload<T>(IGDFProjectKey sProjectKeyManager) where T : GDFDownPayloadLicense
        {
            T rReturn = null;
            if (IsValid(sProjectKeyManager))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }
            return rReturn;
        }

        /// <summary>
        /// Generates a hash for the given project key manager.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <returns>The generated hash.</returns>
        private string GenerateHash(IGDFProjectKey sProjectKeyManager)
        {
            string tSalt = sProjectKeyManager.GetProjectKey(ProjectReference, Environment);
            if (string.IsNullOrEmpty(tSalt) == false)
            {
                string tPayLoadPrint = GDFSecurityTools.GenerateSha(Payload);
                return GDFSecurityTools.GenerateSha(tPayLoadPrint + Stamp + tSalt + Kind.ToString());
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Secure method that generates a hash based on the given project key and stamp
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager instance used to generate the hash</param>
        /// <param name="sStamp">The stamp used to generate the hash</param>
        private void Secure(IGDFProjectKey sProjectKeyManager, string sStamp)
        {
            Stamp = sStamp;
            Hash = GenerateHash(sProjectKeyManager);
        }

        /// <summary>
        /// Test if Request is secured with the specified hash print.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager that will be used to generate the hash print.</param>
        /// <returns>True if the request is secured with the correct hash print, otherwise false.</returns>
        public bool IsValid(IGDFProjectKey sProjectKeyManager)
        {
            bool rReturn = false;
            if (string.IsNullOrEmpty(Hash) == false)
            {
                if (GenerateHash(sProjectKeyManager) == Hash)
                {
                    rReturn = true;
                }
            }

            return rReturn;
        }

        /// <summary>
        /// Method for logging the status of a request.
        /// </summary>
        /// <param name="sId">Optional string identifier for the logger. Default value is "from request logger".</param>
        public void Logger(string sId = "from request logger")
        {
            switch (Status)
            {
                case GDFRequestStatus.Ok:
                    //GDFLogger.Information(nameof(GDFResponseProjectLicense) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.Error:
                case GDFRequestStatus.None:
                case GDFRequestStatus.NoNetwork:
                    //GDFLogger.Error(nameof(GDFResponseProjectLicense) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.ServerIsDisabled:
                case GDFRequestStatus.PleaseChangeServer:
                case GDFRequestStatus.ProjectIsPublishing:
                    //GDFLogger.Warning(nameof(GDFResponseProjectLicense) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
            }
        }
    }
}
