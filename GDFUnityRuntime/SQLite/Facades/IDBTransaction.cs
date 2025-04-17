using System;

namespace GDFUnity
{
    public interface IDBTransaction : IDBOpenable<IDBTransaction>, IDisposable
    {
        public void Rollback();
        
        public void Commit();
    }
}