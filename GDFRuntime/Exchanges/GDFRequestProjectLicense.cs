

using System;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFRequestProjectLicense class represents a request for a project license.
    /// </summary>
    [Serializable]
    public class GDFRequestProjectLicense : GDFBasicRequest
    {
        /// <summary>
        /// Kind of request.
        /// </summary>
        // [JsonProperty(PropertyName ="KIN")]
        public GDFExchangeLicenseKind Kind { set; get; } = GDFExchangeLicenseKind.Unknown;

        /// <summary>
        /// Represents a request for a project license.
        /// </summary>
        public GDFRequestProjectLicense()
        {
            Timestamp = GDFTimestamp.Timestamp();
        }

        /// <summary>
        /// Represents a request for a project license.
        /// </summary>
        public GDFRequestProjectLicense(IGDFProjectKey sProjectKeyManager, long sProjectReference, ProjectEnvironment sEnvironment, GDFExchangeLicenseKind sKind, GDFUpPayloadLicense sUpPayload, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            ProjectReference = sProjectReference;
            Environment = sEnvironment;
            Timestamp = GDFTimestamp.Timestamp();
            Kind = sKind;
            Origin = sOrigin;
            Device = sDevice;
            if (sUpPayload != null)
            {
                SetPayload(sUpPayload);
            }

            if (string.IsNullOrEmpty(Payload))
            {
                Payload = string.Empty;
            }

            Secure(sProjectKeyManager, GDFRandom.RandomStringCypher(32));
        }

        /// <summary>
        /// Set the payload value for the request.
        /// </summary>
        /// <param name="sUpPayload">The payload license object.</param>
        protected void SetPayload(GDFUpPayloadLicense sUpPayload)
        {
            Payload = JsonConvert.SerializeObject(sUpPayload);
        }

        /// <summary>
        /// Return the payload as an instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <returns>The payload as an instance of type T.</returns>
        public T GetPayload<T>(IGDFProjectKey sProjectKeyManager) where T : GDFUpPayloadLicense
        {
            T rReturn = null;
            if (IsValid(sProjectKeyManager))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }

            return rReturn;
        }

        /// <summary>
        /// Generates a hash for the current instance using the provided project key manager.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager to use for generating the hash.</param>
        /// <returns>The generated hash.</returns>
        public string GenerateHash(IGDFProjectKey sProjectKeyManager)
        {
            string tSalt = sProjectKeyManager.GetProjectKey(ProjectReference, Environment);
            if (string.IsNullOrEmpty(tSalt) == false)
            {
                string tPayLoadPrint = GDFSecurityTools.GenerateSha(Payload);
                string tHash = GDFSecurityTools.GenerateSha(tPayLoadPrint + Stamp + tSalt + Kind.ToString() + Origin.ToString());
                return tHash;
            }
            else
            {
                throw new Exception(sProjectKeyManager.GetProjectKeyInstanceName() + " : " + nameof(IGDFProjectKey) + "." + nameof(IGDFProjectKey.GetProjectKey) + " return string empty or null!");
            }
        }

        /// <summary>
        /// Secure the request by generating a stamp and hash based on the project key and the current timestamp.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface</param>
        /// <param name="sStamp">The stamp to be used for securing the request</param>
        public void Secure(IGDFProjectKey sProjectKeyManager, string sStamp)
        {
            Stamp = sStamp;
            Hash = GenerateHash(sProjectKeyManager);
        }

        /// <summary>
        /// Test if Request is secured with the good hash print
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager used to generate the project key</param>
        /// <returns>True if the request is secured with the correct hash, otherwise false</returns>
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
            else
            {
                GDFLogger.Warning(nameof(Hash) + " is empty");
            }

            return rReturn;
        }

        /// <summary>
        /// Create a request object for project license with provided parameters.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sEnvironment">The environment of the project.</param>
        /// <param name="sOrigin">The origin of the request. (Optional, default: Unknown)</param>
        /// <param name="sDevice">The device of the request. (Optional, default: Unknown)</param>
        /// <returns>A new instance of GDFRequestProjectLicense with the specified parameters.</returns>
        public static GDFRequestProjectLicense CreateRequestTest(IGDFProjectKey sProjectKeyManager, long sProjectReference, ProjectEnvironment sEnvironment, GDFExchangeOrigin sOrigin = GDFExchangeOrigin.Unknown, GDFExchangeDevice sDevice = GDFExchangeDevice.Unknown)
        {
            return new GDFRequestProjectLicense(sProjectKeyManager, sProjectReference, sEnvironment, GDFExchangeLicenseKind.Test, new GDFUpPayloadLicense(), sOrigin, sDevice);
        }

        /// <summary>
        /// Logs information about the request and returns a randomly generated string.
        /// </summary>
        /// <returns>A randomly generated string.</returns>
        public string Logger()
        {
            string rReturn = GDFRandom.RandomString(24);
            GDFLogger.Information(nameof(GDFRequestProjectLicense) + " [" + rReturn + "]", GDFLogger.SplitObjectSerializable(this));
            return rReturn;
        }
    }
}

