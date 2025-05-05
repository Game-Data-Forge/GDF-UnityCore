using System.Collections.Generic;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;
using Newtonsoft.Json;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeAuthenticationManager : APIManager, IRuntimeAuthenticationManager
    {
        private readonly object _taskLock = new object();
        
        private class TokenStorage
        {
            [JsonIgnore]
            public MemoryJwtToken data;
            public string Country { get; set; }
            public string Bearer { get; set; }

            public TokenStorage(string country, string bearer)
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

        static private TokenStorage _Token => new TokenStorage(null, null);

        private Event<MemoryJwtToken> _accountChangingEvent;
        private Event<MemoryJwtToken> _accountChangedEvent;
        private TokenStorage _token;
        private TokenStorage _autoToken;
        private Task _task = null;
        private IRuntimeEngine _engine;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public bool IsConnected => _token != null;
        public MemoryJwtToken Token
        {
            get
            {
                if (_token == null)
                {
                    return _Token.data;
                }
                return _token.data;
            }
        }
        public Event<MemoryJwtToken> AccountChangingEvent => _accountChangingEvent;
        public Event<MemoryJwtToken> AccountChangedEvent => _accountChangedEvent;
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

        public RuntimeAuthenticationManager(IRuntimeEngine engine)
        {
            _engine = engine;
            _accountChangingEvent = new Event<MemoryJwtToken>(_engine.ThreadManager);
            _accountChangedEvent = new Event<MemoryJwtToken>(_engine.ThreadManager);

            _engine.AccountManager.DeletedEvent.onBackgroundThread += SignOutRunner;
        }

        ~RuntimeAuthenticationManager()
        {
            _engine.AccountManager.DeletedEvent.onBackgroundThread -= SignOutRunner;
        }

        public Task SignInDevice(GDFCountryISO country)
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = Task.Run(handler => {
                    handler.StepAmount = 4;
                    
                    ResetToken(handler.Split());
                    string bearer;
                    DeviceSignInExchange signInPayload = new DeviceSignInExchange()
                    {
                        Channel = _engine.Configuration.Channel,
                        UniqueIdentifier = _engine.DeviceManager.Id,
                        CountryIso = country.TwoLetterCode
                    };
                    try
                    {
                        _engine.ServerManager.FillHeaders(_headers);
                        bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country.TwoLetterCode, "/api/v1/authentication/device/sign-in"), _headers, signInPayload);
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
                            CountryIso = country.TwoLetterCode
                        };

                        Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                        _engine.ServerManager.FillHeaders(_headers);
                        bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country.TwoLetterCode, "/api/v1/authentication/device/sign-up"), _headers, signUpPayload);
                    }
                    catch
                    {
                        throw;
                    }
                    SetToken(handler.Split(), new TokenStorage(country.TwoLetterCode, bearer));
                }, "Device sign in");

                return _task;
            }
        }

        public Task RegisterEmailPassword(GDFCountryISO country, string email, string password, string confirmPassword)
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = Task.Run(handler => {
                    handler.StepAmount = 3;
                    long projectId = _engine.Configuration.Reference;
                    
                    ResetToken(handler.Split());
                    string bearer;
                    EmailPasswordSignUpExchange payload = new EmailPasswordSignUpExchange()
                    {
                        Channel = _engine.Configuration.Channel,
                        Email = email,
                        Password = password,
                        Consent = true,
                        ConsentVersion = "1.0.0",
                        GameConsentVersion = "1.0.0",
                        CountryIso = country.TwoLetterCode
                    };

                    Debug.LogWarning("Game consent is hard written to 1.0.0 !");

                    _engine.ServerManager.FillHeaders(_headers);
                    bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country.TwoLetterCode, "/api/v1/authentication/email-password/sign-up"), _headers, payload);
                    SetToken(handler.Split(), new TokenStorage(country.TwoLetterCode, bearer));
                }, "Email/password register");

                return _task;
            }
        }

        public Task SignInEmailPassword(GDFCountryISO country, string email, string password)
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = Task.Run(handler => {
                    handler.StepAmount = 3;
                    long projectId = _engine.Configuration.Reference;
                    
                    ResetToken(handler.Split());
                    string bearer;
                    EmailPasswordSignInExchange payload = new EmailPasswordSignInExchange()
                    {
                        Email = email,
                        Password = password,
                        Channel = _engine.Configuration.Channel,
                        CountryIso = country.TwoLetterCode
                    };

                    _engine.ServerManager.FillHeaders(_headers);
                    bearer = Post<string>(handler.Split(), _engine.ServerManager.BuildAuthURL(country.TwoLetterCode, "/api/v1/authentication/email-password/sign-in"), _headers, payload);
                    SetToken(handler.Split(), new TokenStorage(country.TwoLetterCode, bearer));
                }, "Email/password sign in");

                return _task;
            }
        }

        public Task SignOut()
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = Task.Run(SignOutRunner, "Sign out");

                return _task;
            }
        }

        public Task ReSignIn()
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = AutoSignInTask();

                return _task;
            }
        }

        private Task AutoSignInTask()
        {
            string taskName = "Auto sign in";
            if (!CanAutoReSignIn)
            {
                return Task.Failure(new GDFException("ACC", 1, ""), taskName);
            }

            TokenStorage token = _autoToken;

            return Task.Run(handler => {
                ResetToken(handler);
                SetToken(handler, token);
            });
        }

        private void ResetToken(ITaskHandler handler)
        {
            handler.StepAmount = 2;

            TokenStorage lastValue = _token;
            _token = null;
            _headers.Clear();

            GDFUserSettings.Instance.Delete<TokenStorage>(container: _SaveContainer);
            _autoToken = null;

            handler.Step();

            AccountChangingEvent.Invoke(handler.Split(), lastValue?.data);
        }

        protected void SignOutRunner(ITaskHandler handler)
        {
            if (!IsConnected)
            {
                return;
            }

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

        private void SetToken(ITaskHandler handler, TokenStorage value)
        {
            handler.StepAmount = 2;
            _token = value;

            if (value != null)
            {
                GDFUserSettings.Instance.Save(_token, container: _SaveContainer);
            }
            _autoToken = null;

            handler.Step();

            AccountChangedEvent?.Invoke(handler.Split(), _token?.data);
        }
    }
}