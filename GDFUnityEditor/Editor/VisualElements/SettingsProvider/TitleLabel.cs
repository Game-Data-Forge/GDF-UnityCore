using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class TitleLabel : Label
    {
        public TitleLabel(string title) : base(title)
        {
            style.fontSize = 19;
            style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            style.marginLeft = 9;
        }
    }
}