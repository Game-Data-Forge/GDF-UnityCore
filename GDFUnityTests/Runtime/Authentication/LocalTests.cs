using GDFFoundation;
using GDFUnity;

namespace Authentication
{
    public class LocalTests : BaseTests
    {
        protected override Job Authenticate()
        {
            return GDF.Account.Authentication.Local.Login();
        }
    }
}