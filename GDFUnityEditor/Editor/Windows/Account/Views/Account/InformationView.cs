using GDFFoundation;

namespace GDFUnity.Editor
{
    public class InformationView : IWindowView<AccountWindow>
    {
        public string Name => "Information";
        public string Title => "Account information";
        public string Help => "/unity/editor-windows/account/account/information";

        private LabelField _environment;
        private LabelField _country;
        private LabelField _channel;
        private LabelField _account;
        private LabelField _range;
        private LabelField _token;
        private LabelField _bearer;

        public InformationView()
        {
            _environment = new LabelField();
            _environment.text = "Environment";

            _country = new LabelField();
            _country.text = "Country";
            _country.style.marginBottom = 5;

            _channel = new LabelField();
            _channel.text = "Channel";

            _range = new LabelField();
            _range.text = "Range";
            _range.style.marginBottom = 5;

            _account = new LabelField();
            _account.text = "Account";
            _account.style.marginBottom = 5;

            _token = new LabelField();
            _token.text = "Token";

            _bearer = new LabelField();
            _bearer.text = "JWT Bearer";
        }

        public void OnActivate(AccountWindow window, WindowView<AccountWindow> view)
        {
            Country country = GDFEditor.Account.Token.Country;
            MemoryJwtToken token = GDFEditor.Account.Token;

            _environment.value = GDFEditor.Environment.Environment.ToLongString();
            _country.value = $"({country.ToCodeString()}) {country.ToDisplayString()}";
            _channel.value = $"{token.Channel}";
            _account.value = $"{token.Account}";
            _range.value = $"{token.Range}";
            _token.value = $"{token.Token}";
            _bearer.value = $"{GDFEditor.Account.Bearer}";
            
            view.Add(_environment);
            view.Add(_country);
            view.Add(_channel);
            view.Add(_range);
            view.Add(_account);
            view.Add(_token);
            view.Add(_bearer);
        }

        public void OnDeactivate(AccountWindow window, WindowView<AccountWindow> view) { }
    }
}
