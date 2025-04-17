using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class DeviceSettingsProvider : AuthenticationSettingsProvider
    {
        public override string Name => "Device";
        public override string Title => "Device authentication";

        private DeviceSelector _selector;
        private Button _login;

        public override void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons)
        {
            if (_selector == null)
            {
                _selector = new DeviceSelector();
            }
            
            view.consent.RegisterValueChangedCallback(OnConsentChanged);
            view.consent.value = false;

            rootElement.Add(_selector);

            _login = new Button();
            _login.text = "Login";
            _login.clicked += () => {
                view.Load(GDFEditor.Authentication.SignInDevice(view.country.value));
            };
            _login.style.width = 100;
            _login.SetEnabled(view.consent.value);

            buttons.Add(_login);
        }

        private void OnConsentChanged(ChangeEvent<bool> ev)
        {
            _login.SetEnabled(ev.newValue);
        }

        public override void OnDeactivate(AuthenticationView view, VisualElement rootElement)
        {
            view.consent.UnregisterValueChangedCallback(OnConsentChanged);
        }
    }
}
