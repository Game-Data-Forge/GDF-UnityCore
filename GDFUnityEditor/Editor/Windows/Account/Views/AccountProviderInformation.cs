using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountProviderInformation : AccountViewProvider
    {
        public override string Name => "Information";
        public override string Title => "Account information";
        public override string Help => null;

        private LabelField _environment;
        private LabelField _country;
        private LabelField _channel;
        private LabelField _account;
        private LabelField _range;
        private LabelField _token;
        private LabelField _bearer;

        public AccountProviderInformation()
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

        public override void OnActivate(AccountView view, VisualElement rootElement)
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
            
            rootElement.Add(_environment);
            rootElement.Add(_country);
            rootElement.Add(_channel);
            rootElement.Add(_range);
            rootElement.Add(_account);
            rootElement.Add(_token);
            rootElement.Add(_bearer);
        }

        public override void OnDeactivate(AccountView view, VisualElement rootElement)
        {
            
        }
    }
}
