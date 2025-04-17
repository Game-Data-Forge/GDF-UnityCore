using System;

namespace GDFFoundation
{
    [Serializable]
    public class OAuthSignRevokeExchange : ISignReference
    {
        public long Reference { get; set; }
    }
}