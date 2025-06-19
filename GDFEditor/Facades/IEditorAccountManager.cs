using GDFFoundation;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorAccountManager : IRuntimeAccountManager
    {
        public interface IEditorAuthentication : IRuntimeAuthentication
        {
            public interface IEditorLocal : IRuntimeLocal
            {
                
            }
            public interface IEditorDevice : IRuntimeDevice
            {
                
            }
            public interface IEditorEmailPassword : IRuntimeEmailPassword
            {
                
            }
            public interface IEditorLastSession : IRuntimeLastSession
            {
                
            }

            public new IEditorLocal Local { get; }
            public new IEditorDevice Device { get; }
            public new IEditorEmailPassword EmailPassword { get; }
            public new IEditorLastSession LastSession { get; }

        }

        public interface IEditorCredentials : IRuntimeCredentials
        {
            
        }

        public MemoryJwtToken Token { get; }
        public new IEditorAuthentication Authentication { get; }
        public new IEditorCredentials Credentials { get; }
    }
}