using System;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity.Editor.ServiceProviders;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AuthenticationView : VisualElement
    {
        private enum State
        {
            None = 0,
            Selected = 1 << 0,
            LoggedIn = 1 << 1
        }

        internal Toggle consent;
        internal CountryField country;
        private State _state;
        private VisualElement _message;
        private AuthenticationLogoutView _logoutView;
        private VisualElement _body;
        private ButtonList _buttons;
        private Environment _environment;
        private Label _title;
        private AuthenticationWindow _window;

        private State _State
        {
            get => _state;
            set
            {
                _state = value;
                if (_state.HasFlag(State.LoggedIn))
                {
                    _logoutView.style.display = DisplayStyle.Flex;

                    _message.style.display = DisplayStyle.None;
                    _body.style.display = DisplayStyle.None;
                    return;
                }
                
                if (_state.HasFlag(State.Selected))
                {
                    _body.style.display = DisplayStyle.Flex;

                    _logoutView.style.display = DisplayStyle.None;
                    _message.style.display = DisplayStyle.None;
                    return;
                }
                
                _message.style.display = DisplayStyle.Flex;
                _body.style.display = DisplayStyle.None;
                _logoutView.style.display = DisplayStyle.None;
            }
        }

        public AuthenticationView(AuthenticationWindow window)
        {
            _window = window;

            style.minWidth = 200;
            
            _message = new VisualElement();
            _message.style.flexGrow = 1;
            _message.style.justifyContent = Justify.Center;

            _logoutView = new AuthenticationLogoutView(window);

            HelpBox helpBox = new HelpBox("No authentication selected !", HelpBoxMessageType.Info);
            helpBox.style.marginLeft = 50;
            helpBox.style.marginRight = 50;

            _message.Add(helpBox);

            _body = new VisualElement();
            _body.style.justifyContent = Justify.Center;
            _body.style.flexGrow = 1;
            _body.style.paddingLeft = 50;
            _body.style.paddingRight = 50;
            
            _buttons = new ButtonList();
            _buttons.style.flexDirection = FlexDirection.Row;
            _buttons.style.marginTop = 50;

            _title = new Label();
            _title.style.fontSize = 19;
            _title.style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            _title.style.marginBottom = 20;
            _title.style.marginLeft = 3;
            _title.style.marginRight = 3;

            _environment = new Environment(window.mainView);
            _environment.style.marginBottom = 20;
            _environment.style.marginLeft = 0;

            country = new CountryField();
            country.style.marginBottom = 10;

            consent = new Toggle("Agree to the TOS");
            consent.style.marginTop = 40;

            AuthenticationSelection.onSelectionChanged += OnSelectionChanged;
            GDF.Authentication.AccountChangedEvent.onMainThread += OnAuthenticationChanged;

            Add(_message);
            Add(_logoutView);
            Add(_body);

            OnSelectionChanged(null, AuthenticationSelection.Selection);
            OnAuthenticationChanged(GDF.Authentication.Token);
        }

        private void OnSelectionChanged(AuthenticationSettingsProvider last, AuthenticationSettingsProvider selection)
        {
            last?.OnDeactivate(this, _body);

            if (selection == null)
            {
                _State = _state.HasFlag(State.LoggedIn) ? State.LoggedIn : State.None;
                return;
            }
            
            _buttons.Clear();
            _body.Clear();
            _body.Add(_title);
            _body.Add(_environment);
            _body.Add(country);
            selection.OnActivate(this, _body, _buttons);
            _body.Add(consent);
            _body.Add(_buttons);

            Update(selection);

            _State |= State.Selected;
        }

        private void OnAuthenticationChanged(MemoryJwtToken token)
        {
            if (token == null)
            {
                _State = _state.HasFlag(State.Selected) ? State.Selected : State.None;
                return;
            }

            _State |= State.LoggedIn;
        }

        public void Load(ITask load, Action<ITask> onDone = null)
        {
            _window.mainView.AddLoader(load, (task) => {
                try
                {
                    onDone?.Invoke(task);
                }
                finally
                {
                    _window.mainView.SetBodyEnabled(true);
                }
            });

            _window.mainView.SetBodyEnabled(false);
        }

        public void Update(AuthenticationSettingsProvider selection)
        {
            _title.text = selection.Title;
            country.style.display = selection.NeedCountry ? DisplayStyle.Flex : DisplayStyle.None;
            consent.style.display = selection.NeedConsent ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}
