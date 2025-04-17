using System.Collections.Generic;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class DataServiceProvider
    {
        public abstract List<TreeViewItemData<T>> GenerateList<T>();
        public abstract void ApplySearch();
        public abstract VisualElement MakeItem();
        public abstract VisualElement BindItem(int index);
        public abstract VisualElement UnbindItem(int index);
    }
}
