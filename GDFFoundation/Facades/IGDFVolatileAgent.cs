using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a volatile agent that provides various information about a session.
    /// </summary>
    public interface IGDFVolatileAgent
    {
        /// <summary>
        /// Gets the session ID.
        /// </summary>
        /// <returns>The session ID.</returns>
        public string GetSession();

        /// <summary>
        /// Retrieves the account reference for the current context.
        /// </summary>
        /// <returns>The account reference.</returns>
        public long GetAccount();

        /// <summary>
        /// Retrieves the device information from the HttpContext headers.
        /// </summary>
        /// <returns>The device information.</returns>
        public string GetDevice();

        /// <summary>
        /// Retrieves the Harvest version.
        /// </summary>
        /// <returns>The Harvest version.</returns>
        public string GetHarvestVersion();

        /// <summary>
        /// Retrieves the project ID.
        /// </summary>
        /// <returns>The project ID.</returns>
        public long GetProjectReference();

        /// <summary>
        /// Gets the language of the current request.
        /// </summary>
        /// <returns>The language of the current request. Returns "Unknown" if the language cannot be determined.</returns>
        public string GetLanguage();

        /// <summary>
        /// Retrieves the Bundle Id.
        /// </summary>
        /// <returns>The Bundle Id string.</returns>
        public string GetBundleId();

        /// <summary>
        /// Get the path of the current request.
        /// </summary>
        /// <returns>The path of the current request.</returns>
        public string GetPath();

        /// <summary>
        /// Gets the value of the data track.
        /// </summary>
        /// <returns>The value of the data track.</returns>
        public Int64 GetDataTrack();

        /// <summary>
        /// Retrieves the origin of the GDF exchange.
        /// </summary>
        /// <returns>The origin of the GDF exchange.</returns>
        public GDFExchangeOrigin GetOrigin();
    }
}


