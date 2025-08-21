using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class PlayerReferenceDAL : SQLiteDAL<PlayerReferenceDAL, PlayerReferenceStorage>
    {
        private object _lock = new object();
        private const string _GameSaves = "GamesSaves";
        private PropertyInfo _reference;

        public PlayerReferenceDAL() : base()
        {
            _reference = _tableType.GetProperty(nameof(PlayerReferenceStorage.Reference));
        }

        public void Validate(IJobHandler handler, IDBConnection connection)
        {
            ValidateTable(handler, connection);
        }

        public void Get(IJobHandler handler, IDBConnection connection, List<PlayerReferenceStorage> data)
        {
            Select(handler, connection, data);
        }

        public void Record(IJobHandler handler, IDBConnection connection, List<PlayerReferenceStorage> data)
        {
            InsertOrUpdate(handler, connection, data);
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
            query.Append(_GameSaves);
            query.Append(" BLOB NOT NULL DEFAULT 0,");
            query.Append("PRIMARY KEY(`");
            query.Append(nameof(PlayerReferenceStorage.Reference));
            query.Append("`))");

            return query.ToString();
        }

        protected override string GenerateSelect(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT ");
            if (_properties.Count > 0)
            {
                query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            }
            for (int i = 1; i < _properties.Count; i++)
            {
                query.Append(',');
                query.Append(SQLiteType.Get(_properties[i].PropertyType).SelectColumn(_properties[i].Name));
            }
            query.Append(",");
            query.Append(_GameSaves);
            query.Append(" FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected override string GenerateInsertOrUpdate(string tableName, PlayerReferenceStorage item)
        {
            StringBuilder query = new StringBuilder("INSERT OR REPLACE INTO `");
            query.Append(tableName);
            query.Append("`(");
            if (_properties.Count > 0)
            {
                query.Append(SQLiteType.Get(_properties[0].PropertyType).SelectColumn(_properties[0].Name));
            }
            for (int i = 1; i < _properties.Count; i++)
            {
                query.Append(',');
                query.Append(SQLiteType.Get(_properties[i].PropertyType).SelectColumn(_properties[i].Name));
            }
            query.Append(",");
            query.Append(_GameSaves);
            query.Append(") VALUES (");
            if (_properties.Count > 0)
            {
                query.Append('?');
            }
            for (int i = 1; i < _properties.Count; i++)
            {
                query.Append(",?");
            }
            query.Append(",?);");

            return query.ToString();
        }

        protected override void FillData(SQLiteDbRequest request, PlayerReferenceStorage data)
        {
            base.FillData(request, data);
            lock (_lock)
            {
                GameSaves.EmptyBuffer();
                SQLite3.ColumnBlob(request, _properties.Count, GameSaves.buffer);
                data.GameSaves.ReadBuffer();
            }
        }

        protected override void ProcessUpdate(IDBConnection connection, PlayerReferenceStorage data, string tableName)
        {
            int index = 1;
            lock(_lock)
            {
                using (SQLiteDbRequest request = connection.GetRequest<SQLiteDbRequest>())
                {
                    if (data.Count == 0)
                    {
                        request.Open(Delete(tableName, data));
                        SQLiteType.Get(_reference.PropertyType).BindParamter(request, index++, _reference.GetValue(data));
                    }
                    else
                    {
                        string query = InsertOrUpdate(tableName, data);
                        request.Open(query);
                        foreach (PropertyInfo property in _properties)
                        {
                            SQLiteType.Get(property.PropertyType).BindParamter(request, index++, property.GetValue(data));
                        }

                        data.GameSaves.WriteBuffer();
                        SQLite3.BindBlob(request, index, GameSaves.buffer);
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
        }

        protected override void ProcessDelete(IDBConnection connection, PlayerReferenceStorage data, string tableName)
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
