using GDFEditor;
using GDFFoundation;
using System.Collections.Generic;

namespace GDFUnity.Editor
{
    public class EditorConfiguration : IEditorConfiguration
    {
        static public EditorConfiguration CreateFrom(string dashboard, GDFProjectConfiguration configuration)
        {
            if (configuration == null)
            {
                return null;
            }

            return new EditorConfiguration()
            {
                Reference = configuration.Reference,
                Name = configuration.Name,
                Organization = configuration.Organization,
                Dashboard = dashboard,
                CloudConfig = configuration.CloudConfig,
                Credentials = configuration.Credentials,
                Channel = 0,
                Channels = configuration.Channels
            };
        }

        public long Reference { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string PublicToken
        {
            get
            {
                try
                {
                    return Credentials[Environment].PublicKey;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public string Dashboard { get; set; }
        public ProjectEnvironment Environment => EditorEngine.UnsafeInstance?.EnvironmentManager?.Environment ?? ProjectEnvironment.Development;
        public Dictionary<ProjectEnvironment, GDFProjectMinimalCredentials> Credentials { get; set; }
        public CloudConfiguration CloudConfig { get; set; }
        public short Channel { get; set; }
        public Dictionary<string, short> Channels { get; set; }


    }
}