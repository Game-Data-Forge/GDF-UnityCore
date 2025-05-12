using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GDFFoundation;

namespace GDFUnity
{
    public class SyncDateStorage
    {
        public byte Reference { get; set; }
        public DateTime SyncDate { get; set; }
    }

    public class PlayerSyncDateDAL : SQLiteDAL<PlayerSyncDateDAL, SyncDateStorage>
    {
        private class DALData : IDALData
        {
        }

        private PropertyInfo _reference;
        private DALData _dummy = new DALData();

        public PlayerSyncDateDAL() : base()
        {
            _reference = _tableType.GetProperty(nameof(SyncDateStorage.Reference));
        }

        public void Validate(IJobHandler handler, IDBConnection connection)
        {
            ValidateTable(handler, connection, _dummy);
        }

        public DateTime Get(IJobHandler handler, IDBConnection connection)
        {
            List<SyncDateStorage> data = new List<SyncDateStorage>();
            Select(handler, connection, _dummy, data);

            if (data.Count == 0)
            {
                return DateTime.MinValue;
            }

            return data[0].SyncDate;
        }

        public void Record(IJobHandler handler, IDBConnection connection, DateTime syncTime)
        {
            List<SyncDateStorage> data = new List<SyncDateStorage>()
            {
                new SyncDateStorage
                {
                    Reference = 0,
                    SyncDate = syncTime
                }
            };
            InsertOrUpdate(handler, connection, _dummy, data);
        }

        protected override string GenerateCreateTable(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("CREATE TABLE `");
            query.Append(tableName);
            query.Append("` (");
            
            query.Append(SQLiteType.Get(_properties[0].PropertyType).CreateColumn(_properties[0].Name));
            query.Append(',');
            query.Append(SQLiteType.Get(_properties[1].PropertyType).CreateColumn(_properties[1].Name));
            query.Append(',');
            
            query.Append("PRIMARY KEY(`");
            query.Append(nameof(SyncDateStorage.Reference));
            query.Append("`))");

            return query.ToString();
        }

        protected override string GenerateSelect(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT ");

            query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            query.Append(',');
            query.Append(SQLiteType.Get(_properties[1].PropertyType).SelectColumn(_properties[1].Name));

            query.Append(" FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected override string GenerateInsertOrUpdate(string tableName, SyncDateStorage item)
        {
            StringBuilder query = new StringBuilder("INSERT OR REPLACE INTO `");
            query.Append(tableName);
            query.Append("`(");

            query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            query.Append(',');
            query.Append(SQLiteType.Get(_properties[1].PropertyType).SelectColumn(_properties[1].Name));

            query.Append(") VALUES (?,?);");

            return query.ToString();
        }

        protected override void ProcessUpdate(IDBConnection connection, IDALData dalData, SyncDateStorage data, string tableName)
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

        protected override void ProcessDelete(IDBConnection connection, IDALData dalData, SyncDateStorage data, string tableName)
        {
            int index = 1;
            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(Delete(dalData, tableName, data)))
            {
                SQLiteType.Get(_reference.PropertyType).BindParamter(request, index++, _reference.GetValue(data));

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
