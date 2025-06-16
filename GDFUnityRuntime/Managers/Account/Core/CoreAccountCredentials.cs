using System;
using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public abstract class CoreAccountCredentials : IRuntimeAccountManager.IRuntimeCredentials
    {
        protected List<GDFAccountSign> _credentials = null;
        public List<GDFAccountSign> Credentials => _credentials;
        
        public abstract Job Refresh();

        public IEnumerator<GDFAccountSign> GetEnumerator()
        {
            return _credentials.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CoreAccountCredentials<T> : CoreAccountCredentials where T : CoreAccountManager
    {
        private T _manager;

        public CoreAccountCredentials(T manager)
        {
            _manager = manager;
        }

        public override Job Refresh()
        {
            lock (_manager.LOCK)
            {
                _manager.EnsureUseable();

                _manager.job = Job.Run(handler =>
                {
                    using IDisposable _ = _manager.Lock();

                    string url = _manager.GenerateURL(_manager.Country, "/api/v1/accounts/" + _manager.Reference + "/signs");

                    IEnumerable<GDFAccountSign> response = _manager.Delete<IEnumerable<GDFAccountSign>>(handler, url);
                    if (_credentials == null)
                    {
                        _credentials = new List<GDFAccountSign>();
                    }
                    else
                    {
                        _credentials.Clear();
                    }

                    foreach (GDFAccountSign sign in response)
                    {
                        _credentials.Add(sign);
                    }
                }, "Get account credentials");

                return _manager.job;
            }
        }
    }
}