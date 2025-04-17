using System;

namespace GDFFoundation
{
    [Serializable]
    public class ConsentExchange : ISignConsent, ISignCountry, ISignChannel
    {
        public string CountryIso { get; set; } = String.Empty;
        public short Channel { get; set; }
        public bool Consent { set; get; }
        public string ConsentVersion { set; get; }
        public string GameConsentVersion { set; get; }
        public ConsentOptions GameConsentOptions { set; get; }
    }
}