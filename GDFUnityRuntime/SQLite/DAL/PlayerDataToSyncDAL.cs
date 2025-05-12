using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GDFFoundation;

namespace GDFUnity
{
    public class PlayerDataToSyncDAL : SQLiteDAL<PlayerDataToSyncDAL, GDFPlayerDataStorage>
    {
        protected struct DALData : IDALData {}

        private PropertyInfo _reference;
        private PropertyInfo _gameSave;
        private DALData _dummy = new DALData();

        public PlayerDataToSyncDAL()
        {
            _reference = _tableType.GetProperty(nameof(GDFPlayerDataStorage.Reference));
            _gameSave = _tableType.GetProperty(nameof(GDFPlayerDataStorage.GameSave));
            _properties = new List<PropertyInfo>()
            {
                _reference,
                _gameSave,
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.ClassName)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Json)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Project)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Account)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Range)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Channels)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.DataVersion)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Creation)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Modification)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.SyncDateTime)),
                _tableType.GetProperty(nameof(GDFPlayerDataStorage.Trashed))
            };
        }

        public void Validate(IJobHandler handler, IDBConnection connection)
        {
            ValidateTable(handler, connection, _dummy);
        }

        public void Get(IJobHandler handler, IDBConnection connection, List<GDFPlayerDataStorage> data)
        {
            Select(handler, connection, _dummy, data);
        }

        public void Record(IJobHandler handler, IDBConnection connection, List<GDFPlayerDataStorage> data)
        {
            InsertOrUpdate(handler, connection, _dummy, data);
        }

        public void Delete(IJobHandler handler, IDBConnection connection, List<GDFPlayerDataStorage> data)
        {
            Delete(handler, connection, _dummy, data);
        }

        protected override string GenerateTableName(IDALData dalData)
        {
            StringBuilder tableName = new StringBuilder(_tableType.Name);
            tableName.Append("_TO_SYNC");
            return tableName.ToString();
        }

        protected override string GenerateCreateTable(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("CREATE TABLE `");
            query.Append(tableName);
            query.Append("` (");

            foreach (PropertyInfo property in _properties)
            {
                query.Append(SQLiteType.Get(property.PropertyType).CreateColumn(property.Name) + ",");
            }
            
            query.Append("PRIMARY KEY(`");
            query.Append(nameof(GDFPlayerDataStorage.Reference));
            query.Append("`,`");
            query.Append(nameof(GDFPlayerDataStorage.GameSave));
            query.Append("`))");

            return query.ToString();
        }

        protected override string GenerateDelete(string tableName, GDFPlayerDataStorage item)
        {
            StringBuilder query = new StringBuilder("DELETE FROM `");
            query.Append(tableName);
            query.Append("` WHERE `");
            query.Append(nameof(GDFPlayerDataStorage.Reference));
            query.Append("`=? AND ;");
            query.Append(nameof(GDFPlayerDataStorage.GameSave));
            query.Append("`=?;");

            return query.ToString();
        }

        protected override void ProcessUpdate(IDBConnection connection, IDALData dalData, GDFPlayerDataStorage data, string tableName)
        {
            int index = 1;
            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(InsertOrUpdate(dalData, tableName, data)))
            {
                foreach (PropertyInfo property in _properties)
                {
                    SQLiteType.Get(property.PropertyType).BindParamter(request, index++, property.GetValue(data));
                }
                
                try
                {
                    request.Exec();
                }
                catch
                {
                    throw SQLiteException.WriteError(request.connection, request.GetResult());
                }
            }
        }
        
        protected override void ProcessDelete(IDBConnection connection, IDALData dalData, GDFPlayerDataStorage data, string tableName)
        {
            int index = 1;
            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(Delete(dalData, tableName, data)))
            {
                SQLiteType.Get(_reference.PropertyType).BindParamter(request, index++, _reference.GetValue(data));
                SQLiteType.Get(_gameSave.PropertyType).BindParamter(request, index++, _gameSave.GetValue(data));

                try
                {
                    request.Exec();
                }
                catch
                {
                    throw SQLiteException.WriteError(request.connection, request.GetResult());
                }
            }
        }
    }
}
