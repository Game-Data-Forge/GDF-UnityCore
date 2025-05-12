using System;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class CountryField : VisualElement
    {
        public event Action<Country> changed;
        private DropdownField _dropdown;

        public Country value
        {
            get => Country.COUNTRIES[_dropdown.index];
            set => _dropdown.value = value.Name;
        }

        public CountryField()
        {
            _dropdown = new DropdownField("Country", Country.GetNames(), 0);

            Add(_dropdown);

            value = Country.COUNTRIES[_dropdown.index];

            _dropdown.RegisterValueChangedCallback(ev => {
                changed?.Invoke(value);
            });
        }
    }
}
