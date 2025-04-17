using System;

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignInExchange : IEmailSign, IPasswordSign, ISignChannel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public short Channel { get; set; }
    }
}