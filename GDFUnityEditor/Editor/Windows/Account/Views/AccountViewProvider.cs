using UnityEngine.UIElements;

namespace GDFUnity.Editor
{
    public abstract class AccountViewProvider
    {
        public abstract string Name { get; }
        public abstract string Title { get; }
        public abstract string Help { get; }

        public abstract void OnActivate(AccountView view, VisualElement rootElement);
        public abstract void OnDeactivate(AccountView view, VisualElement rootElement);

        public AccountViewProvider() {}
    }
}
