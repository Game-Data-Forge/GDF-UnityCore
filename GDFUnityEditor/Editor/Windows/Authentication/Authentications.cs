using System;
using System.Collections.Generic;
using System.Linq;
using GDFFoundation;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using GDFUnity.Editor.ServiceProviders;

namespace GDFUnity.Editor
{
    public class Authentications : VisualElement
    {
        private class AuthLabel : VisualElement, IPoolItem
        {
            private TextElement _label;

            public string text
            {
                get => _label.text;
                set => _label.text = value;
            }

            public AuthLabel() : base()
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

        private ListView _authentications;
        private ToolbarSearchField _search;
        private AuthenticationWindow _window;
        private List<AuthenticationSettingsProvider> _providers = new List<AuthenticationSettingsProvider>();

        public Authentications(AuthenticationWindow window)
        {
            _window = window;
            Pool<AuthLabel> pool = new Pool<AuthLabel>();

            style.minWidth = 50;
            
            Toolbar toolbar = new Toolbar();
            _search = new ToolbarSearchField();
            _search.style.flexGrow = 1;
            _search.style.flexShrink = 1;
            _search.style.width = new StyleLength(StyleKeyword.Auto);
            _search.onChanged += OnSearchChanged;

            toolbar.Add(_search);

            _authentications = new ListView();
            _authentications.style.flexGrow = 1;
            _authentications.horizontalScrollingEnabled = false;
            _authentications.selectionType = SelectionType.Single;
            _authentications.style.flexBasis = new StyleLength(StyleKeyword.Auto);
            _authentications.fixedItemHeight = EditorGUIUtility.singleLineHeight;
            _authentications.makeItem = () => pool.Get();
            _authentications.bindItem = (ve, i) => {
                AuthLabel label = ve as AuthLabel;
                label.text = _providers[i].Name;
            };
            _authentications.destroyItem = (ve) => (ve as AuthLabel).Dispose();
            _authentications.selectionChanged += OnListSelectionChanged;

            AuthenticationSelection.onSelectionChanged += OnSelectionChanged;

            Add(toolbar);
            Add(_authentications);

            OnSearchChanged();
            OnSelectionChanged(null, AuthenticationSelection.Selection);

            _window.onDestroying += OnDestroy;
        }

        private void OnDestroy()
        {
            AuthenticationSelection.onSelectionChanged -= OnSelectionChanged;
        }

        private void OnListSelectionChanged(IEnumerable<object> objects)
        {
            AuthenticationSelection.onSelectionChanged -= OnSelectionChanged;
            try
            {
                List<AuthenticationSettingsProvider> selection = objects?.Cast<AuthenticationSettingsProvider>().ToList();
                AuthenticationSelection.Selection = selection == null || selection.Count == 0 ? null : selection[0];
            }
            finally
            {
                AuthenticationSelection.onSelectionChanged += OnSelectionChanged;
            }
        }

        private void OnSelectionChanged(AuthenticationSettingsProvider last, AuthenticationSettingsProvider selection)
        {
            int index = _window.providers.IndexOf(selection);
            if (index < 0)
            {
                _authentications.ClearSelection();
            }
            else
            {
                _authentications.selectedIndex = index;
            }
        }

        private void OnSearchChanged()
        {
            if (!_search.hasSearch)
            {
                UpdatedItems(_window.providers);
                return;
            }

            UpdatedItems(_window.providers.Where(x => _search.IsMatch(x.Name)).ToList());
        }

        private void UpdatedItems(List<AuthenticationSettingsProvider> providers)
        {
            int selection = _authentications.selectedIndex;
            int newIndex = selection < 0 ? -1 : providers.IndexOf(_providers[selection]);

            _providers = providers;
            _authentications.itemsSource = providers;
            _authentications.SetSelection(newIndex);
        }
    }
}
