using UnityEditor.UIElements;

namespace GDFUnity.Editor.UIElements
{
    public class DataToolbar : Toolbar
    {
        private DataPane _pane;
        private ToolbarSearchField _search;

        private DataTreeView _TreeView => _pane.treeView;

        public DataToolbar(DataPane pane)
        {
            _pane = pane;

            _search = new ToolbarSearchField();

            Add(_search);
        }
        
        public void OnViewDisplayChange(LoadingView.Display display)
        {
            
        }
    }
}
