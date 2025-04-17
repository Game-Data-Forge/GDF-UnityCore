using System;

namespace GDFFoundation
{
    [Serializable]
    public struct PayloadMessageResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Payload { get; set; }
    }
}