using UnityEngine.UIElements;

namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class AuthenticationSettingsProvider
    {
        public abstract string Name { get; }
        public abstract string Title { get; }
        public abstract string Url { get; }
        public virtual bool NeedCountry => true;
        public virtual bool NeedConsent => true;
        
        public abstract void OnActivate(AuthenticationView view, VisualElement rootElement, ButtonList buttons);

        public abstract void OnDeactivate(AuthenticationView view, VisualElement rootElement);

        public AuthenticationSettingsProvider()
        {
            
        }
    }
}
