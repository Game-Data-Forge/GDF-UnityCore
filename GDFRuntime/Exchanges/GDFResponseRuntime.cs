using Newtonsoft.Json;
using GDFFoundation;
using System;



namespace GDFRuntime
{
    /// <summary>
    /// Represents a response object for runtime data.
    /// </summary>
    [Serializable]
    public class GDFResponseRuntime : GDFBasicResponse
    {
        /// <summary>
        /// Represents the runtime kind of a response.
        /// </summary>
        //[JsonProperty("Kin")]
        public GDFExchangeRuntimeKind RuntimeKind { set; get; } = GDFExchangeRuntimeKind.None;

        /// <summary>
        /// Represents the player token used for authentication and identification purposes.
        /// </summary>
        //[JsonProperty("Pla")]
        public GDFRequestPlayerToken PlayerToken { set; get; } = new GDFRequestPlayerToken();

        /// <summary>
        /// Gets or sets the duration of the runtime data.
        /// </summary>
        //[JsonProperty("Dur")]
        public int Duration { set; get; }

        /// <summary>
        /// Represents a response object for runtime data.
        /// </summary>
        public GDFResponseRuntime()
        {
            Timestamp = GDFTimestamp.Timestamp();
        }

        /// <summary>
        /// Represents a response containing runtime information.
        /// </summary>
        public GDFResponseRuntime(GDFRequestStatus sStatus)
        {
            Timestamp = GDFTimestamp.Timestamp();
            Status = sStatus;
        }

        /// <summary>
        /// Represents a runtime response from the server.
        /// </summary>
        /// <remarks>
        /// This class extends the GDFBasicResponse class and is used for handling runtime responses.
        /// It contains information about the project key manager, player token, runtime kind, payload, status, and error kind.
        /// </remarks>
        /// <example>
        /// <code>
        /// IGDFProjectKey projectKeyManager = new ProjectKeyManager();
        /// GDFRequestPlayerToken playerToken = new RequestPlayerToken();
        /// GDFExchangeRuntimeKind runtimeKind = GDFExchangeRuntimeKind.VersionDevice;
        /// GDFDownPayload? payload = GDFDownPayload.ResponcePayload1;
        /// GDFRequestStatus status = GDFRequestStatus.Success;
        /// GDFSpecificErrorKind errorKind = GDFSpecificErrorKind.None;
        /// GDFResponseRuntime response = new GDFResponseRuntime(projectKeyManager, playerToken, runtimeKind, payload, status, errorKind);
        /// </code>
        /// </example>
        public GDFResponseRuntime(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken, GDFExchangeRuntimeKind sRuntimeKind, GDFDownPayload sPayload, GDFRequestStatus sStatus, GDFSpecificErrorKind sErrorKind)
        {
            Timestamp = GDFTimestamp.Timestamp();
            Duration = 0;
            // if (GDFConfigRuntime.SharedInstance != null)
            // {
            //     ServerIdentity = GDFConfigRuntime.SharedInstance.GetServerIdentity();
            // }

            ProjectReference = sPlayerToken.ProjectReference;
            Environment = sPlayerToken.EnvironmentKind;
            PlayerToken = sPlayerToken;
            RuntimeKind = sRuntimeKind;
            SpecificError = sErrorKind;
            if (sPayload != null)
            {
                SetPayload(sPayload);
            }

            if (string.IsNullOrEmpty(Payload))
            {
                Payload = string.Empty;
            }
            Status = sStatus;
            if (ProjectReference != 0)
            {
                Secure(sProjectKeyManager, GDFRandom.RandomStringCypher(32));
            }
        }

        /// <summary>
        /// Sets the payload for the response.
        /// </summary>
        /// <param name="sPayload">The payload object of type GDFDownPayload.</param>
        protected void SetPayload(GDFDownPayload sPayload)
        {
            Payload = JsonConvert.SerializeObject(sPayload);
        }

        /// <summary>
        /// Returns the payload of type T as an instance of T.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <returns>The payload object of type T, or null if not valid.</returns>
        public T GetPayload<T>(IGDFProjectKey sProjectKeyManager) where T : GDFDownPayload
        {
            T rReturn = null;
            if (IsValid(sProjectKeyManager))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }
            else
            {
                //GDFLogger.Warning("["+IdName+ "] " +nameof (GDFResponseRuntime) +" "+nameof(GetPayload)+" NOT POSSIBLE TO GET OBJECT! for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' " + Payload);
            }
            return rReturn;
        }

