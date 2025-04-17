using UnityEngine.UIElements;

namespace GDFUnity.Editor.UIElements
{
    public class DataPane : VisualElement
    {
        internal DataExplorer explorer;
        internal DataToolbar toolbar;
        internal DataTreeView treeView;
        
        public DataPane(DataExplorer dataExplorer)
        {
            explorer = dataExplorer;
            
            toolbar = new DataToolbar(this);
            treeView = new DataTreeView(this);

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
