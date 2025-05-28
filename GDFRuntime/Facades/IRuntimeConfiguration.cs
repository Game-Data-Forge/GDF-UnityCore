using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeConfiguration
    {
        public long Reference { get; }
        public string Name { get; }
        public string Organization { get; }
        public ProjectEnvironment Environment { get; }
        public string PublicToken { get; }
        public short Channel { get; }
        public CloudConfiguration CloudConfig { get; }
    }
}