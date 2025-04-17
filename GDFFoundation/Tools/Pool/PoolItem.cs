namespace GDFFoundation
{
    public abstract class PoolItem : IPoolItem
    {
        static public void Release(IPoolItem poolItem)
        {
            poolItem.Pool?.Release(poolItem);
        }

        public Pool Pool { get; set; }

        public void Dispose()
        {
            Release(this);
        }

        public abstract void OnPooled();
        public abstract void OnReleased();
    }
}