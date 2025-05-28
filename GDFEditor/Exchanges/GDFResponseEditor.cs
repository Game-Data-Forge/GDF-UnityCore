using Newtonsoft.Json;
using GDFFoundation;
using System;

namespace GDFEditor
{
    /// <summary>
    /// Represents a response editor for GDF requests.
    /// </summary>
    public class GDFResponseEditor
    {
        /// <summary>
        /// Represents the status of a request.
        /// </summary>
        //[JsonProperty("Stt")]
        public GDFRequestStatus Status { set; get; } = GDFRequestStatus.None;

        /// <summary>
        /// Represents the kind of exchange in an editor response.
        /// </summary>
        //[JsonProperty("Kin")]
        public GDFExchangeEditorKind Kind { set; get; } = GDFExchangeEditorKind.Unknown;

        /// <summary>
        /// Payload represents the data payload of a response in the GDFResponseEditor class.
        /// </summary>
        //[JsonProperty("Pay")]
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        /// Represents a timestamp used in the GDFResponseEditor class.
        /// </summary>
        //[JsonProperty("Tim")]
        public DateTime Timestamp { set; get; }

        /// <summary>
        /// Gets or sets the duration of the response.
        /// </summary>
        // [JsonProperty("Dur")]
        public int Duration { set; get; }

        /// <summary>
        /// Represents a server response object.
        /// </summary>
        //[JsonProperty("Ser")]
        public string ServerIdentity { set; get; } = string.Empty;

        /// <summary>
        /// Represents the response editor for stamp studio.
        /// </summary>
        //[JsonProperty("Sta")]
        public string StampStudio { set; get; } = string.Empty; //= DWN_Random.RandomStringToken(64);

        /// <summary>
        /// This class represents a response from HashStudio.
        /// </summary>
        //[JsonProperty("HSD")]
        public string HashStudio { set; get; } = string.Empty; //= DWN_Random.RandomStringToken(64);

        /// <summary>
        /// Represents a response object used in the GDFResponseEditor class.
        /// </summary>
        //[JsonProperty("DBG")]
        public string Debug { set; get; } = string.Empty;

        /// <summary>
        /// Represents the role public key associated with a response in the GDFEditor namespace.
        /// </summary>
        public string RolePublicKey { set; get; } = string.Empty;

        /// <summary>
        /// Represents a response from a server.
        /// </summary>
        public GDFResponseEditor()
        {
            Timestamp = GDFDatetime.Now;
        }


        /// <summary>
        /// GDFResponseEditor class is used for creating a response object for GDFEditor.
        /// </summary>
        public GDFResponseEditor(GDFExchangeEditorKind sKind, GDFDownPayloadEditor sDownPayload, GDFRequestStatus sStatus, string sToken)
        {
            Timestamp = GDFDatetime.Now;
            Duration = 0;
            Kind = sKind;
            if (sDownPayload != null)
            {
                SetPayload(sDownPayload);
            }
            Status = sStatus;
            Secure(GDFRandom.RandomStringCypher(32), sToken);
        }

        /// <summary>
        /// GDFResponseEditor is a class that represents a response to an editor exchange.
        /// It is used to handle the response of an editor exchange and contains information such as the timestamp, duration,
        /// response kind, payload, and status.
        /// </summary>
        public GDFResponseEditor(GDFExchangeEditorKind sKind, GDFDownPayloadEditor sDownPayload, GDFRequestStatus sStatus)
        {
            Timestamp = GDFDatetime.Now;
            Duration = 0;
            Kind = sKind;
            if (sDownPayload != null)
            {
                SetPayload(sDownPayload);
            }
            Status = sStatus;
        }

        /// <summary>
        /// Method to set the payload of the GDFResponseEditor object.
        /// </summary>
        /// <param name="sDownPayload">The down payload object to be set as the payload.</param>
        protected void SetPayload(GDFDownPayloadEditor sDownPayload)
        {
            Payload = JsonConvert.SerializeObject(sDownPayload);
        }

        /// <summary>
        /// Return the payload as instance of T
        /// </summary>
        /// <typeparam name="T">The type of the payload to return. It must be a subclass of GDFDownPayloadEditor.</typeparam>
        /// <param name="sToken">The secret token used to secure the payload.</param>
        /// <returns>An instance of the payload as type T if the payload is valid and secured with the given token. Otherwise, returns null.</returns>
        public T GetPayload<T>(string sToken) where T : GDFDownPayloadEditor
        {
            T rReturn = null;
            if (IsValid(sToken))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }
            return rReturn;
        }

        /// <summary>
        /// Generates a hash value using the provided token.
        /// </summary>
        /// <param name="sToken">The token to be used in the hash generation.</param>
        /// <returns>The generated hash value.</returns>
        private string GenerateHash(string sToken)
        {

            string tSalt = sToken;
            string tPayLoadPrint = GDFSecurityTools.GenerateSha(Payload);
            return GDFSecurityTools.GenerateSha(tPayLoadPrint + StampStudio + tSalt + Kind.ToString());

        }

        /// <summary>
        /// Represents a secure response.
        /// </summary>
        private void Secure(string sStamp, string sToken)
        {
            StampStudio = sStamp;
            HashStudio = GenerateHash(sToken);
        }

        /// <summary>
        /// Test if Request is secured with the good hash print
        /// </summary>
        /// <param name="sToken">The secret token used for validating the hash</param>
        /// <returns>True if the request is secured with the correct hash, otherwise false</returns>
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
        /// Logs the status of the GDFResponseEditor object.
        /// </summary>
        /// <param name="sId">Identifier for the log message (default is "from request logger").</param>
        public void Logger(string sId = "from request logger")
        {
            switch (Status)
            {
                case GDFRequestStatus.Ok:
                    GDFLogger.Information(nameof(GDFResponseEditor) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.Error:
                case GDFRequestStatus.None:
                case GDFRequestStatus.NoNetwork:
                    GDFLogger.Error(nameof(GDFResponseEditor) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.ServerIsDisabled:
                case GDFRequestStatus.PleaseChangeServer:
                case GDFRequestStatus.ProjectIsPublishing:
                    GDFLogger.Warning(nameof(GDFResponseEditor) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
            }
        }
    }
}

