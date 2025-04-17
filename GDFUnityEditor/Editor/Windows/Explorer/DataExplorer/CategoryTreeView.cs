using System.Collections.Generic;
using GDFUnity.Editor.ServiceProviders;
using UnityEditor;
using UnityEngine.UIElements;
using static GDFUnity.Editor.ServiceProviders.CategoryServiceProvider;

namespace GDFUnity.Editor.UIElements
{
    public class CategoryTreeView : TreeView
    {
        private CategoryPane _pane;
        private List<TreeViewItemData<ICategory>> _cache;
        private List<TreeViewItemData<ICategory>> _list;
        private ToolbarSearchField _Search => _pane.toolbar._search;
        private CategoryServiceProvider _Provider => _pane.explorer.window.provider.Category;


        public CategoryTreeView(CategoryPane pane)
        {
            _pane = pane;
            _list = new List<TreeViewItemData<ICategory>>();

            fixedItemHeight = EditorGUIUtility.singleLineHeight;
        }
        
        public void OnViewDisplayChange(LoadingView.Display display)
        {
            if (display == LoadingView.Display.Body)
            {
                Build();
            }
        }

        private void Build()
        {
            _cache = _Provider.GenerateList();
            FillList();
            makeItem = _Provider.MakeItem;
            bindItem = (item, index) => _Provider.BindItem(this, item, index);
            destroyItem = _Provider.DestroyItem;
            selectionType = _Provider.selectionType;
            Rebuild();
        }

        public void OnSearchChanged()
        {
            FillList();
            RefreshItems();
        }

        private void FillList()
        {
            _list.Clear();

            if (!_Search.hasSearch)
            {
                _list.AddRange(_cache);
                
                SetRootItems(_list);
                return;
            }

            SearchInItems(_cache);
            
            SetRootItems(_list);
        }

        private void SearchInItems(IEnumerable<TreeViewItemData<ICategory>> items)
        {
            if (items == null)
            {
                return;
            }

            foreach (TreeViewItemData<ICategory> item in items)
            {
                if (item.data.IsMatch(_Search))
                {
                    _list.Add(new TreeViewItemData<ICategory>(item.id, item.data));
                }

                SearchInItems(item.children);
            }
        }
    }
}
