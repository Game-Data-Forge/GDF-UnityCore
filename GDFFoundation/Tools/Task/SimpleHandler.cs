using System.Threading.Tasks;

namespace GDFFoundation
{
    public class SimpleHandler : IJobHandler
    {
        private bool _cancelled = false;

        public int StepAmount { get; set; }
        public bool IsCanceled => _cancelled;
        
        public Pool Pool { get; set; }

        public SimpleHandler()
        {
            OnPooled();
        }

        public void Step()
        {
            
        }

        public void Cancel()
        {
            _cancelled = true;
        }
        public void ThrowIfCancelled()
        {
            if (_cancelled)
            {
                throw new TaskCanceledException();
            }
        }

        public void OnPooled()
        {
            
        }

        public void OnReleased()
        {
            
        }

        public void Dispose()
        {
            
        }

        public IJobHandler Split(int steps = 1)
        {
            return this;
        }
    }
}