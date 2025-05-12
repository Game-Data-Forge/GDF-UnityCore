using GDFFoundation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GDFUnity
{
    public abstract class SQLiteDAL
    {
        protected interface IDALData
        {
            
        }

        protected class Cache
        {
            public string tableName;
            public string tableExists;
            public string createTable;
            public string truncateTable;
            public string drop;
            public string count;
            public string select;
            public string insertOrUpdate;
            public string delete;
        }
    }

    public abstract class SQLiteDAL<T, U> : SQLiteDAL where T : SQLiteDAL<T, U>, new() where U : new()
    {
        static private T _instance = null;
        static public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
        
        protected Type _tableType = typeof(U);
        protected List<PropertyInfo> _properties = new List<PropertyInfo>();
        private Dictionary<IDALData, Cache> _cache = new Dictionary<IDALData, Cache>();

        public SQLiteDAL()
        {
            foreach (PropertyInfo property in _tableType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                if (property.CanWrite && SQLiteType.Contains(property.PropertyType))
                {
                    _properties.Add(property);
                }
            }
        }

        protected string TableName(IDALData dalData)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.tableName == null)
            {
                cache.tableName = GenerateTableName(dalData);
            }

            return cache.tableName;
        }
        protected virtual string GenerateTableName(IDALData dalData)
        {
            return _tableType.Name;
        }

        protected void ValidateTable (IJobHandler handler, IDBConnection connection, IDALData dalData)
        {
            handler.StepAmount = 3;

            string tableName = GenerateTableName(dalData);
            string creationQuery = CreateTable(dalData, tableName);

            string result = connection.ExecScalar<string>(TableExist(dalData, tableName));
            handler.Step();

            if (creationQuery == result)
            {
                return;
            }

            if (result != null)
            {
                connection.Exec(DropTable(dalData, tableName));
            }
            handler.Step();
            
            connection.Exec(creationQuery.Replace("CREATE TABLE", "CREATE TABLE IF NOT EXISTS"));
        }

        protected string TableExist(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.tableExists == null)
            {
                cache.tableExists = GenerateTableExist(tableName);
            }

            return cache.tableExists;
        }
        protected virtual string GenerateTableExist(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT sql FROM sqlite_master WHERE name = '");
            query.Append(tableName);
            query.Append("';");

            return query.ToString();
        }
        
        protected string DropTable(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.drop == null)
            {
                cache.drop = GenerateDropTable(tableName);
            }

            return cache.drop;
        }
        protected virtual string GenerateDropTable(string tableName)
        {
            StringBuilder query = new StringBuilder("DROP TABLE IF EXISTS `");
            query.Append(tableName);
            query.Append("`;");
            
            return query.ToString();
        }

        protected string CreateTable(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.createTable == null)
            {
                cache.createTable = GenerateCreateTable(tableName);
            }

            return cache.createTable;
        }
        protected abstract string GenerateCreateTable(string tableName);

        protected virtual void TruncateTable(IDBConnection connection, IDALData dalData)
        {
            connection.Exec(TruncateTable(dalData, TableName(dalData)));
        }
        protected string TruncateTable(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.truncateTable == null)
            {
                cache.truncateTable = GenerateTruncateTable(tableName);
            }

            return cache.truncateTable;
        }
        protected virtual string GenerateTruncateTable(string tableName)
        {
            StringBuilder query = new StringBuilder("DELETE FROM `");
            query.Append(tableName);
            query.Append("`;");
            
            return query.ToString();
        }

        protected void Select(IJobHandler handler, IDBConnection connection, IDALData dalData, List<U> data)
        {
            string tableName = GenerateTableName(dalData);
            int count = connection.ExecScalar<int>(Count(dalData, tableName));
            if (count <= 0)
            {
                return;
            }

            handler.StepAmount = count;

            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(Select(dalData, tableName)))
            {
                while (request.Step())
                {
                    U item = new U();
                    FillData(request, item);

                    data.Add(item);

                    handler.Step();
                }
            }
        }

        protected string Count(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.count == null)
            {
                cache.count = GenerateCount(tableName);
            }

            return cache.count;
        }
        protected virtual string GenerateCount(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT COUNT(*) FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected string Select(IDALData dalData, string tableName)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.select == null)
            {
                cache.select = GenerateSelect(tableName);
            }

            return cache.select;
        }
        protected virtual string GenerateSelect(string tableName)
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
            query.Append(" FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected virtual void FillData(SQLiteDbRequest request, U data)
        {
            for (int i = 0; i < _properties.Count; i++)
            {
                _properties[i].SetValue(data, SQLiteType.Get(_properties[i].PropertyType).Read(request, i));
            }
        }

        protected void InsertOrUpdate(IJobHandler handler, IDBConnection connection, IDALData dalData, List<U> data)
        {
            string tableName = GenerateTableName(dalData);

            handler.StepAmount = data.Count;
            using (IDBTransaction transaction = connection.OpenTransaction())
            {
                try
                {
                    foreach (U item in data)
                    {
                        ProcessUpdate(connection, dalData, item, tableName);
                        handler.Step();
                    }
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        
        protected string InsertOrUpdate(IDALData dalData, string tableName, U item)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.insertOrUpdate == null)
            {
                cache.insertOrUpdate = GenerateInsertOrUpdate(tableName, item);
            }

            return cache.insertOrUpdate;
        }
        protected virtual string GenerateInsertOrUpdate(string tableName, U item)
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
            query.Append(") VALUES (");
            if (_properties.Count > 0)
            {
                query.Append('?');
            }
            for (int i = 1; i < _properties.Count; i++)
            {
                query.Append(",?");
            }
            query.Append(");");

            return query.ToString();
        }

        protected void Delete(IJobHandler handler, IDBConnection connection, IDALData dalData, List<U> data)
        {
            string tableName = GenerateTableName(dalData);

            handler.StepAmount = data.Count;
            using (IDBTransaction transaction = connection.OpenTransaction())
            {
                try
                {
                    foreach (U item in data)
                    {
                        ProcessDelete(connection, dalData, item, tableName);
                        handler.Step();
                    }
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        protected string Delete(IDALData dalData, string tableName, U item)
        {
            Cache cache;
            if (!_cache.TryGetValue(dalData, out cache))
            {
                cache = new Cache();
                _cache.Add(dalData, cache);
            }

            if (cache.delete == null)
            {
                cache.delete = GenerateDelete(tableName, item);
            }

            return cache.delete;
        }
        protected virtual string GenerateDelete(string tableName, U item)
        {
            StringBuilder query = new StringBuilder("DELETE FROM `");
            query.Append(tableName);
            query.Append("` WHERE `");
            query.Append(nameof(GDFPlayerDataStorage.Reference));
            query.Append("`=?;");

            return query.ToString();
        }

        protected abstract void ProcessUpdate(IDBConnection connection, IDALData dalData, U data, string tableName);
        protected abstract void ProcessDelete(IDBConnection connection, IDALData dalData, U data, string tableName);
    }
}