        /// <summary>
        /// Generate a hash using the provided project key manager.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager</param>
        /// <returns>The generated hash</returns>
        private string GenerateHash(IGDFProjectKey sProjectKeyManager)
        {
            string rReturn;
            string tPayLoadPrint;
            if (PlayerToken == null)
            {
                PlayerToken = new GDFRequestPlayerToken(ProjectReference, Environment);
            }

            if (Payload == null)
            {
                Payload = string.Empty;
            }
            string tSalt = sProjectKeyManager.GetProjectKey(ProjectReference, Environment);
            if (string.IsNullOrEmpty(tSalt) == false)
            {
                tPayLoadPrint = GDFSecurityTools.GenerateSha(Payload);
                rReturn = GDFSecurityTools.GenerateSha(
                    tPayLoadPrint
                    + Stamp
                    + tSalt
                    + Status.ToString()
                    + RuntimeKind.ToString()
                    + PlayerToken.Token
                    + PlayerToken.AccountRange.ToString()
                    + PlayerToken.EnvironmentKind.ToString()
                    // + PlayerToken.DataTrack
                    );
            }
            else
            {
                rReturn = string.Empty;
                //throw new Exception(sProjectKeyManager.GetProjectKeyInstanceName()+" : "+ nameof(IGDFProjectKey) + "." + nameof(IGDFProjectKey.GetProjectKey) + " return string empty or null!");
            }
            //GDFLogger.Information("["+IdName+ "] " +nameof (GDFResponseRuntime) +"  hash "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"', rReturn = '"+rReturn+"' for message '" + Payload+"'");

            return rReturn;
        }

        /// <summary>
        /// Method to secure the response object by generating a stamp and hash.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sStamp">The stamp to be set.</param>
        protected void Secure(IGDFProjectKey sProjectKeyManager, string sStamp)
        {
            Stamp = sStamp;
            Hash = GenerateHash(sProjectKeyManager);
        }

        /// <summary>
        /// Test if the response object is secured with the correct hash.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <returns>Returns true if the response is secured with the correct hash; otherwise, returns false.</returns>
        public bool IsValid(IGDFProjectKey sProjectKeyManager)
        {
            bool rReturn = false;
            string tHashActual = GenerateHash(sProjectKeyManager);
            if (string.IsNullOrEmpty(Hash) == false)
            {
                if (tHashActual == Hash)
                {
                    rReturn = true;
                }
            }
            if (rReturn == false)
            {
                //GDFLogger.Warning("["+IdName+ "] " +nameof (GDFResponseRuntime) +"." +nameof (IsValid) +" Error  : hash is not valid for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' Hash is '"+Hash+"' and actual generate return '"+tHashActual+"'");
            }
            else
            {
                //GDFLogger.TraceSuccess("["+IdName+ "] " +nameof (GDFResponseRuntime) +"." +nameof (IsValid) +" hash is valid for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' Hash is '"+Hash+"' and actual generate return '"+tHashActual+"'");
            }
            return rReturn;
        }

        /// <summary>
        /// Logs the status of the GDFResponseRuntime object.
        /// </summary>
        /// <param name="sId">The identifier for the log message (default: "from request logger").</param>
        public void Logger(string sId = "from request logger")
        {
            switch (Status)
            {
                case GDFRequestStatus.Ok:
                    //GDFLogger.Information(nameof(GDFResponseRuntime) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.Error:
                case GDFRequestStatus.None:
                case GDFRequestStatus.NoNetwork:
                    //GDFLogger.Error(nameof(GDFResponseRuntime) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
                case GDFRequestStatus.ServerIsDisabled:
                case GDFRequestStatus.PleaseChangeServer:
                case GDFRequestStatus.ProjectIsPublishing:
                    //GDFLogger.Warning(nameof(GDFResponseRuntime) + " [" + sId + "] " + this.Status.ToString(), GDFLogger.SplitObjectSerializable(this));
                    break;
            }
        }
    }
}
