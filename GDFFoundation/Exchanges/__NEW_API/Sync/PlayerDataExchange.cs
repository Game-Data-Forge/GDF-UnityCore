#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj PlayerDataExchange.cs create at 2025/04/08 15:04:53
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Payload for PlayerData write operations
    /// </summary>
    public class PlayerDataExchange
    {
        #region Instance fields and properties

        /// <summary>
        ///     The storages to get.
        /// </summary>
        public List<GDFPlayerDataStorage> Storages { get; set; } = new List<GDFPlayerDataStorage>();

        #endregion
    }
}