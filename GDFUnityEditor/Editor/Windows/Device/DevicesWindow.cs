using System.Collections.Generic;
using GDFUnity.Editor.ServiceProviders;
using UnityEditor;
using UnityEngine;

namespace GDFUnity.Editor
{
    public class DevicesWindow : EditorWindow
    {
        static private GUIContent _title = null;

        [MenuItem("GDF/Account/Devices...", priority = 11, secondaryPriority = 0)]
        static public void Display()
        {
            if (_title == null)
            {
                _title = new GUIContent()
                {
                    image = GDFGUIUtility.IconContent("GDF").image,
                    text = "Devices"
                };
            }

            DevicesWindow window = GetWindow<DevicesWindow>();
            window.titleContent = _title;
            window.Focus();
        }

        internal List<AuthenticationSettingsProvider> providers = new List<AuthenticationSettingsProvider>();
        internal LoadingView mainView;
        private DevicesView deviceView;

        public void CreateGUI()
        {
            providers = AuthenticationSelection.Providers;

            mainView = new LoadingView();
            
            DevicesToolbar toolbar = new DevicesToolbar();
            deviceView = new DevicesView(this, toolbar);

            mainView.AddBody(toolbar);
            mainView.AddBody(deviceView);

            mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(mainView);
        }
        
        public void OnDestroy()
        {
            deviceView.OnDestroy();
        }
    }
}
