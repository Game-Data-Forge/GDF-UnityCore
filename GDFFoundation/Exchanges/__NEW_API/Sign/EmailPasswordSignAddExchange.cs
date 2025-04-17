using System;

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignAddExchange : IEmailSign, IPasswordSign
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}