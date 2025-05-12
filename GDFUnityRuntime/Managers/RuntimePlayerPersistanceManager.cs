using System;
using System.Collections.Generic;
using System.IO;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class RuntimePlayerPersistanceManager : IRuntimePlayerPersistanceManager
    {
        private string _root;
        private SQLiteDbConnection _connection = null;
        private IRuntimeEngine _engine;

        public RuntimePlayerPersistanceManager(IRuntimeEngine engine)
        {
            _engine = engine;
            _engine.AuthenticationManager.AccountChangedNotif.onBackgroundThread += OnAccountChanged;
        }
        
        ~RuntimePlayerPersistanceManager()
        {
            _engine.AuthenticationManager.AccountChangedNotif.onBackgroundThread -= OnAccountChanged;
        }

        public void LoadReference(IJobHandler handler, List<PlayerReferenceStorage> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            handler.StepAmount = 2;
            using (IDBConnection connection = _connection.Open())
            {
                PlayerReferenceDAL.Instance.Validate(handler.Split(), _connection);
                PlayerReferenceDAL.Instance.Get(handler.Split(), _connection, references);
            }
        }
        
        public void SaveReference(IJobHandler handler, List<PlayerReferenceStorage> references)
        {
            if (references == null)
            {
                return;
            }

            handler.StepAmount = 2;
            using (IDBConnection connection = _connection.Open())
            {
                PlayerReferenceDAL.Instance.Validate(handler.Split(), _connection);
                PlayerReferenceDAL.Instance.Record(handler.Split(), _connection, references);
            }
        }

        public void Load(IJobHandler handler, byte gameSave, List<GDFPlayerDataStorage> data, List<GDFPlayerDataStorage> dataToSync)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            handler.StepAmount = 4;
            using (IDBConnection connection = _connection.Open())
            {
                PlayerDataDAL.Instance.Validate(handler.Split(), _connection, gameSave);
                PlayerDataToSyncDAL.Instance.Validate(handler.Split(), _connection);

                if (dataToSync != null)
                {
                    PlayerDataToSyncDAL.Instance.Get(handler.Split(), _connection, dataToSync);
                }
                else
                {
                    handler.Step();
                }

                PlayerDataDAL.Instance.Get(handler.Split(), _connection, data, gameSave);
            }
        }

        public void Save(IJobHandler handler, List<GDFPlayerDataStorage> storages)
        {
            if (storages == null)
            {
                return;
            }

            Dictionary<byte, List<GDFPlayerDataStorage>> cache = SplitStoragesByGameSave(storages);

            handler.StepAmount = cache.Count * 2 + 2;
            using (IDBConnection connection = _connection.Open())
            {
                foreach (KeyValuePair<byte, List<GDFPlayerDataStorage>> pair in cache)
                {
                    PlayerDataDAL.Instance.Validate(handler.Split(), _connection, pair.Key);
                    PlayerDataDAL.Instance.Record(handler.Split(), _connection, pair.Value, pair.Key);
                }
            }
        }

        public void SaveDataToSync(IJobHandler handler, List<GDFPlayerDataStorage> storages)
        {
            handler.StepAmount = 2;
            using (IDBConnection connection = _connection.Open())
            {
                PlayerDataToSyncDAL.Instance.Validate(handler.Split(), _connection);
                PlayerDataToSyncDAL.Instance.Record(handler.Split(), _connection, storages);
            }
        }
        
        public void RemoveDataToSync(IJobHandler handler, List<GDFPlayerDataStorage> storages)
        {
            if (storages == null)
            {
                return;
            }

            using (IDBConnection connection = _connection.Open())
            {
                PlayerDataToSyncDAL.Instance.Validate(handler.Split(), _connection);
                PlayerDataToSyncDAL.Instance.Delete(handler.Split(), connection, storages);
            }
        }

        public DateTime LoadSyncDate(IJobHandler handler)
        {
            using (IDBConnection connection = _connection.Open())
            {
                PlayerSyncDateDAL.Instance.Validate(handler.Split(), _connection);
                return PlayerSyncDateDAL.Instance.Get(handler.Split(), connection);
            }
        }

        public void SaveSyncDate(IJobHandler handler, DateTime syncDate)
        {
            using (IDBConnection connection = _connection.Open())
            {
                PlayerSyncDateDAL.Instance.Validate(handler.Split(), _connection);
                PlayerSyncDateDAL.Instance.Record(handler.Split(), connection, syncDate);
            }
        }

        public void Purge(IJobHandler handler)
        {
            string path = GetFilePath(_engine.AuthenticationManager.Token);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private Dictionary<byte, List<GDFPlayerDataStorage>> SplitStoragesByGameSave(IEnumerable<GDFPlayerDataStorage> storages)
        {
            Dictionary<byte, List<GDFPlayerDataStorage>> dictionary = new Dictionary<byte, List<GDFPlayerDataStorage>>();

            foreach (GDFPlayerDataStorage storage in storages)
            {
                List<GDFPlayerDataStorage> list;
                if (!dictionary.TryGetValue(storage.GameSave, out list))
                {
                    list = new List<GDFPlayerDataStorage>();
                    dictionary.Add(storage.GameSave, list);
                }
                list.Add(storage);
            }

            return dictionary;
        }

        private void OnAccountChanged(IJobHandler handler, MemoryJwtToken token)
        {
            if (token == null)
            {
                return;
            }

            handler.StepAmount = 2;

            string path = GetFilePath(token);

            handler.Step();

            _connection = new SQLiteDbConnection(path);
        }

        private string GetFilePath(MemoryJwtToken token)
        {
            _root = Path.Combine(GDFUserSettings.Instance.GetDataPath(_engine.Configuration.Reference), token.Account.ToString());
            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            return Path.Combine(_root, $"PlayerData.save");
        }
    }
}