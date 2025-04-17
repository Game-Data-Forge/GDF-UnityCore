using System;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class ToolbarSearchField : UnityEditor.UIElements.ToolbarSearchField
    {
        public event Action onChanged;
        private string[] _parts;

        public bool hasSearch => !string.IsNullOrWhiteSpace(value);

        public ToolbarSearchField()
        {
            style.width = new StyleLength(StyleKeyword.Auto);
            style.flexGrow = 1;
            style.flexShrink = 1;

            hierarchy[1].style.flexGrow = 1;
            hierarchy[1].style.flexBasis = 1;
            hierarchy[1].style.flexShrink = 0;

            hierarchy[1].hierarchy[0].style.paddingRight = 0;

            this.RegisterValueChangedCallback(e => {
                _parts = e.newValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                onChanged?.Invoke();
            });
        }

        public bool IsMatch(string value)
        {
            if (_parts == null || _parts.Length == 0)
            {
                return true;
            }

            for (int i = _parts.Length - 1; i >= 0; i--)
            {
                if (value.IndexOf(_parts[i], StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
