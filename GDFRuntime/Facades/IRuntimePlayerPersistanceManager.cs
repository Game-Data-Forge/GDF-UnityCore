using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimePlayerPersistanceManager
    {
        public void LoadReference(IJobHandler handler, List<PlayerReferenceStorage> references);
        public void SaveReference(IJobHandler handler, List<PlayerReferenceStorage> references);
        
        public void Load(IJobHandler handler, byte gameSave, List<GDFPlayerDataStorage> data, List<GDFPlayerDataStorage> dataToSync);
        public void Save(IJobHandler handler, List<GDFPlayerDataStorage> data);

        public void SaveDataToSync(IJobHandler handler, List<GDFPlayerDataStorage> data);
        public void RemoveDataToSync(IJobHandler handler, List<GDFPlayerDataStorage> data);
        
        public DateTime LoadSyncDate(IJobHandler handler);
        public void SaveSyncDate(IJobHandler handler, DateTime syncDate);

        public void Purge(IJobHandler handler);
    }
}