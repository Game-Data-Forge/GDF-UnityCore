using System;

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignModifyExchange : IEmailSign, IPasswordSign, ISignReference
    {
        public long Reference { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}