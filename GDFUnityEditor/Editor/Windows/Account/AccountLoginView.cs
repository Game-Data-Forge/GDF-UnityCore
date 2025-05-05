using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountLoginView : VisualElement
    {
        public AccountLoginView()
        {
            style.minWidth = 200;
            style.flexGrow = 1;
            style.justifyContent = Justify.Center;

            HelpBox helpBox = new HelpBox("You must be connected to an account to see account information !", HelpBoxMessageType.Info);
            helpBox.style.marginLeft = 50;
            helpBox.style.marginRight = 50;
            
            VisualElement buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.Row;
            buttonContainer.style.justifyContent = Justify.Center;

            Button authentication = new Button();
            authentication.text = "Autentication window";
            authentication.style.width = 200;
            authentication.clicked += AuthenticationWindow.Display;

            buttonContainer.Add(authentication);

            Add(helpBox);
            Add(buttonContainer);
        }
    }
}
