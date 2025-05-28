namespace GDFRuntime
{
    public interface IAsyncManager : IStopableManager
    {
        public ManagerState State { get; }

        public void EnsureUseable();
    }
}
