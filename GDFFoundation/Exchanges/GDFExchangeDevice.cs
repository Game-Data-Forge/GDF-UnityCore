

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Enumeration representing the exchange device used for communication.
    /// </summary>
    [Serializable]
    public enum GDFExchangeDevice
    {
        /// <summary>
        /// Enumeration representing an unknown exchange device used for communication.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The enum member representing the iOS exchange device used for communication.
        /// </summary>
        Ios = 11,

        /// <summary>
        /// The Android enum member represents the exchange device used for communication specifically on Android devices.
        /// </summary>
        Android = 12,

        /// <summary>
        /// Macos is an exchange device used for communication.
        /// </summary>
        Macos = 21,

        /// <summary>
        /// Represents a Windows exchange device member of the GDFExchangeDevice enumeration.
        /// </summary>
        Windows = 22,

        /// <summary>
        /// Linux exchange device used for communication.
        /// </summary>
        Linux = 23,

        /// <summary>
        /// Represents a Web device.
        /// </summary>
        Web = 41,

        /// <summary>
        /// Enumeration member representing an error in the exchange device used for communication.
        /// </summary>
        Error = 128,
    }
}

