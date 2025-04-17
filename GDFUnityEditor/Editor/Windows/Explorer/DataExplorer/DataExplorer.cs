using UnityEngine.UIElements;

namespace GDFUnity.Editor.UIElements
{
    public class DataExplorer : TwoPaneSplitView
    {
        internal ExplorerWindow window;
        private CategoryPane _category;
        private DataPane _data;
        public DataExplorer(ExplorerWindow window) : base(0, 200, TwoPaneSplitViewOrientation.Horizontal)
        {
            this.window = window;

            _category = new CategoryPane(this);
            _data = new DataPane(this);

            Add(_category);
            Add(_data);
        }
        
        public void OnViewDisplayChange(LoadingView.Display display)
        {
            _category.OnViewDisplayChange(display);
            _data.OnViewDisplayChange(display);
        }
    }
}
