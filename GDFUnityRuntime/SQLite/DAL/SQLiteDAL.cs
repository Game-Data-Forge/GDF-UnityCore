using GDFFoundation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GDFUnity
{
    public abstract class SQLiteDAL
    {
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
        private Cache _cache = new Cache();

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

        protected string TableName()
        {
            if (_cache.tableName == null)
            {
                _cache.tableName = GenerateTableName();
            }

            return _cache.tableName;
        }
        protected virtual string GenerateTableName()
        {
            return _tableType.Name;
        }

        protected void ValidateTable (IJobHandler handler, IDBConnection connection)
        {
            handler.StepAmount = 3;

            string tableName = GenerateTableName();
            string creationQuery = CreateTable(tableName);

            string result = connection.ExecScalar<string>(TableExist(tableName));
            handler.Step();

            if (creationQuery == result)
            {
                return;
            }

            if (result != null)
            {
                connection.Exec(DropTable(tableName));
            }
            handler.Step();
            
            connection.Exec(creationQuery.Replace("CREATE TABLE", "CREATE TABLE IF NOT EXISTS"));
        }

        protected string TableExist(string tableName)
        {
            if (_cache.tableExists == null)
            {
                _cache.tableExists = GenerateTableExist(tableName);
            }

            return _cache.tableExists;
        }
        protected virtual string GenerateTableExist(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT sql FROM sqlite_master WHERE name = '");
            query.Append(tableName);
            query.Append("';");

            return query.ToString();
        }
        
        protected string DropTable(string tableName)
        {
            if (_cache.drop == null)
            {
                _cache.drop = GenerateDropTable(tableName);
            }

            return _cache.drop;
        }
        protected virtual string GenerateDropTable(string tableName)
        {
            StringBuilder query = new StringBuilder("DROP TABLE IF EXISTS `");
            query.Append(tableName);
            query.Append("`;");
            
            return query.ToString();
        }

        protected string CreateTable(string tableName)
        {
            if (_cache.createTable == null)
            {
                _cache.createTable = GenerateCreateTable(tableName);
            }

            return _cache.createTable;
        }
        protected abstract string GenerateCreateTable(string tableName);

        protected virtual void TruncateTable(IDBConnection connection)
        {
            connection.Exec(TruncateTable(TableName()));
        }
        protected string TruncateTable(string tableName)
        {
            if (_cache.truncateTable == null)
            {
                _cache.truncateTable = GenerateTruncateTable(tableName);
            }

            return _cache.truncateTable;
        }
        protected virtual string GenerateTruncateTable(string tableName)
        {
            StringBuilder query = new StringBuilder("DELETE FROM `");
            query.Append(tableName);
            query.Append("`;");
            
            return query.ToString();
        }

        protected void Select(IJobHandler handler, IDBConnection connection, List<U> data)
        {
            string tableName = GenerateTableName();
            int count = connection.ExecScalar<int>(Count(tableName));
            if (count <= 0)
            {
                return;
            }

            handler.StepAmount = count;

            using (SQLiteDbRequest request = connection.OpenRequest<SQLiteDbRequest>(Select(tableName)))
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

        protected string Count(string tableName)
        {
            if (_cache.count == null)
            {
                _cache.count = GenerateCount(tableName);
            }

            return _cache.count;
        }
        protected virtual string GenerateCount(string tableName)
        {
            StringBuilder query = new StringBuilder("SELECT COUNT(*) FROM `");
            query.Append(tableName);
            query.Append("`;");

            return query.ToString();
        }

        protected string Select(string tableName)
        {
            if (_cache.select == null)
            {
                _cache.select = GenerateSelect(tableName);
            }

            return _cache.select;
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

        protected void InsertOrUpdate(IJobHandler handler, IDBConnection connection, List<U> data)
        {
            string tableName = GenerateTableName();

            handler.StepAmount = data.Count;
            using (IDBTransaction transaction = connection.OpenTransaction())
            {
                try
                {
                    foreach (U item in data)
                    {
                        ProcessUpdate(connection, item, tableName);
                        handler.Step();
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    GDFLogger.Error(e);
                }
            }
        }
        
        protected string InsertOrUpdate(string tableName, U item)
        {
            if (_cache.insertOrUpdate == null)
            {
                _cache.insertOrUpdate = GenerateInsertOrUpdate(tableName, item);
            }

            return _cache.insertOrUpdate;
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

        protected void Delete(IJobHandler handler, IDBConnection connection, List<U> data)
        {
            string tableName = GenerateTableName();

            handler.StepAmount = data.Count;
            using (IDBTransaction transaction = connection.OpenTransaction())
            {
                try
                {
                    foreach (U item in data)
                    {
                        ProcessDelete(connection, item, tableName);
                        handler.Step();
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    GDFLogger.Error(e);
                }
            }
        }

        protected string Delete(string tableName, U item)
        {
            if (_cache.delete == null)
            {
                _cache.delete = GenerateDelete(tableName, item);
            }

            return _cache.delete;
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

        protected abstract void ProcessUpdate(IDBConnection connection, U data, string tableName);
        protected abstract void ProcessDelete(IDBConnection connection, U data, string tableName);
    }
}
