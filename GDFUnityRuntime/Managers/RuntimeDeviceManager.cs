using GDFFoundation;
using GDFRuntime;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeDeviceManager : IRuntimeDeviceManager
    {
        static private GDFExchangeDevice CurrentOS()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                case RuntimePlatform.OSXServer:
                    return GDFExchangeDevice.Macos;
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WindowsServer:
                    return GDFExchangeDevice.Windows;
                case RuntimePlatform.LinuxEditor:
                case RuntimePlatform.LinuxPlayer:
                case RuntimePlatform.LinuxServer:
                case RuntimePlatform.EmbeddedLinuxArm32:
                case RuntimePlatform.EmbeddedLinuxArm64:
                case RuntimePlatform.EmbeddedLinuxX64:
                case RuntimePlatform.EmbeddedLinuxX86:
                    return GDFExchangeDevice.Linux;
                case RuntimePlatform.Android:
                    return GDFExchangeDevice.Android;
                case RuntimePlatform.IPhonePlayer:
                    return GDFExchangeDevice.Ios;
                case RuntimePlatform.WebGLPlayer:
                    return GDFExchangeDevice.Web;
                default:
                    return GDFExchangeDevice.Unknown;

            }
        }

        private string _id;
        private string _name;
        private GDFExchangeDevice _os;

        public virtual string Id => _id;
        public virtual string Name => _name;
        public virtual GDFExchangeDevice OS => _os;

        public RuntimeDeviceManager()
        {
            _id = SystemInfo.deviceUniqueIdentifier;
            _name = SystemInfo.deviceName;
            _os = CurrentOS();
        }
    }
}