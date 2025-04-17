using System.Collections.Generic;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class CategoryServiceProvider
    {
        public interface ICategory
        {
            public bool IsMatch(ToolbarSearchField search);
        }

        public SelectionType selectionType = SelectionType.Multiple;

        public abstract List<TreeViewItemData<ICategory>> GenerateList();
        public abstract VisualElement MakeItem();
        public abstract void BindItem(TreeView treeView, VisualElement item, int index);
        public abstract void DestroyItem(VisualElement item);
    }
}
