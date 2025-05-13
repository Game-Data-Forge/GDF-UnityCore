using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class AuthenticationState
    {
        public enum State
        {
            Login,
            Register
        }

        public abstract string Name { get; }
        public abstract string Url { get; }

        public abstract void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons);
        public abstract void OnDeactivate(AuthenticationView view);
    }
}
