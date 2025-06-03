using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeAccountManager : IAsyncManager
    {
        public interface IRuntimeAuthentication
        {
            public interface IRuntimeDevice
            {
                public Job SignIn(Country country);
            }
            public interface IRuntimeEmailPassword
            {
                public Job Register(Country country, string email);
                public Job SignIn(Country country, string email, string password);
                public Job Rescue(Country country, string email);
            }
            public interface IRuntimeReSign
            {
                public bool IsAvailable { get; }
                public Job SignIn();
            }

            public IRuntimeDevice Device { get; }
            public IRuntimeEmailPassword EmailPassword { get; }
            public IRuntimeReSign ReSign { get; }

            public Job SignOut();
        }

        public interface IRuntimeCredentials : IEnumerable<GDFAccountSign>
        {
            public List<GDFAccountSign> Credentials { get; }
            public Job Refresh();
        }

        public bool IsAuthenticated { get; }
        public MemoryJwtToken Token { get; }
        public string Bearer { get; }

        public Notification<MemoryJwtToken> AccountChanging { get; }
        public Notification<MemoryJwtToken> AccountChanged { get; }
        public Notification AccountDeleting { get; }
        public Notification AccountDeleted { get; }

        public IRuntimeAuthentication Authentication { get; }
        public IRuntimeCredentials Credentials { get; }

        public Job Delete();
    }
}