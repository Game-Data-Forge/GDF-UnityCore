using System;
using System.Collections.Generic;
using GDFFoundation;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class CountryField : VisualElement
    {
        private struct Cache
        {
            public List<Country> countries;
            public List<string> names;
        }

        static private Cache _cache;

        public event Action<Country> changed;
        private DropdownField _dropdown;

        public Country value
        {
            get => _cache.countries[_dropdown.index];
            set => _dropdown.value = CountryTool.COUNTRIES[value];
        }

        static CountryField()
        {
            _cache = new Cache();
            _cache.countries = new List<Country>();
            _cache.names = new List<string>();

            foreach (KeyValuePair<Country, string> country in CountryTool.COUNTRIES)
            {
                _cache.countries.Add(country.Key);
                _cache.names.Add(country.Value);
            }
        }

        public CountryField()
        {
            _dropdown = new DropdownField("Country", _cache.names, 0);

            Add(_dropdown);

            value = _cache.countries[_dropdown.index];

            _dropdown.RegisterValueChangedCallback(ev =>
            {
                changed?.Invoke(value);
            });
        }
    }
}
