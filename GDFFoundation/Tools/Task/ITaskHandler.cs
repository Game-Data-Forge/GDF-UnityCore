namespace GDFFoundation.Tasks
{
    public interface ITaskHandler : IPoolItem
    {
        public int StepAmount { get; set; }
        public bool IsCanceled { get; }

        public void Step();

        public void Cancel();
        public void ThrowIfCancelled();

        public ITaskHandler Split(int steps = 1);
    }
}