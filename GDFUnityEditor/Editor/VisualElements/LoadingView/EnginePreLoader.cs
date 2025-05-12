using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class EnginePreLoader : PreLoader
    {
        private LoadingView _view;
        private HelpBox _helpBox;
        private Button _button;

        public EnginePreLoader()
        {
            style.flexGrow = 1;
            style.paddingLeft = 100;
            style.paddingRight = 100;
            style.justifyContent = Justify.Center;
            _helpBox = new HelpBox();
            _button = new Button();

            Add(_helpBox);
            Add(_button);
        }

        public override void PreLoad(LoadingView view)
        {
            _view = view;
            try
            {
                IJob task = GDFEditor.Launch;
                _helpBox.text = "Loading engine...";
                _helpBox.messageType = HelpBoxMessageType.Info;

                _button.style.display = DisplayStyle.None;
                if (task.InUse())
                {
                    _view.AddLoader(task, OnEngineLoaded);
                }
                else
                {
                    OnEngineLoaded(task);
                }
            }
            catch
            {
                _helpBox.messageType = HelpBoxMessageType.Error;
                _helpBox.text = "Engine couldn't be loaded.\nPlease check the engine configuration.";
                
                _button.text = "Check engine configuration";
                _button.clicked += () => {
                    GlobalSettingsProvider.Display();
                };
                _button.style.display = DisplayStyle.Flex;
            }
        }

        private void OnEngineLoaded (IJob task)
        {
            _view.MainDisplay = LoadingView.Display.Body;
        }
    }
}