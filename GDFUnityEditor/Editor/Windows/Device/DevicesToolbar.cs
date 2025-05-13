using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class DevicesToolbar : Toolbar
    {
        private ToolbarSearchField _searchField;
        private string[] _search = null;
        public event Action<string[]> onSearchChanged;
        
        public string[] search => _search;

        public DevicesToolbar()
        {
            ToolbarButton addButton = new ToolbarButton();
            addButton.style.IconContent("Toolbar Plus");
            addButton.style.minWidth = 26;
            addButton.tooltip = "Add device";
            addButton.clicked += () => {
                GDFEditor.Device.Add();
            };

            _searchField = new ToolbarSearchField();
            _searchField.style.flexGrow = 1;
            _searchField.style.flexShrink = 1;
            _searchField.style.width = new StyleLength(StyleKeyword.Auto);
            _searchField.RegisterValueChangedCallback((ev) => {
                _search = ev.newValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                onSearchChanged?.Invoke(_search);
            });
            
            Add(addButton);
            Add(_searchField);
            Add(new HelpButton("/unity/windows/devices-window", Position.Relative));
        }
    }
}
