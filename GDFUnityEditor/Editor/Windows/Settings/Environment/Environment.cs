using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class Environment : VisualElement
    {
        private EnumField _field;
        private LoadingView _mainView;

        public Environment(LoadingView mainView) : base()
        {
            _mainView = mainView;
            style.marginLeft = 7;

            mainView.onDisplayChanged += OnDisplayReady;

            OnDisplayReady(_mainView.MainDisplay);
        }

        public Environment(EnvironmentSettingsProvider provider) : this(provider.mainView)
        { }

        ~Environment()
        {
            GDFEditor.Environment.EnvironmentChanged.onMainThread -= OnEnvironmentChanged;
        }

        private void OnDisplayReady(LoadingView.Display display)
        {
            if (display == LoadingView.Display.PreLoader) return;

            _field = new EnumField("Environment", GDFEditor.Environment.Environment);
            _field.RegisterValueChangedCallback((evt) => {
                _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
                IJob task = GDFEditor.Environment.SetEnvironment((ProjectEnvironment)evt.newValue);
                _mainView.AddLoader(task, OnSetEnvironmentDone);
                _field.SetEnabled(false);
            });

            Add(_field);

            GDFEditor.Environment.EnvironmentChanged.onMainThread += OnEnvironmentChanged;
        }

        private void OnSetEnvironmentDone(IJob task)
        {
            _field.SetEnabled(true);
        }

        private void OnEnvironmentChanged (ProjectEnvironment environment)
        {
            _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
        }
    }
}