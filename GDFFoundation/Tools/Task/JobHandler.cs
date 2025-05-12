using System;

namespace GDFFoundation
{
    public class JobHandler : IJobHandler
    {
        static private Pool<JobHandler> _pool = new Pool<JobHandler>();

        static public JobHandler Get(Job task)
        {
            JobHandler handler = _pool.Get();
            handler._task = task;
            handler._minGlobal = 0;
            handler._maxGlobal = 1;
            return handler;
        }

        private JobHandler _handler = null;
        private Job _task;
        private int _step;
        private int _stepAmount;
        private float _minGlobal;
        private float _maxGlobal;

        public int StepAmount
        {
            get => _stepAmount;
            set => _stepAmount = value;
        }
        public bool IsCanceled => _task.IsCancelled;
        
        public Pool Pool { get; set; }

        public void Step()
        {
            ThrowIfCancelled();

            _step++;
            _task.progress = Lerp(_minGlobal, _maxGlobal, (float)_step / _stepAmount);
        }

        public void Cancel()
        {
            _task.Cancel();
        }
        public void ThrowIfCancelled()
        {
            _task.source.Token.ThrowIfCancellationRequested();
        }

        public void OnPooled()
        {
            _minGlobal = 0;
            _maxGlobal = 1;
            _step = 0;
            _stepAmount = 0;
        }

        public void OnReleased()
        {
            _task = null;
            _handler = null;
        }

        public void Dispose()
        {
            _handler?.Dispose();
            PoolItem.Release(this);
        }

        public IJobHandler Split(int steps = 1)
        {
            ThrowIfCancelled();
            
            if (steps <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(steps), "Cannot be inferior or equal to 0 !");
            }

            if (_handler == null)
            {
                _handler = _pool.Get();
                _handler._task = _task;
            }

            _handler._minGlobal = _task.Progress;
            _handler._maxGlobal = Lerp(_minGlobal, _maxGlobal, (_step + steps) / _stepAmount);
            _handler._step = 0;
            
            return _handler;
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