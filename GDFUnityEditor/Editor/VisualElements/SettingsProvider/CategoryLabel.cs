using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class CategoryLabel : Label
    {
        public CategoryLabel(string category) : base(category)
        {
            style.unityFontStyleAndWeight = UnityEngine.FontStyle.Bold;
            style.marginLeft = 10;
            style.marginTop = 15;
        }
    }
}