using System;

namespace GDFFoundation
{
    [Serializable]
    public struct OkMessageResult
    {
        public string message { get; set; }
        public string environment { get; set; }
        public string project { get; set; }
        public string channel { get; set; }
        public long account { get; set; }
    }
}