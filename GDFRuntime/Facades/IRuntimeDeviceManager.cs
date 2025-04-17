using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeDeviceManager
    {
        public string Id { get; }
        public string Name { get; }
        public GDFExchangeDevice OS { get; }
    }
}