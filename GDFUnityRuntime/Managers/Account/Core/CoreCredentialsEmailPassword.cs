using System;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class CoreCredentialsEmailPassword : IRuntimeAccountManager.IRuntimeCredentials.IRuntimeEmailPassword
    {
        private CoreAccountManager _manager;

        public CoreCredentialsEmailPassword(CoreAccountManager manager)
        {
            _manager = manager;
        }

        public Job EditPassword(Country country, long reference, string email, string password, string newPassword)
        {
            lock (_manager.LOCK)
            {
                _manager.EnsureUseable();

                _manager.job = Job.Run(handler =>
                {
                    using IDisposable _ = _manager.Lock();

                    SignModifyExchange payload = new SignModifyExchange()
                    {
                        Reference = reference,
                        OldEmail = email,
                        OldPassword = password,
                        NewPassword = newPassword
                    };

                    string url = _manager.GenerateURL(country, "/api/v1/accounts/" + _manager.Reference + "/signs/" + reference);
                    _manager.Put<string>(handler, url, payload);
                }, "Edit password");
            }

            return _manager.job;
        }
    }
}