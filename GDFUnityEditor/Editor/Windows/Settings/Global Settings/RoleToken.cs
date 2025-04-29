using GDFFoundation;
using GDFFoundation.Tasks;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class RoleToken : VisualElement
    {
        private GlobalSettingsProvider _provider;
        private TextField _token;
        private Button _paste;
        private Button _reset;

        public RoleToken(GlobalSettingsProvider provider) : base()
        {
            _provider = provider;
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = StyleKeyword.Initial;
            style.flexShrink = StyleKeyword.Initial;

            _token = new TextField("Role token");
            _token.tooltip = "The role token available in the dashboard.\n(cannot be manually edited, use the 'paste' button instead).";
            _token.style.flexGrow = 0;
            _token.isPasswordField = true;
            _token.style.marginLeft = 0;
            _token.style.marginRight = 0;
            _token.style.paddingLeft = 10;
            _token.focusable = false;
            _token[1].style.display = DisplayStyle.None;

            _paste = new Button();
            _paste.tooltip = "The role token available in the dashboard.\n(cannot be manually edited, use the 'paste' button instead).";
            _paste.text = "Paste role token from clipboard";
            _paste.style.flexGrow = 1;
            _paste.style.marginLeft = 0;
            _paste.clicked += OnPaste;
            
            _reset = new Button();
            _reset.tooltip = "Reset the role token.";
            _reset.style.IconContent("clear");
            _reset.style.marginLeft = 0;
            _reset.style.width = 20;
            _reset.clicked += OnReset;

            Add(_token);
            Add(_paste);
            Add(_reset);

            provider.onStateChanged += OnProviderStateChanged;
            provider.onConfigurationUpdateRequest += RequestConfigurationUpdate;

            OnProviderStateChanged(provider.ProviderState);
        }

        private void OnProviderStateChanged(GlobalSettingsProvider.State state)
        {
            if (state >= GlobalSettingsProvider.State.NoRole)
            {
                style.display = DisplayStyle.Flex;
            }
            else
            {
                style.display = DisplayStyle.None;
            }

            _token.SetEnabled(state <= GlobalSettingsProvider.State.NoRole);
            _paste.SetEnabled(state <= GlobalSettingsProvider.State.NoRole);
            _reset.SetEnabled(state > GlobalSettingsProvider.State.CheckingRole);
        }

        private void OnPaste()
        {
            _provider.role.Token = EditorGUIUtility.systemCopyBuffer.Trim();
            RequestConfigurationUpdate();
        }

        internal void RequestConfigurationUpdate()
        {
            ITask operation = EditorConfigurationEngine.Instance.RequestConfigurationUpdate(_provider.dashboardAddress, _provider.role.Token);
            _provider.mainView.AddLoader(operation, OnServerConnectionDone);
            _provider.ProviderState = GlobalSettingsProvider.State.CheckingRole;
        }

        private void OnReset()
        {
            _provider.ProviderState = GlobalSettingsProvider.State.NoRole;
        }

        private void OnServerConnectionDone(ITask operation)
        {
            if (operation.State == TaskState.Success)
            {
                _provider.ProviderState = GlobalSettingsProvider.State.NoChannel;
            }
            else
            {
                _provider.ProviderState = GlobalSettingsProvider.State.NoRole;
            }

            _provider.Configuration = EditorConfiguration.CreateFrom(_provider.dashboardAddress, (operation as Task<GDFProjectConfiguration>).Result);
        }
    }
}