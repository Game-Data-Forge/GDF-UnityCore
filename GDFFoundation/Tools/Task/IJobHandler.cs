namespace GDFFoundation
{
    public interface IJobHandler : IPoolItem
    {
        public int StepAmount { get; set; }
        public bool IsCanceled { get; }

        public void Step();

        public void Cancel();
        public void ThrowIfCancelled();

        public IJobHandler Split(int steps = 1);
    }
}