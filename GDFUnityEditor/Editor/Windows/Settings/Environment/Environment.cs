using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class Environment : VisualElement
    {
        private EnumField _field;

        public Environment(LoadingView loadingView) : base()
        {
            style.marginLeft = 7;

            _field = new EnumField("Environment", GDFEditor.Environment.Environment);
            _field.RegisterValueChangedCallback((evt) => {
                _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
                IJob task = GDFEditor.Environment.SetEnvironment((ProjectEnvironment)evt.newValue);
                loadingView.AddLoader(task, OnSetEnvironmentDone);
                _field.SetEnabled(false);
            });

            Add(_field);

            GDFEditor.Environment.EnvironmentChanged.onMainThread += OnEnvironmentChanged;
        }

        public Environment(EnvironmentSettingsProvider provider) : this(provider.mainView)
        { }

        ~Environment()
        {
            GDFEditor.Environment.EnvironmentChanged.onMainThread -= OnEnvironmentChanged;
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