#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFEnvironmentKind.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Define the environment concept :
    ///     <list type="bullet">
    ///         <item>
    ///             <term>
    ///                 <see cref="Development" />
    ///             </term>
    ///             <description> environment to create the game</description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 <see cref="PlayTest" />
    ///             </term>
    ///             <description> environment to parameter the game</description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 <see cref="Preproduction" />
    ///             </term>
    ///             <description> environment to test the release</description>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 <see cref="Production" />
    ///             </term>
    ///             <description> environment to play</description>
    ///         </item>
    ///     </list>
    /// </summary>
    [Serializable]
    public enum ProjectEnvironment
    {
        /// <summary>
        ///     Developers use this environment to create the game
        /// </summary>
        Development = 0,

        /// <summary>
        ///     Level-designers use this environment to parameter the game
        /// </summary>
        PlayTest = 1,

        /// <summary>
        ///     Editors can test Preproduction package in this environment before publish data train package
        /// </summary>
        Preproduction = 2,

        /// <summary>
        ///     Players use this environment to play
        /// </summary>
        Production = 3,
    }
}