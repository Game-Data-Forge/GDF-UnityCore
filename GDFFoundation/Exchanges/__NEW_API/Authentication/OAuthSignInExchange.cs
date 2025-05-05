using System;
using GDFFoundation;

namespace GDFFoundation
{
    [Serializable]
    public class OAuthSignInExchange : IOAuthSign, ISignChannel
    {
        public GDFOAuthKind OAuth { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string ClientId { get; set; }
        public short Channel { get; set; }
        public string CountryIso { get; set; }
    }
}