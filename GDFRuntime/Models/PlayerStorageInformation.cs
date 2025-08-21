using System;

namespace GDFRuntime
{
    public class PlayerStorageInformation
    {
        public byte Reference { get; set; }
        public DateTime SyncDate { get; set; }
        public int Count => GameSaves.Count;
        
        public GameSaves GameSaves = new GameSaves();
    }
}