using System.Threading.Tasks;

namespace GDFFoundation.Tasks
{
    public class SimpleHandler : ITaskHandler
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

        public ITaskHandler Split(int steps = 1)
        {
            return this;
        }

        private float Lerp(float min, float max, float value)
        {
            float result = min + (max - min) * value;
            if (result < min)
            {
                return min;
            }

            if (result > max)
            {
                return max;
            }

            return result;
        }
    }
}