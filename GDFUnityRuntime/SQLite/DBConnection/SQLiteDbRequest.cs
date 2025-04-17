using System;
using System.Text;
using GDFFoundation;
using GDFUnity;

namespace GDFUnity
{
    public class SQLiteDbRequest : IDBRequest, IPoolItem
    {
        internal SQLiteDbConnection connection;
        private IntPtr _handle = IntPtr.Zero;
        private SQLite3.Result _result;

        public Pool Pool { get; set; }
        
        public IDBRequest Open(string sql)
        {
            _result = SQLite3.Result.OK;
            if (_handle != IntPtr.Zero)
            {
                return this;
            }

            _result = SQLite3.Prepare2(connection, sql, Encoding.UTF8.GetByteCount(sql), out _handle, IntPtr.Zero);
            if (SQLiteException.IsError(_result))
            {
                _handle = IntPtr.Zero;
                throw SQLiteException.RequestOpenError(connection, _result);
            }
            
            connection.openedRequests++;
            return this;
        }

        public T Open<T>(string sql) where T : IDBRequest
        {
            IDBRequest request = Open(sql);
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

        public void OnPooled()
        {
            
        }

        public bool Step()
        {
            if (_handle == IntPtr.Zero)
            {
                _result = SQLite3.Result.OK;
                throw SQLiteException.RequestNotOpenedError(connection, _result);
            }

            _result = SQLite3.Step(_handle);
            if (SQLiteException.IsError(_result))
            {
                throw SQLiteException.RequestSteppingError(connection, _result);
            }
            
            return _result != SQLite3.Result.Done;
        }

        public void Close()
        {
            if (_handle == IntPtr.Zero)
            {
                _result = SQLite3.Result.OK;
                return;
            }
            
            _result = SQLite3.Finalize(_handle);
            if (_result != SQLite3.Result.OK)
            {
                throw SQLiteException.RequestCloseError(connection, _result);
            }

            _handle = IntPtr.Zero;
            connection.openedRequests--;
        }

        public void Exec(string sql)
        {
            _result = SQLite3.Result.OK;
            try
            {
                Open(sql);
                Exec();
            }
            finally
            {
                Close();
            }
        }
        public void Exec()
        {
            Step();
        }

        public T ExecScalar<T>(string sql)
        {
            _result = SQLite3.Result.OK;
            try
            {
                Open(sql);
                return ExecScalar<T>();
            }
            finally
            {
                Close();
            }
        }
        public T ExecScalar<T>()
        {
            if(!Step())
            {
                return default;
            }
            return (T)SQLiteType.Get<T>().Read(this, 0);
        }

        public SQLite3.Result GetResult()
        {
            return _result;
        }

        public void OnReleased()
        {
            connection = null;
        }

        public void Dispose()
        {
            Close();
            PoolItem.Release(this);
        }

        ~SQLiteDbRequest()
        {
            Close();
        }

        static public implicit operator IntPtr(SQLiteDbRequest sRequest)
        {
            return sRequest._handle;
        }

        static public implicit operator SQLite3.Result(SQLiteDbRequest sRequest)
        {
            return sRequest._result;
        }
    }
}
