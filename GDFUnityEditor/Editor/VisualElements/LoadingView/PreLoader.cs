using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public abstract class PreLoader : VisualElement
    {
        public abstract void PreLoad(LoadingView view);
    }
}