using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public class HeaderFoldout : Foldout
    {
        private ToolbarButton _button;
        private Action _actionMenu;
        private VisualElement _foldout;

        public Label label => _foldout[0][1] as Label;

        public HeaderFoldout() : base()
        {
            _foldout = hierarchy[0];
            _foldout.style.marginTop = 1;
            _foldout.style.marginBottom = 1;
            _foldout.style.height = 18;
            _foldout.AddToClassList("unity-toolbar-button");

            hierarchy[1].style.paddingBottom = 6;
            hierarchy[1].style.paddingTop = 3;

            Toolbar background = new Toolbar();
            background.style.position = Position.Absolute;
            background.style.height = 20;
            background.style.borderBottomWidth = 0;
            background.style.borderTopWidth = 0;
            background.style.top = 0;
            background.style.left = 0;
            background.style.right = 0;
            background.style.flexDirection = FlexDirection.RowReverse;

            _button = new ClickableElement();
            _button.style.IconContent("pane options");
            _button.style.width = 20;
            _button.style.left = 0;
            _button.clicked += () => _actionMenu?.Invoke();

            background.Add(_button);
            
            Toolbar topLine = new Toolbar();
            topLine.style.position = Position.Absolute;
            topLine.style.top = 20;
            topLine.style.left = 0;
            topLine.style.right = 0;
            topLine.style.height = 1;
            topLine.style.borderBottomWidth = 1;

            hierarchy.Insert(1, topLine);
            
            Toolbar bottomLine = new Toolbar();
            bottomLine.style.height = 2;
            bottomLine.style.borderBottomWidth = 2;

            hierarchy.Insert(0, background);
            hierarchy.Add(bottomLine);

            RegisterActionMenu(null);
        }

        public void RegisterActionMenu(Action actionMenu)
        {
            _actionMenu = actionMenu;
            UpdateActionMenu();
        }
        
        public void UnregisterActionMenu()
        {
            _actionMenu = null;
            UpdateActionMenu();
        }

        private void UpdateActionMenu()
        {
            if (_actionMenu == null)
            {
                _button.style.display = DisplayStyle.None;
                _foldout.style.marginRight = 0;
            }
            else
            {
                _button.style.display = DisplayStyle.Flex;
                _foldout.style.marginRight = 21;
            }
        }
    }
}
