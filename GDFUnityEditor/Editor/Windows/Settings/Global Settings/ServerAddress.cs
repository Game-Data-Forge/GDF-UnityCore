using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class ServerAddress : VisualElement
    {
        private GlobalSettingsProvider _provider;
        private TextField _address;
        private Button _connect;
        private Button _reset;

        public ServerAddress(GlobalSettingsProvider provider) : base()
        {
            _provider = provider;
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = StyleKeyword.Initial;
            style.flexShrink = StyleKeyword.Initial;

            _address = new TextField("Dashboard address");
            _address.tooltip = "The address of the Dashboard server.\nIt must be of format: 'http[s]://foo.bar.com[:port][/]";
            _address.style.flexGrow = 1;
            _address.style.marginLeft = 0;
            _address.style.paddingLeft = 10;
            _address.keyboardType = UnityEngine.TouchScreenKeyboardType.URL;

            _connect = new Button();
            _connect.tooltip = "Connect to the Dashboard server.";
            _connect.style.IconContent("SceneLoadIn");
            _connect.style.backgroundPositionX = new BackgroundPosition(BackgroundPositionKeyword.Left, 0);
            _connect.style.marginLeft = 0;
            _connect.style.width = 20;
            _connect.clicked += OnConnect;
            
            _reset = new Button();
            _reset.style.marginLeft = 0;
            _reset.style.width = 20;
            _reset.clicked += OnReset;
            
            _address.RegisterValueChangedCallback((ev) => {
                _provider.dashboardAddress = ev.newValue.Trim();
                _connect.SetEnabled (EditorConfigurationEngine.Instance.IsValidDashboardAddress(_provider.dashboardAddress));
            });
            _address.RegisterCallback<NavigationSubmitEvent>((_) => {
                if (_connect.enabledInHierarchy)
                {
                    OnConnect();
                }
            });

            _address.value = _provider.dashboardAddress;

            Add(_address);
            Add(_connect);
            Add(_reset);

            provider.onStateChanged += OnProviderStateChanged;

            OnProviderStateChanged(provider.ProviderState);
        }

        private void OnProviderStateChanged(GlobalSettingsProvider.State state)
        {
            _address.SetEnabled(state == GlobalSettingsProvider.State.NoAddress);
            _connect.SetEnabled(state == GlobalSettingsProvider.State.NoAddress);
            
            if (state <= GlobalSettingsProvider.State.CheckingAddress)
            {
                _reset.tooltip = "Reset the dashboard to the default GDF address.";
                _reset.style.IconContent("Refresh");
                _reset.style.backgroundPositionX = new BackgroundPosition(BackgroundPositionKeyword.Center);
            }
            else
            {
                _reset.tooltip = "Disconnect from the server.";
                _reset.style.IconContent("SceneLoadOut");
                _reset.style.backgroundPositionX = new BackgroundPosition(BackgroundPositionKeyword.Left, 0);
            }

            _reset.SetEnabled(state != GlobalSettingsProvider.State.CheckingAddress && state != GlobalSettingsProvider.State.CheckingRole);
        }

        private void OnConnect()
        {
            IJob operation = EditorConfigurationEngine.Instance.ContactDashboard(_provider.dashboardAddress);
            _provider.mainView.AddLoader(operation, OnServerConnectionDone);
            _provider.ProviderState = GlobalSettingsProvider.State.CheckingAddress;
        }

        private void OnReset()
        {
            if (_provider.ProviderState == GlobalSettingsProvider.State.NoAddress)
            {
                _address.value = EditorConfigurationEngine.DASHBOARD_ADDRESS;
            }
            _provider.ProviderState = GlobalSettingsProvider.State.NoAddress;
        }

        private void OnServerConnectionDone(IJob operation)
        {
            if (operation.State == JobState.Success)
            {
                _provider.ProviderState = GlobalSettingsProvider.State.NoRole;
            }
            else
            {
                _provider.ProviderState = GlobalSettingsProvider.State.NoAddress;
            }
        }
    }
}