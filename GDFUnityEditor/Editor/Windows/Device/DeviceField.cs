using System.Collections.Generic;
using GDFEditor;
using GDFFoundation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class DeviceField : VisualElement, IPoolItem
    {
        static HashSet<Device> _foldouts = new HashSet<Device>();
        private HeaderFoldout _foldout;
        private TextField _id;
        private TextField _name;
        private EnumField _os;
        private Device _device;
        private Toggle _selection;
        private DevicesToolbar _toolbar;

        public Pool Pool { get; set; }

        public DeviceField() : base()
        {
            _name = new TextField();
            _name.style.position = Position.Absolute;
            _name.style.left = 33;
            _name.style.width = 200;
            _name.style.top = 0;

            _selection = new Toggle();
            _selection.style.position = Position.Absolute;
            _selection.style.left = 15;
            _selection.style.width = 200;
            _selection.style.top = 2;
            _selection.RegisterValueChangedCallback((ev) => {
                if (ev.newValue)
                {
                    GDFEditor.Device.Select(_device);
                }
                else
                {
                    _selection.value = true;
                }
            });

            _name.RegisterCallback<FocusEvent>((ev) => {
                _foldout.SetEnabled(false);
            });
            _name.RegisterCallback<BlurEvent>((ev) => {
                _foldout.SetEnabled(true);
                GDFEditor.Device.Save();
            });
            _name.RegisterValueChangedCallback((ev) => {
                _device.Name = ev.newValue;
            });

            _foldout = new HeaderFoldout();
            _foldout.RegisterValueChangedCallback((ev) => OnFoldoutChange(ev.newValue));



            _id = new TextField("Id");

            _os = new EnumField("OS", GDFExchangeDevice.Unknown);
            _os.RegisterValueChangedCallback((ev) => {
                _device.OS = (GDFExchangeDevice)ev.newValue;
            });

            _foldout.Add(_id);
            _foldout.Add(_os);

            Add(_foldout);
            Add(_selection);
            Add(_name);
        }

        private void OnFoldoutChange(bool value)
        {
            if (value)
            {
                _name.style.display = DisplayStyle.Flex;
                _os.style.display = DisplayStyle.Flex;
                _foldouts.Remove(_device);
            }
            else
            {
                _name.style.display = DisplayStyle.None;
                _os.style.display = DisplayStyle.None;
                _foldouts.Add(_device);
            }
        }

        public void Dispose()
        {
            PoolItem.Release(this);
        }

        public void OnPooled()
        {
            _device = null;
            _id.SetEnabled(false);
        }

        public void OnReleased()
        {
        }

        public void SetDevice(DevicesToolbar toolbar, Device device, bool isDefault)
        {
            _device = device;
            _toolbar = toolbar;
            _toolbar.onSearchChanged -= SearchChanged;
            _toolbar.onSearchChanged += SearchChanged;
            
            _foldout.value = !_foldouts.Contains(device);
            OnFoldoutChange(_foldout.value);

            _foldout.text = device.Name;
            _name.value = device.Name;
            _id.value = device.Id;
            _os.value = device.OS;

            _name.SetEnabled(!isDefault);
            _os.SetEnabled(!isDefault);
            _selection.value = device.Id == GDFEditor.Device.Id;
            _name.tooltip = isDefault ? "Cannot change the name of the actual device." : "";
            
            _foldout.label.style.paddingLeft = 20;

            _foldout.RegisterActionMenu(() => {
                GenericMenu menu = new GenericMenu();
                if (device.Id == GDFEditor.Device.Id)
                {
                    menu.AddDisabledItem(new GUIContent("Selected"));
                }
                else
                {
                    menu.AddItem(new GUIContent("Select"), false, () => {
                        GDFEditor.Device.Select(device);
                    });
                }

                if (!isDefault)
                {
                    menu.AddItem(new GUIContent("Remove"), false, () => {
                        GDFEditor.Device.Delete(device);
                    });
                }
                menu.ShowAsContext();
            });

            SearchChanged(_toolbar.search);
        }

        private void SearchChanged (string[] values)
        {
            style.display = IsValidSearch(values) ? DisplayStyle.Flex : DisplayStyle.None;
        }

        private bool IsValidSearch(string[] values)
        {
            if (values == null || values.Length == 0) return true;

            foreach (string value in values)
            {
                if (!string.IsNullOrWhiteSpace(value) && _device.Name.IndexOf(value, System.StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
