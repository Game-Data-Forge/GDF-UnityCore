using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeAccountManager : IAsyncManager
    {
        public interface IRuntimeAuthentication
        {
            public interface IRuntimeLocal
            {
                public bool Exists { get; }
                public Job Login();
            }
            public interface IRuntimeDevice
            {
                public Job Login(Country country);
            }
            public interface IRuntimeEmailPassword
            {
                public Job Register(Country country, string email);
                public Job Login(Country country, string email, string password);
                public Job Rescue(Country country, string email);
            }
            public interface IRuntimeLastSession
            {
                public bool IsAvailable { get; }
                public Job Login();
            }

            public IRuntimeLocal Local { get; }
            public IRuntimeDevice Device { get; }
            public IRuntimeEmailPassword EmailPassword { get; }
            public IRuntimeLastSession LastSession { get; }

            public Job SignOut();
        }

        public interface IRuntimeCredentials : IEnumerable<GDFAccountSign>
        {
            public interface IRuntimeEmailPassword
            {
                public Job EditPassword(Country country, long reference, string email, string password, string newPassword);
            }

            public List<GDFAccountSign> Credentials { get; }
            public Job Refresh();
            
            public IRuntimeEmailPassword EmailPassword { get; }
        }

        public bool IsAuthenticated { get; }
        public bool IsLocal { get; }
        public long Reference { get; }
        public int Range { get; }
        public Country Country { get; }
        public string Bearer { get; }
        public string LocalIdentity { get; }
        public string Identity { get; }

        public Notification<MemoryJwtToken> AccountChanging { get; }
        public Notification<MemoryJwtToken> AccountChanged { get; }
        public Notification AccountDeleting { get; }
        public Notification AccountDeleted { get; }

        public IRuntimeAuthentication Authentication { get; }
        public IRuntimeCredentials Credentials { get; }

        public Job Delete();
    }
}