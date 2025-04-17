namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class DataExplorerServiceProvider
    {
        public abstract CategoryServiceProvider Category { get; }
        public abstract DataServiceProvider Data { get; }
    }
}
