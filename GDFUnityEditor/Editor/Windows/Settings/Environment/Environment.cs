using GDFFoundation;
using GDFFoundation.Tasks;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class Environment : VisualElement
    {
        private EnumField _field;

        public Environment(LoadingView mainView) : base()
        {
            style.marginLeft = 7;

            try
            {
                _field = new EnumField("Environment", GDFEditor.Environment.Environment);
                _field.RegisterValueChangedCallback((evt) => {
                    _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
                    ITask task = GDFEditor.Environment.SetEnvironment((GDFEnvironmentKind)evt.newValue);
                    mainView.AddLoader(task, OnSetEnvironmentDone);
                    _field.SetEnabled(false);
                });

                Add(_field);

                GDFEditor.Environment.EnvironmentChangedEvent.onMainThread += OnEnvironmentChanged;
            }
            catch { }
        }

        public Environment(EnvironmentSettingsProvider provider) : this(provider.mainView)
        { }

        ~Environment()
        {
            GDFEditor.Environment.EnvironmentChangedEvent.onMainThread -= OnEnvironmentChanged;
        }

        private void OnSetEnvironmentDone(ITask task)
        {
            _field.SetEnabled(true);
        }

        private void OnEnvironmentChanged (GDFEnvironmentKind environment)
        {
            _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
        }
    }
}