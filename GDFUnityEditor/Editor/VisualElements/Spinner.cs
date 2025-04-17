using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

namespace GDFUnity.Editor
{
    public class Spinner : VisualElement
    {
        private ValueAnimation<float> _animation = null;

        public bool IsSpinning => _animation?.isRunning ?? false;
        public event Action<float> onSpinUpdate;

        public Spinner() : base()
        {
            style.IconContent("Loading");
            
            style.maxHeight = 16;
            style.height = 16;
            style.maxWidth = 16;
            style.width = 16;

            style.marginLeft = 2;
            style.marginTop = 2;
            style.marginRight = 2;
        }

        public void Spin()
        {
            if (IsSpinning)
            {
                return;
            }

            _animation = experimental.animation.Start(0, 360, 2000, (ve, val) => {
                ve.style.rotate = new Rotate(val);
                onSpinUpdate?.Invoke(val);
            }).Ease(v => v);

            _animation.OnCompleted(Spin);
        }

        public void Stop()
        {
            if (_animation != null)
            {
                _animation.onAnimationCompleted = null;
                _animation.Stop();
                _animation = null;
            }

            style.rotate = new Rotate(0);
        }
    }
}