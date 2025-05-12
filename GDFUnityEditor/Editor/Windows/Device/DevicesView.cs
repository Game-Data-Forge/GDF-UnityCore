using System.Collections.Generic;
using GDFEditor;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class DevicesView : ScrollView
    {
        private Pool<DeviceField> _pool = new Pool<DeviceField>();
        private List<Device> _devices;
        private DevicesToolbar _toolbar;

        public DevicesView(DevicesWindow window, DevicesToolbar toolbar) : base(ScrollViewMode.Vertical)
        {
            window.mainView.onDisplayChanged += display => {
                if (display == LoadingView.Display.PreLoader) return;

                _toolbar = toolbar;
                _devices = GDFEditor.Device.Devices;

                GDFEditor.Device.onDeviceChanged += UpdateList;
                UpdateList();
            };
        }

        public void OnDestroy()
        {
            GDFEditor.Device.onDeviceChanged -= UpdateList;
        }

        private void UpdateList(Device device)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            Clear();

            List<DeviceField> fields = new List<DeviceField>();

            foreach (Device device in _devices)
            {
                DeviceField field = _pool.Get();
                field.SetDevice(_toolbar, device, GDFEditor.Device.IsDefault(device));
                Add(field);
                fields.Add(field);
            }

            foreach (DeviceField field in fields)
            {
                field.Dispose();
            }
        }
    }
}
