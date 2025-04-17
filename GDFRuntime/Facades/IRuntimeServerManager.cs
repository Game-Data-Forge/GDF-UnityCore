using System;
using System.Collections.Generic;

namespace GDFRuntime
{
    public interface IRuntimeServerManager
    {
        public string SyncAgent { get; }
        public string AuthAgent(string countryISO);

        public string BuildSyncURL(string path);
        public string BuildAuthURL(string countryISO, string path);
        public void FillHeaders(Dictionary<string, string> headers);
        public void FillHeaders(Dictionary<string, string> headers, string bearer);
    }
}
