using GDFFoundation;

namespace GDFFoundation
{

    public interface IOAuthSign
    {
        public GDFOAuthKind OAuth { set; get; }
        public string AccessToken { set; get; }
        public string ClientID { set; get; }
    }
}