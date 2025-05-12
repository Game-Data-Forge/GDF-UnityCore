using System;

namespace GDFFoundation
{
    [Serializable]
    public class SignModifyExchange : IGDFLongReference
    {
        public long Reference { get; set; }
        public string OldEmail { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}