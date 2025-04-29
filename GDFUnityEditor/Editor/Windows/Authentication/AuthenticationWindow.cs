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
        [MenuItem("GDF/Account/Authentication...", priority = 11, secondaryPriority = 1)]
        static public void Display()
        {
            AuthenticationWindow window = GetWindow<AuthenticationWindow>("Authentication");
            window.Focus();
        }

        internal List<AuthenticationSettingsProvider> providers = new List<AuthenticationSettingsProvider>();
        internal LoadingView mainView;
        internal event Action onDestroying;

        public void CreateGUI()
        {
            providers = AuthenticationSelection.Providers;

            VisualElement mainViewBody = new VisualElement();
            mainViewBody.style.flexGrow = 1;
            mainView = new LoadingView(mainViewBody);
            mainView.AddPreloader(new EnginePreLoader());

            TwoPaneSplitView splitView = new TwoPaneSplitView(0, 150, TwoPaneSplitViewOrientation.Horizontal);
            splitView.Add(new Authentications(this));
            splitView.Add(new AuthenticationView(this));

            mainView.AddBody(splitView);

            rootVisualElement.Add(mainView);
        }
        
        public void OnDestroy()
        {
            onDestroying?.Invoke();
        }
    }
}
