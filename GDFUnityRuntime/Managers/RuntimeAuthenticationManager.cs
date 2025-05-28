using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;
using Newtonsoft.Json;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeAuthenticationManager : APIManager, IRuntimeAuthenticationManager
    {
        private readonly object _lock = new object();

        private class TokenStorage
        {
            [JsonIgnore]
            public MemoryJwtToken data;
            public Country Country { get; set; }
            public string Bearer { get; set; }

            public TokenStorage(Country country, string bearer)
            {
                Country = country;
                Bearer = $"Bearer {bearer}";

                if (bearer == null)
                {
                    return;
                }

                int first = bearer.IndexOf('.') + 1;
                int last = bearer.LastIndexOf('.');
                string base64 = bearer.Substring(first, last - first);
                string json = base64.FromBase64URL();

                data = JsonConvert.DeserializeObject<MemoryJwtToken>(json);
            }
        }

        private Notification<MemoryJwtToken> _accountChangingEvent;
        private Notification<MemoryJwtToken> _accountChangedEvent;
        private TokenStorage _token;
        private TokenStorage _autoToken;
        private IRuntimeEngine _engine;
        private Job _job = null;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public bool IsConnected => _token != null;
        public MemoryJwtToken Token
        {
            get
            {
                if (_token == null)
                {
                    return null;
                }
                return _token.data;
            }
        }
        public Notification<MemoryJwtToken> AccountChangingNotif => _accountChangingEvent;
        public Notification<MemoryJwtToken> AccountChangedNotif => _accountChangedEvent;
        public string Bearer => _token?.Bearer;

        private string _SaveContainer => $"{_engine.Configuration.Reference}/{_engine.EnvironmentManager.Environment.ToLongString()}";

        public bool CanAutoReSignIn
        {
            get
            {
                if (_autoToken == null)
                {
                    _autoToken = GDFUserSettings.Instance.LoadOrDefault<TokenStorage>(null, container: _SaveContainer);
                }
                return _autoToken != null;
            }
        }

        protected override Job Job => _job;

        public RuntimeAuthenticationManager(IRuntimeEngine engine)
        {
            _engine = engine;
            _accountChangingEvent = new Notification<MemoryJwtToken>(_engine.ThreadManager);
            _accountChangedEvent = new Notification<MemoryJwtToken>(_engine.ThreadManager);

            _engine.AccountManager.DeletedNotif.onBackgroundThread += SignOutRunner;

            State = ManagerState.Ready;
        }

        ~RuntimeAuthenticationManager()
        {
            _engine.AccountManager.DeletedNotif.onBackgroundThread -= SignOutRunner;
        }

        public Job SignInDevice(Country country)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    using Locker _ = Locker.Lock(this);

                    handler.StepAmount = 4;

                    ResetToken(handler.Split());
                    string bearer;
                    DeviceSignInExchange signInPayload = new DeviceSignInExchange()
                    {
                        Channel = _engine.Configuration.Channel,
                        UniqueIdentifier = _engine.DeviceManager.Id,
                        Country = country
                    };
                    try
                    {
                        _engine.ServerManager.FillHeaders(_headers);
                        bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/device/sign-in"), _headers, signInPayload);
                    }
                    catch (APIException e)
                    {
                        if (e.StatusCode != System.Net.HttpStatusCode.Forbidden)
                        {
                            throw;
                        }

                        DeviceSignUpExchange signUpPayload = new DeviceSignUpExchange()
                        {
                            Channel = _engine.Configuration.Channel,
                            UniqueIdentifier = _engine.DeviceManager.Id,
                            Consent = true,
                            ConsentVersion = "1.0.0",
                            GameConsentVersion = "1.0.0",
                            Country = country
                        };

                        Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                        _engine.ServerManager.FillHeaders(_headers);
                        bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/device/sign-up"), _headers, signUpPayload);
                    }
                    catch
                    {
                        throw;
                    }
                    SetToken(handler.Split(), new TokenStorage(country, bearer));
                }, "Device sign in");

                return _job;
            }
        }

        public Job RegisterEmailPassword(Country country, string email)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    using Locker _ = Locker.Lock(this);

                    handler.StepAmount = 3;
                    long projectId = _engine.Configuration.Reference;

                    ResetToken(handler.Split());
                    string bearer;
                    EmailPasswordSignUpExchange payload = new EmailPasswordSignUpExchange()
                    {
                        Channel = _engine.Configuration.Channel,
                        Email = email,
                        LanguageIso = "en-US",
                        Consent = true,
                        ConsentVersion = "1.0.0",
                        GameConsentVersion = "1.0.0",
                        Country = country
                    };

                    Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                    _engine.ServerManager.FillHeaders(_headers);
                    bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/email-password/sign-up"), _headers, payload);
                    SetToken(handler.Split(), new TokenStorage(country, bearer));
                }, "Email/password register");

                return _job;
            }
        }

        public Job SignInEmailPassword(Country country, string email, string password)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    using Locker _ = Locker.Lock(this);

                    handler.StepAmount = 3;
                    long projectId = _engine.Configuration.Reference;

                    ResetToken(handler.Split());
                    string bearer;
                    EmailPasswordSignInExchange payload = new EmailPasswordSignInExchange()
                    {
                        Email = email,
                        Password = password,
                        Channel = _engine.Configuration.Channel,
                        Country = country
                    };

                    _engine.ServerManager.FillHeaders(_headers);
                    bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/email-password/sign-in"), _headers, payload);
                    SetToken(handler.Split(), new TokenStorage(country, bearer));
                }, "Email/password sign in");

                return _job;
            }
        }

        public Job SignOut()
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(SignOutRunner, "Sign out");

                return _job;
            }
        }

        public Job ReSignIn()
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = AutoSignInJob();

                return _job;
            }
        }

        private Job AutoSignInJob()
        {
            string taskName = "Auto sign in";
            if (!CanAutoReSignIn)
            {
                return Job.Failure(new GDFException("ACC", 1, ""), taskName);
            }

            TokenStorage token = _autoToken;

            return Job.Run(handler =>
            {
                using Locker _ = Locker.Lock(this);

                ResetToken(handler);
                SetToken(handler, token);
            });
        }

        private void ResetToken(IJobHandler handler)
        {
            handler.StepAmount = 2;

            TokenStorage lastValue = _token;
            _token = null;
            _headers.Clear();

            GDFUserSettings.Instance.Delete<TokenStorage>(container: _SaveContainer);
            _autoToken = null;

            handler.Step();

            AccountChangingNotif.Invoke(handler.Split(), lastValue?.data);
        }

        protected void SignOutRunner(IJobHandler handler)
        {
            if (!IsConnected)
            {
                return;
            }

            using Locker _ = Locker.Lock(this);

            handler.StepAmount = 3;
            TokenStorage storage = _token;

            ResetToken(handler.Split());
            _headers.Clear();

            try
            {
                _engine.ServerManager.FillHeaders(_headers, storage.Bearer);
                Put<int>(handler.Split(), _engine.ServerManager.BuildAuthURL(storage.Country, "/api/v1/authentication/close-session"), _headers);
            }
            catch { }
            finally
            {
                SetToken(handler.Split(), null);
            }
        }

        private void SetToken(IJobHandler handler, TokenStorage value)
        {
            handler.StepAmount = 2;
            _token = value;

            if (value != null)
            {
                GDFUserSettings.Instance.Save(_token, container: _SaveContainer);
            }
            _autoToken = null;

            handler.Step();

            AccountChangedNotif?.Invoke(handler.Split(), _token?.data);
        }

        public Job SignInFacebook(Country country, string appId, string token)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    OAuthAuthRunner(handler, GDFOAuthKind.Facebook, country, appId, token);
                }, "Facebook authentication");

                return _job;
            }
        }

        public Job SignInGoogle(Country country, string clientId, string token)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    OAuthAuthRunner(handler, GDFOAuthKind.Google, country, clientId, token);
                }, "Google authentication");

                return _job;
            }
        }

        public Job SignInApple(Country country, string clientId, string token)
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler =>
                {
                    OAuthAuthRunner(handler, GDFOAuthKind.Apple, country, clientId, token);
                }, "Apple authentication");

                return _job;
            }
        }

        private void OAuthAuthRunner(IJobHandler handler, GDFOAuthKind type, Country country, string clientId, string token)
        {
            using Locker _ = Locker.Lock(this);

            handler.StepAmount = 4;

            ResetToken(handler.Split());
            string bearer;
            OAuthSignInExchange signInPayload = new OAuthSignInExchange()
            {
                OAuth = type,
                Channel = _engine.Configuration.Channel,
                Country = country,
                ClientId = clientId,
                AccessToken = token
            };
            try
            {
                _engine.ServerManager.FillHeaders(_headers);
                bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/oauth/sign-in"), _headers, signInPayload);
            }
            catch (APIException e)
            {
                if (e.StatusCode != System.Net.HttpStatusCode.Forbidden)
                {
                    throw;
                }

                OAuthSignUpExchange signUpPayload = new OAuthSignUpExchange()
                {
                    OAuth = type,
                    Channel = _engine.Configuration.Channel,
                    ClientId = clientId,
                    AccessToken = token,
                    Consent = true,
                    ConsentVersion = "1.0.0",
                    GameConsentVersion = "1.0.0",
                    Country = country
                };

                Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                _engine.ServerManager.FillHeaders(_headers);
                bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country, "/api/v1/authentication/oauth/sign-up"), _headers, signUpPayload);
            }
            catch
            {
                throw;
            }
            SetToken(handler.Split(), new TokenStorage(country, bearer));
        }
    }
}