using System;
using System.Collections.Generic;
using GDFFoundation;
using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public interface IRuntimePlayerPersistanceManager
    {
        public void LoadReference(ITaskHandler handler, List<PlayerReferenceStorage> references);
        public void SaveReference(ITaskHandler handler, List<PlayerReferenceStorage> references);
        
        public void Load(ITaskHandler handler, byte gameSave, List<GDFPlayerDataStorage> data, List<GDFPlayerDataStorage> dataToSync);
        public void Save(ITaskHandler handler, List<GDFPlayerDataStorage> data);

        public void SaveDataToSync(ITaskHandler handler, List<GDFPlayerDataStorage> data);
        public void RemoveDataToSync(ITaskHandler handler, List<GDFPlayerDataStorage> data);
        
        public DateTime LoadSyncDate(ITaskHandler handler);
        public void SaveSyncDate(ITaskHandler handler, DateTime syncDate);

        public void Purge(ITaskHandler handler);
    }
}