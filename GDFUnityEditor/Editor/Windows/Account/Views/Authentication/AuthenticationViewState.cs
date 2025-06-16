namespace GDFUnity.Editor.ServiceProviders
{
    public abstract class AuthenticationViewState
    {
        public abstract string Name { get; }
        public abstract string Help { get; }

        public abstract void OnActivate(AccountWindow window, AccountView view);
        public abstract void OnDeactivate(AccountWindow window, AccountView view);
    }
}
