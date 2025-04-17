using System;
using GDFUnity;

namespace GDFUnity
{
    public interface IDBRequest : IDBManipulator, IDBExecutable, IDisposable
    {
        public IDBRequest Open(string query);
        public T Open<T>(string query) where T : IDBRequest;

        public bool Step();

        public void Exec();
        public T ExecScalar<T>();
    }
}