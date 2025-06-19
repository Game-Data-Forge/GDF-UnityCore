using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class LocalView : AuthenticationView, IWindowView<AccountWindow>
    {
        public string Name => "Local";
        public string Title => "Local authentication";
        public string Help => "/unity/editor-windows/account/authentication/local";

        public override bool NeedCountry => false;
        public override bool NeedConsent => false;

        private Button _login;

        public LocalView(AccountView view) : base(view)
        {
            _login = new Button();
            _login.text = "Login";
            _login.style.width = 100;
            _login.clicked += () =>
            {
                view.Load(GDFEditor.Account.Authentication.Local.Login());
            };
        }

        protected override void OnActivate(AccountWindow window, AccountView view)
        {
            view.buttons.Add(_login);
        }
        
        protected override void OnDeactivate(AccountWindow window, AccountView view)
        {

        }
    }
}
