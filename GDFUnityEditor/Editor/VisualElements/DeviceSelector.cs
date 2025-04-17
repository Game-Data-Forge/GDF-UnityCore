using GDFEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class DeviceSelector : VisualElement
    {
        private PopupField<Device> _devices;

        public DeviceSelector()
        {
            style.flexDirection = FlexDirection.Row;
            style.flexGrow = 1;
            style.maxHeight = 20;

            _devices = new PopupField<Device>("Device");
            _devices.style.flexGrow = 1;
            _devices.formatSelectedValueCallback += Display;
            _devices.formatListItemCallback += Display;

            _devices.RegisterValueChangedCallback((ev) => {
                GDFEditor.Device.Select(ev.newValue);
            });

            _devices.choices = GDFEditor.Device.Devices;

            Button manage = new Button();
            manage.text = "Manage devices";
            manage.clicked += () => DevicesWindow.Display();

            GDFEditor.Device.onDeviceChanged += OnDeviceChanged;

            Add(_devices);
            Add(manage);

            OnDeviceChanged(GDFEditor.Device.Current);
        }

        private string Display(Device device)
        {
            return device?.Name ?? "";
        }

        private void OnDeviceChanged(Device device)
        {
            _devices.choices = GDFEditor.Device.Devices;
            _devices.value = device;
        }
    }
}
