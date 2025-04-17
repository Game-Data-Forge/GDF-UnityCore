using System;
using GDFFoundation.Tasks;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AuthenticationLogoutView : VisualElement
    {
        private AuthenticationWindow _window;
        public AuthenticationLogoutView(AuthenticationWindow window)
        {
            _window = window;

            style.minWidth = 200;
            style.flexGrow = 1;
            style.justifyContent = Justify.Center;

            HelpBox helpBox = new HelpBox("Already connected !", HelpBoxMessageType.Info);
            helpBox.style.marginLeft = 50;
            helpBox.style.marginRight = 50;
            
            VisualElement buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.Row;
            buttonContainer.style.justifyContent = Justify.Center;

            Button logout = new Button();
            logout.text = "Logout";
            logout.style.width = 100;
            logout.clicked += () => {
                Load(GDF.Authentication.SignOut());
            };

            buttonContainer.Add(logout);

            Add(helpBox);
            Add(buttonContainer);
        }

        public void Load(ITask load, Action<ITask> onDone = null)
        {
            _window.mainView.AddLoader(load, (task) => {
                try
                {
                    onDone?.Invoke(task);
                }
                finally
                {
                    _window.mainView.SetBodyEnabled(true);
                }
            });

            _window.mainView.SetBodyEnabled(false);
        }
    }
}
