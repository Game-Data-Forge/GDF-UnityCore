using System;
using GDFFoundation;

namespace GDFFoundation
{
    [Serializable]
    public class OAuthSignAdd : IOAuthSign
    {
        public GDFOAuthKind OAuth { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string ClientId { get; set; }
    }
}