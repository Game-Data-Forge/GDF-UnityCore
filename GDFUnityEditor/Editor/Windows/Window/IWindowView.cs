using UnityEditor;

namespace GDFUnity.Editor
{
    public interface IWindowView<T> where T : EditorWindow
    {
        public string Name { get; }
        public string Title { get; }
        public string Help { get; }

        public void OnActivate(T window, WindowView<T> view);
        public void OnDeactivate(T window, WindowView<T> view);
    }
}
