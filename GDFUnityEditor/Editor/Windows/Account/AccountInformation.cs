using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountInformation : VisualElement
    {
        private LabelField _environment;
        private LabelField _country;
        private LabelField _channel;
        private LabelField _account;
        private LabelField _range;
        private LabelField _token;
        private LabelField _bearer;

        public AccountInformation()
        {
            style.minWidth = 200;
            style.justifyContent = Justify.Center;
            style.flexGrow = 1;
            style.paddingLeft = 50;
            style.paddingRight = 50;

            Label title = new Label();
            title.text = "Account information";
            title.style.fontSize = 19;
            title.style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            title.style.marginBottom = 20;
            title.style.marginLeft = 3;
            title.style.marginRight = 3;

            _environment = new LabelField();
            _environment.text = "Environment";
            _environment.style.marginLeft = 3;
            _environment.style.marginRight = 3;


            _country = new LabelField();
            _country.text = "Country";
            _country.style.marginLeft = 3;
            _country.style.marginRight = 3;
            _country.style.marginBottom = 5;

            _channel = new LabelField();
            _channel.text = "Channel";
            _channel.style.marginLeft = 3;
            _channel.style.marginRight = 3;

            _range = new LabelField();
            _range.text = "Range";
            _range.style.marginLeft = 3;
            _range.style.marginRight = 3;
            _range.style.marginBottom = 5;

            _account = new LabelField();
            _account.text = "Account";
            _account.style.marginLeft = 3;
            _account.style.marginRight = 3;
            _account.style.marginBottom = 5;

            _token = new LabelField();
            _token.text = "Token";
            _token.style.marginLeft = 3;
            _token.style.marginRight = 3;

            _bearer = new LabelField();
            _bearer.text = "JWT Bearer";
            _bearer.style.marginLeft = 3;
            _bearer.style.marginRight = 3;

            Add(title);
            Add(_environment);
            Add(_country);
            Add(_channel);
            Add(_range);
            Add(_account);
            Add(_token);
            Add(_bearer);
        }

        public void Update()
        {
            GDFCountryISO countryISO = GDFEditor.Authentication.Country;
            MemoryJwtToken token = GDFEditor.Authentication.Token;

            _environment.value = GDFEditor.Environment.Environment.ToLongString();
            _country.value = $"({countryISO?.TwoLetterCode}) {countryISO?.Name}";
            _channel.value = $"{token.Channel}";
            _account.value = $"{token.Account}";
            _range.value = $"{token.Range}";
            _token.value = $"{token.Token}";
            _bearer.value = $"{GDFEditor.Authentication.Bearer}";
        }
    }
}
