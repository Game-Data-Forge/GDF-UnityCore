using System.Collections.Generic;
using GDFEditor;
using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;
using static GDFUnity.RuntimeConfigurationEngine;

namespace GDFUnity.Editor
{
    public class ProjectInformation : VisualElement
    {
        private class Info : LabelField
        {
            private const string ErrorIcon = "TestFailed";
            private const string SuccessIcon = "TestPassed";
            private VisualElement _icon;

            public Info() : base()
            {
                _icon = new VisualElement();
                _icon.style.position = Position.Absolute;
                _icon.style.IconContent("console.erroricon.sml");
                _icon.style.flexGrow = 0;
                _icon.style.flexShrink = 0;
                _icon.style.marginTop = 2;
                _icon.style.left = 2;
                _icon.style.display = DisplayStyle.None;
                
                Add(_icon);
            }

            public Info(string label) : this()
            {
                text = label;
            }

            public void SetState(bool? success = null, string tooltip = null)
            {
                if (success == null)
                {
                    _icon.style.display = DisplayStyle.None;
                }
                else
                {
                    _icon.style.display = DisplayStyle.Flex;
                    _icon.style.IconContent(success.Value ? SuccessIcon : ErrorIcon);
                }
                this.tooltip = tooltip;
            }
        }

        private GlobalSettingsProvider _provider;
        private Info _state;
        private Info _reference;
        private Info _name;
        private Info _organization;
        private TreeView _credentials;
        private Info _credentialsError;
        private Info _channel;
        private Info _channelsError;
        private TreeView _channels;
        private Info _dashboard;
        private TreeView _authAgentPool;
        private Info _authAgentPoolError;
        private TreeView _syncAgentPool;
        private Info _syncAgentPoolError;

        public ProjectInformation(GlobalSettingsProvider provider) : base()
        {
            _provider = provider;
            Pool<Info> pool = new Pool<Info>();

            Add(new CategoryLabel("Project Information"));

            _state = new Info("State");
            _state.style.marginLeft = 10;
            _state.style.marginBottom = 5;
            _state.style.paddingLeft = 18;

            _reference = new Info("Reference");
            _reference.style.marginLeft = 10;
            _reference.style.paddingLeft = 18;

            _name = new Info("Name");
            _name.style.marginLeft = 10;
            _name.style.paddingLeft = 18;

            _organization = new Info("Organization");
            _organization.style.marginLeft = 10;
            _organization.style.paddingLeft = 18;

            _credentials = new TreeView();
            _credentials.fixedItemHeight = EditorGUIUtility.singleLineHeight;
            _credentials.selectionType = SelectionType.None;
            _credentials.style.flexBasis = new StyleLength(StyleKeyword.Auto);
            _credentials.horizontalScrollingEnabled = false;
            _credentials.makeItem = () => pool.Get();
            _credentials.bindItem = (ve, i) => {
                string value = _credentials.GetItemDataForIndex<string>(i);
                Info field = ve as Info;
                field.text = value;
                if (i == 0)
                {
                    field.value = "";
                    return;
                }

                field.value = provider.Configuration.Credentials[value.ToEnvironment()].PublicKey;
            };
            _credentials.destroyItem = (ve) => (ve as Info).Dispose();
            _credentials.style.marginLeft = 10;

            _credentialsError = new Info("Credentials");
            _credentialsError.style.marginLeft = 10;
            _credentialsError.style.paddingLeft = 18;
            _credentialsError.SetState(false, "The credentials are not a valid for the GDF project.");

            _channel = new Info("Channel");
            _channel.style.marginLeft = 10;
            _channel.style.paddingLeft = 18;

            _channels = new TreeView();
            _channels.fixedItemHeight = EditorGUIUtility.singleLineHeight;
            _channels.selectionType = SelectionType.None;
            _channels.style.flexBasis = new StyleLength(StyleKeyword.Auto);
            _channels.horizontalScrollingEnabled = false;
            _channels.makeItem = () => pool.Get();
            _channels.bindItem = (ve, i) => {
                string value = _channels.GetItemDataForIndex<string>(i);
                Info field = ve as Info;
                field.text = value;
                if (i == 0)
                {
                    field.value = "";
                    return;
                }

                field.value = provider.Configuration.Channels[value].ToString();
            };
            _channels.destroyItem = (ve) => (ve as Info).Dispose();
            _channels.style.marginLeft = 10;

            _channelsError = new Info("Channels");
            _channelsError.style.marginLeft = 10;
            _channelsError.style.paddingLeft = 18;
            _channelsError.SetState(false, "The channels are not a valid for the GDF project.");

            _dashboard = new Info("Dashboard");
            _dashboard.style.marginLeft = 10;
            _dashboard.style.paddingLeft = 18;
            
            _authAgentPool = new TreeView();
            _authAgentPool.fixedItemHeight = EditorGUIUtility.singleLineHeight;
            _authAgentPool.style.flexBasis = new StyleLength(StyleKeyword.Auto);
            _authAgentPool.selectionType = SelectionType.None;
            _authAgentPool.horizontalScrollingEnabled = false;
            _authAgentPool.makeItem = () => pool.Get();
            _authAgentPool.bindItem = (ve, i) => {
                object value = _authAgentPool.GetItemDataForIndex<object>(i);
                Info field = ve as Info;
                if (i == 0)
                {
                    field.text = (string)value;
                    field.value = "";
                    return;
                }

                Country country = (Country)value;
                field.text = country.ToCodeString();
                field.value = provider.Configuration.CloudConfig.Auth[country];
            };
            _authAgentPool.destroyItem = (ve) => (ve as Info).Dispose();
            _authAgentPool.style.marginLeft = 10;
            _authAgentPool.style.maxHeight = 100;

            _authAgentPoolError = new Info("Auth agent pool");
            _authAgentPoolError.style.marginLeft = 10;
            _authAgentPoolError.style.paddingLeft = 18;
            _authAgentPoolError.SetState(false, "The auth agent pool is not a valid for the GDF project.");

            _syncAgentPool = new TreeView();
            _syncAgentPool.fixedItemHeight = EditorGUIUtility.singleLineHeight;
            _syncAgentPool.style.flexBasis = new StyleLength(StyleKeyword.Auto);
            _syncAgentPool.selectionType = SelectionType.None;
            _syncAgentPool.horizontalScrollingEnabled = false;
            _syncAgentPool.makeItem = () => pool.Get();
            _syncAgentPool.bindItem = (ve, i) => {
                object value = _syncAgentPool.GetItemDataForIndex<object>(i);
                Info field = ve as Info;
                if (i == 0)
                {
                    field.text = (string)value;
                    field.value = "";
                    return;
                }

                Country country = (Country)value;
                field.text = country.ToCodeString();
                field.value = provider.Configuration.CloudConfig.Sync[country];
            };
            _syncAgentPool.destroyItem = (ve) => (ve as Info).Dispose();
            _syncAgentPool.style.marginLeft = 10;
            _syncAgentPool.style.maxHeight = 100;

            _syncAgentPoolError = new Info("Sync agent pool");
            _syncAgentPoolError.style.marginLeft = 10;
            _syncAgentPoolError.style.paddingLeft = 18;
            _syncAgentPoolError.SetState(false, "The sync agent pool is not a valid for the GDF project.");

            Add(_state);
            Add(_reference);
            Add(_name);
            Add(_organization);
            Add(_credentials);
            Add(_credentialsError);
            Add(_channel);
            Add(_channels);
            Add(_channelsError);
            Add(_dashboard);
            Add(_authAgentPool);
            Add(_authAgentPoolError);
            Add(_syncAgentPool);
            Add(_syncAgentPoolError);

            provider.onConfigurationChanged += UpdateConfiguration;
            provider.onStateChanged += (state) => {
                if (state < GlobalSettingsProvider.State.NoChannel)
                {
                    provider.Configuration = null;
                }
            };

            UpdateConfiguration(provider.Configuration);
        }
        
