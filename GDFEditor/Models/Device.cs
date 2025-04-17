using GDFFoundation;

namespace GDFEditor
{
    public class Device : ICredentials
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public GDFExchangeDevice OS { get; set; }
    }
}
