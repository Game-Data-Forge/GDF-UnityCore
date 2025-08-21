using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class PlayerSyncDateDAL : SQLiteDAL<PlayerSyncDateDAL, PlayerStorageInformation>
    {
        private object _lock = new object();
        private const string _GameSaves = "GamesSaves";
        private PropertyInfo _reference;

        public PlayerSyncDateDAL() : base()
        {
            _reference = _tableType.GetProperty(nameof(PlayerStorageInformation.Reference));
        }

        public void Validate(IJobHandler handler, IDBConnection connection)
        {
            ValidateTable(handler, connection);
        }

        public PlayerStorageInformation Get(IJobHandler handler, IDBConnection connection)
        {
            List<PlayerStorageInformation> data = new List<PlayerStorageInformation>();
            Select(handler, connection, data);

            if (data.Count == 0)
            {
                return new PlayerStorageInformation();
            }

            return data[0];
        }

        public void Record(IJobHandler handler, IDBConnection connection, PlayerStorageInformation information)
        {
            List<PlayerStorageInformation> data = new List<PlayerStorageInformation>() { information };
            InsertOrUpdate(handler, connection, data);
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

            query.Append(_GameSaves);
            query.Append(" BLOB NOT NULL DEFAULT 0,");
            query.Append("PRIMARY KEY(`");
            query.Append(nameof(PlayerStorageInformation.Reference));
            query.Append("`))");

            return query.ToString();
        }

        protected override string GenerateSelect(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT ");

            query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            query.Append(',');
            query.Append(SQLiteType.Get(_properties[1].PropertyType).SelectColumn(_properties[1].Name));
            query.Append(',');
            query.Append(_GameSaves);
            query.Append(" FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected override string GenerateInsertOrUpdate(string tableName, PlayerStorageInformation item)
        {
            StringBuilder query = new StringBuilder("INSERT OR REPLACE INTO `");
            query.Append(tableName);
            query.Append("`(");

            query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            query.Append(',');
            query.Append(SQLiteType.Get(_properties[1].PropertyType).SelectColumn(_properties[1].Name));
            query.Append(',');
            query.Append(_GameSaves);
            query.Append(") VALUES (?,?,?);");

            return query.ToString();
        }

        protected override void FillData(SQLiteDbRequest request, PlayerStorageInformation data)
        {
            base.FillData(request, data);
            lock (_lock)
            {
                GameSaves.EmptyBuffer();
                SQLite3.ColumnBlob(request, _properties.Count, GameSaves.buffer);
                data.GameSaves.ReadBuffer();
            }
        }

        protected override void ProcessUpdate(IDBConnection connection, PlayerStorageInformation data, string tableName)
        {
            int index = 1;
            lock (_lock)
            {
                using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(InsertOrUpdate(tableName, data)))
                {
                    foreach (PropertyInfo property in _properties)
                    {
                        SQLiteType.Get(property.PropertyType).BindParamter(request, index++, property.GetValue(data));
                    }
                    
                    data.GameSaves.WriteBuffer();
                    SQLite3.BindBlob(request, index, GameSaves.buffer);

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

        protected override void ProcessDelete(IDBConnection connection, PlayerStorageInformation data, string tableName)
        {
            int index = 1;
            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(Delete(tableName, data)))
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
