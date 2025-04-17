using System;
using System.Collections.Generic;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorDeviceManager : IRuntimeDeviceManager
    {
        public event Action<Device> onDeviceChanged;
        
        public List<Device> Devices { get; }
        
        public Device Current { get; }

        public void Select(Device device);
        public Device Add();
        public bool Delete(Device device);
        public bool IsDefault(Device device);
        public void Save();
    }
}