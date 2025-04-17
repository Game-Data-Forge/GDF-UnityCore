using System;

namespace GDFFoundation
{
    public interface IPoolItem : IDisposable
    {
        public Pool Pool { get; set; }
        public void OnPooled();
        public void OnReleased();
    }
}