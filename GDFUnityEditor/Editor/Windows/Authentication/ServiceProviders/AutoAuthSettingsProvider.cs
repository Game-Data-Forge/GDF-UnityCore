using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class AutoAuthSettingsProvider : AuthenticationSettingsProvider
    {
        public override string Name => "Automatic";
        public override string Title => "Automatic authentication";
        public override string Url => "/unity/windows/authentication/views/automatic-reconnection-view";

        public override bool NeedCountry => false;
        public override bool NeedConsent => false;

        private Button _login;

        public override void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons)
        {
            if (_login == null)
            {
                _login = new Button();
                _login.text = "Login";
                _login.clicked += () => {
                    view.Load(GDFEditor.Authentication.ReSignIn());
                };
                _login.style.width = 100;

                GDFEditor.Environment.EnvironmentChangedNotif.onMainThread += OnEnvironmentChanged;
                GDF.Authentication.AccountChangedNotif.onMainThread += OnAccountChanged;
            }
            
            buttons.Add(_login);

            UpdateLoginButton();
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
            _login.SetEnabled(GDF.Authentication.CanAutoReSignIn);
        }

        public override void OnDeactivate(AuthenticationView view, VisualElement rootElement)
        {
            
        }
    }
}
