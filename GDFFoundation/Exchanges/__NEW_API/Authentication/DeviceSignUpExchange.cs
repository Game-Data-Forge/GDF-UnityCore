using System;

namespace GDFFoundation
{
    [Serializable]
    public class DeviceSignUpExchange : IDeviceSign, ISignConsent
    {
        // public GDFExchangeDevice DeviceKind { set; get; } = GDFExchangeDevice.Unknown;
        public string UniqueIdentifier { set; get; } = string.Empty;
        public bool Consent { get; set; } = false;
        public string ConsentVersion { get; set; } = "1.0.0";
        public string GameConsentVersion { get; set; } = "1.0.0";
        public ConsentOptions GameConsentOptions { get; set; } = 0;
        public short Channel { get; set; } = 0;
        public string CountryIso { get; set; } = string.Empty;
    }
}