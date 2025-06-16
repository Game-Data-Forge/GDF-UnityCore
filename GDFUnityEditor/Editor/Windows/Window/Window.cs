using UnityEditor;
using UnityEngine;

namespace GDFUnity.Editor
{
    public abstract class Window : EditorWindow
    {
        static private Texture _defaultIcon = null;
        static public Texture DefaultIcon
        {
            get
            {
                if (_defaultIcon == null)
                {
                    _defaultIcon = GDFGUIUtility.IconContent("GDF").image;
                }
                return _defaultIcon;
            }
        }

        private GUIContent _title = null;
        private LoadingView _mainView = null;
        public GUIContent Title
        {
            get
            {
                if (_title == null)
                {
                    _title = GenerateTitle();
                }

                return _title;
            }
        }
        public LoadingView MainView => _mainView;

        public void CreateGUI()
        {
            _mainView = BuildLoadingView();

            _mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(_mainView);

            _mainView.onDisplayChanged += Display;

            Display(_mainView.MainDisplay);
        }

        protected virtual LoadingView BuildLoadingView()
        {
            return new LoadingView();
        }
        protected abstract void GUIReady();
        protected abstract GUIContent GenerateTitle();

        private void Display(LoadingView.Display display)
        {
            if (display != LoadingView.Display.Body) return;

            GUIReady();
        }
    }
}
