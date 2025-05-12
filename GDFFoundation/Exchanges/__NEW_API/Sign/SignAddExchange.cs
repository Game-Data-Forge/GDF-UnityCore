using System;

namespace GDFFoundation
{
    [Serializable]
    public class SignAddExchange : IEmailSign, IPasswordSign
    {
        public GDFAccountSignType Kind { set; get; } = GDFAccountSignType.EmailPassword;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
    }
}