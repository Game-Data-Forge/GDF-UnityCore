using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountWindow : EditorWindow
    {
        internal const string HELP_URL = "/unity/windows/account-window"; 
        
        [MenuItem("GDF/Account/Account...", priority = 11, secondaryPriority = 3)]
        static public void Display()
        {
            AccountWindow window = GetWindow<AccountWindow>("Account");
            window.Focus();
        }

        internal LoadingView mainView;

        private AccountLoginView _loginView;
        private AccountInformation _information;

        public void CreateGUI()
        {
            VisualElement mainViewBody = new VisualElement();
            mainViewBody.style.flexGrow = 1;
            mainView = new LoadingView(mainViewBody);
            
            _loginView = new AccountLoginView();
            _information = new AccountInformation(this);

            mainView.AddBody(_loginView);
            mainView.AddBody(_information);

            mainView.onDisplayChanged += OnMainViewStateChanged;
            
            mainView.AddPreloader(new EnginePreLoader());
            rootVisualElement.Add(mainView);
            rootVisualElement.Add(new HelpButton(HELP_URL, Position.Absolute));
        }

        private void OnAccountChanged(MemoryJwtToken token)
        {
            if (token == null)
            {
                _loginView.style.display = DisplayStyle.Flex;
                _information.style.display = DisplayStyle.None;
            }
            else
            {
                _loginView.style.display = DisplayStyle.None;
                _information.style.display = DisplayStyle.Flex;
                _information.Update();
            }
        }

        private void OnMainViewStateChanged(LoadingView.Display display)
        {
            if (display == LoadingView.Display.Body)
            {
                GDFEditor.Authentication.AccountChangedNotif.onMainThread -= OnAccountChanged;
                GDFEditor.Authentication.AccountChangedNotif.onMainThread += OnAccountChanged;

                OnAccountChanged(GDFEditor.Authentication.Token);
            }
            else
            {
                OnAccountChanged(null);
            }
        }
        
        public void OnDestroy()
        {
            GDFEditor.Authentication.AccountChangedNotif.onMainThread -= OnAccountChanged;
        }
    }
}
