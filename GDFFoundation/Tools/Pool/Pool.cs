using System.Collections.Generic;

namespace GDFFoundation
{
    public abstract class Pool
    {
        protected Queue<IPoolItem> _pool = new Queue<IPoolItem>();

        internal void Release(IPoolItem poolItem)
        {
            poolItem.OnReleased();
            if (!_pool.Contains(poolItem))
            {
                _pool.Enqueue(poolItem);
            }
        }
    }

    public class Pool<T> : Pool where T : IPoolItem, new()
    {
        public T Get()
        {
            if (_pool.Count > 0)
            {
                return Prepare((T)_pool.Dequeue());
            }

            return Prepare(new T());
        }

        private T Prepare(T poolItem)
        {
            poolItem.Pool = this;
            poolItem.OnPooled();
            return poolItem;
        }
    }
}