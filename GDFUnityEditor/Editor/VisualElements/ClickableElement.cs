using UnityEditor.UIElements;

namespace GDFUnity.Editor
{
    public class ClickableElement : ToolbarButton
    {
        public ClickableElement() : base()
        {
            style.borderLeftWidth = 0;
            style.borderRightWidth = 0;
        }
    }
}
