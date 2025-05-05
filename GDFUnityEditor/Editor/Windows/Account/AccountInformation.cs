using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountInformation : VisualElement
    {
        private AccountWindow _window;
        private LabelField _environment;
        private LabelField _country;
        private LabelField _channel;
        private LabelField _account;
        private LabelField _range;
        private LabelField _token;
        private LabelField _bearer;

        public AccountInformation(AccountWindow window)
        {
            _window = window;

            VisualElement titleBar = new VisualElement();
            titleBar.style.marginBottom = 20;
            titleBar.style.marginTop = 50;
            titleBar.style.marginLeft = 53;
            titleBar.style.marginRight = 53;
            titleBar.style.flexDirection = FlexDirection.Row;

            Label title = new Label();
            title.text = "Account information";
            title.style.flexGrow = 1;
            title.style.fontSize = 19;
            title.style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;

            Button delete = new Button(Delete);
            delete.text = "Delete";
            delete.tooltip = "Delete the account";

            titleBar.Add(title);
            titleBar.Add(delete);

            ScrollView scroll = new ScrollView(ScrollViewMode.Vertical);
            scroll.style.flexGrow = 1;

            _environment = new LabelField();
            _environment.text = "Environment";
            _environment.style.marginLeft = 53;
            _environment.style.marginRight = 53;

            _country = new LabelField();
            _country.text = "Country";
            _country.style.marginLeft = 53;
            _country.style.marginRight = 53;
            _country.style.marginBottom = 5;

            _channel = new LabelField();
            _channel.text = "Channel";
            _channel.style.marginLeft = 53;
            _channel.style.marginRight = 53;

            _range = new LabelField();
            _range.text = "Range";
            _range.style.marginLeft = 53;
            _range.style.marginRight = 53;
            _range.style.marginBottom = 5;

            _account = new LabelField();
            _account.text = "Account";
            _account.style.marginLeft = 53;
            _account.style.marginRight = 53;
            _account.style.marginBottom = 5;

            _token = new LabelField();
            _token.text = "Token";
            _token.style.marginLeft = 53;
            _token.style.marginRight = 53;

            _bearer = new LabelField();
            _bearer.text = "JWT Bearer";
            _bearer.style.marginLeft = 53;
            _bearer.style.marginRight = 53;

            Add(titleBar);
            Add(scroll);
            scroll.Add(_environment);
            scroll.Add(_country);
            scroll.Add(_channel);
            scroll.Add(_range);
            scroll.Add(_account);
            scroll.Add(_token);
            scroll.Add(_bearer);
        }

        public void Update()
        {
            GDFCountryISO countryISO = GDFEditor.Authentication.Token.GetCountry();
            MemoryJwtToken token = GDFEditor.Authentication.Token;

            _environment.value = GDFEditor.Environment.Environment.ToLongString();
            _country.value = $"({countryISO?.TwoLetterCode}) {countryISO?.Name}";
            _channel.value = $"{token.Channel}";
            _account.value = $"{token.Account}";
            _range.value = $"{token.Range}";
            _token.value = $"{token.Token}";
            _bearer.value = $"{GDFEditor.Authentication.Bearer}";
        }

        private void Delete()
        {
            if (!EditorUtility.DisplayDialog("Account deletion", "You are about to delete the current account. All data related to this account will be deleted and you will be disconnected."+
                "\nDo you wish to proceed?", "Yes", "No"))
            {
                return;
            }
            
            SetEnabled(false);

            _window.mainView.AddLoader(GDF.Account.Delete(), _ => {
                SetEnabled(true);
            });
        }
    }
}
