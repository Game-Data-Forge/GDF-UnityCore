using System;

namespace GDFFoundation
{
    [Serializable]
    public class GDFAccountConsent : GDFAccountData, ISignConsent, ISignCountry
    {
        
        public bool Consent { set; get; } = false;
        public string ConsentVersion { set; get; } = "0.0.0";
        public string GameConsentVersion { set; get; } = "0.0.0";
        public ConsentOptions GameConsentOptions { set; get; } = ConsentOptions.None;
        public short Channel { get; set; } = 0;
        public string CountryIso { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}