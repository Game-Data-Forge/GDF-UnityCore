using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class DeviceView : AuthenticationView, IWindowView<AccountWindow>
    {
        public string Name => "Device";
        public string Title => "Device authentication";
        public string Help => "/unity/editor-windows/account/authentication/device";

        private DeviceSelector _selector;
        private Button _login;

        public DeviceView(AccountView view) : base(view)
        {
            _selector = new DeviceSelector();
            _login = new Button();
            _login.text = "Login";
            _login.clicked += () =>
            {
                Load(GDFEditor.Account.Authentication.Device.Login(view.country.value));
            };
        }

        protected override void OnActivate(AccountWindow window, AccountView view)
        {
            view.consent.RegisterValueChangedCallback(OnConsentChanged);
            view.consent.value = false;

            view.Add(_selector);

            _login.style.width = 100;
            _login.SetEnabled(view.consent.value);

            view.buttons.Add(_login);
        }

        protected override void OnDeactivate(AccountWindow window, AccountView view)
        {
            view.consent.UnregisterValueChangedCallback(OnConsentChanged);
        }

        private void OnConsentChanged(ChangeEvent<bool> ev)
        {
            _login.SetEnabled(ev.newValue);
        }
    }
}
