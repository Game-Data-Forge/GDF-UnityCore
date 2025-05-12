using GDFFoundation;
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
                    IJob task = GDFEditor.Environment.SetEnvironment((GDFEnvironmentKind)evt.newValue);
                    mainView.AddLoader(task, OnSetEnvironmentDone);
                    _field.SetEnabled(false);
                });

                Add(_field);

                GDFEditor.Environment.EnvironmentChangedNotif.onMainThread += OnEnvironmentChanged;
            }
            catch { }
        }

        public Environment(EnvironmentSettingsProvider provider) : this(provider.mainView)
        { }

        ~Environment()
        {
            GDFEditor.Environment.EnvironmentChangedNotif.onMainThread -= OnEnvironmentChanged;
        }

        private void OnSetEnvironmentDone(IJob task)
        {
            _field.SetEnabled(true);
        }

        private void OnEnvironmentChanged (GDFEnvironmentKind environment)
        {
            _field.SetValueWithoutNotify(GDFEditor.Environment.Environment);
        }
    }
}