        private void UpdateConfiguration (IEditorConfiguration configuration)
        {
            if (configuration == null)
            {
                style.display = DisplayStyle.None;
                return;
            }
            style.display = DisplayStyle.Flex;

            List<GDFException> errors = EditorConfigurationEngine.Instance.ValidationReport(configuration);

            UpdateState(errors);
            UpdateReference(configuration, errors);
            UpdateName(configuration, errors);
            UpdateOrganization(configuration, errors);
            UpdateCredentials(configuration, errors);
            UpdateChannel(configuration, errors);
            UpdateChannels(configuration, errors);
            UpdateDashboard(configuration, errors);
            UpdateAuthAgentPool(configuration, errors);
            UpdateSyncAgentPool(configuration, errors);

            if (errors.Count == 0)
            {
                _provider.ProviderState = GlobalSettingsProvider.State.Ready;
            }
        }

        private void UpdateState(List<GDFException> errors)
        {
            if (errors.Count == 0)
            {
                _state.value = "Ready";
                _state.SetState(true, "The configuration is usable in editor and in game.");
            }
            else
            {
                _state.value = "Invalid";
                _state.SetState(false, "There is one or more errors found in the configuration !\nGDF will not be usable in editor and in game.");
            }
        }

        private void UpdateReference(IEditorConfiguration configuration, List<GDFException> errors)
        {
            _reference.value = configuration.Reference.ToString();

            if (errors.Contains(EditorConfigurationEngine.RuntimeExceptions.InvalidReference))
            {
                _reference.SetState(false, "The reference is not a valid reference of a GDF project.");
            }
            else
            {
                _reference.SetState();
            }
        }
        
        private void UpdateName(IEditorConfiguration configuration, List<GDFException> errors)
        {
            _name.value = configuration.Name;

            if (errors.Contains(EditorConfigurationEngine.RuntimeExceptions.InvalidName))
            {
                _name.SetState(false, "The name is not a valid name of a GDF project.");
            }
            else
            {
                _name.SetState();
            }
        }
        
