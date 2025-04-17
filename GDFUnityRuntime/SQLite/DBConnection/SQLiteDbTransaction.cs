using GDFFoundation;

namespace GDFUnity
{
    public class SQLiteDbTransaction : IDBTransaction, IPoolItem
    {
        public enum State
        {
            Opened = 0,
            Commited = 1,
            Rollbacked = 2
        }

        internal SQLiteDbConnection connection;
        private SQLite3.Result _result;
        private State _state;

        public Pool Pool { get; set; }

        public IDBTransaction Open()
        {
            connection.Exec("BEGIN;");
            _state = State.Opened;
            return this;
        }

        public T Open<T>() where T : IDBTransaction
        {
            IDBTransaction transaction = Open();
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

        public void OnPooled()
        {
            
        }

        public void Rollback()
        {
            if (_state != State.Opened)
            {
                return;
            }
            
            connection.Exec("ROLLBACK;");
            _state = State.Rollbacked;
        }

        public void Commit()
        {
            if (_state != State.Opened)
            {
                return;
            }
            
            connection.Exec("COMMIT;");
            _state = State.Commited;
        }

        public SQLite3.Result GetResult()
        {
            return _result;
        }

        public void OnReleased()
        {
            
        }

        public void Close()
        {
            if (_state == State.Opened)
            {
                Commit();
            }
        }

        public void Dispose()
        {
            Close();
            PoolItem.Release(this);
        }
    }
}
