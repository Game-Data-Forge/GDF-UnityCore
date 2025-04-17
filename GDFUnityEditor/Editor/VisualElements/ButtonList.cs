using System.Collections.Generic;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class ButtonList : VisualElement
    {
        private List<VisualElement> _elements = new List<VisualElement>();

        public ButtonList()
        {

        }

        public new void Clear()
        {
            base.Clear();
            _elements.Clear();
        }

        public new void Add(VisualElement element)
        {
            if (_elements.Count == 0)
            {
                base.Add(Spacer());
            }

            base.Add(element);
            _elements.Add(element);
            base.Add(Spacer());
        }

        private VisualElement Spacer()
        {
            VisualElement space = new VisualElement();
            space.style.flexGrow = 1;
            return space;
        }
    }
}
