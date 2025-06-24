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
        private HelpButton _help;

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
        public string helpUrl
        {
            get => _help?.url;
            set
            {
                if (_help == null) return;
                _help.url = value;
            }
        }

        protected virtual bool DisableInPlayMode => false;

        public void CreateGUI()
        {
            _mainView = BuildLoadingView();

            _mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(_mainView);

            _mainView.onDisplayChanged += Display;

            Display(_mainView.MainDisplay);

            if (!DisableInPlayMode) return;
            
            if (Application.isPlaying)
            {
                OnDomainChange(PlayModeStateChange.EnteredPlayMode);
            }

            EditorApplication.playModeStateChanged += OnDomainChange;
        }

        protected virtual void OnDestroy()
        {
            EditorApplication.playModeStateChanged -= OnDomainChange;
        }

        public void RegisterHelp(HelpButton help)
        {
            _help = help;
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

            _mainView.Clear();

            GUIReady();
        }

        private void OnDomainChange(PlayModeStateChange state)
        {
            rootVisualElement.SetEnabled(state == PlayModeStateChange.EnteredEditMode);
        }
    }
}
