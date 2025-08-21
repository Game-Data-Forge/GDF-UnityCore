namespace GDFUnity
{
    public class RuntimeAccountCredentials : CoreAccountCredentials<RuntimeAccountManager, RuntimeCredentialsEmailPassword>
    {
        public RuntimeAccountCredentials(RuntimeAccountManager manager) : base(manager)
        {
            _emailPassword = new RuntimeCredentialsEmailPassword(manager);
        }
    }
}