using System;
using GDFFoundation;
using GDFRuntime;
using static GDFUnity.CoreAccountManager;

namespace GDFUnity
{
    public abstract class CoreAuthenticationReSign : IRuntimeAccountManager.IRuntimeAuthentication.IRuntimeReSign
    {
        public abstract bool IsAvailable { get; }

        public abstract Job SignIn();
    }

    public class CoreAuthenticationReSign<T> : CoreAuthenticationReSign where T : IRuntimeEngine
    {
        private T _engine;
        private CoreAccountManager _manager;
        private TokenStorage _reSignStorage;

        public override bool IsAvailable
        {
            get
            {
                LoadStorage();
                return _reSignStorage != null;
            }
        }
        private string _Container => $"{_engine.Configuration.Reference}/{_engine.EnvironmentManager.Environment.ToLongString()}";

        public CoreAuthenticationReSign(T engine, CoreAccountManager manager)
        {
            _engine = engine;
            _manager = manager;

            _manager.AccountChanging.onBackgroundThread += OnAccountChanging;
            _manager.AccountChanged.onBackgroundThread += OnAccountChanged;
        }

        ~CoreAuthenticationReSign()
        {
            _manager.AccountChanging.onBackgroundThread -= OnAccountChanging;
            _manager.AccountChanged.onBackgroundThread -= OnAccountChanged;
        }

        public override Job SignIn()
        {
            lock (_manager.LOCK)
            {
                _manager.EnsureUseable();

                _manager.job = AutoSignInJob();

                return _manager.job;
            }
        }

        private void OnAccountChanging(IJobHandler handler, MemoryJwtToken value)
        {
            GDFUserSettings.Instance.Delete<TokenStorage>(container: _Container);
            _reSignStorage = null;
        }

        private void OnAccountChanged(IJobHandler handler, MemoryJwtToken value)
        {
            _reSignStorage = null;
            if (_manager.storage == null) return;

            GDFUserSettings.Instance.Save(_manager.storage, container: _Container);
        }

        private void LoadStorage()
        {
            if (_reSignStorage != null) return;

            _reSignStorage = GDFUserSettings.Instance.LoadOrDefault<TokenStorage>(null, container: _Container);
        }

        private Job AutoSignInJob()
        {
            string taskName = "Auto sign in";
            if (!IsAvailable)
            {
                return Job.Failure(new GDFException("ACC", 1, ""), taskName);
            }

            TokenStorage token = _reSignStorage;

            return Job.Run(handler =>
            {
                using IDisposable _ = _manager.Lock();

                _manager.ResetToken(handler);
                _manager.SetToken(handler, token);
            });
        }
    }
}