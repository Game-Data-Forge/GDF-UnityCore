using System;
using GDFFoundation;

namespace GDFFoundation
{
    [Serializable]
    public class OAuthSignAddExchange : IOAuthSign
    {
        public GDFOAuthKind OAuth { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string ClientID { get; set; }
    }
}