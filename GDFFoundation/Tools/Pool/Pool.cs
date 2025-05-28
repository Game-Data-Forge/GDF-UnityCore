#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj Pool.cs create at 2025/05/19 22:05:40
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    public abstract class Pool
    {
        #region Instance fields and properties

        protected Queue<IPoolItem> _pool = new Queue<IPoolItem>();

        #endregion

        #region Instance methods

        internal void Release(IPoolItem poolItem)
        {
            poolItem.OnReleased();
            if (!_pool.Contains(poolItem))
            {
                _pool.Enqueue(poolItem);
            }
        }

        #endregion
    }

    public class Pool<T> : Pool where T : IPoolItem, new()
    {
        #region Instance methods

        public T Get()
        {
            while (_pool.Count > 0)
            {
                T item = (T)_pool.Dequeue();
                if (item == null) continue;

                return Prepare(item);
            }

            return Prepare(new T());
        }

        private T Prepare(T poolItem)
        {
            poolItem.Pool = this;
            poolItem.OnPooled();
            return poolItem;
        }

        #endregion
    }
}