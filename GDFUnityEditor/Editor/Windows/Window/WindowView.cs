using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class WindowView<T> : VisualElement
        where T : EditorWindow
    {
        protected T _window;
        protected IWindowView<T> _current;

        protected TitleLabel _title;
        private VisualElement _body;

        public IWindowView<T> Current
        {
            get => _current;
            set => SetView(value);
        }
        public string Text
        {
            get => _title.text;
            set => _title.text = value;
        }

        public WindowView(T window)
        {
            _window = window;

            _title = new TitleLabel();
            _title.style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            _title.style.marginTop = 23;
            _title.style.marginBottom = 20;
            _title.style.marginLeft = 23;
            _title.style.marginRight = 23;

            ScrollView scroll = new ScrollView(ScrollViewMode.Vertical);
            scroll.style.flexGrow = 1;
            scroll.style.minHeight = 50;

            _body = new VisualElement();
            _body.style.paddingLeft = 23;
            _body.style.paddingRight = 23;

            scroll.Add(_body);

            base.Add(_title);
            base.Add(scroll);
        }

        public new void Add(VisualElement element)
        {
            _body.Add(element);
        }

        protected void AddBody(VisualElement element)
        {
            base.Add(element);
        }

        protected virtual void SetView(IWindowView<T> view)
        {
            _current?.OnDeactivate(_window, this);
            _body.Clear();
            _current = view;
            _title.text = _current?.Title;
            //_window.help.url = provider.Help;
            _current?.OnActivate(_window, this);
        }
    }
}
