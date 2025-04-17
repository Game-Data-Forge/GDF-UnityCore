using System;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class CountryField : VisualElement
    {
        public event Action<GDFCountryISO> changed;
        private DropdownField _dropdown;

        public GDFCountryISO value
        {
            get => GDFCountryISO.Countries[_dropdown.index];
            set => _dropdown.value = value.Name;
        }

        public CountryField()
        {
            _dropdown = new DropdownField("Country", GDFCountryISO.GetNames(), 0);

            Add(_dropdown);

            value = GDFCountryISO.Countries[_dropdown.index];

            _dropdown.RegisterValueChangedCallback(ev => {
                changed?.Invoke(value);
            });
        }
    }
}
