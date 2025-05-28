using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeServerManager
    {
        public string SyncAgent { get; }
        public string AuthAgent(Country country);

        public string BuildSyncURL(string path);
        public string BuildAuthURL(Country country, string path);
        public void FillHeaders(Dictionary<string, string> headers);
        public void FillHeaders(Dictionary<string, string> headers, string bearer);
    }
}
