using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public abstract class PreLoader : VisualElement
    {
        protected LoadingView _view;

        public abstract bool IsLoaded { get; }
        public abstract void PreLoad();

        public void SetView(LoadingView view)
        {
            _view = view;
        }
    }
}