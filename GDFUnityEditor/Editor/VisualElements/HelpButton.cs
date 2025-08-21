using UnityEngine;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class HelpButton : VisualElement
    {
        public const string DOC_SERVER = "https://documentation.game-data-forge.com";
        private string _url;

        public string url
        {
            get => _url;
            set
            {
                _url = value;
                if (_url == null)
                {
                    style.display = DisplayStyle.None;
                    return;
                }
                style.display = DisplayStyle.Flex;
                _url = url.Trim();
            }
        }

        public HelpButton(Position position) : this(null, position)
        {
            
        }

        public HelpButton(string url, Position position) : base()
        {
            this.url = url;

            style.IconContent("_Help");
            style.height = 20;
            style.width = 20;
            style.borderLeftWidth = 0;
            style.borderRightWidth = 0;
            style.position = position;
            if (position == Position.Absolute)
            {
                style.right = 0;
                style.top = 0;
            }

            RegisterCallback<ClickEvent>(Click);
        }

        private void Click(ClickEvent evt)
        {
            Application.OpenURL(DOC_SERVER + _url);
        }
    }
}
