using System;
using System.Text;
using GDFFoundation;
using UnityEngine;

namespace GDFUnity
{
    public class SQLiteDbConnection : IDBConnection
    {
        private Pool<SQLiteDbTransaction> _transactionPool = new Pool<SQLiteDbTransaction>();
        private Pool<SQLiteDbRequest> _requestPool = new Pool<SQLiteDbRequest>();

        private byte[] _path;
        private IntPtr _handle = IntPtr.Zero;
        internal ulong openedRequests = 0;
        public SQLite3.Result result;

        public SQLiteDbConnection(string databasePath)
        {
            int utf8Length = Encoding.UTF8.GetByteCount(databasePath);
            _path = new byte[utf8Length + 1];
            Encoding.UTF8.GetBytes(databasePath, 0, databasePath.Length, _path, 0);
        }

        public IDBConnection Open()
        {
            result = SQLite3.Result.OK;
            if (_handle == IntPtr.Zero)
            {
                result = SQLite3.Open(_path, out _handle, (int)(SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create), IntPtr.Zero);
                if (SQLiteException.IsError(result))
                {
                    _handle = IntPtr.Zero;
                    throw SQLiteException.ConnectionOpenError(this, result);
                }
            }
            
            Exec("PRAGMA encoding = \"UTF-8\";");
            return this;
        }

        public T Open<T>() where T : IDBConnection
        {
            IDBConnection connection = Open();
            try
            {
                return (T)connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }

        public IDBRequest GetRequest()
        {
            if (_handle != IntPtr.Zero)
            {
                SQLiteDbRequest req = _requestPool.Get();
                req.connection = this;
                return req;
            }
            return null;
        }

        public T GetRequest<T>() where T : IDBRequest
        {
            IDBRequest request = GetRequest();
            try
            {
                return (T)request;
            }
            catch
            {
                request.Dispose();
                throw;
            }
        }

        public IDBRequest OpenRequest(string sql)
        {
            IDBRequest request = GetRequest();
            return request.Open(sql);
        }

        public T OpenRequest<T>(string sql) where T : IDBRequest
        {
            IDBRequest request = OpenRequest(sql);
            try
            {
                return (T)request;
            }
            catch
            {
                request.Dispose();
                throw;
            }
        }

        public IDBTransaction GetTransaction()
        {
            if (_handle != IntPtr.Zero)
            {
                SQLiteDbTransaction transaction = _transactionPool.Get();
                transaction.connection = this;
                return transaction;
            }
            return null;
        }

        public T GetTransaction<T>() where T : IDBTransaction
        {
            IDBTransaction transaction = GetTransaction();
            try
            {
                return (T)transaction;
            }
            catch
            {
                transaction.Dispose();
                throw;
            }
        }

        public IDBTransaction OpenTransaction()
        {
            IDBTransaction transaction = GetTransaction();
            return transaction.Open();
        }

        public T OpenTransaction<T>() where T : IDBTransaction
        {
            IDBTransaction transaction = OpenTransaction();
            try
            {
                return (T)transaction;
            }
            catch
            {
                transaction.Dispose();
                throw;
            }
        }

        public void Exec(string sql)
        {
            if (_handle == IntPtr.Zero)
            {
                result = SQLite3.Result.OK;
                throw SQLiteException.ConnectionNotOpenedError(this, result);
            }

            using (IDBRequest request = GetRequest())
            {
                request.Exec(sql);
            }
        }

        public T ExecScalar<T>(string sql)
        {
            if (_handle == IntPtr.Zero)
            {
                result = SQLite3.Result.OK;
                throw SQLiteException.ConnectionNotOpenedError(this, result);
            }

            using (IDBRequest request = GetRequest())
            {
                return request.ExecScalar<T>(sql);
            }
        }

        public void Close()
        {
            if (_handle == IntPtr.Zero)
            {
                result = SQLite3.Result.OK;
                return;
            }

            if (openedRequests != 0)
            {
                Debug.LogWarning("You are trying to close a database connection with active requests! This might lead to unwanted behaviours...\nRequests still active: " + openedRequests);
            }

            result = SQLite3.Close(_handle);
            if (SQLiteException.IsError(result))
            {
                throw SQLiteException.ConnectionCloseError(this, result);
            }
            
            _handle = IntPtr.Zero;
        }

        public string GetPath()
        {
            return Encoding.UTF8.GetString(_path);
        }

        public SQLite3.Result GetResult()
        {
            return result;
        }

        public void Dispose()
        {
            Close();
        }

        static public implicit operator IntPtr(SQLiteDbConnection connection)
        {
            return connection._handle;
        }

        static public implicit operator SQLite3.Result(SQLiteDbConnection connection)
        {
            return connection.result;
        }
    }
}
