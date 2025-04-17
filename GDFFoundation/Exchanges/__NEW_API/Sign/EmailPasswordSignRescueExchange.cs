using System;

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignRescueExchange : IEmailSign, IPasswordSign
    {
        public string Email { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
    }
}