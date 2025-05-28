using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAccountManager : APIManager, IRuntimeAccountManager
    {
        private readonly object _lock = new object();
        
        private Notification _deletingEvent;
        private Notification _deletedEvent;
        private IRuntimeEngine _engine;
        private Job _job = null;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public Notification DeletingNotif => _deletingEvent;
        public Notification DeletedNotif => _deletedEvent;

        protected override Job Job => _job;

        public RuntimeAccountManager(IRuntimeEngine engine)
        {
            _engine = engine;
            _deletingEvent = new Notification(_engine.ThreadManager);
            _deletedEvent = new Notification(_engine.ThreadManager);

            State = ManagerState.Ready;
        }

        public Job Delete()
        {
            lock (_lock)
            {
                EnsureUseable();

                _job = Job.Run(handler => {
                    using Locker _ = Locker.Lock(this);

                    handler.StepAmount = 3;

                    _deletingEvent.Invoke(handler.Split());

                    MemoryJwtToken token = _engine.AuthenticationManager.Token;

                    _headers.Clear();
                    _engine.ServerManager.FillHeaders(_headers, _engine.AuthenticationManager.Bearer);
                    Delete<int>(handler.Split(), _engine.ServerManager.BuildAuthURL(token.Country, "/api/v1/accounts/" + token.Account), _headers);

                    _deletedEvent.Invoke(handler.Split());

                }, "Delete Account");

                return _job;
            }
        }
    }
}