using System;

namespace GDFUnity
{
    public interface IDBOpenable<T> : IDBManipulator, IDisposable
    {
        public T Open();
        public U Open<U>() where U : T;
    }
}
