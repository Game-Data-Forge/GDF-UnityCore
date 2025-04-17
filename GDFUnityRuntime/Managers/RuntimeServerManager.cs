using System;
using System.Collections.Generic;
using System.Linq;
using GDFRuntime;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeServerManager : IRuntimeServerManager
    {
        private const string _HEADER_PROJECT_KEY = "PublicKey";
        private const string _HEADER_BEARER = "Authorization";

        private IRuntimeEngine _engine;

        public string SyncAgent
        {
            get
            {
                Debug.LogWarning("Sync agent returned without region or account range checking !");
                return _engine.Configuration.AgentPool.First().Value.TrimEnd('/');
            }
        }
        
        public RuntimeServerManager(IRuntimeEngine engine)
        {
            _engine = engine;
        }

        public string AuthAgent(string countryISO)
        {
            Debug.Log("Auth agent returned without region checking !");
            return _engine.Configuration.AgentPool.First().Value.TrimEnd('/');
        }

        public string BuildAuthURL(string countryISO, string path)
        {
            UriBuilder builder = new UriBuilder(SyncAgent);
            builder.Path = path;
            return builder.ToString();
        }

        public string BuildSyncURL(string path)
        {
            UriBuilder builder = new UriBuilder(SyncAgent);
            builder.Path = path;
            return builder.ToString();
        }

        public void FillHeaders(Dictionary<string, string> headers)
        {
            if (headers.ContainsKey(_HEADER_PROJECT_KEY))
            {
                headers[_HEADER_PROJECT_KEY] = _engine.Configuration.PublicToken;
            }
            else
            {
                headers.Add(_HEADER_PROJECT_KEY, _engine.Configuration.PublicToken);
            }
        }

        public void FillHeaders(Dictionary<string, string> headers, string bearer)
        {
            FillHeaders(headers);
            if (headers.ContainsKey(_HEADER_BEARER))
            {
                headers[_HEADER_BEARER] = bearer;
            }
            else
            {
                headers.Add(_HEADER_BEARER, bearer);
            }
        }
    }
}