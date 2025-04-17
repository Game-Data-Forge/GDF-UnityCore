using UnityEngine.UIElements;

namespace GDFUnity.Editor.UIElements
{
    public class CategoryPane : VisualElement
    {
        internal DataExplorer explorer;
        internal CategoryToolbar toolbar;
        internal CategoryTreeView treeView;

        public CategoryPane(DataExplorer dataExplorer)
        {
            explorer = dataExplorer;

            toolbar = new CategoryToolbar(this);
            treeView = new CategoryTreeView(this);

            toolbar._search.onChanged += treeView.OnSearchChanged;

            Add(toolbar);
            Add(treeView);
        }
        
        public void OnViewDisplayChange(LoadingView.Display display)
        {
            toolbar.OnViewDisplayChange(display);
            treeView.OnViewDisplayChange(display);
        }
    }
}
