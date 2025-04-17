using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Payload for PlayerData write operations
    /// </summary>
    public class PlayerDataExchange
    {
        /// <summary>
        /// The storages to get.
        /// </summary>
        public List<GDFPlayerDataStorage> Storages {  get; set; } = new List<GDFPlayerDataStorage>();
    }
}