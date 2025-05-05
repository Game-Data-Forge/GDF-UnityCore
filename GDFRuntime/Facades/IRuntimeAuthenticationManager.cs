using GDFFoundation;
using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public interface IRuntimeAuthenticationManager
    {
        public bool IsConnected { get; }
        public bool CanAutoReSignIn { get; }
        public MemoryJwtToken Token { get; }
        public string Bearer { get; }

        public Event<MemoryJwtToken> AccountChangingEvent { get; }
        public Event<MemoryJwtToken> AccountChangedEvent { get; }

        public Task ReSignIn();
        public Task SignOut();

        public Task SignInDevice(GDFCountryISO country);
        
        public Task RegisterEmailPassword(GDFCountryISO country, string email, string password, string confirmPassword);
        public Task SignInEmailPassword(GDFCountryISO country, string email, string password);
    }
}