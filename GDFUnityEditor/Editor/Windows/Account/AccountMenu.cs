using System.Collections.Generic;
using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class AccountMenu : ListView
    {
        private class MenuLabel : VisualElement, IPoolItem
        {
            private TextElement _label;

            public string text
            {
                get => _label.text;
                set => _label.text = value;
            }

            public MenuLabel() : base()
            {
                style.paddingLeft = EditorGUIUtility.singleLineHeight;
                style.whiteSpace = WhiteSpace.NoWrap;

                _label = new TextElement();
                _label.style.marginTop = 1;
                _label.style.flexWrap = Wrap.NoWrap;

                Add(_label);
            }

            public Pool Pool { get; set; }

            public void Dispose() { }

            public void OnPooled() { }

            public void OnReleased()
            {
                PoolItem.Release(this);
            }
        }

        private List<AccountViewProvider> _providers = null;

        public AccountMenu(AccountWindow window)
        {
            Pool<MenuLabel> pool = new Pool<MenuLabel>();

            style.flexGrow = 1;
            horizontalScrollingEnabled = false;
            style.flexBasis = new StyleLength(StyleKeyword.Auto);
            fixedItemHeight = EditorGUIUtility.singleLineHeight;
            makeItem = () => pool.Get();
            bindItem = (ve, i) =>
            {
                MenuLabel label = ve as MenuLabel;
                label.text = _providers[i].Name;
            };
            destroyItem = (ve) => (ve as MenuLabel).Dispose();

            BuildItems(window);

            itemsSource = _providers;
        }

        private void BuildItems(AccountWindow window)
        {
            if (_providers != null) return;

            _providers = new List<AccountViewProvider>
            {
                new AccountProviderInformation(),
                new AccountProviderCredentials(window),
                new AccountProviderManagement(window)
            };
        }
    }
}
