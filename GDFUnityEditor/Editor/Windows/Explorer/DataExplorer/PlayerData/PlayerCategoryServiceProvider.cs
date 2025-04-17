using System;
using System.Collections.Generic;
using GDFEditor;
using GDFFoundation;
using UnityEditor;
using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public class PlayerCategoryServiceProvider : CategoryServiceProvider
    {
        private struct Category : ICategory
        {
            public TypeHierarchy value;

            public Category(TypeHierarchy value)
            {
                this.value = value;
            }

            public bool IsMatch(ToolbarSearchField search)
            {
                return search.IsMatch(value.type.Name);
            }
        }

        private class Element : Label, IPoolItem
        {
            public Pool Pool { get; set; }

            public Element()
            {
                style.marginTop = EditorGUIUtility.standardVerticalSpacing / 2;
                style.height = EditorGUIUtility.singleLineHeight - EditorGUIUtility.standardVerticalSpacing;
            }

            public void Dispose()
            {
                PoolItem.Release(this);
            }

            public void OnPooled()
            {
                
            }

            public void OnReleased()
            {
                
            }
        }

        static private List<TreeViewItemData<ICategory>> _fullList = null;
        static private Pool<Element> _pool = new Pool<Element> ();
        public override List<TreeViewItemData<ICategory>> GenerateList()
        {
            if (_fullList == null)
            {
                _fullList = new List<TreeViewItemData<ICategory>>();

                string className = GDFEditor.Types.GetClassName(typeof(GDFPlayerData));
                TypeHierarchy playerData = GDFEditor.Types.Player[className];

                _fullList.Add(GenerateList(playerData));
            }
            

            return new List<TreeViewItemData<ICategory>>(_fullList);
        }

        private TreeViewItemData<ICategory> GenerateList(TypeHierarchy hierarchy)
        {
            List<TreeViewItemData<ICategory>> list = new List<TreeViewItemData<ICategory>>();
            foreach (TypeHierarchy child in hierarchy.children)
            {
                list.Add(GenerateList(child));
            }

            string className = GDFEditor.Types.GetClassName(hierarchy.type);
            return new TreeViewItemData<ICategory>(className.GetHashCode(), new Category(hierarchy), list);
        }

        public override VisualElement MakeItem()
        {
            return _pool.Get();
        }

        public override void BindItem(TreeView treeView, VisualElement item, int index)
        {
            Category category = (Category)treeView.GetItemDataForIndex<ICategory>(index);
            Element element = item as Element;

            element.text = category.value.type.Name;
        }

        public override void DestroyItem(VisualElement item)
        {
            Element poolItem = item as Element;
            if (poolItem == null)
            {
                return;
            }

            poolItem.Dispose();
        }
    }
}
