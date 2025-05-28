#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFPlan.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public enum GDFPlan
    {
        /// <summary>
        ///     Totally free ... no clusetr, no service, local device only
        /// </summary>
        Disconnected = 0,

        /// <summary>
        ///     pay only active user on standard game
        /// </summary>
        Standard = 1,

        /// <summary>
        ///     pay for your server user on standard game
        /// </summary>
        Dedicated = 2,

        /// <summary>
        ///     pay for your server user on customized model game
        /// </summary>
        Custom = 3,

        /// <summary>
        ///     manage your cluster by yourself
        /// </summary>
        Community = 4,

        /// <summary>
        ///     manage your cluster by yourself
        /// </summary>
        Fork = 5,
    }
}