        private void UpdateOrganization(IEditorConfiguration configuration, List<GDFException> errors)
        {
            _organization.value = configuration.Organization;

            if (errors.Contains(EditorConfigurationEngine.RuntimeExceptions.InvalidOrganization))
            {
                _organization.SetState(false, "The organization is not a valid organization of a GDF project.");
            }
            else
            {
                _organization.SetState();
            }
        }

        private void UpdateCredentials(IEditorConfiguration configuration, List<GDFException> errors)
        {
            if (errors.Contains(EditorConfigurationEngine.EditorExceptions.InvalidCredentials))
            {
                _credentialsError.style.display = DisplayStyle.Flex;
                _credentials.style.display = DisplayStyle.None;
            }
            else
            {
                _credentialsError.style.display = DisplayStyle.None;
                _credentials.style.display = DisplayStyle.Flex;
                FillCredentials(configuration);
            }
        }

        private void UpdateChannel(IEditorConfiguration configuration, List<GDFException> errors)
        {
            _channel.value = configuration.Channel.ToString();

            if (errors.Contains(EditorConfigurationEngine.RuntimeExceptions.InvalidChannel))
            {
                _channel.SetState(false, "The channel is not a valid channel of a GDF project.");
            }
            else
            {
                _channel.SetState();
            }
        }

        private void UpdateChannels(IEditorConfiguration configuration, List<GDFException> errors)
        {
            if (errors.Contains(EditorConfigurationEngine.EditorExceptions.InvalidChannels))
            {
                _channelsError.style.display = DisplayStyle.Flex;
                _channels.style.display = DisplayStyle.None;
            }
            else
            {
                _channelsError.style.display = DisplayStyle.None;
                _channels.style.display = DisplayStyle.Flex;
                FillChannels(configuration);
            }
        }

        private void FillCredentials (IEditorConfiguration configuration)
        {
            int id = 0;
            List<TreeViewItemData<string>> items = new List<TreeViewItemData<string>>();
            foreach (ProjectEnvironment channel in configuration.Credentials.Keys)
            {
                items.Add(new TreeViewItemData<string>(++id, channel.ToLongString()));
            }

            List<TreeViewItemData<string>> root = new List<TreeViewItemData<string>>
            {
                new TreeViewItemData<string>(0, "Credentials", items)
            };

            _credentials.SetRootItems(root);
            _credentials.Rebuild();
        }

        private void FillChannels (IEditorConfiguration configuration)
        {
            int id = 0;
            List<TreeViewItemData<string>> items = new List<TreeViewItemData<string>>();
            foreach (string channel in configuration.Channels.Keys)
            {
                items.Add(new TreeViewItemData<string>(++id, channel));
            }

            List<TreeViewItemData<string>> root = new List<TreeViewItemData<string>>
            {
                new TreeViewItemData<string>(0, "Channels", items)
            };

            _channels.SetRootItems(root);
            _channels.Rebuild();
        }

        private void UpdateDashboard(IEditorConfiguration configuration, List<GDFException> errors)
        {
            _dashboard.value = configuration.Dashboard;

            if (errors.Contains(EditorConfigurationEngine.EditorExceptions.InvalidDashboard))
            {
                _dashboard.SetState(false, "The dashboard is not a valid dashboard of a GDF project.");
            }
            else
            {
                _dashboard.SetState();
            }
        }

        private void UpdateAuthAgentPool(IEditorConfiguration configuration, List<GDFException> errors)
        {
            if (errors.Contains(RuntimeExceptions.InvalidAuthAgentPool))
            {
                _authAgentPoolError.style.display = DisplayStyle.Flex;
                _authAgentPool.style.display = DisplayStyle.None;
            }
            else
            {
                _authAgentPoolError.style.display = DisplayStyle.None;
                _authAgentPool.style.display = DisplayStyle.Flex;
                FillAgentPool(_authAgentPool, "Auth agent pool", configuration.CloudConfig.Auth);
            }
        }

        private void UpdateSyncAgentPool(IEditorConfiguration configuration, List<GDFException> errors)
        {
            if (errors.Contains(RuntimeExceptions.InvalidSyncAgentPool))
            {
                _syncAgentPoolError.style.display = DisplayStyle.Flex;
                _syncAgentPool.style.display = DisplayStyle.None;
            }
            else
            {
                _syncAgentPoolError.style.display = DisplayStyle.None;
                _syncAgentPool.style.display = DisplayStyle.Flex;
                FillAgentPool(_syncAgentPool, "Sync agent pool", configuration.CloudConfig.Sync);
            }
        }

        private void FillAgentPool (TreeView treeView, string name, ServerConfiguration agents)
        {
            int id = 0;
            List<TreeViewItemData<object>> items = new List<TreeViewItemData<object>>();
            foreach (KeyValuePair<Country, string> country in agents.Enumerate())
            {
                items.Add(new TreeViewItemData<object>(++id, country.Key));
            }

            List<TreeViewItemData<object>> root = new List<TreeViewItemData<object>>
            {
                new TreeViewItemData<object>(0, name, items)
            };

            treeView.SetRootItems(root);
            treeView.Rebuild();
        }
    }
}