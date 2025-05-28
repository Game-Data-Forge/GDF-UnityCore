using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeAuthenticationManager : IAsyncManager
    {
        public bool IsConnected { get; }
        public bool CanAutoReSignIn { get; }
        public MemoryJwtToken Token { get; }
        public string Bearer { get; }

        public Notification<MemoryJwtToken> AccountChangingNotif { get; }
        public Notification<MemoryJwtToken> AccountChangedNotif { get; }

        public Job ReSignIn();
        public Job SignOut();

        public Job SignInDevice(Country country);
        
        public Job RegisterEmailPassword(Country country, string email);
        public Job SignInEmailPassword(Country country, string email, string password);

        public Job SignInFacebook(Country country, string appId, string token);
        public Job SignInGoogle(Country country, string clientId, string token);
        public Job SignInApple(Country country, string clientId, string token);
    }
}