using System;

namespace GDFFoundation
{
    [Serializable]
    public class DeviceSignInExchange : IDeviceSign, ISignChannel
    {
        // public GDFExchangeDevice DeviceKind { set; get; } = GDFExchangeDevice.Unknown;
        public string UniqueIdentifier { set; get; } = string.Empty;
        public short Channel { get; set; }
        public string CountryIso { get; set; } = string.Empty;
    }
}