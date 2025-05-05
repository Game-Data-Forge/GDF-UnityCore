using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountWindow : EditorWindow
    {
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
            mainView.AddPreloader(new EnginePreLoader());
            
            _loginView = new AccountLoginView();
            _information = new AccountInformation(this);

            mainView.AddBody(_loginView);
            mainView.AddBody(_information);

            mainView.onDisplayChanged += OnMainViewStateChanged;

            OnMainViewStateChanged(mainView.MainDisplay);

            rootVisualElement.Add(mainView);
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
                GDFEditor.Authentication.AccountChangedEvent.onMainThread -= OnAccountChanged;
                GDFEditor.Authentication.AccountChangedEvent.onMainThread += OnAccountChanged;

                OnAccountChanged(GDFEditor.Authentication.Token);
            }
            else
            {
                OnAccountChanged(null);
            }
        }
        
        public void OnDestroy()
        {
            GDFEditor.Authentication.AccountChangedEvent.onMainThread -= OnAccountChanged;
        }
    }
}
