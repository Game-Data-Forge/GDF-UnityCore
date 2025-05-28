using System;
using System.Collections.Generic;
using GDFUnity.Editor.ServiceProviders;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AuthenticationWindow : EditorWindow
    {
        static private GUIContent _title = null;

        internal const string HELP_URL = "/unity/windows/authentication/authentication-window"; 

        [MenuItem("GDF/Account/Authentication...", priority = 11, secondaryPriority = 1)]
        static public void Display()
        {
            if (_title == null)
            {
                _title = new GUIContent()
                {
                    image = GDFGUIUtility.IconContent("GDF").image,
                    text = "Authentication"
                };
            }

            AuthenticationWindow window = GetWindow<AuthenticationWindow>();
            window.titleContent = _title;
            window.Focus();
        }

        internal List<AuthenticationSettingsProvider> providers = new List<AuthenticationSettingsProvider>();
        internal LoadingView mainView;
        internal HelpButton help;
        internal event Action onDestroying;

        public void CreateGUI()
        {
            providers = AuthenticationSelection.Providers;

            VisualElement mainViewBody = new VisualElement();
            mainViewBody.style.flexGrow = 1;
            mainView = new LoadingView(mainViewBody);

            TwoPaneSplitView splitView = new TwoPaneSplitView(0, 150, TwoPaneSplitViewOrientation.Horizontal);
            splitView.Add(new Authentications(this));
            splitView.Add(new AuthenticationView(this));
            help = new HelpButton(HELP_URL, Position.Absolute);
            
            mainView.AddBody(splitView);

            mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(mainView);
            rootVisualElement.Add(help);
        }
        
        public void OnDestroy()
        {
            onDestroying?.Invoke();
        }
    }
}
