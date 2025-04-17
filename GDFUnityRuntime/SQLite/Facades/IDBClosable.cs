using System;

namespace GDFUnity
{
    public interface IDBManipulator : IDisposable
    {
        public SQLite3.Result GetResult();
        public void Close();
    }
}
