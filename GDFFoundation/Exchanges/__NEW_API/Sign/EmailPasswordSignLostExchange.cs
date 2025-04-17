using System;

namespace GDFFoundation
{
    [Serializable]
    public class EmailPasswordSignLostExchange : IEmailSign
    {
        public string Email { get; set; } = string.Empty;
    }
}