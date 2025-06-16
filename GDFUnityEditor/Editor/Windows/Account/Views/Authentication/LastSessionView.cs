using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class LastSessionView : AuthenticationView, IWindowView<AccountWindow>
    {
        public string Name => "Last session";
        public string Title => "Last session authentication";
        public string Help => "/unity/editor-windows/account/authentication/last-session";

        public override bool NeedCountry => false;
        public override bool NeedConsent => false;

        private Button _login;

        public LastSessionView(AccountView view) : base(view)
        {
            _login = new Button();
            _login.text = "Login";
            _login.style.width = 100;
            _login.clicked += () =>
            {
                view.Load(GDFEditor.Account.Authentication.LastSession.Login());
            };
            
            GDFEditor.Environment.EnvironmentChanged.onMainThread += OnEnvironmentChanged;
            GDF.Account.AccountChanged.onMainThread += OnAccountChanged;
        }

        protected override void OnActivate(AccountWindow window, AccountView view)
        {
            view.buttons.Add(_login);

            UpdateLoginButton();
        }
        
        protected override void OnDeactivate(AccountWindow window, AccountView view)
        {

        }

        private void OnEnvironmentChanged(ProjectEnvironment environment)
        {
            UpdateLoginButton();
        }

        private void OnAccountChanged(MemoryJwtToken token)
        {
            UpdateLoginButton();
        }

        private void UpdateLoginButton()
        {
            _login.SetEnabled(GDF.Account.Authentication.LastSession.IsAvailable);
        }

    }
}
