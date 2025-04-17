

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents the flags for Navigator OS of a device.
    /// </summary>
    [Serializable]
    [Flags]
    public enum GDFNavigatorOSFlag : int
    {
        /// <summary>
        /// Represents the None member of the GDFNavigatorOSFlag enumeration.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents the Windows operating system flag for the GDFNavigatorOSFlag enum.
        /// </summary>
        Windows = 1,

        /// <summary>
        /// Represents the macOS operating system flag for the GDFNavigatorOSFlag enum.
        /// </summary>
        MacOS = 2,

        /// <summary>
        /// Linux flag representing the Linux operating system for a device.
        /// </summary>
        Linux = 4,


        /// <summary>
        /// Enumerates the operating system flags for GDFNavigator.
        /// </summary>
        iOS = 64,

        /// <summary>
        /// Represents the Android operating system flag of the GDFNavigatorOSFlag enum.
        /// </summary>
        Android = 128,

        /// <summary>
        /// Represents the flag for the Navigator OS of a device that includes all desktop platforms (Windows, MacOS, and Linux).
        /// </summary>
        AllDesktops = Windows | MacOS | Linux,

        /// <summary>
        /// Represents the flag for All Mobiles in the Navigator OS of a device.
        /// </summary>
        AllMobiles = iOS | Android,

        /// <summary>
        /// Represents all the flags for Navigator OS of a device.
        /// </summary>
        All = Windows | MacOS | Linux | iOS | Android
    }
}

