using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeAuthenticationManager
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
        
        public Job RegisterEmailPassword(Country country, string email, string password, string confirmPassword);
        public Job SignInEmailPassword(Country country, string email, string password);
    }
}