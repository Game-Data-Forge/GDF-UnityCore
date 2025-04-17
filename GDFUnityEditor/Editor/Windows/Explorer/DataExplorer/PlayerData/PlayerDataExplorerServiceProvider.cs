namespace GDFUnity.Editor.ServiceProviders
{
    public class PlayerDataExplorerServiceProvider : DataExplorerServiceProvider
    {
        private CategoryServiceProvider _category = new PlayerCategoryServiceProvider();
        private DataServiceProvider _data = new PlayerDataServiceProvider();

        public override CategoryServiceProvider Category => _category;
        public override DataServiceProvider Data => _data;
    }
}
