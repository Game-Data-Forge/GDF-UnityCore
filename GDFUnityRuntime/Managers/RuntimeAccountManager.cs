using System.Collections.Generic;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeAccountManager : APIManager, IRuntimeAccountManager
    {
        private readonly object _taskLock = new object();
        
        private Event _deletingEvent;
        private Event _deletedEvent;
        private Task _task = null;
        private IRuntimeEngine _engine;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public Event DeletingEvent => _deletingEvent;
        public Event DeletedEvent => _deletedEvent;

        public RuntimeAccountManager(IRuntimeEngine engine)
        {
            _engine = engine;
            _deletingEvent = new Event(_engine.ThreadManager);
            _deletedEvent = new Event(_engine.ThreadManager);
        }

        public Task Delete()
        {
            lock (_taskLock)
            {
                _task.EnsureNotInUse();

                _task = Task.Run(handler => {
                    handler.StepAmount = 3;

                    _deletingEvent.Invoke(handler.Split());

                    MemoryJwtToken token = _engine.AuthenticationManager.Token;

                    _headers.Clear();
                    _engine.ServerManager.FillHeaders(_headers, _engine.AuthenticationManager.Bearer);
                    Delete<int>(handler.Split(), _engine.ServerManager.BuildAuthURL(token.Country, "/api/v1/accounts/" + token.Account), _headers);

                    _deletedEvent.Invoke(handler.Split());

                }, "Delete Account");

                return _task;
            }
        }
    }
}