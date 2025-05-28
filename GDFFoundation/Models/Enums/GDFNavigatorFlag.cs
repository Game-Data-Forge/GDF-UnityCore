#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFNavigatorFlag.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Flag enumeration for different web navigators.
    /// </summary>
    [Serializable]
    [Flags]
    public enum GDFNavigatorFlag : int
    {
        /// <summary>
        ///     Represents the None member of the GDFNavigatorFlag enum.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Enum member Safari of enum GDFNavigatorFlag.
        /// </summary>
        Safari = 1,

        /// <summary>
        ///     Represents the Chrome browser.
        /// </summary>
        Chrome = 2,

        /// <summary>
        ///     Represents the Firefox browser in the GDFNavigatorFlag enumeration.
        /// </summary>
        Firefox = 4,

        /// Represents the Edge browser in the GDFNavigatorFlag enum.
        /// /
        Edge = 8,

        /// <summary>
        ///     Represents a flag for a game in the GDFNavigator.
        /// </summary>
        /// <remarks>
        ///     The GDFNavigatorFlag enum is used to specify whether a game is available in the GDFNavigator.
        /// </remarks>
        Game = 128,

        /// <summary>
        ///     Represents a flag that indicates support for all browsers in the <see cref="GDFNavigatorFlag" /> enum.
        /// </summary>
        AllBrowsers = Safari | Chrome | Firefox | Edge,

        /// <summary>
        ///     Enum representing the flags for <see cref="GDFNavigatorFlag" />. These flags represent different types of browsers.
        /// </summary>
        All = Safari | Chrome | Firefox | Edge | Game
    }
}