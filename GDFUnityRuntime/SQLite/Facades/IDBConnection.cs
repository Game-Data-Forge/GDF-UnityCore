using System;

namespace GDFUnity
{
    public interface IDBConnection : IDBOpenable<IDBConnection>, IDBExecutable, IDisposable
    {
        public IDBRequest GetRequest();
        public T GetRequest<T>() where T : IDBRequest;

        public IDBRequest OpenRequest(string sql);
        public T OpenRequest<T>(string sql) where T : IDBRequest;

        public IDBTransaction GetTransaction();
        public T GetTransaction<T>() where T : IDBTransaction;

        public IDBTransaction OpenTransaction();
        public T OpenTransaction<T>() where T : IDBTransaction;
    }
}
