using System.Collections.Generic;
using System.Linq;
using GDFEditor;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class Channel : VisualElement
    {
        private enum State
        {
            NoChannel = 0,
            InvalidChannel = 1,
            ValidChannel = 2
        }

        private class Error : VisualElement
        {
            public Error() : base ()
            {
                style.flexDirection = FlexDirection.Row;
                style.flexGrow = 1;
                style.marginLeft = 10;

                Label label = new Label("Channel");
                label.AddToClassList("unity-base-field__label");

                TextElement message = new TextElement();
                message.text = "No channel found in configuration!";
                message.tooltip = "Please, refresh after having fixed your project's channels in the dashboard.";
                message.style.paddingLeft = 18;
                message.style.IconContent("console.erroricon.sml");
                message.style.backgroundPositionX = new BackgroundPosition(BackgroundPositionKeyword.Left, 2);
                message.style.flexGrow = 1;

                Add(label);
                Add(message);
            }
        }

        private GlobalSettingsProvider _provider;
        private DropdownField _channels;
        private Error _error;
        private State _state = State.NoChannel;

        public Channel(GlobalSettingsProvider provider) : base()
        {
            _provider = provider;
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = StyleKeyword.Initial;
            style.flexShrink = StyleKeyword.Initial;

            _channels = new DropdownField("Channel");
            _channels.tooltip = "The channel of the project.";
            _channels.style.flexGrow = 1;
            _channels.style.marginLeft = 0;
            _channels.style.paddingLeft = 10;

            _error = new Error();
            
            Button reset = new Button();
            reset.tooltip = "Refresh the list of channel from the dashboard.";
            reset.style.IconContent("Refresh");
            reset.style.marginLeft = 0;
            reset.style.width = 20;
            reset.clicked += OnRefresh;

            Add(_channels);
            Add(_error);
            Add(reset);

            _channels.RegisterValueChangedCallback((ev) => {
                try
                {
                    _provider.Configuration.Channel = _provider.Configuration.Channels[ev.newValue];
                }
                catch
                {
                    _provider.Configuration.Channel = 0;
                }
                _provider.UpdatedConfiguration(_provider.Configuration.Reference);
            });

            provider.onStateChanged += OnProviderStateChanged;
            provider.onConfigurationChanged += OnConfigurationChanged;

            OnProviderStateChanged(provider.ProviderState);
            OnConfigurationChanged(provider.Configuration);
        }

        private void OnProviderStateChanged(GlobalSettingsProvider.State state)
        {
            if (state >= GlobalSettingsProvider.State.NoChannel)
            {
                style.display = DisplayStyle.Flex;
            }
            else
            {
                style.display = DisplayStyle.None;
            }
        }

        private void OnRefresh()
        {
            _provider.RequestConfigurationUpdate();
        }

        private void OnConfigurationChanged(IEditorConfiguration configuration)
        {
            if (configuration == null)
            {
                return;
            }
            
            _channels.choices.Clear();
            foreach (KeyValuePair<string, short> channel in configuration.Channels)
            {
                _channels.choices.Add(channel.Key);
            }

            if (configuration.Channel != 0)
            {
                if (configuration.Channels.Values.Contains(configuration.Channel))
                {
                    SetState(State.ValidChannel);
                    return;
                }
                SetState(State.InvalidChannel);
                return;
            }

            if (configuration.Channels.Count == 0)
            {
                SetState(State.NoChannel);
                return;
            }

            if (configuration.Channels.Count == 1)
            {
                _provider.Configuration.Channel = configuration.Channels.Select(x => x.Value).FirstOrDefault();
                SetState(State.ValidChannel);
                return;
            }

            string defaultChannel = configuration.Channels.Keys.Where(x => x.ToLower() == "unity" || x.ToLower() == "unity3d" || x.ToLower() == "game").FirstOrDefault();
            if (defaultChannel == null)
            {
                SetState(State.InvalidChannel);
                return;
            }

            _provider.Configuration.Channel = configuration.Channels[defaultChannel];
            SetState(State.ValidChannel);
        }

        private void SetState(State value)
        {
            _state = value;
            switch (_state)
            {
                case State.ValidChannel:
                _provider.ProviderState = GlobalSettingsProvider.State.Ready;
                _channels.style.display = DisplayStyle.Flex;
                _error.style.display = DisplayStyle.None;

                _channels.value = _provider.Configuration.Channels.Where(x => x.Value == _provider.Configuration.Channel).Select(x => x.Key).FirstOrDefault();
                return;
                case State.InvalidChannel:
                _channels.style.display = DisplayStyle.Flex;
                _error.style.display = DisplayStyle.None;

                _channels.index = -1;
                return;
                default:
                _channels.style.display = DisplayStyle.None;
                _error.style.display = DisplayStyle.Flex;
                return;
            }
        }
    }
}