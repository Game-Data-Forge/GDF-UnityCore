using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountView : ScrollView
    {
        private AccountViewProvider _current;

        private TitleLabel _title;
        private VisualElement _body;
        private AccountWindow _window;

        public AccountView(AccountWindow window) : base(ScrollViewMode.Vertical)
        {
            _window = window;
            style.flexGrow = 1;

            _title = new TitleLabel();
            _title.style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            _title.style.marginTop = 23;
            _title.style.marginBottom = 20;
            _title.style.marginLeft = 23;
            _title.style.marginRight = 23;

            _body = new VisualElement();
            _body.style.paddingLeft = 23;
            _body.style.paddingRight = 23;

            _window.menu.selectionChanged += selection => {
                foreach (object item in selection)
                {
                    SetProvider(item as AccountViewProvider);
                    return;
                }
            };

            Add(_title);
            Add(_body);
        }

        public void SetProvider(AccountViewProvider provider)
        {
            _current?.OnDeactivate(this, _body);
            _body.Clear();
            _current = provider;
            _title.text = _current.Title;
            _window.help.url = provider.Help;
            _current.OnActivate(this, _body);
        }
    }
}
