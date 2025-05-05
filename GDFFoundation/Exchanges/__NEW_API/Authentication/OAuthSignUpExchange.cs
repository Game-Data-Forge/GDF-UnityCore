using System;
using GDFFoundation;

namespace GDFFoundation
{
    [Serializable]
    public class OAuthSignUpExchange : IOAuthSign, ISignConsent
    {
        public GDFOAuthKind OAuth { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string ClientId { get; set; }
        public short Channel { get; set; }
        public bool Consent { set; get; }
        public string ConsentVersion { set; get; }
        public string GameConsentVersion { set; get; }
        public ConsentOptions GameConsentOptions { set; get; }
        public string CountryIso { get; set; }
    }
}