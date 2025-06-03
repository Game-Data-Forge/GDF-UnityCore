using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorAccountManager : IRuntimeAccountManager
    {
        public interface IEditorAuthentication : IRuntimeAuthentication
        {
            public interface IEditorDevice : IRuntimeDevice
            {
                
            }
            public interface IEditorEmailPassword : IRuntimeEmailPassword
            {
                
            }
            public interface IEditorReSign : IRuntimeReSign
            {
                
            }

            public new IEditorDevice Device { get; }
            public new IEditorEmailPassword EmailPassword { get; }
            public new IEditorReSign ReSign { get; }

        }

        public interface IEditorCredentials : IRuntimeCredentials
        {
            
        }

        public new IEditorAuthentication Authentication { get; }
        public new IEditorCredentials Credentials { get; }
    }
}