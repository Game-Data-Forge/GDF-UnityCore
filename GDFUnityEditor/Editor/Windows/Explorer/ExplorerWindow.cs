using UnityEditor;
using GDFUnity.Editor.UIElements;
using GDFUnity.Editor.ServiceProviders;

namespace GDFUnity.Editor
{
    public class ExplorerWindow : EditorWindow
    {
        //[MenuItem("GDF/Data/Explorer...", priority = 22, secondaryPriority = 1)]
        static public void Display()
        {
            ExplorerWindow window = GetWindow<ExplorerWindow>("Data explorer");
            window.Focus();
        }

        internal DataExplorerServiceProvider provider = new PlayerDataExplorerServiceProvider();
        internal LoadingView mainView;
        
        public void CreateGUI()
        {
            DataExplorer dataExplorer = new DataExplorer(this);

            mainView = new LoadingView(dataExplorer);
            mainView.AddPreloader(new EnginePreLoader());

            mainView.onDisplayChanged += dataExplorer.OnViewDisplayChange;
            dataExplorer.OnViewDisplayChange(mainView.MainDisplay);

            rootVisualElement.Add(mainView);
        }
    }
}
