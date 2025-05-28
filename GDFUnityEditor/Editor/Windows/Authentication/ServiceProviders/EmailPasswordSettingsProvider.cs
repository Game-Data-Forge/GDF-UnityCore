using UnityEditor.VersionControl;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class EmailPasswordSettingsProvider : AuthenticationSettingsProvider
    {
        private class LoginState : AuthenticationState
        {
            public override string Name => "Login";
            public override string Url => "/unity/windows/authentication/views/email-password-authentication-view#the-login-page";

            private EmailPasswordSettingsProvider _provider;
            private TextField _email;
            private TextField _password;
            private Button _registerPage;
            private Button _login;

            public LoginState(EmailPasswordSettingsProvider provider)
            {
                _provider = provider;
            }

            public override void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons)
            {
                if (_email == null)
                {
                    _email = new TextField("Email");
                    _email.style.marginBottom = 5;
                    _email.keyboardType = UnityEngine.TouchScreenKeyboardType.EmailAddress;
                    _email.RegisterCallback<NavigationSubmitEvent>((_) => {
                        Login(view);
                    });
                    _password = new TextField("Password");
                    _password.isPasswordField = true;
                    _password.RegisterCallback<NavigationSubmitEvent>((_) => {
                        Login(view);
                    });

                    _registerPage = new Button();
                    _registerPage.text = "Register page";
                    _registerPage.style.width = 100;
                    _registerPage.clicked += () => {
                        _provider.SetState(_provider._register);
                    };

                    _login = new Button();
                    _login.text = "Login";
                    _login.style.width = 100;
                    _login.clicked += () => {
                        Login(view);
                    };
                }

                rootElement.Add(_email);
                rootElement.Add(_password);

                buttons.Add(_registerPage);
                buttons.Add(_login);
            }

            public override void OnDeactivate(AuthenticationView view)
            {
                
            }

            private void Login(AuthenticationView view)
            {
                view.Load(GDFEditor.Authentication.SignInEmailPassword(view.country.value, _email.value, _password.value));
            }
        }
        private class RegisterState : AuthenticationState
        {
            public override string Name => "Register";
            public override string Url => "/unity/windows/authentication/views/email-password-authentication-view#the-register-page";

            private EmailPasswordSettingsProvider _provider;
            private TextField _email;
            private Button _loginPage;
            private Button _register;
            private HelpBox _message;

            public RegisterState(EmailPasswordSettingsProvider provider)
            {
                _provider = provider;
            }

            public override void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons)
            {
                if (_email == null)
                {
                    _email = new TextField("Email");
                    _email.style.marginBottom = 5;
                    _email.keyboardType = UnityEngine.TouchScreenKeyboardType.EmailAddress;
                    _email.RegisterCallback<NavigationSubmitEvent>((_) =>
                    {
                        Register(view);
                    });

                    _loginPage = new Button();
                    _loginPage.text = "Login page";
                    _loginPage.style.width = 100;
                    _loginPage.clicked += () =>
                    {
                        _provider.SetState(_provider._login);
                    };

                    _register = new Button();
                    _register.text = "Register";
                    _register.style.width = 100;
                    _register.clicked += () =>
                    {
                        Register(view);
                    };

                    _message = new HelpBox("Enter a valid email address.\nThe account password will be sent to it on register.", HelpBoxMessageType.Info);
                    _message.style.marginBottom = 5;
                }

                rootElement.Add(_message);
                rootElement.Add(_email);
                
                buttons.Add(_loginPage);
                buttons.Add(_register);

                view.consent.RegisterValueChangedCallback(OnConsentChanged);
                view.consent.value = false;
                
                _register.SetEnabled(view.consent.value);
            }

            public override void OnDeactivate(AuthenticationView view)
            {
                view.consent.UnregisterValueChangedCallback(OnConsentChanged);
            }

            private void Register(AuthenticationView view)
            {
                view.Load(GDFEditor.Authentication.RegisterEmailPassword(view.country.value, _email.value));
            }

            private void OnConsentChanged(ChangeEvent<bool> ev)
            {
                _register.SetEnabled(ev.newValue);
            }
        }

        public override string Name => "Email password";
        public override string Title => $"{Name} authentication: {_current?.Name}";
        public override string Url => _current?.Url;
        public override bool NeedConsent => _needConsent;

        private AuthenticationView _view;
        private VisualElement _body;
        private ButtonList _buttons;

        private AuthenticationState _current;
        private RegisterState _register;
        private LoginState _login;
        private bool _needConsent = false;

        public override void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons)
        {
            if (_body == null)
            {
                _body = new VisualElement();

                _register = new RegisterState(this);
                _login = new LoginState(this);
            }
            
            _view = view;
            _buttons = buttons;

            rootElement.Add(_body);
            
            SetState(_login);
        }

        private void SetState(AuthenticationState current)
        {
            _body.Clear();
            _buttons.Clear();

            _current?.OnDeactivate(_view);
            _current = current;

            _needConsent = current is RegisterState;

            _view.Update(this);

            _current?.OnActivate(_view, _body, _buttons);
        }

        public override void OnDeactivate(AuthenticationView view, VisualElement rootElement)
        {
            _current?.OnDeactivate(_view);
        }
    }
}
