using System;
using GDFFoundation;
using GDFRuntime;
using Newtonsoft.Json;
using static GDFUnity.CoreAccountManager;

namespace GDFUnity
{
    public abstract class CoreAuthenticationLocal : IRuntimeAccountManager.IRuntimeAuthentication.IRuntimeLocal
    {
        public abstract bool Exists { get; }
        public abstract Job Login();
    }

    public class CoreAuthenticationLocal<T> : CoreAuthenticationLocal where T : IRuntimeEngine
    {
        protected T _engine;
        protected TokenStorage _storage;
        private CoreAccountManager _manager;

        public override bool Exists
        {
            get
            {
                LoadStorage();
                return _storage != null;
            }
        }
        private string _Container => $"{_engine.Configuration.Reference}/{_engine.EnvironmentManager.Environment.ToLongString()}";

        public CoreAuthenticationLocal(T engine, CoreAccountManager manager)
        {
            _engine = engine;
            _manager = manager;
            _manager.AccountDeleting.onBackgroundThread += OnAccountDeleting;
        }

        ~CoreAuthenticationLocal()
        {
            _manager.AccountDeleting.onBackgroundThread -= OnAccountDeleting;
        }

        public override Job Login()
        {
            lock (_manager.LOCK)
            {
                _manager.EnsureUseable();

                _manager.job = Job.Run(handler =>
                {
                    using IDisposable _ = _manager.Lock();

                    handler.StepAmount = 2;

                    _manager.ResetToken(handler.Split());
                    if (!Exists)
                    {
                        _storage = new TokenStorage(Country.None, "###." + JsonConvert.SerializeObject(new MemoryJwtToken
                        {
                            Account = 0,
                            Channel = _engine.Configuration.Channel,
                            Country = Country.None,
                            Environment = _engine.EnvironmentManager.Environment,
                            LastSync = DateTime.MinValue,
                            Project = _engine.Configuration.Reference,
                            Range = 0,
                            Token = "LOCAL",
                        }).ToBase64URL() + ".###");
                        GDFUserSettings.Instance.Save(_storage, container: _Container);
                    }
                    _manager.SetToken(handler.Split(), _storage);
                }, "Local login");

                return _manager.job;
            }
        }

        private void OnAccountDeleting(IJobHandler handler)
        {
            if (!GDF.Account.IsLocal)
            {
                return;
            }

            GDFUserSettings.Instance.Delete<TokenStorage>(null, container: _Container);
            _storage = null;
        }

        private void LoadStorage()
        {
            if (_storage != null) return;

            _storage = GDFUserSettings.Instance.LoadOrDefault<TokenStorage>(null, container: _Container);
        }
    }
}