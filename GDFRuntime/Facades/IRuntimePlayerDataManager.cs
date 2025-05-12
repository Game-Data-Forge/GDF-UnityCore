using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimePlayerDataManager
    {
        public byte GameSave { get; }
        public bool HasDataToSave { get; }
        public bool HasDataToSync { get; }

        public Job LoadCommonGameSave();
        public Job LoadGameSave(byte gameSave);
        public Job DeleteGameSave();

        public void Add(GDFPlayerData data, bool defaultGameSave = false);
        public void Add(string reference, GDFPlayerData data, bool defaultGameSave = false);

        public GDFPlayerData Get(string reference, bool defaultGameSave = false);
        public GDFPlayerData Get(Type type, string reference, bool defaultGameSave = false);

        public T Get<T>(string reference, bool defaultGameSave = false) where T : GDFPlayerData;
        public List<GDFPlayerData> Get(Type type, bool includeInherited = true, bool defaultGameSave = false);
        public List<T> Get<T>(bool includeInherited = true, bool defaultGameSave = false) where T : GDFPlayerData;

        public DataStateInfo GetState(GDFPlayerData data);

        public void AddToSaveQueue(GDFPlayerData data);

        public void Delete(GDFPlayerData data);

        public Job Save();
        public Job Sync();
        
        public Job Purge();
    }
}