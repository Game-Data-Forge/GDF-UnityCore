using UnityEditor.UIElements;

namespace GDFUnity.Editor.UIElements
{
    public class CategoryToolbar : Toolbar
    {
        private CategoryPane _pane;
        internal ToolbarSearchField _search;
        
        public CategoryToolbar(CategoryPane pane)
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
