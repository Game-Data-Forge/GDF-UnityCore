using System;

namespace GDFFoundation
{
    [Serializable]
    public struct ApiErrorMessage
    {
        public int StatusCode { get; set; }
        public string InnerCode { get; set; }
        public string Message { get; set; }
        public string Help { get; set; }
    }
}