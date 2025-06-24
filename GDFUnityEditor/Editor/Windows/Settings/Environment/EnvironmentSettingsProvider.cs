using GDFFoundation;
using GDFUnityEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class EnvironmentSettingsProvider : SettingsProvider
    {
        public const string PATH = "Project/Game Data Forge/Environment";
        static private readonly string[] _KEYWORDS = new string[] { "Game", "Data", "Forge", "GDF", "Environment" };

        static private EnvironmentSettingsProvider _instance = null;

        [SettingsProvider]
        static public SettingsProvider Generate()
        {
            if (_instance == null)
            {
                _instance = new EnvironmentSettingsProvider();
            }

            return _instance;
        }

        internal LoadingView mainView;

        private EnvironmentSettingsProvider() : base(PATH, SettingsScope.Project, _KEYWORDS)
        {
            GDFLogger.SetWriter(new GDFLoggerUnityEditor(GDFLogLevel.Trace));
            EditorApplication.playModeStateChanged += OnDomainChange;
        }

        ~EnvironmentSettingsProvider()
        {
            EditorApplication.playModeStateChanged -= OnDomainChange;
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            rootElement.Add(new TitleLabel("Game Data Forge: Environment"));

            mainView = new LoadingView(new ScrollView(ScrollViewMode.Vertical));
            mainView.AddPreloader(new EnginePreLoader());

            rootElement.Add(mainView);
            rootElement.Add(new HelpButton("/unity/configuration/environment", Position.Absolute));

            mainView.onDisplayChanged += OnReady;

            OnReady(mainView.MainDisplay);
        }

        public void OnReady(LoadingView.Display display)
        {
            if (display != LoadingView.Display.Body) return;

            mainView.Clear();

            mainView.AddBody(new CategoryLabel("Environment selection"));
            mainView.AddBody(new Environment(mainView));

            if (Application.isPlaying)
            {
                OnDomainChange(PlayModeStateChange.EnteredPlayMode);
            }
        }

        public void VerifyConfiguration()
        {
            if (mainView == null)
            {
                return;
            }
            mainView.MainDisplay = LoadingView.Display.PreLoader;
        }

        private void OnDomainChange(PlayModeStateChange state)
        {
            mainView?.SetEnabled(state == PlayModeStateChange.EnteredEditMode);
        }
    }
}