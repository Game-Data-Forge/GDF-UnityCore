using GDFFoundation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountWindow : EditorWindow
    {
        static private GUIContent _title = null;

        internal const string HELP_URL = "/unity/windows/account-window"; 
        
        [MenuItem("GDF/Account/Account...", priority = 11, secondaryPriority = 3)]
        static public void Display()
        {
            if (_title == null)
            {
                _title = new GUIContent()
                {
                    image = GDFGUIUtility.IconContent("GDF").image,
                    text = "Account"
                };
            }

            AccountWindow window = GetWindow<AccountWindow>();
            window.titleContent = _title;
            window.Focus();
        }

        internal LoadingView mainView;
        internal HelpButton help;
        internal AccountMenu menu;

        private AccountLoginView _loginView;
        private TwoPaneSplitView _main;

        public void CreateGUI()
        {
            VisualElement mainViewBody = new VisualElement();
            mainViewBody.style.flexGrow = 1;
            mainView = new LoadingView(mainViewBody);
            
            _main = new TwoPaneSplitView(0, 150, TwoPaneSplitViewOrientation.Horizontal);
            menu = new AccountMenu(this);
            _main.Add(menu);
            _main.Add(new AccountView(this));
            _loginView = new AccountLoginView();
            help = new HelpButton(HELP_URL, Position.Absolute);

            mainView.AddBody(_loginView);
            mainView.AddBody(_main);

            mainView.onDisplayChanged += OnMainViewStateChanged;
            
            mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(mainView);
            rootVisualElement.Add(help);
        }

        private void OnAccountChanged(MemoryJwtToken token)
        {
            if (token == null)
            {
                _loginView.style.display = DisplayStyle.Flex;
                _main.style.display = DisplayStyle.None;
                help.url = HELP_URL;
            }
            else
            {
                _loginView.style.display = DisplayStyle.None;
                _main.style.display = DisplayStyle.Flex;
                menu.selectedIndex = 0;
            }
        }

        private void OnMainViewStateChanged(LoadingView.Display display)
        {
            if (display == LoadingView.Display.Body)
            {
                GDFEditor.Account.AccountChanged.onMainThread -= OnAccountChanged;
                GDFEditor.Account.AccountChanged.onMainThread += OnAccountChanged;

                OnAccountChanged(GDFEditor.Account.Token);
            }
            else
            {
                OnAccountChanged(null);
            }
        }
        
        public void OnDestroy()
        {
            GDFEditor.Account.AccountChanged.onMainThread -= OnAccountChanged;
        }
    }
}
