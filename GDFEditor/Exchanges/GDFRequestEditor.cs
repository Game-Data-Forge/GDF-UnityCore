

using System;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFEditor
{
    /// <summary>
    /// Class representing a GDFRequestEditor object.
    /// </summary>
    [Serializable]
    public class GDFRequestEditor
    {
        /// <summary>
        /// The origin of the request in the GDFRequestEditor class.
        /// </summary>
        //[JsonProperty("Ori")]
        public GDFExchangeOrigin Origin { set; get; } = GDFExchangeOrigin.Unknown;

        /// <summary>
        /// Represents a device used for exchanging data.
        /// </summary>
        //[JsonProperty("Dvc")]
        public GDFExchangeDevice Device { set; get; } = GDFExchangeDevice.Unknown;

        /// <summary>
        /// The kind of the request in the GDFRequestEditor class.
        /// </summary>
        //[JsonProperty("Kin")]
        public GDFExchangeEditorKind Kind { set; get; } = GDFExchangeEditorKind.Unknown;

        /// <summary>
        /// Payload property represents the payload of the request.
        /// </summary>
        /// <remarks>
        /// The payload is the data that is being sent in the request. It is stored as a JSON string.
        /// </remarks>
        //[JsonProperty("Pay")]
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp of the request.
        /// </summary>
        //[JsonProperty("Tim")]
        public long Timestamp { set; get; }

        /// <summary>
        /// Represents a StampStudio object used in GDFRequestEditor.
        /// </summary>
        //[JsonProperty("Sta")]
        public string StampStudio { set; get; } = string.Empty; //= DWN_Random.RandomStringToken(64);

        /// <summary>
        /// Represents a request made in HashStudio.
        /// </summary>
        //[JsonProperty("HSD")]
        public string HashStudio { set; get; } = string.Empty; //= DWN_Random.RandomStringToken(64);

        /// <summary>
        /// The public key of the role associated with the request.
        /// </summary>
        public string RolePublicKey { set; get; } = string.Empty;

        /// <summary>
        /// Represents a request editor for JSON data.
        /// </summary>
        public GDFRequestEditor()
        {
            Timestamp = GDFTimestamp.Timestamp();
        }

        /// <summary>
        /// Class representing an editor-level request.
        /// </summary>
        public GDFRequestEditor(string sRolePublicToken, GDFExchangeEditorKind sKind, GDFUpPayloadEditor sUpPayload, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice, string sToken)
        {
            Timestamp = GDFTimestamp.Timestamp();
            RolePublicKey = sRolePublicToken;
            Kind = sKind;
            Origin = sOrigin;
            Device = sDevice;
            if (sUpPayload != null)
            {
                SetPayload(sUpPayload);
            }
            Secure(GDFRandom.RandomStringCypher(32), sToken);
        }

        /// <summary>
        /// Constructor of standard Request not secured
        /// </summary>
        /// <param name="sTest"></param>
        /// <param name="sUpPayload">The payload of the request</param>
        /// <param name="sOrigin">The origin of the request</param>
        /// <param name="sDevice">The device of the request</param>
        private GDFRequestEditor(GDFExchangeEditorKind sTest, GDFUpPayloadEditor sUpPayload, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            Timestamp = GDFTimestamp.Timestamp();
            Kind = sTest;
            Origin = sOrigin;
            Device = sDevice;
            SetPayload(sUpPayload);
        }

        /// <summary>
        /// Sets the payload of the GDFRequestEditor object.
        /// </summary>
        /// <param name="sUpPayload">The payload to be set.</param>
        protected void SetPayload(GDFUpPayloadEditor sUpPayload)
        {
            Payload = JsonConvert.SerializeObject(sUpPayload);
        }

        /// <summary>
        /// Return the payload as instance of T.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <returns>The payload as an instance of T, or null if the payload is not valid or cannot be deserialized.</returns>
        public T GetPayload<T>() where T : GDFUpPayloadEditor
        {
            T rReturn = null;
            // if (IsValid( sCrucialKeyManager))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }
            return rReturn;
        }

        /// <summary>
        /// Generates a hash for the request using the given token.
        /// </summary>
        /// <param name="sToken">The token used to generate the hash.</param>
        /// <returns>The generated hash string.</returns>
        public string GenerateHash(string sToken)
        {
            string tSalt = sToken;
            string tPayLoadPrint = GDFSecurityTools.GenerateSha(Payload);
            return GDFSecurityTools.GenerateSha(tPayLoadPrint + StampStudio + tSalt + Kind.ToString() + Origin.ToString());

        }

        /// <summary>
        /// Generates a secure stamp and hash for the GDFRequestEditor.
        /// </summary>
        /// <param name="sStamp">The secure stamp to be set.</param>
        /// <param name="sToken">The token used to generate the hash.</param>
        public void Secure(string sStamp, string sToken)
        {
            StampStudio = sStamp;
            HashStudio = GenerateHash(sToken);
        }

        /// <summary>
        /// Test if the request is secured with the correct hash.
        /// </summary>
        /// <param name="sToken">The token to generate the hash.</param>
        /// <returns>True if the request is secured with the correct hash, otherwise false.</returns>
        public bool IsValid(string sToken)
        {
            bool rReturn = false;
            if (string.IsNullOrEmpty(HashStudio) == false)
            {
                if (GenerateHash(sToken) == HashStudio)
                {
                    rReturn = true;
                }
            }
            return rReturn;
        }

        /// <summary>
        /// Creates a test request for the GDFRequestEditor class.
        /// </summary>
        /// <param name="sOrigin">The origin of the exchange. Default value is Unknown.</param>
        /// <param name="sDevice">The device of the exchange. Default value is Unknown.</param>
        /// <returns>A new GDFRequestEditor instance with Test exchange kind, empty payload, and the specified origin and device.</returns>
        public static GDFRequestEditor CreateRequestTest(GDFExchangeOrigin sOrigin = GDFExchangeOrigin.Unknown, GDFExchangeDevice sDevice = GDFExchangeDevice.Unknown)
        {
            return new GDFRequestEditor(GDFExchangeEditorKind.Test,
                new GDFUpPayloadEditor(), sOrigin, sDevice);
        }


        /// <summary>
        /// Logs the details of the <see cref="GDFRequestEditor"/> instance and returns a randomly generated string.
        /// </summary>
        /// <returns>A randomly generated string.</returns>
        public string Logger()
        {
            string rReturn = GDFRandom.RandomString(24);
            GDFLogger.Information(nameof(GDFRequestEditor) + " [" + rReturn + "]", GDFLogger.SplitObjectSerializable(this));
            return rReturn;
        }
    }
}

