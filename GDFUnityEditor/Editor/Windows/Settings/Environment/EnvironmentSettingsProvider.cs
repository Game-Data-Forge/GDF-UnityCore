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
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            rootElement.Add(new TitleLabel("Game Data Forge: Environment"));

            mainView = new LoadingView(new ScrollView(ScrollViewMode.Vertical));
            mainView.AddPreloader(new EnginePreLoader());
            

            mainView.AddBody(new CategoryLabel("Environment selection"));
            mainView.AddBody(new Environment(this));
            
            rootElement.Add(mainView);
        }

        public void VerifyConfiguration()
        {
            if (mainView == null)
            {
                return;
            }
            mainView.MainDisplay = LoadingView.Display.PreLoader;
        }
    }
}