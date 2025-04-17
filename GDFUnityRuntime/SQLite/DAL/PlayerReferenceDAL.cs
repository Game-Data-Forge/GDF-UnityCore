using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFUnity
{
    public class PlayerReferenceDAL : SQLiteDAL<PlayerReferenceDAL, PlayerReferenceStorage>
    {
        private class DALData : IDALData
        {
        }

        private object _lock = new object();
        private byte[] _flags = new byte[8] {
            0b00000001,0b00000010,0b00000100,0b00001000,0b00010000,0b00100000,0b01000000,0b10000000
        };
        private byte[] _buffer = new byte[32];
        private PropertyInfo _reference;
        private string _GameSaves = "GamesSaves";
        private DALData _dummy = new DALData();

        public PlayerReferenceDAL() : base()
        {
            _reference = _tableType.GetProperty(nameof(PlayerReferenceStorage.Reference));
        }

        public void Validate(ITaskHandler handler, IDBConnection connection)
        {
            ValidateTable(handler, connection, _dummy);
        }

        public void Get(ITaskHandler handler, IDBConnection connection, List<PlayerReferenceStorage> data)
        {
            Select(handler, connection, _dummy, data);
        }

        public void Record(ITaskHandler handler, IDBConnection connection, List<PlayerReferenceStorage> data)
        {
            InsertOrUpdate(handler, connection, _dummy, data);
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
            lock(_lock)
            {
                Array.Fill(_buffer, (byte)0);
                SQLite3.ColumnBlob(request, _properties.Count, _buffer);
                for (int i = 0; i < 32; i ++)
                {
                    if (_buffer[i] == 0)
                    {
                        continue;
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        if ((_buffer[i] & _flags[j]) != _flags[j])
                        {
                            continue;
                        }
                        data.Add((byte)((31-i) * 8 + j));
                    }
                }
            }
        }

        protected override void ProcessUpdate(IDBConnection connection, IDALData dalData, PlayerReferenceStorage data, string tableName)
        {
            int index = 1;
            lock(_lock)
            {
                using (SQLiteDbRequest request = connection.GetRequest<SQLiteDbRequest>())
                {
                    if (data.Count == 0)
                    {
                        request.Open(Delete(dalData, tableName, data));
                        SQLiteType.Get(_reference.PropertyType).BindParamter(request, index++, _reference.GetValue(data));
                    }
                    else
                    {
                        string query = InsertOrUpdate(dalData, tableName, data);
                        request.Open(query);
                        foreach (PropertyInfo property in _properties)
                        {
                            SQLiteType.Get(property.PropertyType).BindParamter(request, index++, property.GetValue(data));
                        }

                        Array.Fill(_buffer, (byte)0);

                        foreach (byte gameSave in data)
                        {
                            int index1 = 31 - gameSave / 8;
                            int index2 = gameSave % 8;
                            _buffer[index1] |= _flags[index2];
                        }

                        SQLite3.BindBlob(request, index, _buffer);
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

        protected override void ProcessDelete(IDBConnection connection, IDALData dalData, PlayerReferenceStorage data, string tableName)
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
