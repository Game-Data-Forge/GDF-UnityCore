using System;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a runtime request for GDF.
    /// </summary>
    [Serializable]
    public class GDFRequestRuntime : GDFBasicRequest
    {
        /// <summary>
        /// The Kind property of the GDFRequestRuntime class.
        /// </summary>
        /// <value>
        /// This property represents the exchange runtime kind of the request.
        /// </value>
        //[JsonProperty("Kin")]
        public GDFExchangeRuntimeKind Kind { set; get; }

        /// <summary>
        /// Represents the player token used in a runtime request.
        /// </summary>
        //[JsonProperty("Pla")]
        public GDFRequestPlayerToken PlayerToken { set; get; }

        /// <summary>
        /// Represents a runtime request for the GDF application.
        /// </summary>
        public GDFRequestRuntime()
        {
            Timestamp = GDFTimestamp.Timestamp();
            PlayerToken = new GDFRequestPlayerToken();
        }

        /// <summary>
        /// Represents a runtime request for exchanging data with the server.
        /// </summary>
        /// <remarks>
        /// This class is responsible for creating and managing a runtime request in the GDFRuntime namespace.
        /// It extends the GDFBasicRequest class and implements the IGDFProjectKey interface.
        /// </remarks>
        /// <example>
        /// Here is an example of how to use the GDFRequestRuntime class:
        /// <code>
        /// var projectKeyManager = new GDFProjectKeyManager();
        /// var playerToken = new GDFRequestPlayerToken();
        /// var kind = GDFExchangeRuntimeKind.PlayerToken;
        /// var upPayload = new GDFUpPayload();
        /// var origin = GDFExchangeOrigin.Local;
        /// var device = GDFExchangeDevice.Desktop;
        /// var request = new GDFRequestRuntime(projectKeyManager, playerToken, kind, upPayload, origin, device);
        /// </code>
        /// </example>
        public GDFRequestRuntime(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken, GDFExchangeRuntimeKind sKind,
            GDFUpPayload sUpPayload, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            Timestamp = GDFTimestamp.Timestamp();
            ProjectReference = sPlayerToken.ProjectReference;
            Environment = sPlayerToken.EnvironmentKind;
            PlayerToken = sPlayerToken;
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
            if (ProjectReference != 0)
            {
                Secure(sProjectKeyManager, GDFRandom.RandomStringCypher(32));
            }
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime for testing purposes.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token used for the request.</param>
        /// <param name="sOrigin">The origin of the request, representing where it comes from.</param>
        /// <param name="sDevice">The device used for the request.</param>
        /// <returns>A new instance of GDFRequestRuntime configured for testing purposes.</returns>
        public static GDFRequestRuntime CreateRequestTest(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.Test,
                new GDFUpPayload(), sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with None exchange runtime kind.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sOrigin">The exchange origin.</param>
        /// <param name="sDevice">The exchange device.</param>
        /// <returns>A new instance of GDFRequestRuntime with None exchange runtime kind.</returns>
        public static GDFRequestRuntime CreateRequestNone(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.None,
                new GDFUpPayload(), sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a sign-in request for the GDFRequestRuntime class.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token of the request.</param>
        /// <param name="sAccountSign">The account sign information of the request.</param>
        /// <param name="sOrigin">The origin of the request (e.g. Game, App, Web, UnityEditor).</param>
        /// <param name="sDevice">The device type of the request (e.g. Ios, Android, Macos, Windows, Web).</param>
        /// <returns>A new instance of the GDFRequestRuntime class.</returns>
        public static GDFRequestRuntime CreateRequestSignIn(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFAccountSign sAccountSign, GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignIn,
                new GDFUpPayloadAccountSignIn() { AccountSign = sAccountSign }, sOrigin, sDevice);
        }

        public static GDFRequestRuntime CreateAccountDelete(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.AccountDelete,
                new GDFUpPayload(), sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a sign-up request using the provided parameters.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sAccountSign">The account sign.</param>
        /// <param name="sOrigin">The exchange origin.</param>
        /// <param name="sDevice">The exchange device.</param>
        /// <returns>A new instance of GDFRequestRuntime.</returns>
        public static GDFRequestRuntime CreateRequestSignUp(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFAccountSign sAccountSign, GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignUp,
                new GDFUpPayloadAccountSignUp() { AccountSign = sAccountSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a sign out request.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sDeviceSign">The device sign.</param>
        /// <param name="sOrigin">The exchange origin.</param>
        /// <param name="sDevice">The exchange device.</param>
        /// <returns>A new instance of GDFRequestRuntime.</returns>
        public static GDFRequestRuntime CreateRequestSignOut(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFAccountSign sDeviceSign, GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignOut,
                new GDFUpPayloadAccountSignOut() { DeviceSign = sDeviceSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a request to sign lost in the GDF system.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sRescueEmail">The rescue email.</param>
        /// <param name="sOrigin">The origin of the request.</param>
        /// <param name="sDevice">The device of the request.</param>
        /// <returns>A new instance of GDFRequestRuntime with the specified parameters.</returns>
        public static GDFRequestRuntime CreateRequestSignLost(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken, string sRescueEmail,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignLost,
                new GDFUpPayloadAccountSignLost() { RescueEmail = sRescueEmail }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a request for signing in using account rescue.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sAccountSign">The account sign.</param>
        /// <param name="sOrigin">The exchange origin.</param>
        /// <param name="sDevice">The exchange device.</param>
        /// <returns>A new instance of GDFRequestRuntime for signing in using account rescue.</returns>
        public static GDFRequestRuntime CreateRequestSignRescue(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken, GDFAccountSign sAccountSign, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignRescue, new GDFUpPayloadAccountSignRescue() { AccountSign = sAccountSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new GDFRequestRuntime with GDFExchangeRuntimeKind.SignAdd using the given parameters.
        /// </summary>
        /// <param name="sProjectKeyManager">The IGDFProjectKey to use for the request</param>
        /// <param name="sPlayerToken">The GDFRequestPlayerToken to use for the request</param>
        /// <param name="sAccountSign">The GDFAccountSign to add to the request</param>
        /// <param name="sOrigin">The GDFExchangeOrigin of the request</param>
        /// <param name="sDevice">The GDFExchangeDevice of the request</param>
        /// <returns>A new GDFRequestRuntime instance with GDFExchangeRuntimeKind.SignAdd</returns>
        public static GDFRequestRuntime CreateRequestSignAdd(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken, GDFAccountSign sAccountSign, GDFExchangeOrigin sOrigin, GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignAdd, new GDFUpPayloadAccountSignAdd() { AccountSign = sAccountSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with GDFExchangeRuntimeKind.SignModify.
        /// </summary>
        /// <param name="sProjectKeyManager">The IGDFProjectKey object to manage the project key.</param>
        /// <param name="sPlayerToken">The GDFRequestPlayerToken object representing the player token.</param>
        /// <param name="sOldAccountSign">The GDFAccountSign object representing the old account sign.</param>
        /// <param name="sNewAccountSign">The GDFAccountSign object representing the new account sign.</param>
        /// <param name="sOrigin">The GDFExchangeOrigin enum representing the exchange origin.</param>
        /// <param name="sDevice">The GDFExchangeDevice enum representing the exchange device.</param>
        /// <returns>The created GDFRequestRuntime instance.</returns>
        public static GDFRequestRuntime CreateRequestSignModify(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFAccountSign sOldAccountSign, GDFAccountSign sNewAccountSign,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignModify,
                new GDFUpPayloadAccountSignModify()
                { OldAccountSign = sOldAccountSign, NewAccountSign = sNewAccountSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of the GDFRequestRuntime class with the specified parameters and returns it.
        /// </summary>
        /// <param name="sProjectKeyManager">The IGDFProjectKey instance to be used for the request.</param>
        /// <param name="sPlayerToken">The GDFRequestPlayerToken instance to be used for the request.</param>
        /// <param name="sAccountSign">The GDFAccountSign instance for which the signature delete request is to be created.</param>
        /// <param name="sOrigin">The GDFExchangeOrigin value indicating the origin of the request.</param>
        /// <param name="sDevice">The GDFExchangeDevice value indicating the device associated with the request.</param>
        /// <returns>A new instance of the GDFRequestRuntime class representing a signature delete request.</returns>
        public static GDFRequestRuntime CreateRequestSignDelete(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFAccountSign sAccountSign, GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SignDelete,
                new GDFUpPayloadAccountSignDelete() { AccountSign = sAccountSign }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a request to check if an email exists.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sEmail">The email to check.</param>
        /// <param name="sOrigin">The origin of the request.</param>
        /// <param name="sDevice">The device of the request.</param>
        /// <returns>A new instance of GDFRequestRuntime with the specified parameters.</returns>
        public static GDFRequestRuntime CreateRequestCheckIfEmailExist(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            string sEmail, GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.CheckIfEmailIsUsed,
                new GDFUpPayloadCheckIfEmailIsUsed(GDFAccountSign.GenerateHashRescue(sEmail,sPlayerToken.ProjectReference)) {  }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a runtime request to get all signs.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sOrigin">The origin of the exchange.</param>
        /// <param name="sDevice">The device of the exchange.</param>
        /// <returns>A new instance of GDFRequestRuntime for getting all signs.</returns>
        public static GDFRequestRuntime CreateRequestGetAllSign(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.GetAllSign,
                new GDFUpPayloadAccountSignAll() { }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with the provided parameters.
        /// </summary>
        /// <param name="sProjectKeyManager">An object implementing the IGDFProjectKey interface that manages the project key.</param>
        /// <param name="sPlayerToken">An instance of GDFRequestPlayerToken representing the player token.</param>
        /// <param name="sUpPayloadDataSyncByIncrement">An instance of GDFUpPayloadDataSyncByIncrement representing the payload for sync by increment.</param>
        /// <param name="sOrigin">An enum value of GDFExchangeOrigin representing the origin of the request.</param>
        /// <param name="sDevice">An enum value of GDFExchangeDevice representing the device used for the request.</param>
        /// <returns>A new instance of GDFRequestRuntime for sync data by increment.</returns>
        public static GDFRequestRuntime CreateRequestSyncDataByIncrement(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFUpPayloadDataSyncByIncrement sUpPayloadDataSyncByIncrement
            , GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.SyncDataByIncrement,
                sUpPayloadDataSyncByIncrement, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of the GDFRequestRuntime class for getting all player data.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token for authentication.</param>
        /// <param name="sOrigin">The origin of the request.</param>
        /// <param name="sDevice">The device in which the request is coming from.</param>
        /// <returns>A new instance of the GDFRequestRuntime class configured for getting all player data.</returns>
        public static GDFRequestRuntime CreateGetAllPlayerData(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.GetAllPlayerData,
                new GDFUpPayloadDataSyncByIncrement() { }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with the provided parameters for creating a relationship.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="sOrigin">The exchange origin.</param>
        /// <param name="sDevice">The exchange device.</param>
        /// <returns>A new instance of GDFRequestRuntime with the specified parameters.</returns>
        public static GDFRequestRuntime CreateRequestCreateRelationship(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice)
        {

            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.CreateRelationship,
                new GDFUpPayloadDataSyncByIncrement() { }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with the given parameters and GDFExchangeRuntimeKind.LinkRelationship.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token used for the request.</param>
        /// <param name="sOrigin">The origin of the request.</param>
        /// <param name="sDevice">The device making the request.</param>
        /// <param name="sCode">The code used to link the relationships.</param>
        /// <returns>A new instance of GDFRequestRuntime with GDFExchangeRuntimeKind.LinkRelationship.</returns>
        public static GDFRequestRuntime CreateRequestLinkRelationship(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice,
            string sCode
        )
        {

            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.LinkRelationship,
                new GDFUpPayloadLinkRelationship(sCode) { }, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of the GDFRequestRuntime class with the given parameters to finalize a relationship.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token of the request.</param>
        /// <param name="sOrigin">The origin of the request as one of the values from the GDFExchangeOrigin enum.</param>
        /// <param name="sDevice">The device of the request as one of the values from the GDFExchangeDevice enum.</param>
        /// <param name="sRelationship">The relationship to be finalized.</param>
        /// <param name="sIsAccepted">A boolean value indicating whether the relationship is accepted or not.</param>
        /// <returns>A new instance of the GDFRequestRuntime class with the given parameters to finalize the relationship.</returns>
        public static GDFRequestRuntime CreateRequestFinalizeRelationship(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice,
            GDFRelationship sRelationship,
            bool sIsAccepted
        )
        {

            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.FinalizeRelationship,
                new GDFUpPayloadFinalizeRelationship(sRelationship.Reference, sIsAccepted) { }, sOrigin, sDevice);
        }
        
        /// <summary>
        /// Creates a new instance of GDFRequestRuntime with the provided parameters for retrieving relationships.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface.</param>
        /// <param name="sPlayerToken">The player token instance of GDFRequestPlayerToken class.</param>
        /// <param name="sOrigin">The exchange origin enumeration value of GDFExchangeOrigin.</param>
        /// <param name="sDevice">The exchange device enumeration value of GDFExchangeDevice.</param>
        /// <returns>A new instance of GDFRequestRuntime for retrieving relationships.</returns>
        public static GDFRequestRuntime CreateRequestGetRelationships(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice
        )
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.GetRelationship,
                new GDFUpPayload(), sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new GDFRequestRuntime for getting relationships.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager.</param>
        /// <param name="sPlayerToken">The player token.</param>
        /// <param name="uUpPayloadGetRelationship">The payload for getting relationships.</param>
        /// <param name="sOrigin">The origin of the request.</param>
        /// <param name="sDevice">The device for the request.</param>
        /// <returns>A new instance of GDFRequestRuntime for getting relationships.</returns>
        public static GDFRequestRuntime CreateRequestGetRelationships(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFUpPayloadGetRelationship uUpPayloadGetRelationship,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice
        )
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.GetRelationship,
                uUpPayloadGetRelationship, sOrigin, sDevice);
        }

        /// <summary>
        /// Creates a new instance of GDFRequestRuntime for updating a relationship.
        /// </summary>
        /// <param name="sProjectKeyManager">The IGDFProjectKey instance representing the project key manager.</param>
        /// <param name="sPlayerToken">The GDFRequestPlayerToken instance representing the player token.</param>
        /// <param name="sOrigin">The GDFExchangeOrigin value representing the origin of the request.</param>
        /// <param name="sDevice">The GDFExchangeDevice value representing the device of the request.</param>
        /// <param name="sRelationship">The GDFRelationship instance representing the relationship to update.</param>
        /// <returns>A new instance of GDFRequestRuntime for updating a relationship.</returns>
        public static GDFRequestRuntime CreateRequestUpdateRelationship(IGDFProjectKey sProjectKeyManager, GDFRequestPlayerToken sPlayerToken,
            GDFExchangeOrigin sOrigin,
            GDFExchangeDevice sDevice, GDFRelationship sRelationship
        )
        {
            return new GDFRequestRuntime(sProjectKeyManager, sPlayerToken, GDFExchangeRuntimeKind.UpdateRelationship,
                new GDFUpPayloadUpdateRelationship(sRelationship), sOrigin, sDevice);
        }

        /// <summary>
        /// Sets the payload of the request.
        /// </summary>
        /// <param name="sUpPayload">The payload to be set.</param>
        public void SetPayload(GDFUpPayload sUpPayload)
        {
            Payload = JsonConvert.SerializeObject(sUpPayload);
        }

        /// <summary>
        /// Return the payload as instance of T
        /// </summary>
        /// <typeparam name="T">The type of payload object</typeparam>
        /// <param name="sProjectKeyManager">The project key manager implementing the IGDFProjectKey interface</param>
        /// <returns>An instance of T if the payload is valid and can be deserialized, otherwise null</returns>
        public T GetPayload<T>(IGDFProjectKey sProjectKeyManager) where T : GDFUpPayload
        {
            T rReturn = null;
            if (IsValid(sProjectKeyManager))
            {
                rReturn = JsonConvert.DeserializeObject<T>(Payload);
            }
            else
            {
                //GDFLogger.Warning("["+IdName+ "] " +nameof (GDFRequestRuntime) +" "+nameof(GetPayload)+" NOT POSSIBLE TO GET OBJECT! for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' " + Payload);
            }
            return rReturn;
        }

        /// <summary>
        /// Generates the hash value for the current GDFRequestRuntime object.
        /// </summary>
        /// <param name="sProjectKeyManager">An instance of the IGDFProjectKey interface.</param>
        /// <returns>The generated hash value as a string.</returns>
        protected string GenerateHash(IGDFProjectKey sProjectKeyManager)
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
                    + Kind.ToString()
                    + PlayerToken.Token
                    + PlayerToken.AccountRange.ToString()
                    + PlayerToken.EnvironmentKind.ToString()
                    + Origin.ToString()
                    // + PlayerToken.DataTrack.ToString())
                    );
            }
            else
            {
                throw new Exception("Project : '"+sProjectKeyManager.GetProjectKeyInstanceName()+"' : "+ nameof(IGDFProjectKey) + "." + nameof(IGDFProjectKey.GetProjectKey) + " return string empty or null for Environment : "+Environment.ToString()+"!");
                //return string.Empty;
            }

            //GDFLogger.Information("["+IdName+ "] " +nameof (GDFRequestRuntime) +"  hash "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"', rReturn = '"+rReturn+"' for message '" + Payload);
            return rReturn;
        }

        /// <summary>
        /// Sets the Stamp property to the provided sStamp value and generates the Hash based on the sProjectKeyManager.
        /// </summary>
        /// <param name="sProjectKeyManager">The project key manager object implementing the IGDFProjectKey interface.</param>
        /// <param name="sStamp">The stamp value to set.</param>
        public void Secure(IGDFProjectKey sProjectKeyManager, string sStamp)
        {
            Stamp = sStamp;
            Hash = GenerateHash(sProjectKeyManager);
        }

        /// <summary>
        /// Test if Request is secured with the good hash print
        /// </summary>
        /// <param name="sProjectKeyManager">The IGDFProjectKey instance used for checking hash validity</param>
        /// <returns>True if the hash is valid for the request, false otherwise</returns>
        public bool IsValid(IGDFProjectKey sProjectKeyManager)
        {
            bool rReturn = false;
            string tHashActual = GenerateHash(sProjectKeyManager);
            if (string.IsNullOrEmpty(Hash) == false)
            {
                if (tHashActual == Hash)
                {
                    if (PlayerToken.ProjectReference == ProjectReference)
                    {
                        rReturn = true;
                    }
                }
            }
            if (rReturn == false)
            {
                GDFLogger.Warning("["+IdName+ "] " +nameof (GDFRequestRuntime) +"." +nameof (IsValid) +" Error  : hash is not valid for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' Hash is '"+Hash+"' and actual generate return '"+tHashActual+"'");
            }
            else
            {
                //GDFLogger.TraceSuccess("["+IdName+ "] " +nameof (GDFRequestRuntime) +"." +nameof (IsValid) +" hash is valid for "+ProjectReference+" "+Environment.ToString()+" (player token "+ProjectReference+" "+Environment.ToString()+") with salt result  '" +sProjectKeyManager.GetProjectKey(PlayerToken.ProjectReference, PlayerToken.EnvironmentKind)+"' Hash is '"+Hash+"' and actual generate return '"+tHashActual+"'");
            }
            return rReturn;
        }

        /// <summary>
        /// Method to log a URL.
        /// </summary>
        /// <param name="sUrl">The URL to be logged.</param>
        /// <returns>Returns a randomly generated string.</returns>
        public string Logger(string sUrl)
        {
            string rReturn = GDFRandom.RandomString(24);
            //GDFLogger.Information(nameof(GDFRequestRuntime) + " ["+rReturn+"] ", sUrl);
            //GDFLogger.Information(nameof(GDFRequestRuntime) + " ["+rReturn+"] ", GDFLogger.SplitObjectSerializable(this));
            return rReturn;
        }
    }
}
